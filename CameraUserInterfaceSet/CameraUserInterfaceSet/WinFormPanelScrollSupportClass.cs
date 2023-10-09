using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormPanelScrollSupportClass
{
    static class PanelScroll
    {

        static public void setup(Size frameSize, Size contentSize, object scrollBar)
        {
            if (scrollBar is VScrollBar)
            {
                VScrollBar bar = ((VScrollBar)scrollBar);
                bar.Enabled = contentSize.Height > frameSize.Height;
                bar.Maximum = contentSize.Height;
                bar.LargeChange = frameSize.Height;

            }
            else if (scrollBar is HScrollBar)
            {
                HScrollBar bar = ((HScrollBar)scrollBar);
                bar.Enabled = contentSize.Width > frameSize.Width;
                bar.Maximum = contentSize.Width;
                bar.LargeChange = frameSize.Width;

            }

        }

        static public void moveContentsLocation(Panel content, object scrollBar)
        {
            if (scrollBar is VScrollBar)
            {
                content.Top = -((VScrollBar)scrollBar).Value;

            }
            else if (scrollBar is HScrollBar)
            {
                content.Left = -((HScrollBar)scrollBar).Value;

            }

        }

        static public void wheelScrollContents(Panel frame, object content, MouseEventArgs e)
        {

            if(content is Panel)
            {
                Panel p = ((Panel)content);

                int topBuff = p.Top + e.Delta;

                int offsetMax = p.Height - frame.Height;

                if (topBuff < -offsetMax) { topBuff = -offsetMax;  }

                else if (topBuff >= 0) { topBuff = 0; }

                p.Top = topBuff;

            }

        }

        static public void clearControls(Panel content)
        {
            foreach(var control in content.Controls)
            {
                if(control is PictureBox)
                {
                    PictureBox p = ((PictureBox)control);
                    if (p.Image != null) p.Image.Dispose();
                    p.Dispose();
                }

            }

            content.Controls.Clear();

        }

        static private void pictureBox_Click_Save(object sender, EventArgs e)
        {
            PictureBox p = ((PictureBox)sender);

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "PNG|*.png";
            sfd.FileName = p.Name;

            if (sfd.ShowDialog() != DialogResult.OK) return;

            p.Image.Save(sfd.FileName);

        }

        static public Bitmap OpenBitmapFile()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "PNG|*.png";

            if (ofd.ShowDialog() != DialogResult.OK) return null;

            return new Bitmap(ofd.FileName);

        }

        static public void pictureBoxAdd(Panel content,Bitmap image,string contentName, PictureBoxSizeMode sizeMode = PictureBoxSizeMode.Zoom,int offsetX=0,int offsetY=0,int width = 0, int height=0)
        {
            PictureBox p = new PictureBox();
            p.Left = offsetX;
            p.Top = offsetY;
            p.Name = contentName;
            p.Image = image;
            p.Width = width == 0 ? image.Width : width;
            p.Height = height == 0 ? image.Height : height;
            p.SizeMode = sizeMode;
            p.Click += pictureBox_Click_Save;

            content.Controls.Add(p);
            content.Width = offsetX + p.Width;
            content.Height = offsetY + p.Height;

        }

        static public void pictureBoxSizeModeChange(Panel content, PictureBoxSizeMode sizeMode)
        {
            foreach (var control in content.Controls)
            {
                if (control is PictureBox)
                {
                    ((PictureBox)control).SizeMode = sizeMode;
                    
                }

            }

        }

        static public void pictureBoxUpdate(Panel content,Bitmap image,string pictureBoxName)
        {
            foreach (var control in content.Controls)
            {
                if (control is PictureBox)
                {
                    PictureBox p = (PictureBox)control;

                    if (p.Name == pictureBoxName)
                    {
                        pictureBoxUpdate(p, image);
                        return;
                    }

                }

            }

        }

        private delegate void Delegate_pictureBoxUpdate(PictureBox p, Bitmap image);
        static public void pictureBoxUpdate(PictureBox p, Bitmap image)
        {
            if (p.InvokeRequired)
            {
                p.Invoke(new Delegate_pictureBoxUpdate(pictureBoxUpdate), new object[2] { p, image });
            }
            else
            {
                if (p.Image != null) p.Image.Dispose();
                p.Image = image;
            }
 
        }


    }
}
