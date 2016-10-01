namespace ControlWorks.UI.Console
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtSqlServerStatus = new System.Windows.Forms.TextBox();
            this.pbSqlServerStatus = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblPviStatus = new System.Windows.Forms.Label();
            this.lblCpuStatus = new System.Windows.Forms.Label();
            this.pbCpuStatus = new System.Windows.Forms.PictureBox();
            this.pbPviStatus = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtHeartbeat = new System.Windows.Forms.TextBox();
            this.pbHeartbeat = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnControlWorksService = new System.Windows.Forms.Button();
            this.pbControlWorksService = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tpCoilInfo = new System.Windows.Forms.TabPage();
            this.dgCoilInfo = new System.Windows.Forms.DataGridView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnGetCoilData = new System.Windows.Forms.Button();
            this.tpSensorData = new System.Windows.Forms.TabPage();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.txtCoilId = new System.Windows.Forms.ToolStripTextBox();
            this.dgSensorInfo = new System.Windows.Forms.DataGridView();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.tpRmR = new System.Windows.Forms.TabPage();
            this.dgRmR = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSqlServerStatus)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCpuStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPviStatus)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbHeartbeat)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbControlWorksService)).BeginInit();
            this.tpCoilInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgCoilInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tpSensorData.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgSensorInfo)).BeginInit();
            this.tpRmR.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgRmR)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 486);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(644, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tpCoilInfo);
            this.tabControl1.Controls.Add(this.tpSensorData);
            this.tabControl1.Controls.Add(this.tpRmR);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(644, 486);
            this.tabControl1.TabIndex = 5;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(636, 457);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "System Info";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtSqlServerStatus);
            this.groupBox4.Controls.Add(this.pbSqlServerStatus);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Location = new System.Drawing.Point(323, 187);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(228, 92);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Sql Server";
            // 
            // txtSqlServerStatus
            // 
            this.txtSqlServerStatus.Location = new System.Drawing.Point(6, 64);
            this.txtSqlServerStatus.Name = "txtSqlServerStatus";
            this.txtSqlServerStatus.Size = new System.Drawing.Size(216, 20);
            this.txtSqlServerStatus.TabIndex = 8;
            this.txtSqlServerStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pbSqlServerStatus
            // 
            this.pbSqlServerStatus.Location = new System.Drawing.Point(183, 29);
            this.pbSqlServerStatus.Name = "pbSqlServerStatus";
            this.pbSqlServerStatus.Size = new System.Drawing.Size(39, 22);
            this.pbSqlServerStatus.TabIndex = 7;
            this.pbSqlServerStatus.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(81, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Database Status";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblPviStatus);
            this.groupBox3.Controls.Add(this.lblCpuStatus);
            this.groupBox3.Controls.Add(this.pbCpuStatus);
            this.groupBox3.Controls.Add(this.pbPviStatus);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(30, 187);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(228, 92);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "PVI Communication";
            // 
            // lblPviStatus
            // 
            this.lblPviStatus.AutoSize = true;
            this.lblPviStatus.Location = new System.Drawing.Point(144, 32);
            this.lblPviStatus.Name = "lblPviStatus";
            this.lblPviStatus.Size = new System.Drawing.Size(35, 13);
            this.lblPviStatus.TabIndex = 5;
            this.lblPviStatus.Text = "label5";
            // 
            // lblCpuStatus
            // 
            this.lblCpuStatus.AutoSize = true;
            this.lblCpuStatus.Location = new System.Drawing.Point(144, 64);
            this.lblCpuStatus.Name = "lblCpuStatus";
            this.lblCpuStatus.Size = new System.Drawing.Size(35, 13);
            this.lblCpuStatus.TabIndex = 6;
            this.lblCpuStatus.Text = "label6";
            // 
            // pbCpuStatus
            // 
            this.pbCpuStatus.Location = new System.Drawing.Point(92, 61);
            this.pbCpuStatus.Name = "pbCpuStatus";
            this.pbCpuStatus.Size = new System.Drawing.Size(39, 22);
            this.pbCpuStatus.TabIndex = 4;
            this.pbCpuStatus.TabStop = false;
            // 
            // pbPviStatus
            // 
            this.pbPviStatus.Location = new System.Drawing.Point(92, 29);
            this.pbPviStatus.Name = "pbPviStatus";
            this.pbPviStatus.Size = new System.Drawing.Size(39, 22);
            this.pbPviStatus.TabIndex = 3;
            this.pbPviStatus.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "CPU Station 1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "PVI Service";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtHeartbeat);
            this.groupBox2.Controls.Add(this.pbHeartbeat);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(323, 44);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(228, 92);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Heartbeat";
            // 
            // txtHeartbeat
            // 
            this.txtHeartbeat.Location = new System.Drawing.Point(6, 65);
            this.txtHeartbeat.Name = "txtHeartbeat";
            this.txtHeartbeat.Size = new System.Drawing.Size(216, 20);
            this.txtHeartbeat.TabIndex = 7;
            this.txtHeartbeat.Text = "Connected";
            this.txtHeartbeat.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pbHeartbeat
            // 
            this.pbHeartbeat.Location = new System.Drawing.Point(183, 25);
            this.pbHeartbeat.Name = "pbHeartbeat";
            this.pbHeartbeat.Size = new System.Drawing.Size(39, 22);
            this.pbHeartbeat.TabIndex = 6;
            this.pbHeartbeat.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(74, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Service Heartbeat";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnControlWorksService);
            this.groupBox1.Controls.Add(this.pbControlWorksService);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(30, 44);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(228, 92);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Control Works Service";
            // 
            // btnControlWorksService
            // 
            this.btnControlWorksService.Location = new System.Drawing.Point(6, 63);
            this.btnControlWorksService.Name = "btnControlWorksService";
            this.btnControlWorksService.Size = new System.Drawing.Size(216, 23);
            this.btnControlWorksService.TabIndex = 3;
            this.btnControlWorksService.Text = "button1";
            this.btnControlWorksService.UseVisualStyleBackColor = true;
            this.btnControlWorksService.Click += new System.EventHandler(this.btnControlWorksService_Click);
            // 
            // pbControlWorksService
            // 
            this.pbControlWorksService.Location = new System.Drawing.Point(183, 25);
            this.pbControlWorksService.Name = "pbControlWorksService";
            this.pbControlWorksService.Size = new System.Drawing.Size(39, 22);
            this.pbControlWorksService.TabIndex = 2;
            this.pbControlWorksService.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(92, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Service Status";
            // 
            // tpCoilInfo
            // 
            this.tpCoilInfo.Controls.Add(this.splitContainer1);
            this.tpCoilInfo.Location = new System.Drawing.Point(4, 25);
            this.tpCoilInfo.Name = "tpCoilInfo";
            this.tpCoilInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpCoilInfo.Size = new System.Drawing.Size(1371, 582);
            this.tpCoilInfo.TabIndex = 1;
            this.tpCoilInfo.Text = "Batch Details";
            this.tpCoilInfo.UseVisualStyleBackColor = true;
            // 
            // dgCoilInfo
            // 
            this.dgCoilInfo.AllowUserToAddRows = false;
            this.dgCoilInfo.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgCoilInfo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgCoilInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCoilInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgCoilInfo.Location = new System.Drawing.Point(0, 0);
            this.dgCoilInfo.MultiSelect = false;
            this.dgCoilInfo.Name = "dgCoilInfo";
            this.dgCoilInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgCoilInfo.Size = new System.Drawing.Size(1365, 536);
            this.dgCoilInfo.TabIndex = 1;
            this.dgCoilInfo.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgCoilInfo_CellDoubleClick);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnGetCoilData);
            this.splitContainer1.Panel1.Controls.Add(this.label7);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.dtpEndDate);
            this.splitContainer1.Panel1.Controls.Add(this.dtpStartDate);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgCoilInfo);
            this.splitContainer1.Size = new System.Drawing.Size(1365, 576);
            this.splitContainer1.SplitterDistance = 36;
            this.splitContainer1.TabIndex = 2;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Location = new System.Drawing.Point(48, 11);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(200, 20);
            this.dtpStartDate.TabIndex = 0;
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Location = new System.Drawing.Point(297, 11);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(200, 20);
            this.dtpEndDate.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "From:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(268, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(23, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "To:";
            // 
            // btnGetCoilData
            // 
            this.btnGetCoilData.Location = new System.Drawing.Point(503, 8);
            this.btnGetCoilData.Name = "btnGetCoilData";
            this.btnGetCoilData.Size = new System.Drawing.Size(103, 23);
            this.btnGetCoilData.TabIndex = 4;
            this.btnGetCoilData.Text = "Get Coil Data";
            this.btnGetCoilData.UseVisualStyleBackColor = true;
            this.btnGetCoilData.Click += new System.EventHandler(this.btnGetCoilData_Click);
            // 
            // tpSensorData
            // 
            this.tpSensorData.Controls.Add(this.dgSensorInfo);
            this.tpSensorData.Controls.Add(this.toolStrip1);
            this.tpSensorData.Location = new System.Drawing.Point(4, 25);
            this.tpSensorData.Name = "tpSensorData";
            this.tpSensorData.Padding = new System.Windows.Forms.Padding(3);
            this.tpSensorData.Size = new System.Drawing.Size(1371, 582);
            this.tpSensorData.TabIndex = 2;
            this.tpSensorData.Text = "Sensor Data";
            this.tpSensorData.UseVisualStyleBackColor = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.txtCoilId,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(3, 3);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1365, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(44, 22);
            this.toolStripLabel1.Text = "Coil Id:";
            // 
            // txtCoilId
            // 
            this.txtCoilId.Name = "txtCoilId";
            this.txtCoilId.Size = new System.Drawing.Size(100, 25);
            // 
            // dgSensorInfo
            // 
            this.dgSensorInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSensorInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgSensorInfo.Location = new System.Drawing.Point(3, 28);
            this.dgSensorInfo.Name = "dgSensorInfo";
            this.dgSensorInfo.Size = new System.Drawing.Size(1365, 551);
            this.dgSensorInfo.TabIndex = 1;
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(94, 22);
            this.toolStripButton1.Text = "Get Sensor Data";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // tpRmR
            // 
            this.tpRmR.Controls.Add(this.dgRmR);
            this.tpRmR.Location = new System.Drawing.Point(4, 25);
            this.tpRmR.Name = "tpRmR";
            this.tpRmR.Padding = new System.Windows.Forms.Padding(3);
            this.tpRmR.Size = new System.Drawing.Size(1371, 582);
            this.tpRmR.TabIndex = 3;
            this.tpRmR.Text = "RMR Data";
            this.tpRmR.UseVisualStyleBackColor = true;
            // 
            // dgRmR
            // 
            this.dgRmR.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgRmR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgRmR.Location = new System.Drawing.Point(3, 3);
            this.dgRmR.Name = "dgRmR";
            this.dgRmR.Size = new System.Drawing.Size(1365, 576);
            this.dgRmR.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 508);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "Form1";
            this.Text = "Coil Data Dashboard";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSqlServerStatus)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCpuStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPviStatus)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbHeartbeat)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbControlWorksService)).EndInit();
            this.tpCoilInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgCoilInfo)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tpSensorData.ResumeLayout(false);
            this.tpSensorData.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgSensorInfo)).EndInit();
            this.tpRmR.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgRmR)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabPage tpCoilInfo;
        private System.Windows.Forms.PictureBox pbControlWorksService;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.PictureBox pbHeartbeat;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtHeartbeat;
        private System.Windows.Forms.Button btnControlWorksService;
        private System.Windows.Forms.PictureBox pbCpuStatus;
        private System.Windows.Forms.PictureBox pbPviStatus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblPviStatus;
        private System.Windows.Forms.Label lblCpuStatus;
        private System.Windows.Forms.PictureBox pbSqlServerStatus;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSqlServerStatus;
        private System.Windows.Forms.DataGridView dgCoilInfo;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Button btnGetCoilData;
        private System.Windows.Forms.TabPage tpSensorData;
        private System.Windows.Forms.DataGridView dgSensorInfo;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox txtCoilId;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.TabPage tpRmR;
        private System.Windows.Forms.DataGridView dgRmR;
    }
}

