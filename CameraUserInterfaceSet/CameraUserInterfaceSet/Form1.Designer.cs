namespace CameraUserInterfaceSet
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage_IndCam = new System.Windows.Forms.TabPage();
            this.groupBox_IndCamImagingTestCondition = new System.Windows.Forms.GroupBox();
            this.textBox_IndCamImagingTestCondition_exposureTime = new System.Windows.Forms.TextBox();
            this.textBox_IndCamImagingTestCondition_gain = new System.Windows.Forms.TextBox();
            this.label_IndCamImagingTestCondition_exposureTime_Title = new System.Windows.Forms.Label();
            this.label_IndCamImagingTestCondition_gain_Title = new System.Windows.Forms.Label();
            this.comboBox_IndCam_TileMode = new System.Windows.Forms.ComboBox();
            this.button_panel_IndCamPictureBoxFrame_Tool1 = new System.Windows.Forms.Button();
            this.textBox_IndCam_TileSize = new System.Windows.Forms.TextBox();
            this.label_IndCam_TileMode_Title = new System.Windows.Forms.Label();
            this.label_IndCam_TileSizeTitle = new System.Windows.Forms.Label();
            this.hScrollBar_IndCamPictureBoxFrame = new System.Windows.Forms.HScrollBar();
            this.dataGridView_IndCamImagingConditionList = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button_IndCamListConnect = new System.Windows.Forms.Button();
            this.button_IndCamListUpdate = new System.Windows.Forms.Button();
            this.label_IndCamImagingConditionListTitle = new System.Windows.Forms.Label();
            this.label_IndCamListTitle = new System.Windows.Forms.Label();
            this.dataGridView_IndCamList = new System.Windows.Forms.DataGridView();
            this.Column_IndCamTest = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Column_IndCamModelName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_IndCamAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_IndCamImagingConditionList = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_IndCamSavePath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vScrollBar_IndCamPictureBoxFrame = new System.Windows.Forms.VScrollBar();
            this.panel_IndCamPictureBoxFrame = new System.Windows.Forms.Panel();
            this.panel_IndCamPictureBox = new System.Windows.Forms.Panel();
            this.tabPage_NetCam = new System.Windows.Forms.TabPage();
            this.tabPage_Signal = new System.Windows.Forms.TabPage();
            this.checkBox_IndCamImagingTest_ViewFit = new System.Windows.Forms.CheckBox();
            this.tabControl1.SuspendLayout();
            this.tabPage_IndCam.SuspendLayout();
            this.groupBox_IndCamImagingTestCondition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_IndCamImagingConditionList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_IndCamList)).BeginInit();
            this.panel_IndCamPictureBoxFrame.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage_IndCam);
            this.tabControl1.Controls.Add(this.tabPage_NetCam);
            this.tabControl1.Controls.Add(this.tabPage_Signal);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1580, 950);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage_IndCam
            // 
            this.tabPage_IndCam.Controls.Add(this.groupBox_IndCamImagingTestCondition);
            this.tabPage_IndCam.Controls.Add(this.comboBox_IndCam_TileMode);
            this.tabPage_IndCam.Controls.Add(this.button_panel_IndCamPictureBoxFrame_Tool1);
            this.tabPage_IndCam.Controls.Add(this.textBox_IndCam_TileSize);
            this.tabPage_IndCam.Controls.Add(this.label_IndCam_TileMode_Title);
            this.tabPage_IndCam.Controls.Add(this.label_IndCam_TileSizeTitle);
            this.tabPage_IndCam.Controls.Add(this.hScrollBar_IndCamPictureBoxFrame);
            this.tabPage_IndCam.Controls.Add(this.dataGridView_IndCamImagingConditionList);
            this.tabPage_IndCam.Controls.Add(this.button_IndCamListConnect);
            this.tabPage_IndCam.Controls.Add(this.button_IndCamListUpdate);
            this.tabPage_IndCam.Controls.Add(this.label_IndCamImagingConditionListTitle);
            this.tabPage_IndCam.Controls.Add(this.label_IndCamListTitle);
            this.tabPage_IndCam.Controls.Add(this.dataGridView_IndCamList);
            this.tabPage_IndCam.Controls.Add(this.vScrollBar_IndCamPictureBoxFrame);
            this.tabPage_IndCam.Controls.Add(this.panel_IndCamPictureBoxFrame);
            this.tabPage_IndCam.Location = new System.Drawing.Point(4, 25);
            this.tabPage_IndCam.Name = "tabPage_IndCam";
            this.tabPage_IndCam.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_IndCam.Size = new System.Drawing.Size(1572, 921);
            this.tabPage_IndCam.TabIndex = 0;
            this.tabPage_IndCam.Text = "IndCam";
            this.tabPage_IndCam.UseVisualStyleBackColor = true;
            // 
            // groupBox_IndCamImagingTestCondition
            // 
            this.groupBox_IndCamImagingTestCondition.Controls.Add(this.checkBox_IndCamImagingTest_ViewFit);
            this.groupBox_IndCamImagingTestCondition.Controls.Add(this.textBox_IndCamImagingTestCondition_exposureTime);
            this.groupBox_IndCamImagingTestCondition.Controls.Add(this.textBox_IndCamImagingTestCondition_gain);
            this.groupBox_IndCamImagingTestCondition.Controls.Add(this.label_IndCamImagingTestCondition_exposureTime_Title);
            this.groupBox_IndCamImagingTestCondition.Controls.Add(this.label_IndCamImagingTestCondition_gain_Title);
            this.groupBox_IndCamImagingTestCondition.Location = new System.Drawing.Point(11, 180);
            this.groupBox_IndCamImagingTestCondition.Name = "groupBox_IndCamImagingTestCondition";
            this.groupBox_IndCamImagingTestCondition.Size = new System.Drawing.Size(233, 126);
            this.groupBox_IndCamImagingTestCondition.TabIndex = 12;
            this.groupBox_IndCamImagingTestCondition.TabStop = false;
            this.groupBox_IndCamImagingTestCondition.Text = "TestCondition";
            // 
            // textBox_IndCamImagingTestCondition_exposureTime
            // 
            this.textBox_IndCamImagingTestCondition_exposureTime.Location = new System.Drawing.Point(127, 54);
            this.textBox_IndCamImagingTestCondition_exposureTime.Name = "textBox_IndCamImagingTestCondition_exposureTime";
            this.textBox_IndCamImagingTestCondition_exposureTime.Size = new System.Drawing.Size(100, 22);
            this.textBox_IndCamImagingTestCondition_exposureTime.TabIndex = 2;
            // 
            // textBox_IndCamImagingTestCondition_gain
            // 
            this.textBox_IndCamImagingTestCondition_gain.Location = new System.Drawing.Point(127, 19);
            this.textBox_IndCamImagingTestCondition_gain.Name = "textBox_IndCamImagingTestCondition_gain";
            this.textBox_IndCamImagingTestCondition_gain.Size = new System.Drawing.Size(100, 22);
            this.textBox_IndCamImagingTestCondition_gain.TabIndex = 2;
            // 
            // label_IndCamImagingTestCondition_exposureTime_Title
            // 
            this.label_IndCamImagingTestCondition_exposureTime_Title.AutoSize = true;
            this.label_IndCamImagingTestCondition_exposureTime_Title.Location = new System.Drawing.Point(7, 57);
            this.label_IndCamImagingTestCondition_exposureTime_Title.Name = "label_IndCamImagingTestCondition_exposureTime_Title";
            this.label_IndCamImagingTestCondition_exposureTime_Title.Size = new System.Drawing.Size(96, 15);
            this.label_IndCamImagingTestCondition_exposureTime_Title.TabIndex = 1;
            this.label_IndCamImagingTestCondition_exposureTime_Title.Text = "exposureTime";
            // 
            // label_IndCamImagingTestCondition_gain_Title
            // 
            this.label_IndCamImagingTestCondition_gain_Title.AutoSize = true;
            this.label_IndCamImagingTestCondition_gain_Title.Location = new System.Drawing.Point(7, 22);
            this.label_IndCamImagingTestCondition_gain_Title.Name = "label_IndCamImagingTestCondition_gain_Title";
            this.label_IndCamImagingTestCondition_gain_Title.Size = new System.Drawing.Size(32, 15);
            this.label_IndCamImagingTestCondition_gain_Title.TabIndex = 0;
            this.label_IndCamImagingTestCondition_gain_Title.Text = "gain";
            // 
            // comboBox_IndCam_TileMode
            // 
            this.comboBox_IndCam_TileMode.FormattingEnabled = true;
            this.comboBox_IndCam_TileMode.Location = new System.Drawing.Point(107, 786);
            this.comboBox_IndCam_TileMode.Name = "comboBox_IndCam_TileMode";
            this.comboBox_IndCam_TileMode.Size = new System.Drawing.Size(138, 23);
            this.comboBox_IndCam_TileMode.TabIndex = 11;
            this.comboBox_IndCam_TileMode.Text = "Zoom";
            this.comboBox_IndCam_TileMode.SelectedIndexChanged += new System.EventHandler(this.comboBox_IndCam_TileMode_SelectedIndexChanged);
            // 
            // button_panel_IndCamPictureBoxFrame_Tool1
            // 
            this.button_panel_IndCamPictureBoxFrame_Tool1.Location = new System.Drawing.Point(1540, 894);
            this.button_panel_IndCamPictureBoxFrame_Tool1.Name = "button_panel_IndCamPictureBoxFrame_Tool1";
            this.button_panel_IndCamPictureBoxFrame_Tool1.Size = new System.Drawing.Size(21, 21);
            this.button_panel_IndCamPictureBoxFrame_Tool1.TabIndex = 10;
            this.button_panel_IndCamPictureBoxFrame_Tool1.Text = "..";
            this.button_panel_IndCamPictureBoxFrame_Tool1.UseVisualStyleBackColor = true;
            this.button_panel_IndCamPictureBoxFrame_Tool1.Click += new System.EventHandler(this.button_panel_IndCamPictureBoxFrame_Tool1_Click);
            // 
            // textBox_IndCam_TileSize
            // 
            this.textBox_IndCam_TileSize.Location = new System.Drawing.Point(6, 786);
            this.textBox_IndCam_TileSize.Name = "textBox_IndCam_TileSize";
            this.textBox_IndCam_TileSize.Size = new System.Drawing.Size(95, 22);
            this.textBox_IndCam_TileSize.TabIndex = 9;
            this.textBox_IndCam_TileSize.TextChanged += new System.EventHandler(this.panel_IndCamPictureBoxSizeUpdate);
            // 
            // label_IndCam_TileMode_Title
            // 
            this.label_IndCam_TileMode_Title.AutoSize = true;
            this.label_IndCam_TileMode_Title.Location = new System.Drawing.Point(104, 768);
            this.label_IndCam_TileMode_Title.Name = "label_IndCam_TileMode_Title";
            this.label_IndCam_TileMode_Title.Size = new System.Drawing.Size(60, 15);
            this.label_IndCam_TileMode_Title.TabIndex = 8;
            this.label_IndCam_TileMode_Title.Text = "tileMode";
            // 
            // label_IndCam_TileSizeTitle
            // 
            this.label_IndCam_TileSizeTitle.AutoSize = true;
            this.label_IndCam_TileSizeTitle.Location = new System.Drawing.Point(3, 768);
            this.label_IndCam_TileSizeTitle.Name = "label_IndCam_TileSizeTitle";
            this.label_IndCam_TileSizeTitle.Size = new System.Drawing.Size(53, 15);
            this.label_IndCam_TileSizeTitle.TabIndex = 8;
            this.label_IndCam_TileSizeTitle.Text = "tileSize";
            // 
            // hScrollBar_IndCamPictureBoxFrame
            // 
            this.hScrollBar_IndCamPictureBoxFrame.Location = new System.Drawing.Point(260, 895);
            this.hScrollBar_IndCamPictureBoxFrame.Name = "hScrollBar_IndCamPictureBoxFrame";
            this.hScrollBar_IndCamPictureBoxFrame.Size = new System.Drawing.Size(1280, 21);
            this.hScrollBar_IndCamPictureBoxFrame.TabIndex = 7;
            this.hScrollBar_IndCamPictureBoxFrame.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar_IndCamPictureBoxFrame_Scroll);
            // 
            // dataGridView_IndCamImagingConditionList
            // 
            this.dataGridView_IndCamImagingConditionList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_IndCamImagingConditionList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.dataGridView_IndCamImagingConditionList.Location = new System.Drawing.Point(6, 327);
            this.dataGridView_IndCamImagingConditionList.Name = "dataGridView_IndCamImagingConditionList";
            this.dataGridView_IndCamImagingConditionList.RowTemplate.Height = 24;
            this.dataGridView_IndCamImagingConditionList.Size = new System.Drawing.Size(239, 427);
            this.dataGridView_IndCamImagingConditionList.TabIndex = 5;
            this.dataGridView_IndCamImagingConditionList.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridView_IndCamImagingConditionList_CellPainting);
            this.dataGridView_IndCamImagingConditionList.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.panel_IndCamPictureBoxSizeUpdate);
            this.dataGridView_IndCamImagingConditionList.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.panel_IndCamPictureBoxSizeUpdate);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Gain";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 30;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "ExposureTime";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 80;
            // 
            // button_IndCamListConnect
            // 
            this.button_IndCamListConnect.Location = new System.Drawing.Point(211, 1);
            this.button_IndCamListConnect.Name = "button_IndCamListConnect";
            this.button_IndCamListConnect.Size = new System.Drawing.Size(75, 23);
            this.button_IndCamListConnect.TabIndex = 4;
            this.button_IndCamListConnect.Text = "Connect";
            this.button_IndCamListConnect.UseVisualStyleBackColor = true;
            this.button_IndCamListConnect.Click += new System.EventHandler(this.button_IndCamListConnect_Click);
            // 
            // button_IndCamListUpdate
            // 
            this.button_IndCamListUpdate.Location = new System.Drawing.Point(117, 1);
            this.button_IndCamListUpdate.Name = "button_IndCamListUpdate";
            this.button_IndCamListUpdate.Size = new System.Drawing.Size(75, 23);
            this.button_IndCamListUpdate.TabIndex = 4;
            this.button_IndCamListUpdate.Text = "Update";
            this.button_IndCamListUpdate.UseVisualStyleBackColor = true;
            // 
            // label_IndCamImagingConditionListTitle
            // 
            this.label_IndCamImagingConditionListTitle.AutoSize = true;
            this.label_IndCamImagingConditionListTitle.Location = new System.Drawing.Point(8, 309);
            this.label_IndCamImagingConditionListTitle.Name = "label_IndCamImagingConditionListTitle";
            this.label_IndCamImagingConditionListTitle.Size = new System.Drawing.Size(137, 15);
            this.label_IndCamImagingConditionListTitle.TabIndex = 3;
            this.label_IndCamImagingConditionListTitle.Text = "ImagingConditionList";
            // 
            // label_IndCamListTitle
            // 
            this.label_IndCamListTitle.AutoSize = true;
            this.label_IndCamListTitle.Location = new System.Drawing.Point(7, 5);
            this.label_IndCamListTitle.Name = "label_IndCamListTitle";
            this.label_IndCamListTitle.Size = new System.Drawing.Size(77, 15);
            this.label_IndCamListTitle.TabIndex = 3;
            this.label_IndCamListTitle.Text = "IndCamList";
            // 
            // dataGridView_IndCamList
            // 
            this.dataGridView_IndCamList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_IndCamList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_IndCamTest,
            this.Column_IndCamModelName,
            this.Column_IndCamAddress,
            this.Column_IndCamImagingConditionList,
            this.Column_IndCamSavePath});
            this.dataGridView_IndCamList.Location = new System.Drawing.Point(6, 26);
            this.dataGridView_IndCamList.Name = "dataGridView_IndCamList";
            this.dataGridView_IndCamList.RowTemplate.Height = 24;
            this.dataGridView_IndCamList.Size = new System.Drawing.Size(1560, 137);
            this.dataGridView_IndCamList.TabIndex = 2;
            this.dataGridView_IndCamList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_IndCamList_CellContentClick);
            this.dataGridView_IndCamList.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.panel_IndCamPictureBoxSizeUpdate);
            this.dataGridView_IndCamList.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.panel_IndCamPictureBoxSizeUpdate);
            // 
            // Column_IndCamTest
            // 
            this.Column_IndCamTest.HeaderText = "Test";
            this.Column_IndCamTest.Name = "Column_IndCamTest";
            this.Column_IndCamTest.Text = "";
            this.Column_IndCamTest.Width = 50;
            // 
            // Column_IndCamModelName
            // 
            this.Column_IndCamModelName.HeaderText = "ModelName";
            this.Column_IndCamModelName.Name = "Column_IndCamModelName";
            this.Column_IndCamModelName.Width = 150;
            // 
            // Column_IndCamAddress
            // 
            this.Column_IndCamAddress.HeaderText = "Address";
            this.Column_IndCamAddress.Name = "Column_IndCamAddress";
            this.Column_IndCamAddress.Width = 150;
            // 
            // Column_IndCamImagingConditionList
            // 
            this.Column_IndCamImagingConditionList.HeaderText = "ImagingConditionList";
            this.Column_IndCamImagingConditionList.Name = "Column_IndCamImagingConditionList";
            this.Column_IndCamImagingConditionList.Width = 150;
            // 
            // Column_IndCamSavePath
            // 
            this.Column_IndCamSavePath.HeaderText = "SavePath";
            this.Column_IndCamSavePath.Name = "Column_IndCamSavePath";
            this.Column_IndCamSavePath.Width = 300;
            // 
            // vScrollBar_IndCamPictureBoxFrame
            // 
            this.vScrollBar_IndCamPictureBoxFrame.Location = new System.Drawing.Point(1540, 175);
            this.vScrollBar_IndCamPictureBoxFrame.Name = "vScrollBar_IndCamPictureBoxFrame";
            this.vScrollBar_IndCamPictureBoxFrame.Size = new System.Drawing.Size(21, 720);
            this.vScrollBar_IndCamPictureBoxFrame.TabIndex = 1;
            this.vScrollBar_IndCamPictureBoxFrame.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar_IndCamPictureBoxFrame_Scroll);
            // 
            // panel_IndCamPictureBoxFrame
            // 
            this.panel_IndCamPictureBoxFrame.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_IndCamPictureBoxFrame.Controls.Add(this.panel_IndCamPictureBox);
            this.panel_IndCamPictureBoxFrame.Location = new System.Drawing.Point(260, 175);
            this.panel_IndCamPictureBoxFrame.Name = "panel_IndCamPictureBoxFrame";
            this.panel_IndCamPictureBoxFrame.Size = new System.Drawing.Size(1280, 720);
            this.panel_IndCamPictureBoxFrame.TabIndex = 0;
            // 
            // panel_IndCamPictureBox
            // 
            this.panel_IndCamPictureBox.Location = new System.Drawing.Point(0, 0);
            this.panel_IndCamPictureBox.Name = "panel_IndCamPictureBox";
            this.panel_IndCamPictureBox.Size = new System.Drawing.Size(64, 64);
            this.panel_IndCamPictureBox.TabIndex = 0;
            this.panel_IndCamPictureBox.SizeChanged += new System.EventHandler(this.panel_IndCamPictureBox_SizeChanged);
            // 
            // tabPage_NetCam
            // 
            this.tabPage_NetCam.Location = new System.Drawing.Point(4, 25);
            this.tabPage_NetCam.Name = "tabPage_NetCam";
            this.tabPage_NetCam.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_NetCam.Size = new System.Drawing.Size(1572, 921);
            this.tabPage_NetCam.TabIndex = 1;
            this.tabPage_NetCam.Text = "NetCam";
            this.tabPage_NetCam.UseVisualStyleBackColor = true;
            // 
            // tabPage_Signal
            // 
            this.tabPage_Signal.Location = new System.Drawing.Point(4, 25);
            this.tabPage_Signal.Name = "tabPage_Signal";
            this.tabPage_Signal.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Signal.Size = new System.Drawing.Size(1572, 921);
            this.tabPage_Signal.TabIndex = 2;
            this.tabPage_Signal.Text = "Signal";
            this.tabPage_Signal.UseVisualStyleBackColor = true;
            // 
            // checkBox_IndCamImagingTest_ViewFit
            // 
            this.checkBox_IndCamImagingTest_ViewFit.AutoSize = true;
            this.checkBox_IndCamImagingTest_ViewFit.Location = new System.Drawing.Point(10, 91);
            this.checkBox_IndCamImagingTest_ViewFit.Name = "checkBox_IndCamImagingTest_ViewFit";
            this.checkBox_IndCamImagingTest_ViewFit.Size = new System.Drawing.Size(100, 19);
            this.checkBox_IndCamImagingTest_ViewFit.TabIndex = 3;
            this.checkBox_IndCamImagingTest_ViewFit.Text = "ViewsizeFit";
            this.checkBox_IndCamImagingTest_ViewFit.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1582, 953);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "CameraUserInterfaceSet";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage_IndCam.ResumeLayout(false);
            this.tabPage_IndCam.PerformLayout();
            this.groupBox_IndCamImagingTestCondition.ResumeLayout(false);
            this.groupBox_IndCamImagingTestCondition.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_IndCamImagingConditionList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_IndCamList)).EndInit();
            this.panel_IndCamPictureBoxFrame.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage_IndCam;
        private System.Windows.Forms.VScrollBar vScrollBar_IndCamPictureBoxFrame;
        private System.Windows.Forms.Panel panel_IndCamPictureBoxFrame;
        private System.Windows.Forms.Panel panel_IndCamPictureBox;
        private System.Windows.Forms.TabPage tabPage_NetCam;
        private System.Windows.Forms.TabPage tabPage_Signal;
        private System.Windows.Forms.Label label_IndCamListTitle;
        private System.Windows.Forms.DataGridView dataGridView_IndCamList;
        private System.Windows.Forms.Button button_IndCamListUpdate;
        private System.Windows.Forms.Label label_IndCamImagingConditionListTitle;
        private System.Windows.Forms.DataGridView dataGridView_IndCamImagingConditionList;
        private System.Windows.Forms.DataGridViewButtonColumn Column_IndCamTest;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_IndCamModelName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_IndCamAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_IndCamImagingConditionList;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_IndCamSavePath;
        private System.Windows.Forms.HScrollBar hScrollBar_IndCamPictureBoxFrame;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.TextBox textBox_IndCam_TileSize;
        private System.Windows.Forms.Label label_IndCam_TileSizeTitle;
        private System.Windows.Forms.Button button_panel_IndCamPictureBoxFrame_Tool1;
        private System.Windows.Forms.ComboBox comboBox_IndCam_TileMode;
        private System.Windows.Forms.Label label_IndCam_TileMode_Title;
        private System.Windows.Forms.GroupBox groupBox_IndCamImagingTestCondition;
        private System.Windows.Forms.TextBox textBox_IndCamImagingTestCondition_exposureTime;
        private System.Windows.Forms.TextBox textBox_IndCamImagingTestCondition_gain;
        private System.Windows.Forms.Label label_IndCamImagingTestCondition_exposureTime_Title;
        private System.Windows.Forms.Label label_IndCamImagingTestCondition_gain_Title;
        private System.Windows.Forms.Button button_IndCamListConnect;
        private System.Windows.Forms.CheckBox checkBox_IndCamImagingTest_ViewFit;
    }
}

