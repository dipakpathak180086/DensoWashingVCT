namespace DENSO_VCT_APP
{
    partial class frmAssemblyScanning
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAssemblyScanning));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnMini = new System.Windows.Forms.Button();
            this.gbPrintingParameter = new System.Windows.Forms.GroupBox();
            this.txtTrayNo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblScannerStatus = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnStart = new System.Windows.Forms.Button();
            this.lblHeader = new System.Windows.Forms.Label();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblMsg = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.TrayBarcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.timerAllHardware = new System.Windows.Forms.Timer(this.components);
            this.tmrCaseVerify = new System.Windows.Forms.Timer(this.components);
            this.timerTcpClient = new System.Windows.Forms.Timer(this.components);
            this.gbPrintingParameter.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Transparent;
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBack.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnBack.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnBack.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBack.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(72)))), ((int)(((byte)(146)))));
            this.btnBack.Image = ((System.Drawing.Image)(resources.GetObject("btnBack.Image")));
            this.btnBack.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnBack.Location = new System.Drawing.Point(90, 5);
            this.btnBack.Margin = new System.Windows.Forms.Padding(5);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(66, 47);
            this.btnBack.TabIndex = 8;
            this.btnBack.Text = "&Back";
            this.btnBack.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnMini
            // 
            this.btnMini.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMini.BackColor = System.Drawing.Color.Transparent;
            this.btnMini.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMini.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMini.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.btnMini.FlatAppearance.BorderSize = 0;
            this.btnMini.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnMini.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnMini.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnMini.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMini.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMini.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(72)))), ((int)(((byte)(146)))));
            this.btnMini.Image = ((System.Drawing.Image)(resources.GetObject("btnMini.Image")));
            this.btnMini.Location = new System.Drawing.Point(1299, 3);
            this.btnMini.Name = "btnMini";
            this.btnMini.Size = new System.Drawing.Size(29, 22);
            this.btnMini.TabIndex = 210;
            this.btnMini.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMini.UseVisualStyleBackColor = false;
            this.btnMini.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // gbPrintingParameter
            // 
            this.gbPrintingParameter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbPrintingParameter.Controls.Add(this.txtTrayNo);
            this.gbPrintingParameter.Controls.Add(this.label4);
            this.gbPrintingParameter.Controls.Add(this.lblScannerStatus);
            this.gbPrintingParameter.Controls.Add(this.label6);
            this.gbPrintingParameter.Controls.Add(this.panel2);
            this.gbPrintingParameter.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.gbPrintingParameter.ForeColor = System.Drawing.Color.MidnightBlue;
            this.gbPrintingParameter.Location = new System.Drawing.Point(3, 3);
            this.gbPrintingParameter.Name = "gbPrintingParameter";
            this.gbPrintingParameter.Size = new System.Drawing.Size(1330, 114);
            this.gbPrintingParameter.TabIndex = 193;
            this.gbPrintingParameter.TabStop = false;
            this.gbPrintingParameter.Enter += new System.EventHandler(this.gbPrintingParameter_Enter);
            // 
            // txtTrayNo
            // 
            this.txtTrayNo.BackColor = System.Drawing.Color.White;
            this.txtTrayNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTrayNo.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTrayNo.Location = new System.Drawing.Point(142, 30);
            this.txtTrayNo.Name = "txtTrayNo";
            this.txtTrayNo.Size = new System.Drawing.Size(474, 33);
            this.txtTrayNo.TabIndex = 270;
            this.txtTrayNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTrayNo_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(22, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 26);
            this.label4.TabIndex = 271;
            this.label4.Text = "Scan Tray *:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblScannerStatus
            // 
            this.lblScannerStatus.BackColor = System.Drawing.Color.Red;
            this.lblScannerStatus.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScannerStatus.Location = new System.Drawing.Point(142, 77);
            this.lblScannerStatus.Name = "lblScannerStatus";
            this.lblScannerStatus.Size = new System.Drawing.Size(149, 30);
            this.lblScannerStatus.TabIndex = 269;
            this.lblScannerStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblScannerStatus.Visible = false;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(16, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 30);
            this.label6.TabIndex = 268;
            this.label6.Text = "Scanner Status:";
            this.label6.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnStart);
            this.panel2.Controls.Add(this.btnBack);
            this.panel2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.panel2.Location = new System.Drawing.Point(715, 17);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(241, 63);
            this.panel2.TabIndex = 195;
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.Transparent;
            this.btnStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStart.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.btnStart.FlatAppearance.BorderSize = 0;
            this.btnStart.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnStart.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnStart.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnStart.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(72)))), ((int)(((byte)(146)))));
            this.btnStart.Image = global::DENSO_VCT_APP.Properties.Resources.iconfinder_16_web_essential_3401834;
            this.btnStart.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnStart.Location = new System.Drawing.Point(14, 5);
            this.btnStart.Margin = new System.Windows.Forms.Padding(5);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(66, 47);
            this.btnStart.TabIndex = 10;
            this.btnStart.Text = "Start";
            this.btnStart.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Visible = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblHeader
            // 
            this.lblHeader.BackColor = System.Drawing.Color.Transparent;
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHeader.Font = new System.Drawing.Font("Cambria", 24F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.AliceBlue;
            this.lblHeader.Location = new System.Drawing.Point(0, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(1346, 41);
            this.lblHeader.TabIndex = 212;
            this.lblHeader.Text = "TRAY ASSEMBLY SCANNING";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnMinimize
            // 
            this.btnMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimize.BackColor = System.Drawing.Color.Transparent;
            this.btnMinimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinimize.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnMinimize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnMinimize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMinimize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(72)))), ((int)(((byte)(146)))));
            this.btnMinimize.Location = new System.Drawing.Point(1308, -72);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(28, 32);
            this.btnMinimize.TabIndex = 211;
            this.btnMinimize.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMinimize.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblMsg);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.gbPrintingParameter);
            this.panel1.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.panel1.Location = new System.Drawing.Point(4, 42);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1338, 709);
            this.panel1.TabIndex = 213;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // lblMsg
            // 
            this.lblMsg.BackColor = System.Drawing.Color.Ivory;
            this.lblMsg.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblMsg.Font = new System.Drawing.Font("Cambria", 24.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsg.ForeColor = System.Drawing.Color.Black;
            this.lblMsg.Location = new System.Drawing.Point(0, 642);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(1336, 65);
            this.lblMsg.TabIndex = 267;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.dgv);
            this.panel3.Location = new System.Drawing.Point(3, 123);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1330, 516);
            this.panel3.TabIndex = 194;
            // 
            // dgv
            // 
            this.dgv.AllowDrop = true;
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToOrderColumns = true;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TrayBarcode,
            this.StartTime,
            this.EndTime});
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.EnableHeadersVisualStyles = false;
            this.dgv.GridColor = System.Drawing.SystemColors.ControlText;
            this.dgv.Location = new System.Drawing.Point(0, 0);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            this.dgv.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.dgv.RowTemplate.Height = 45;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(1330, 516);
            this.dgv.StandardTab = true;
            this.dgv.TabIndex = 266;
            // 
            // TrayBarcode
            // 
            this.TrayBarcode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.TrayBarcode.DataPropertyName = "TrayBarcode";
            this.TrayBarcode.Frozen = true;
            this.TrayBarcode.HeaderText = "TRAY BARCODE";
            this.TrayBarcode.Name = "TrayBarcode";
            this.TrayBarcode.ReadOnly = true;
            this.TrayBarcode.Width = 300;
            // 
            // StartTime
            // 
            this.StartTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.StartTime.DataPropertyName = "StartTime";
            this.StartTime.HeaderText = "START TIME";
            this.StartTime.Name = "StartTime";
            this.StartTime.ReadOnly = true;
            this.StartTime.Width = 300;
            // 
            // EndTime
            // 
            this.EndTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.EndTime.DataPropertyName = "EndTime";
            this.EndTime.HeaderText = "END TIME";
            this.EndTime.Name = "EndTime";
            this.EndTime.ReadOnly = true;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(1288, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 214;
            this.label5.Text = "Minimize";
            // 
            // timerAllHardware
            // 
            this.timerAllHardware.Enabled = true;
            this.timerAllHardware.Tick += new System.EventHandler(this.timerAllHardware_Tick);
            // 
            // tmrCaseVerify
            // 
            this.tmrCaseVerify.Interval = 1;
            this.tmrCaseVerify.Tick += new System.EventHandler(this.tmrCaseVerify_Tick);
            // 
            // timerTcpClient
            // 
            this.timerTcpClient.Interval = 1;
            this.timerTcpClient.Tick += new System.EventHandler(this.timerTcpClient_Tick);
            // 
            // frmAssemblyScanning
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(58)))), ((int)(((byte)(86)))));
            this.ClientSize = new System.Drawing.Size(1346, 755);
            this.ControlBox = false;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnMini);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.btnMinimize);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAssemblyScanning";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmReprinting_Load);
            this.gbPrintingParameter.ResumeLayout(false);
            this.gbPrintingParameter.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnMini;
        private System.Windows.Forms.GroupBox gbPrintingParameter;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Label lblScannerStatus;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Timer timerAllHardware;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Timer tmrCaseVerify;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Timer timerTcpClient;
        private System.Windows.Forms.TextBox txtTrayNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrayBarcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndTime;
    }
}