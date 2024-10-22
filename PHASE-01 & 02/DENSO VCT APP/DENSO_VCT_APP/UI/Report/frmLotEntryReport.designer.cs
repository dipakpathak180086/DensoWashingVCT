namespace DENSO_VCT_APP
{
    partial class frmLotEntryReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLotEntryReport));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnMini = new System.Windows.Forms.Button();
            this.gbPrintingParameter = new System.Windows.Forms.GroupBox();
            this.lblChildName = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblModelName = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbLot = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblChildPart = new System.Windows.Forms.Label();
            this.lblModelNo = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dpFromDate = new System.Windows.Forms.DateTimePicker();
            this.dpToDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblHeader = new System.Windows.Forms.Label();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSerchByLot = new System.Windows.Forms.TextBox();
            this.gbPrintingParameter.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.Transparent;
            this.btnReset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReset.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.btnReset.FlatAppearance.BorderSize = 0;
            this.btnReset.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnReset.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnReset.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReset.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(72)))), ((int)(((byte)(146)))));
            this.btnReset.Image = ((System.Drawing.Image)(resources.GetObject("btnReset.Image")));
            this.btnReset.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnReset.Location = new System.Drawing.Point(178, 11);
            this.btnReset.Margin = new System.Windows.Forms.Padding(5);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(76, 47);
            this.btnReset.TabIndex = 4;
            this.btnReset.Text = "R&eset";
            this.btnReset.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(72)))), ((int)(((byte)(146)))));
            this.btnClose.Image = global::DENSO_VCT_APP.Properties.Resources.Delete;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnClose.Location = new System.Drawing.Point(265, 11);
            this.btnClose.Margin = new System.Windows.Forms.Padding(5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(76, 47);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "&Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
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
            this.btnMini.Location = new System.Drawing.Point(1157, 3);
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
            this.gbPrintingParameter.Controls.Add(this.txtSerchByLot);
            this.gbPrintingParameter.Controls.Add(this.label7);
            this.gbPrintingParameter.Controls.Add(this.lblChildName);
            this.gbPrintingParameter.Controls.Add(this.label10);
            this.gbPrintingParameter.Controls.Add(this.lblModelName);
            this.gbPrintingParameter.Controls.Add(this.label8);
            this.gbPrintingParameter.Controls.Add(this.cmbLot);
            this.gbPrintingParameter.Controls.Add(this.label6);
            this.gbPrintingParameter.Controls.Add(this.lblChildPart);
            this.gbPrintingParameter.Controls.Add(this.lblModelNo);
            this.gbPrintingParameter.Controls.Add(this.label4);
            this.gbPrintingParameter.Controls.Add(this.label2);
            this.gbPrintingParameter.Controls.Add(this.dpFromDate);
            this.gbPrintingParameter.Controls.Add(this.dpToDate);
            this.gbPrintingParameter.Controls.Add(this.label1);
            this.gbPrintingParameter.Controls.Add(this.label3);
            this.gbPrintingParameter.Controls.Add(this.panel2);
            this.gbPrintingParameter.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.gbPrintingParameter.ForeColor = System.Drawing.Color.MidnightBlue;
            this.gbPrintingParameter.Location = new System.Drawing.Point(3, 3);
            this.gbPrintingParameter.Name = "gbPrintingParameter";
            this.gbPrintingParameter.Size = new System.Drawing.Size(1184, 224);
            this.gbPrintingParameter.TabIndex = 0;
            this.gbPrintingParameter.TabStop = false;
            this.gbPrintingParameter.Text = "Report";
            // 
            // lblChildName
            // 
            this.lblChildName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblChildName.AutoSize = true;
            this.lblChildName.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblChildName.Location = new System.Drawing.Point(615, 64);
            this.lblChildName.Name = "lblChildName";
            this.lblChildName.Size = new System.Drawing.Size(216, 26);
            this.lblChildName.TabIndex = 215;
            this.lblChildName.Text = "XXXXXXXXXXXXXXXXX";
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold);
            this.label10.Location = new System.Drawing.Point(430, 64);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(179, 26);
            this.label10.TabIndex = 214;
            this.label10.Text = "Child Part Name. *:";
            // 
            // lblModelName
            // 
            this.lblModelName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblModelName.AutoSize = true;
            this.lblModelName.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblModelName.Location = new System.Drawing.Point(615, 25);
            this.lblModelName.Name = "lblModelName";
            this.lblModelName.Size = new System.Drawing.Size(216, 26);
            this.lblModelName.TabIndex = 213;
            this.lblModelName.Text = "XXXXXXXXXXXXXXXXX";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(463, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(146, 26);
            this.label8.TabIndex = 212;
            this.label8.Text = "Model Name *:";
            // 
            // cmbLot
            // 
            this.cmbLot.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmbLot.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold);
            this.cmbLot.FormattingEnabled = true;
            this.cmbLot.Location = new System.Drawing.Point(211, 143);
            this.cmbLot.Name = "cmbLot";
            this.cmbLot.Size = new System.Drawing.Size(211, 34);
            this.cmbLot.TabIndex = 211;
            this.cmbLot.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbLot_KeyPress);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(68, 146);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(136, 26);
            this.label6.TabIndex = 210;
            this.label6.Text = "Lot Number *:";
            // 
            // lblChildPart
            // 
            this.lblChildPart.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblChildPart.AutoSize = true;
            this.lblChildPart.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblChildPart.Location = new System.Drawing.Point(206, 64);
            this.lblChildPart.Name = "lblChildPart";
            this.lblChildPart.Size = new System.Drawing.Size(216, 26);
            this.lblChildPart.TabIndex = 209;
            this.lblChildPart.Text = "XXXXXXXXXXXXXXXXX";
            this.lblChildPart.Click += new System.EventHandler(this.lblChildPart_Click);
            // 
            // lblModelNo
            // 
            this.lblModelNo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblModelNo.AutoSize = true;
            this.lblModelNo.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblModelNo.Location = new System.Drawing.Point(206, 25);
            this.lblModelNo.Name = "lblModelNo";
            this.lblModelNo.Size = new System.Drawing.Size(216, 26);
            this.lblModelNo.TabIndex = 208;
            this.lblModelNo.Text = "XXXXXXXXXXXXXXXXX";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(8, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(196, 26);
            this.label4.TabIndex = 207;
            this.label4.Text = "Child Part Number. *:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(39, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(165, 26);
            this.label2.TabIndex = 206;
            this.label2.Text = "Model Number *:";
            // 
            // dpFromDate
            // 
            this.dpFromDate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dpFromDate.CustomFormat = "dd-MM-yyyy";
            this.dpFromDate.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold);
            this.dpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpFromDate.Location = new System.Drawing.Point(211, 101);
            this.dpFromDate.Name = "dpFromDate";
            this.dpFromDate.Size = new System.Drawing.Size(211, 33);
            this.dpFromDate.TabIndex = 0;
            this.dpFromDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dpFromDate_KeyPress);
            // 
            // dpToDate
            // 
            this.dpToDate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dpToDate.CustomFormat = "dd-MM-yyyy";
            this.dpToDate.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold);
            this.dpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpToDate.Location = new System.Drawing.Point(615, 101);
            this.dpToDate.Name = "dpToDate";
            this.dpToDate.Size = new System.Drawing.Size(210, 33);
            this.dpToDate.TabIndex = 1;
            this.dpToDate.CloseUp += new System.EventHandler(this.dpToDate_CloseUp);
            this.dpToDate.ValueChanged += new System.EventHandler(this.dpToDate_ValueChanged);
            this.dpToDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dpToDate_KeyPress);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(511, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 26);
            this.label1.TabIndex = 205;
            this.label1.Text = "To Date *:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(80, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 26);
            this.label3.TabIndex = 205;
            this.label3.Text = "From Date *:";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.btnExport);
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Controls.Add(this.btnSearch);
            this.panel2.Controls.Add(this.btnReset);
            this.panel2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.panel2.Location = new System.Drawing.Point(836, 101);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(348, 70);
            this.panel2.TabIndex = 195;
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.Transparent;
            this.btnExport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExport.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.btnExport.FlatAppearance.BorderSize = 0;
            this.btnExport.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnExport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnExport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExport.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnExport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(72)))), ((int)(((byte)(146)))));
            this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
            this.btnExport.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnExport.Location = new System.Drawing.Point(91, 11);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(76, 47);
            this.btnExport.TabIndex = 1;
            this.btnExport.Text = "&Download";
            this.btnExport.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Transparent;
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSearch.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(72)))), ((int)(((byte)(146)))));
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSearch.Location = new System.Drawing.Point(4, 11);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(76, 47);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "&Search";
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblHeader
            // 
            this.lblHeader.BackColor = System.Drawing.Color.Transparent;
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHeader.Font = new System.Drawing.Font("Cambria", 24F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.AliceBlue;
            this.lblHeader.Location = new System.Drawing.Point(0, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(1204, 35);
            this.lblHeader.TabIndex = 212;
            this.lblHeader.Text = "REPORT";
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
            this.btnMinimize.Location = new System.Drawing.Point(1166, -72);
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
            this.panel1.Controls.Add(this.gbPrintingParameter);
            this.panel1.Controls.Add(this.dgv);
            this.panel1.Location = new System.Drawing.Point(4, 42);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1196, 514);
            this.panel1.TabIndex = 213;
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeRows = false;
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dgv.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Garamond", 12.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.dgv.EnableHeadersVisualStyles = false;
            this.dgv.GridColor = System.Drawing.Color.AliceBlue;
            this.dgv.Location = new System.Drawing.Point(5, 233);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersVisible = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            this.dgv.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(1194, 272);
            this.dgv.StandardTab = true;
            this.dgv.TabIndex = 194;
            this.dgv.TabStop = false;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(1146, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 214;
            this.label5.Text = "Minimize";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(6, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(109, 38);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 262;
            this.pictureBox1.TabStop = false;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(336, 192);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(216, 26);
            this.label7.TabIndex = 216;
            this.label7.Text = "Search By Lot Number :";
            // 
            // txtSerchByLot
            // 
            this.txtSerchByLot.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtSerchByLot.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSerchByLot.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold);
            this.txtSerchByLot.Location = new System.Drawing.Point(558, 189);
            this.txtSerchByLot.Name = "txtSerchByLot";
            this.txtSerchByLot.Size = new System.Drawing.Size(290, 33);
            this.txtSerchByLot.TabIndex = 217;
            this.txtSerchByLot.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSerchByLot_KeyDown);
            // 
            // frmLotEntryReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(58)))), ((int)(((byte)(86)))));
            this.ClientSize = new System.Drawing.Size(1204, 560);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnMini);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.btnMinimize);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmLotEntryReport";
            this.Text = "Spooling Report";
            this.Load += new System.EventHandler(this.frmReprinting_Load);
            this.gbPrintingParameter.ResumeLayout(false);
            this.gbPrintingParameter.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnMini;
        private System.Windows.Forms.GroupBox gbPrintingParameter;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.DateTimePicker dpToDate;
        private System.Windows.Forms.DateTimePicker dpFromDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Label lblChildPart;
        private System.Windows.Forms.Label lblModelNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbLot;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblModelName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblChildName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtSerchByLot;
    }
}