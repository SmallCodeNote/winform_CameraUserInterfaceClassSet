using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using System.Media;

using OpenCvSharp;
using OpenCvSharp.Extensions;

using FluentScheduler;

using WinFormToStringClass;
using FileCreateSupportClass;
using WinFormPanelScrollSupportClass;
using IndCamControlClass;

using NetCamControlClass;
using SoundControlClass;


namespace CameraUserInterfaceSet
{
    public partial class Form1 : Form
    {

        NetCamControl netCamControl;

        string ThisExeLocationDirectory = "";
        string WinFormControlsSetupFilePath = @"param\controlsSetup.txt";

        SoundPlayer player = null;


        public Form1()
        {
            InitializeComponent();
            ThisExeLocationDirectory = Path.GetDirectoryName(Application.ExecutablePath);

            this.panel_IndCamPictureBoxFrame.MouseWheel
                += new System.Windows.Forms.MouseEventHandler(this.panelFrame_MouseWheel);
                        
            comboBox_IndCam_TileMode.Items.Add(PictureBoxSizeMode.Zoom);
            comboBox_IndCam_TileMode.Items.Add(PictureBoxSizeMode.CenterImage);
            comboBox_IndCam_TileMode.Items.Add(PictureBoxSizeMode.StretchImage);
            comboBox_IndCam_TileMode.Items.Add(PictureBoxSizeMode.Normal);

            JobManager.Initialize();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Load Controls Setup File
            string setupFilePath = Path.Combine(ThisExeLocationDirectory, WinFormControlsSetupFilePath);

            if (File.Exists(setupFilePath))
            {
                WinFormToString.setControlFromString(this, File.ReadAllText(setupFilePath));
            }

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

            PanelScroll.clearControls(panel_IndCamPictureBox);

            if (netCamControl != null) netCamControl.Dispose();


            //Save Controls Setup File
            string targetPath = Path.Combine(ThisExeLocationDirectory, WinFormControlsSetupFilePath);

            DirectoryCheck.Create(Path.GetDirectoryName(targetPath));
            File.WriteAllText(targetPath, WinFormToString.ToString(this));

        }

        private void dataGridView_IndCamImagingConditionList_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            //Draw row index
            int RowCount = ((DataGridView)sender).Rows.Count - 1;

            if (e.ColumnIndex < 0 && e.RowIndex >= 0 && e.RowIndex < RowCount)
            {
                e.Paint(e.ClipBounds, DataGridViewPaintParts.All);
                Rectangle indexRect = e.CellBounds;
                indexRect.Inflate(-2, -2);
                TextRenderer.DrawText(e.Graphics,
                    (e.RowIndex + 1).ToString(),
                    e.CellStyle.Font,
                    indexRect,
                    e.CellStyle.ForeColor,
                    TextFormatFlags.Right | TextFormatFlags.VerticalCenter);
                e.Handled = true;
            }

        }


        private void vScrollBar_IndCamPictureBoxFrame_Scroll(object sender, ScrollEventArgs e)
        {
            PanelScroll.moveContentsLocation(this.panel_IndCamPictureBox, sender);
        }

        private void hScrollBar_IndCamPictureBoxFrame_Scroll(object sender, ScrollEventArgs e)
        {
            PanelScroll.moveContentsLocation(this.panel_IndCamPictureBox, sender);
        }

        private void panel_IndCamPictureBox_SizeChanged(object sender, EventArgs e)
        {
            PanelScroll.setup(this.panel_IndCamPictureBoxFrame.Size, this.panel_IndCamPictureBox.Size, this.vScrollBar_IndCamPictureBoxFrame);
            PanelScroll.setup(this.panel_IndCamPictureBoxFrame.Size, this.panel_IndCamPictureBox.Size, this.hScrollBar_IndCamPictureBoxFrame);
        }

        private void panel_IndCamPictureBoxSizeUpdate()
        {
            try
            {
                string[] tileSizeElmStr = textBox_IndCam_TileSize.Text.Split(',');
                if (tileSizeElmStr.Length < 2) return;

                int tileWidth = int.Parse(tileSizeElmStr[0]);
                int tileHeight = int.Parse(tileSizeElmStr[1]);
                panel_IndCamPictureBox.Width = tileWidth * (dataGridView_IndCamList.RowCount - 1);
                panel_IndCamPictureBox.Height = tileHeight * (dataGridView_IndCamImagingConditionList.RowCount - 1);

            }
            catch { }

        }

        private void panel_IndCamPictureBoxSizeUpdate(object sender, DataGridViewRowsAddedEventArgs e)
        {
            panel_IndCamPictureBoxSizeUpdate();

        }

        private void panel_IndCamPictureBoxSizeUpdate(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            panel_IndCamPictureBoxSizeUpdate();

        }

        private void panel_IndCamPictureBoxSizeUpdate(object sender, EventArgs e)
        {
            panel_IndCamPictureBoxSizeUpdate();

        }

