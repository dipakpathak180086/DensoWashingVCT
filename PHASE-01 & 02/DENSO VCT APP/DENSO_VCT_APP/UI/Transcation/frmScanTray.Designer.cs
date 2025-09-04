namespace DENSO_VCT_APP
{
    partial class frmScanTray
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmScanTray));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblScanStatus = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.btnTrayAuto = new System.Windows.Forms.PictureBox();
            this.btnTrayManual = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnTrayClose = new System.Windows.Forms.PictureBox();
            this.label17 = new System.Windows.Forms.Label();
            this.btnTrayUnmapped = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtScanTray = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTrayMessage = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblModelNo = new System.Windows.Forms.Label();
            this.lblChildPartNo = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblTotalQty = new System.Windows.Forms.Label();
            this.lblScanQty = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblTrayScanTotalQty = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.dgvTray = new System.Windows.Forms.DataGridView();
            this.chkSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.TRAYS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SCANNEDON = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serialTrayPort1 = new System.IO.Ports.SerialPort(this.components);
            this.lblScannedBarcode = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnTrayAuto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnTrayManual)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnTrayClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnTrayUnmapped)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTray)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblScanStatus);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.btnTrayAuto);
            this.panel1.Controls.Add(this.btnTrayManual);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btnTrayClose);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.btnTrayUnmapped);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1348, 52);
            this.panel1.TabIndex = 0;
            // 
            // lblScanStatus
            // 
            this.lblScanStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblScanStatus.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScanStatus.Location = new System.Drawing.Point(127, 12);
            this.lblScanStatus.Name = "lblScanStatus";
            this.lblScanStatus.Size = new System.Drawing.Size(267, 28);
            this.lblScanStatus.TabIndex = 268;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(1052, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 15);
            this.label5.TabIndex = 267;
            this.label5.Text = "Auto";
            // 
            // label16
            // 
            this.label16.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold);
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(988, 32);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(52, 15);
            this.label16.TabIndex = 266;
            this.label16.Text = "Manual";
            // 
            // btnTrayAuto
            // 
            this.btnTrayAuto.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnTrayAuto.BackColor = System.Drawing.Color.Transparent;
            this.btnTrayAuto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.btnTrayAuto.Location = new System.Drawing.Point(1055, 7);
            this.btnTrayAuto.Name = "btnTrayAuto";
            this.btnTrayAuto.Size = new System.Drawing.Size(26, 25);
            this.btnTrayAuto.TabIndex = 265;
            this.btnTrayAuto.TabStop = false;
            this.btnTrayAuto.Click += new System.EventHandler(this.btnTrayAuto_Click);
            // 
            // btnTrayManual
            // 
            this.btnTrayManual.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnTrayManual.BackColor = System.Drawing.Color.Transparent;
            this.btnTrayManual.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.btnTrayManual.Location = new System.Drawing.Point(1001, 7);
            this.btnTrayManual.Name = "btnTrayManual";
            this.btnTrayManual.Size = new System.Drawing.Size(26, 25);
            this.btnTrayManual.TabIndex = 264;
            this.btnTrayManual.TabStop = false;
            this.btnTrayManual.Click += new System.EventHandler(this.btnTrayManual_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(3, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(109, 44);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 263;
            this.pictureBox2.TabStop = false;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(1302, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 15);
            this.label3.TabIndex = 241;
            this.label3.Text = "Close";
            // 
            // btnTrayClose
            // 
            this.btnTrayClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTrayClose.BackColor = System.Drawing.Color.White;
            this.btnTrayClose.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnTrayClose.Image = ((System.Drawing.Image)(resources.GetObject("btnTrayClose.Image")));
            this.btnTrayClose.Location = new System.Drawing.Point(1302, 1);
            this.btnTrayClose.Name = "btnTrayClose";
            this.btnTrayClose.Size = new System.Drawing.Size(38, 32);
            this.btnTrayClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnTrayClose.TabIndex = 224;
            this.btnTrayClose.TabStop = false;
            this.btnTrayClose.Click += new System.EventHandler(this.btnTrayClose_Click);
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold);
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(1221, 34);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(77, 15);
            this.label17.TabIndex = 240;
            this.label17.Text = "Un-Mapped";
            // 
            // btnTrayUnmapped
            // 
            this.btnTrayUnmapped.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTrayUnmapped.BackColor = System.Drawing.Color.White;
            this.btnTrayUnmapped.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnTrayUnmapped.Image = ((System.Drawing.Image)(resources.GetObject("btnTrayUnmapped.Image")));
            this.btnTrayUnmapped.Location = new System.Drawing.Point(1236, 1);
            this.btnTrayUnmapped.Name = "btnTrayUnmapped";
            this.btnTrayUnmapped.Size = new System.Drawing.Size(38, 32);
            this.btnTrayUnmapped.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnTrayUnmapped.TabIndex = 228;
            this.btnTrayUnmapped.TabStop = false;
            this.btnTrayUnmapped.Click += new System.EventHandler(this.btnTrayUnmapped_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(58)))), ((int)(((byte)(86)))));
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Cambria", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1346, 52);
            this.label2.TabIndex = 217;
            this.label2.Text = "SCAN TRAY";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtScanTray
            // 
            this.txtScanTray.BackColor = System.Drawing.Color.White;
            this.txtScanTray.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtScanTray.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtScanTray.Font = new System.Drawing.Font("Calibri", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtScanTray.Location = new System.Drawing.Point(262, 59);
            this.txtScanTray.Name = "txtScanTray";
            this.txtScanTray.ReadOnly = true;
            this.txtScanTray.Size = new System.Drawing.Size(400, 53);
            this.txtScanTray.TabIndex = 216;
            this.txtScanTray.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtScanTray_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Calibri", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(4, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(191, 47);
            this.label4.TabIndex = 217;
            this.label4.Text = "Scan Tray*:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblTrayMessage
            // 
            this.lblTrayMessage.BackColor = System.Drawing.Color.Transparent;
            this.lblTrayMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTrayMessage.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblTrayMessage.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrayMessage.ForeColor = System.Drawing.Color.White;
            this.lblTrayMessage.Location = new System.Drawing.Point(0, 674);
            this.lblTrayMessage.Name = "lblTrayMessage";
            this.lblTrayMessage.Size = new System.Drawing.Size(1348, 76);
            this.lblTrayMessage.TabIndex = 227;
            this.lblTrayMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTrayMessage.Click += new System.EventHandler(this.lblTrayMessage_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Calibri", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 47);
            this.label1.TabIndex = 230;
            this.label1.Text = "Model No. :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblModelNo
            // 
            this.lblModelNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblModelNo.Font = new System.Drawing.Font("Calibri", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModelNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblModelNo.Location = new System.Drawing.Point(262, 3);
            this.lblModelNo.Name = "lblModelNo";
            this.lblModelNo.Size = new System.Drawing.Size(400, 53);
            this.lblModelNo.TabIndex = 231;
            this.lblModelNo.Text = "XXXXXXXXXXXXX";
            // 
            // lblChildPartNo
            // 
            this.lblChildPartNo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblChildPartNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblChildPartNo.Font = new System.Drawing.Font("Calibri", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChildPartNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblChildPartNo.Location = new System.Drawing.Point(925, 3);
            this.lblChildPartNo.Name = "lblChildPartNo";
            this.lblChildPartNo.Size = new System.Drawing.Size(411, 48);
            this.lblChildPartNo.TabIndex = 233;
            this.lblChildPartNo.Text = "XXXXXXXXXXXXX";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Font = new System.Drawing.Font("Calibri", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label9.Location = new System.Drawing.Point(668, 3);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(251, 47);
            this.label9.TabIndex = 232;
            this.label9.Text = "Child Part No. :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.Font = new System.Drawing.Font("Calibri", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label10.Location = new System.Drawing.Point(668, 59);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(179, 47);
            this.label10.TabIndex = 234;
            this.label10.Text = "Total Qty :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblTotalQty
            // 
            this.lblTotalQty.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalQty.Font = new System.Drawing.Font("Calibri", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalQty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTotalQty.Location = new System.Drawing.Point(925, 57);
            this.lblTotalQty.Name = "lblTotalQty";
            this.lblTotalQty.Size = new System.Drawing.Size(411, 48);
            this.lblTotalQty.TabIndex = 235;
            this.lblTotalQty.Text = "XXXXXXXXXXXXX";
            // 
            // lblScanQty
            // 
            this.lblScanQty.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblScanQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblScanQty.Font = new System.Drawing.Font("Calibri", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScanQty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblScanQty.Location = new System.Drawing.Point(925, 111);
            this.lblScanQty.Name = "lblScanQty";
            this.lblScanQty.Size = new System.Drawing.Size(411, 48);
            this.lblScanQty.TabIndex = 237;
            this.lblScanQty.Text = "XXXXXXXXXXXXX";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label13.Font = new System.Drawing.Font("Calibri", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label13.Location = new System.Drawing.Point(670, 115);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(229, 47);
            this.label13.TabIndex = 236;
            this.label13.Text = "Washed Qty :";
            this.label13.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblTrayScanTotalQty
            // 
            this.lblTrayScanTotalQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTrayScanTotalQty.Font = new System.Drawing.Font("Calibri", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrayScanTotalQty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTrayScanTotalQty.Location = new System.Drawing.Point(262, 115);
            this.lblTrayScanTotalQty.Name = "lblTrayScanTotalQty";
            this.lblTrayScanTotalQty.Size = new System.Drawing.Size(402, 48);
            this.lblTrayScanTotalQty.TabIndex = 240;
            this.lblTrayScanTotalQty.Text = "XXXXXXXXXXXXX";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label14.Font = new System.Drawing.Font("Calibri", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label14.Location = new System.Drawing.Point(4, 115);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(252, 47);
            this.label14.TabIndex = 239;
            this.label14.Text = "T.Washed Qty :";
            this.label14.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dgvTray
            // 
            this.dgvTray.AllowUserToAddRows = false;
            this.dgvTray.AllowUserToDeleteRows = false;
            this.dgvTray.AllowUserToResizeRows = false;
            this.dgvTray.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTray.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dgvTray.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(58)))), ((int)(((byte)(86)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTray.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTray.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTray.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chkSelect,
            this.TRAYS,
            this.Qty,
            this.SCANNEDON});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTray.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvTray.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTray.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.dgvTray.EnableHeadersVisualStyles = false;
            this.dgvTray.GridColor = System.Drawing.SystemColors.ControlText;
            this.dgvTray.Location = new System.Drawing.Point(395, 3);
            this.dgvTray.MultiSelect = false;
            this.dgvTray.Name = "dgvTray";
            this.dgvTray.RowHeadersVisible = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Cambria", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            this.dgvTray.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvTray.RowTemplate.Height = 45;
            this.dgvTray.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTray.Size = new System.Drawing.Size(982, 468);
            this.dgvTray.StandardTab = true;
            this.dgvTray.TabIndex = 238;
            this.dgvTray.TabStop = false;
            this.dgvTray.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTray_CellContentClick);
            this.dgvTray.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTray_CellValueChanged);
            // 
            // chkSelect
            // 
            this.chkSelect.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Cambria", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.NullValue = false;
            this.chkSelect.DefaultCellStyle = dataGridViewCellStyle2;
            this.chkSelect.FalseValue = "False";
            this.chkSelect.HeaderText = "SELECT";
            this.chkSelect.IndeterminateValue = "False";
            this.chkSelect.MinimumWidth = 100;
            this.chkSelect.Name = "chkSelect";
            this.chkSelect.TrueValue = "True";
            // 
            // TRAYS
            // 
            this.TRAYS.DataPropertyName = "TRAYS";
            this.TRAYS.HeaderText = "TRAYS ID";
            this.TRAYS.MinimumWidth = 150;
            this.TRAYS.Name = "TRAYS";
            // 
            // Qty
            // 
            this.Qty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Qty.DataPropertyName = "Qty";
            this.Qty.HeaderText = "QTY";
            this.Qty.MinimumWidth = 80;
            this.Qty.Name = "Qty";
            this.Qty.Width = 80;
            // 
            // SCANNEDON
            // 
            this.SCANNEDON.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SCANNEDON.DataPropertyName = "SCANNEDON";
            this.SCANNEDON.HeaderText = "WASHING DATE TIME";
            this.SCANNEDON.Name = "SCANNEDON";
            // 
            // serialTrayPort1
            // 
            this.serialTrayPort1.ReceivedBytesThreshold = 2;
            this.serialTrayPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialTrayPort1_DataReceived);
            // 
            // lblScannedBarcode
            // 
            this.lblScannedBarcode.AutoSize = true;
            this.lblScannedBarcode.Font = new System.Drawing.Font("Calibri", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScannedBarcode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblScannedBarcode.Location = new System.Drawing.Point(37, 608);
            this.lblScannedBarcode.Name = "lblScannedBarcode";
            this.lblScannedBarcode.Size = new System.Drawing.Size(0, 45);
            this.lblScannedBarcode.TabIndex = 242;
            this.lblScannedBarcode.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblScannedBarcode.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(386, 468);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 241;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.txtScanTray);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.lblTrayScanTotalQty);
            this.panel2.Controls.Add(this.lblModelNo);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.lblChildPartNo);
            this.panel2.Controls.Add(this.lblScanQty);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.lblTotalQty);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 52);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1348, 171);
            this.panel2.TabIndex = 243;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.4585F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 71.5415F));
            this.tableLayoutPanel1.Controls.Add(this.dgvTray, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 229);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1380, 474);
            this.tableLayoutPanel1.TabIndex = 244;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // frmScanTray
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1348, 750);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lblScannedBarcode);
            this.Controls.Add(this.lblTrayMessage);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmScanTray";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmScanTray_FormClosing);
            this.Load += new System.EventHandler(this.frmScanTray_Load);
            this.Shown += new System.EventHandler(this.frmScanTray_Shown);
            this.GiveFeedback += new System.Windows.Forms.GiveFeedbackEventHandler(this.frmScanTray_GiveFeedback);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnTrayAuto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnTrayManual)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnTrayClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnTrayUnmapped)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTray)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox btnTrayClose;
        private System.Windows.Forms.Label lblTrayMessage;
        private System.Windows.Forms.PictureBox btnTrayUnmapped;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblModelNo;
        private System.Windows.Forms.Label lblChildPartNo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblTotalQty;
        private System.Windows.Forms.Label lblScanQty;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblTrayScanTotalQty;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dgvTray;
        private System.IO.Ports.SerialPort serialTrayPort1;
        public System.Windows.Forms.TextBox txtScanTray;
        public System.Windows.Forms.Label lblScannedBarcode;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chkSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn TRAYS;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn SCANNEDON;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.PictureBox btnTrayAuto;
        private System.Windows.Forms.PictureBox btnTrayManual;
        private System.Windows.Forms.Label lblScanStatus;
    }
}