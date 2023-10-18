using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using System.Drawing;

using System.IO;
using System.Collections.Concurrent;

using OpenCvSharp;
using OpenCvSharp.Extensions;

using SimpleLogClass;

namespace NetCamControlClass
{
    class NetCamControl: IDisposable
    {
        /// <summary>
        /// rtsp capture
        /// </summary>
        VideoCapture videoCapture;

        Mat frameMat_Last;

        CancellationTokenSource tokenSource;

        BlockingCollection<Mat> matQue;
        Task frameGrabingTask;

        public int queCount
        {
            get { return matQue.Count; }
        }

        public int maxQUeSize
        {
            get
            {
                return matQue.BoundedCapacity;
            }
            set
            {
                lock (matQue)
                {
                    BlockingCollection<Mat> b = matQue;
                    matQue = new BlockingCollection<Mat>(value);

                    for (int i = 0; i < matQue.Count; i++)
                    {
                        matQue.Add(b.ElementAt(i));
                    }

                    b.Dispose();

                }

            }

        }
        
        public NetCamControl(string address ,string id , string passwd,int maxQueSize = 1024)
        {
            videoCapture = new VideoCapture("rtsp://" +id + ":" + passwd + "@" + address);

            tokenSource = new CancellationTokenSource();
            frameGrabingTask = Task.Run(() => Grabing(tokenSource.Token));

            matQue = new BlockingCollection<Mat>(maxQueSize);

        }

        public void Dispose()
        {
            tokenSource.Cancel();

            try
            {
                Thread.Sleep((int)(1000 / videoCapture.Fps));
                videoCapture.Release();
                videoCapture.Dispose();
            }
            catch
            {

            }

            matQue.Dispose();

        }

        public bool grabingRun = false;

        private void Grabing(CancellationToken token)
        {
            grabingRun = true;

            do
            {
                if (token.IsCancellationRequested) break;

                try
                {
                    frameMat_Last = new Mat();
                    videoCapture.Read(frameMat_Last);

                    if (matQue.Count >= matQue.BoundedCapacity)
                    {
                        matQue.Take().Dispose();
                    }

                    matQue.Add(frameMat_Last);

                }
                catch
                {
                    SimpleLog.Write();
                }

            } while (true);

            grabingRun = false;

        }


        public Bitmap GetImage()
        {
            if (matQue.Count == 0) { return new Bitmap(255, 255); }
            Bitmap resultImage;

            Mat m = matQue.ElementAt(matQue.Count - 1);

            using (Mat frameMat = m.Clone())
            {
                resultImage = BitmapConverter.ToBitmap(frameMat);

            }

            return resultImage;

        }

        private Mat[] MatBufferClone(MatType rtype)
        {
            return MatBufferClone(rtype, matQue.Count);

        }


        private Mat[] MatBufferClone(MatType rtype, int getFrameCount)
        {
            if (getFrameCount > matQue.Count || getFrameCount <= 0) { getFrameCount = matQue.Count; }
            List<Mat> matList = new List<Mat>();

            int startIndex = matQue.Count - getFrameCount;
            int endIndex = matQue.Count ;

            lock (matQue)
            {
                for (int i = startIndex; i < endIndex; i++)
                {
                    Mat frameMat = new Mat();
                    matQue.ElementAt(i).ConvertTo(frameMat, rtype);
                    matList.Add(frameMat);
                }
            }

            return matList.ToArray();

        }


        public Bitmap GetImageTimeAverage()
        {
            return GetImageTimeAverage(matQue.Count);

        }


        public Bitmap GetImageTimeAverage(int getFrameCount)
        {
            if (getFrameCount > matQue.Count || getFrameCount <= 0) { getFrameCount = matQue.Count; }

            Mat[] frameMats = MatBufferClone(MatType.CV_64FC3, getFrameCount);
            Mat resultMat = frameMats[0] - frameMats[0];

            foreach(var frameMat in frameMats)
            {
                resultMat += frameMat;
                frameMat.Dispose();
            }

            resultMat /= frameMats.Length;

            Mat resultMatImage = new Mat();
            resultMat.ConvertTo(resultMatImage, MatType.CV_8UC3);

            Bitmap resultImage = BitmapConverter.ToBitmap(resultMatImage);

            resultMatImage.Dispose();
            resultMat.Dispose();

            return resultImage;

        }


        public Bitmap GetImageTimeMedian(int getFrameCount)
        {
            if (getFrameCount > matQue.Count || getFrameCount <= 0) { getFrameCount = matQue.Count; }

            Mat[] frameMats = MatBufferClone(MatType.CV_8UC3);
            Mat resultMat = frameMats[0] - frameMats[0];

            int pointerLength = resultMat.Channels() * resultMat.Width * resultMat.Height;

            int getIndex = getFrameCount / 2;

            byte[] timeSq = new byte[getFrameCount];

            unsafe
            {
                byte* rP = resultMat.DataPointer;
                byte*[] fP = new byte*[frameMats.Length];

                for (int i = 0; i < getFrameCount; i++)
                {
                    fP[i] = frameMats[i].DataPointer;
                }

                for (int p = 0; p < pointerLength; p++)
                {
                    for (int i = 0; i < getFrameCount; i++)
                    {
                        timeSq[i] = fP[i][p];
                    }

                    Array.Sort(timeSq);
                    rP[p] = timeSq[getIndex];

                }

            }

            Bitmap resultImage = BitmapConverter.ToBitmap(resultMat);
            resultMat.Dispose();
            return resultImage;

        }

        public void saveMovie(string filename)
        {

            saveMovie(filename, matQue.Count);

        }


        public void saveMovie(string filename, int getFrameCount)
        {
            Mat[] frameMats = MatBufferClone(MatType.CV_8UC3,getFrameCount);

            using (VideoWriter videoWriter = new VideoWriter(filename, FourCC.WMV3, videoCapture.Fps, frameMats[0].Size())) { 

                foreach (var frameMat in frameMats)
                {
                    videoWriter.Write(frameMat);

                }

            }

        }

    }
}