        private void button_panel_IndCamPictureBoxFrame_Tool1_Click(object sender, EventArgs e)
        {
            int tileWidth = 0;
            int tileHeight = 0;

            int labelHeigntMax = 0;
            try
            {
                string[] tileSizeElmStr = textBox_IndCam_TileSize.Text.Split(',');
                if (tileSizeElmStr.Length < 2) return;

                tileWidth = int.Parse(tileSizeElmStr[0]);
                tileHeight = int.Parse(tileSizeElmStr[1]);

            }
            catch { return; }


            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "PNG|*.png";
            if (ofd.ShowDialog() != DialogResult.OK) return;
            
            PanelScroll.clearControls(panel_IndCamPictureBox);

            for (int i = 0; i < dataGridView_IndCamList.Rows.Count-1; i++)
            {
                for (int j = 0; j < dataGridView_IndCamImagingConditionList.Rows.Count - 1; j++)
                {
                    Label L = new Label();
                    L.Top= (tileHeight + L.Height) * j;
                    L.Left = tileWidth * i;
                    L.Name = "Label_"+Path.GetFileNameWithoutExtension(ofd.FileName) + i.ToString("000") + j.ToString("000");
                    L.Text = "i" + i.ToString("000") +","+ "j" + j.ToString("000");
                    panel_IndCamPictureBox.Controls.Add(L);

                    if (labelHeigntMax < L.Height) labelHeigntMax = L.Height;

                    PanelScroll.pictureBoxAdd(panel_IndCamPictureBox,
                        new Bitmap(ofd.FileName), 
                        "PictureBox_" + Path.GetFileNameWithoutExtension(ofd.FileName) + i.ToString("000") + j.ToString("000"),
                        (PictureBoxSizeMode)(comboBox_IndCam_TileMode.SelectedItem),
                        tileWidth * i, 
                        (tileHeight + labelHeigntMax) * j + L.Height,
                        tileWidth,
                        tileHeight
                        );

                }

            }

            panel_IndCamPictureBox.Width = (dataGridView_IndCamList.Rows.Count - 1) * tileWidth;
            panel_IndCamPictureBox.Height = (dataGridView_IndCamImagingConditionList.Rows.Count - 1) * (tileHeight + labelHeigntMax);

            return;

        }

        private void panelFrame_MouseWheel(object sender, MouseEventArgs e)
        {
            PanelScroll.wheelScrollContents(panel_IndCamPictureBoxFrame, panel_IndCamPictureBox, e);
            vScrollBar_IndCamPictureBoxFrame.Value = -panel_IndCamPictureBox.Top;

        }

        private void pictureBox_Click_Save(object sender, EventArgs e)
        {
            PictureBox p = ((PictureBox)sender);

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "PNG|*.png";
            sfd.FileName = p.Name;

            if (sfd.ShowDialog() != DialogResult.OK) return;

            p.Image.Save(sfd.FileName);

        }


        public int[] stringToIntArray(string line)
        {
            string[] cols = line.Split(',');
            List<int> items = new List<int>();

            foreach(var c in cols)
            {
                items.Add(int.Parse(c));

            }

            return items.ToArray();

        }

        private void dataGridView_IndCamList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            List<IndCamImagingCondition> indCamImagingConditionList = getIndCamImagingConditionList();

