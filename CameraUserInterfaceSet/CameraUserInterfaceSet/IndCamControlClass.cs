using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Drawing;

using System.IO;

using OpenCvSharp;
using OpenCvSharp.Extensions;

using SimpleLogClass;


namespace IndCamControlClass
{

    public struct IndCamImagingCondition
    {
        public int gain;
        public int exposureTime;

        public IndCamImagingCondition(int gain , int exposureTime)
        {
            this.gain = gain;
            this.exposureTime = exposureTime;

        }

    }

    class IndCamControl:IDisposable
    {

        ArenaNET.ISystem system;

        public IndCamControl()
        {
            system = ArenaNET.Arena.OpenSystem();
            system.UpdateDevices(100);

        }

        public void Dispose()
        {
            ArenaNET.Arena.CloseSystem(system);
            GC.SuppressFinalize(this);
        }


        ~IndCamControl()
        {
            try
            {
                ArenaNET.Arena.CloseSystem(system);
            }
            catch { }

        }

        public List<ArenaNET.IDeviceInfo> getDevicesInfo()
        {
            system.UpdateDevices(100);
            return system.Devices;

        }

        public ArenaNET.IDevice getDevice(string Address)
        {
            system.UpdateDevices(100);

            foreach (var deviceInfo in system.Devices)
            {
                if(deviceInfo.IpAddressStr == Address)return system.CreateDevice(deviceInfo);

            }

            return null;

        }


        public Bitmap getFrameBitmap(string Address, double exposureTime, double movieTimeLength)
        {
            ArenaNET.IDevice device = getDevice(Address);

            Bitmap resultImage = getFrameBitmap(device, exposureTime, movieTimeLength);
            system.DestroyDevice(device);

            return resultImage;

        }


        public Bitmap getFrameBitmap(ArenaNET.IDevice device, double gain, double exposureTime)
        {
            setImagingCondition(device, gain, exposureTime);

            try
            {
                if (device == null) return null;
                device.StartStream();

                ArenaNET.IImage frame = device.GetImage((ulong)(exposureTime + 200));
                device.RequeueBuffer(frame);

                ArenaNET.IImage frameCnv = ArenaNET.ImageFactory.Convert(frame, ArenaNET.EPfncFormat.BGR8);

                device.StopStream();

                Bitmap resultImage = new Bitmap((int)(frameCnv.Width), (int)(frameCnv.Height));
                Graphics g = Graphics.FromImage(resultImage);
                g.DrawImage(frameCnv.Bitmap, 0, 0);
                g.Dispose();

                ArenaNET.ImageFactory.Destroy(frameCnv);
                ArenaNET.ImageFactory.Destroy(frame);

                return resultImage;

            }
            catch (Exception ex)
            {
                SimpleLog.Write(ex.Message);
            }

            return null;

        }



        public void recordVideo(string fileName, ArenaNET.IDeviceInfo deviceInfo, double exposureTime, double movieTimeLength)
        {
            ArenaNET.IDevice device = system.CreateDevice(deviceInfo);

            recordVideo(fileName, device, exposureTime, movieTimeLength);

            system.DestroyDevice(device);

        }

        public Task recordVideo(string fileName, ArenaNET.IDevice device, double exposureTime, double movieTimeLength, int framePictureOutputInterval = 0)
        {
            int maxFrameCount = (int)(movieTimeLength * 1000.0 / exposureTime);
            List<ArenaNET.IImage> frames = new List<ArenaNET.IImage>();

            device.StartStream();

            for (int i = 0; i < maxFrameCount; i++)
            {
                try
                {
                    ArenaNET.IImage frame = device.GetImage((ulong)(exposureTime + 200));
                    frames.Add(ArenaNET.ImageFactory.Convert(frame, ArenaNET.EPfncFormat.BGR8));
                    device.RequeueBuffer(frame);
                }
                catch (Exception ex)
                {
                    SimpleLog.Write("frame add error : " + ex.Message);
                    break;
                }
            }

            device.StopStream();

            return Task.Run(() => encodeVideo(fileName, frames, exposureTime, movieTimeLength, framePictureOutputInterval));

        }


        public void encodeVideo(string fileName, List<ArenaNET.IImage> frames, double exposureTime, double movieTimeLength, int framePictureOutputInterval=0)
        {
            double fps = movieTimeLength * 1000.0 / exposureTime;

            using (VideoWriter videoWriter = new VideoWriter(Path.ChangeExtension(fileName, ".wmv"), FourCC.WMV3, fps, new OpenCvSharp.Size(frames[0].Width, frames[0].Height)))
            {
                try
                {

                    int frameCount = 0;
                    int pictureCount = 0;

                    foreach (var frame in frames)
                    {
                        using (Mat frameMat = BitmapConverter.ToMat(frame.Bitmap))
                        {
                            videoWriter.Write(frameMat);

                        }

                        if (framePictureOutputInterval > 0 && frameCount % framePictureOutputInterval == 0)
                        {
                            frame.Bitmap.Save(Path.ChangeExtension(fileName, "." + pictureCount.ToString("0000") + ".png"), System.Drawing.Imaging.ImageFormat.Png);
                            pictureCount++;
                        }

                        frameCount++;

                        ArenaNET.ImageFactory.Destroy(frame);
                    }
                }
                catch (Exception ex)
                {
                    SimpleLog.Write("encode process error : " + ex.Message);
                }

            }

            frames.Clear();
            
        }

        public void setImagingCondition(List<ArenaNET.IDevice> devices, List< IndCamImagingCondition> imagingConditions)
        {
            foreach(var device in devices)
            {
                foreach(var imagingCondition in imagingConditions)
                {
                    setImagingCondition(device, imagingCondition);

                }

            }

        }

        public void setImagingCondition(ArenaNET.IDevice device, IndCamImagingCondition imagingCondition)
        {
            setImagingCondition( device, imagingCondition.gain, imagingCondition.exposureTime);
        }

        public void setImagingCondition(ArenaNET.IDevice device, double gain, double exposureTime)
        {
            var gainAutoNode = (ArenaNET.IEnumeration)device.NodeMap.GetNode("GainAuto");
            if (gainAutoNode.Entry.Symbolic == "On") gainAutoNode.FromString("Off");
           
            var exposureAutoNode = device.NodeMap.GetNode("ExposureAuto") as ArenaNET.IEnumeration;
            if (exposureAutoNode.Entry.Symbolic == "On") exposureAutoNode.FromString("Off");
            
            var exposureTimeNode = device.NodeMap.GetNode("ExposureTime") as ArenaNET.IFloat;
            if (exposureTime < exposureTimeNode.Min) exposureTime = exposureTimeNode.Min;
            if (exposureTime > exposureTimeNode.Max) exposureTime = exposureTimeNode.Max;
            exposureTimeNode.Value = exposureTime;

            var acquisitionModeNode = device.NodeMap.GetNode("AcquisitionMode") as ArenaNET.IEnumeration;
            acquisitionModeNode.Symbolic = "Continuous";

        }

    }

}