            DataGridView dgv = (DataGridView)sender;
            if (e.ColumnIndex == 0)
            {
                string address = dgv.Rows[e.RowIndex].Cells[2].Value.ToString();
                double gain = double.Parse(textBox_IndCamImagingTestCondition_gain.Text);
                double exposureTime = double.Parse(textBox_IndCamImagingTestCondition_exposureTime.Text);
                

                using (IndCamControl indCamSystem = new IndCamControl())
                {
                    //Bitmap image = indCamSystem.getFrameBitmap(address, gain, exposureTime);
                    Bitmap image = PanelScroll.OpenBitmapFile();

                    PanelScroll.clearControls(panel_IndCamPictureBox);

                    if (checkBox_IndCamImagingTest_ViewFit.Checked)
                    {
                        PanelScroll.pictureBoxAdd(panel_IndCamPictureBox, image, gain.ToString("00") + "_" + exposureTime.ToString("0000"), (PictureBoxSizeMode)(comboBox_IndCam_TileMode.SelectedItem), 0,0,panel_IndCamPictureBoxFrame.Width,panel_IndCamPictureBoxFrame.Height);
                        panel_IndCamPictureBox.Width = panel_IndCamPictureBoxFrame.Width;
                        panel_IndCamPictureBox.Height = panel_IndCamPictureBoxFrame.Height;

                    }
                    else
                    {
                        PanelScroll.pictureBoxAdd(panel_IndCamPictureBox, image, gain.ToString("00") + "_" + exposureTime.ToString("0000"));
                    }
                }
                
            }

        }

        private List<IndCamImagingCondition> getIndCamImagingConditionList()
        {
            List<IndCamImagingCondition> resultList = new List<IndCamImagingCondition>();
            int ConditionIndexMax = dataGridView_IndCamImagingConditionList.RowCount - 2;

            for (int i = 0; i < ConditionIndexMax; i++)
            {
                string gainString = dataGridView_IndCamImagingConditionList.Rows[i].Cells[0].Value.ToString();
                string exposureTimeString = dataGridView_IndCamImagingConditionList.Rows[i].Cells[1].Value.ToString();

                IndCamImagingCondition imagingCondition = new IndCamImagingCondition( int.Parse(gainString),  int.Parse(exposureTimeString));
                resultList.Add(imagingCondition);

            }

            return resultList;

        }

        private void button_IndCamListConnect_Click(object sender, EventArgs e)
        {

        }

        private void comboBox_IndCam_TileMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            PanelScroll.pictureBoxSizeModeChange(panel_IndCamPictureBox, (PictureBoxSizeMode)(comboBox_IndCam_TileMode.SelectedItem));

        }

        private void button_NetCam_getImage_Click(object sender, EventArgs e)
        {
            if (pictureBox_NetCam_View.Image != null) pictureBox_NetCam_View.Image.Dispose();
            pictureBox_NetCam_View.Image = netCamControl.GetImage();

        }

        private void button_NetCam_getAverage_Click(object sender, EventArgs e)
        {
            int frameRange = int.Parse(textBox_NetCam_frameRange.Text);
            if (pictureBox_NetCam_View.Image != null) pictureBox_NetCam_View.Image.Dispose();
            pictureBox_NetCam_View.Image = netCamControl.GetImageTimeAverage(frameRange);
        }

        private void button_NetCam_getTimeMedian_Click(object sender, EventArgs e)
        {
            int frameRange = int.Parse(textBox_NetCam_frameRange.Text);
            if (pictureBox_NetCam_View.Image != null) pictureBox_NetCam_View.Image.Dispose();
            pictureBox_NetCam_View.Image = netCamControl.GetImageTimeMedian(frameRange);
        }

        private void button_NetCam_saveMovie_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "WMV|*.wmv";

            if (sfd.ShowDialog() != DialogResult.OK) return;

            netCamControl.saveMovie(sfd.FileName);

        }

        private void button_NetCam_Connect__Click(object sender, EventArgs e)
        {
            if (button_NetCam_Connect.Text=="Connect")
            {
                button_NetCam_Connect.Enabled = false;
                label_NetCam_Status.Text = "Connecting..."; NetCam_Status = "Connecting...";
                backgroundWorker_NetCam_Connect.RunWorkerAsync();

                button_NetCam_Connect.Text = "DisConnect";

            }
            else
            {

                if (backgroundWorker_NetCam_Connect.IsBusy)
                {
                    backgroundWorker_NetCam_Connect.CancelAsync();
                    Thread.Sleep(200);
                }

               

            }

        }


        string NetCam_Status = "";

        private void backgroundWorker_NetCam_Connect_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bw = (BackgroundWorker)sender;
            bw.ReportProgress(0);

            if (netCamControl != null) { netCamControl.Dispose(); }
            netCamControl = new NetCamControl(textBox_NetCam_Address.Text, textBox_NetCam_id.Text, textBox_NetCam_passwd.Text);

            do
            {
                NetCam_Status = "queCount = " + netCamControl.queCount.ToString();

                if (netCamControl.queCount > 0)
                {
                    bw.ReportProgress(2);

                }
                else
                {
                    bw.ReportProgress(1);

                }

                Thread.Sleep(100);

                if (bw.CancellationPending)
                {

                    e.Cancel = true;
                    return;
                }

            } while (true);

        }

        private void backgroundWorker_NetCam_Connect_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == 0)
            {
                groupBox_NetCam_Operation.Enabled = false;

            }
            else if (e.ProgressPercentage == 1)
            {
                groupBox_NetCam_Operation.Enabled = false;
                label_NetCam_Status.Text = NetCam_Status;

            }
            else if (e.ProgressPercentage == 2)
            {
                groupBox_NetCam_Operation.Enabled = true;
                label_NetCam_Status.Text = NetCam_Status;

                button_NetCam_Connect.Enabled = true;

            }

            label_NetCam_Status.Refresh();

        }

        private void backgroundWorker_NetCam_Connect_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (netCamControl != null) { netCamControl.Dispose(); }

            button_NetCam_Connect.Text = "Connect";
            groupBox_NetCam_Operation.Enabled = false;
            label_NetCam_Status.Text = "...";
        }

        private void button_ScheduleList_Load_Click(object sender, EventArgs e)
        {
            JobManager.Stop();
            JobManager.AddJob(() => UpdateText(label_ScheduleList_Status,DateTime.Now.ToString("HH:mm:ss")), s => s.ToRunEvery(5).Seconds());
            JobManager.Initialize();
        }

        public delegate void DelegateUpdateText(object control, object value);

        private void UpdateText(object control, object value)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new DelegateUpdateText(this.UpdateText), new object[] { control, value });
                return;
            }

            if (control is Label) { ((Label)control).Text = ((string)value); }
            else if (control is TextBox) { ((TextBox)control).Text = ((string)value); }
            else if (control is Button) { ((Button)control).Text = ((string)value); }

        }


    }

}
