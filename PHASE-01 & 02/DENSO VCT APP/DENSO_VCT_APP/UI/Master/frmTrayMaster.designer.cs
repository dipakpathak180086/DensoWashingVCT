﻿namespace DENSO_VCT_APP
{
    partial class frmTrayMaster
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTrayMaster));
            this.dgv = new System.Windows.Forms.DataGridView();
            this.TrayCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrayName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrayPackSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsBlock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Active = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreatedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreatedOn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblCount = new System.Windows.Forms.Label();
            this.lblHeader = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTrayName = new System.Windows.Forms.TextBox();
            this.txtTrayCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPackSize = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dgv.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TrayCode,
            this.TrayName,
            this.TrayPackSize,
            this.IsBlock,
            this.Active,
            this.CreatedBy,
            this.CreatedOn});
            this.dgv.EnableHeadersVisualStyles = false;
            this.dgv.GridColor = System.Drawing.Color.AliceBlue;
            this.dgv.Location = new System.Drawing.Point(5, 157);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.dgv.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(1075, 398);
            this.dgv.StandardTab = true;
            this.dgv.TabIndex = 187;
            this.dgv.TabStop = false;
            this.dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellDoubleClick);
            // 
            // TrayCode
            // 
            this.TrayCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.TrayCode.DataPropertyName = "TrayCode";
            this.TrayCode.HeaderText = "Tray Code";
            this.TrayCode.Name = "TrayCode";
            this.TrayCode.ReadOnly = true;
            this.TrayCode.Width = 140;
            // 
            // TrayName
            // 
            this.TrayName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.TrayName.DataPropertyName = "TrayName";
            this.TrayName.HeaderText = "Tray Name";
            this.TrayName.Name = "TrayName";
            this.TrayName.ReadOnly = true;
            this.TrayName.Width = 180;
            // 
            // TrayPackSize
            // 
            this.TrayPackSize.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.TrayPackSize.DataPropertyName = "TrayPackSize";
            this.TrayPackSize.HeaderText = "Pack Size";
            this.TrayPackSize.Name = "TrayPackSize";
            this.TrayPackSize.ReadOnly = true;
            this.TrayPackSize.Width = 190;
            // 
            // IsBlock
            // 
            this.IsBlock.DataPropertyName = "IsBlock";
            this.IsBlock.HeaderText = "Is Block";
            this.IsBlock.Name = "IsBlock";
            this.IsBlock.ReadOnly = true;
            // 
            // Active
            // 
            this.Active.DataPropertyName = "Active";
            this.Active.HeaderText = "Active";
            this.Active.Name = "Active";
            this.Active.ReadOnly = true;
            // 
            // CreatedBy
            // 
            this.CreatedBy.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CreatedBy.DataPropertyName = "CreatedBy";
            this.CreatedBy.HeaderText = "Created By";
            this.CreatedBy.Name = "CreatedBy";
            this.CreatedBy.ReadOnly = true;
            this.CreatedBy.Width = 150;
            // 
            // CreatedOn
            // 
            this.CreatedOn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CreatedOn.DataPropertyName = "CreatedOn";
            this.CreatedOn.HeaderText = "Created On";
            this.CreatedOn.Name = "CreatedOn";
            this.CreatedOn.ReadOnly = true;
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Font = new System.Drawing.Font("Calibri", 12F);
            this.lblCount.ForeColor = System.Drawing.Color.Maroon;
            this.lblCount.Location = new System.Drawing.Point(8, 125);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(106, 19);
            this.lblCount.TabIndex = 182;
            this.lblCount.Text = "Rows Count : 0";
            // 
            // lblHeader
            // 
            this.lblHeader.BackColor = System.Drawing.Color.Transparent;
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHeader.Font = new System.Drawing.Font("Cambria", 24F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.AliceBlue;
            this.lblHeader.Location = new System.Drawing.Point(0, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(1099, 41);
            this.lblHeader.TabIndex = 212;
            this.lblHeader.Text = "TRAY MASTER";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.dgv);
            this.panel1.Controls.Add(this.lblCount);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnReset);
            this.panel1.Controls.Add(this.btnExport);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.panel1.Location = new System.Drawing.Point(6, 43);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1093, 623);
            this.panel1.TabIndex = 213;
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold);
            this.txtSearch.Location = new System.Drawing.Point(284, 118);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(284, 33);
            this.txtSearch.TabIndex = 190;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label2.Location = new System.Drawing.Point(140, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 26);
            this.label2.TabIndex = 191;
            this.label2.Text = "Search By Tray:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtTrayName);
            this.groupBox1.Controls.Add(this.txtTrayCode);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.chkActive);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtPackSize);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.groupBox1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.groupBox1.Location = new System.Drawing.Point(5, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1056, 110);
            this.groupBox1.TabIndex = 193;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Enter Details:";
            // 
            // txtTrayName
            // 
            this.txtTrayName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtTrayName.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold);
            this.txtTrayName.Location = new System.Drawing.Point(661, 25);
            this.txtTrayName.MaxLength = 150;
            this.txtTrayName.Name = "txtTrayName";
            this.txtTrayName.Size = new System.Drawing.Size(346, 33);
            this.txtTrayName.TabIndex = 1;
            // 
            // txtTrayCode
            // 
            this.txtTrayCode.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtTrayCode.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold);
            this.txtTrayCode.Location = new System.Drawing.Point(121, 25);
            this.txtTrayCode.MaxLength = 150;
            this.txtTrayCode.Name = "txtTrayCode";
            this.txtTrayCode.Size = new System.Drawing.Size(382, 33);
            this.txtTrayCode.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(535, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 26);
            this.label1.TabIndex = 191;
            this.label1.Text = "Tray Name*:";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(569, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 26);
            this.label4.TabIndex = 188;
            this.label4.Text = "Status *:";
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold);
            this.chkActive.Location = new System.Drawing.Point(663, 67);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(86, 30);
            this.chkActive.TabIndex = 3;
            this.chkActive.Text = "Active";
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(8, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 26);
            this.label3.TabIndex = 187;
            this.label3.Text = "Pack Size.*:";
            // 
            // txtPackSize
            // 
            this.txtPackSize.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtPackSize.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold);
            this.txtPackSize.Location = new System.Drawing.Point(121, 64);
            this.txtPackSize.MaxLength = 150;
            this.txtPackSize.Name = "txtPackSize";
            this.txtPackSize.Size = new System.Drawing.Size(114, 33);
            this.txtPackSize.TabIndex = 2;
            this.txtPackSize.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPackSize_KeyPress);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(-5, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 26);
            this.label5.TabIndex = 185;
            this.label5.Text = "Tray Code.*:";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(72)))), ((int)(((byte)(146)))));
            this.btnClose.Image = global::DENSO_VCT_APP.Properties.Resources.Delete;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnClose.Location = new System.Drawing.Point(1019, 562);
            this.btnClose.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(66, 55);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "&Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(72)))), ((int)(((byte)(146)))));
            this.btnSave.Image = global::DENSO_VCT_APP.Properties.Resources.iconfinder_Save_1493294;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSave.Location = new System.Drawing.Point(889, 562);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(66, 55);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "&Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReset.BackColor = System.Drawing.Color.Transparent;
            this.btnReset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReset.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.btnReset.FlatAppearance.BorderSize = 0;
            this.btnReset.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnReset.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnReset.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(72)))), ((int)(((byte)(146)))));
            this.btnReset.Image = ((System.Drawing.Image)(resources.GetObject("btnReset.Image")));
            this.btnReset.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnReset.Location = new System.Drawing.Point(951, 562);
            this.btnReset.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(66, 55);
            this.btnReset.TabIndex = 1;
            this.btnReset.Text = "&Reset";
            this.btnReset.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.BackColor = System.Drawing.Color.Transparent;
            this.btnExport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExport.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.btnExport.FlatAppearance.BorderSize = 0;
            this.btnExport.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnExport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnExport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(72)))), ((int)(((byte)(146)))));
            this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
            this.btnExport.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnExport.Location = new System.Drawing.Point(936, 396);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(66, 55);
            this.btnExport.TabIndex = 9;
            this.btnExport.Text = "&Export";
            this.btnExport.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.BackColor = System.Drawing.Color.Transparent;
            this.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(72)))), ((int)(((byte)(146)))));
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDelete.Location = new System.Drawing.Point(868, 396);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(66, 55);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
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
            this.btnMinimize.Image = ((System.Drawing.Image)(resources.GetObject("btnMinimize.Image")));
            this.btnMinimize.Location = new System.Drawing.Point(1040, 5);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(28, 20);
            this.btnMinimize.TabIndex = 0;
            this.btnMinimize.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMinimize.UseVisualStyleBackColor = false;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(1030, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 13);
            this.label6.TabIndex = 214;
            this.label6.Text = "Minimize";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(6, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(85, 40);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 215;
            this.pictureBox1.TabStop = false;
            // 
            // frmTrayMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(58)))), ((int)(((byte)(86)))));
            this.ClientSize = new System.Drawing.Size(1099, 673);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnMinimize);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.Transparent;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmTrayMaster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tray Master";
            this.Load += new System.EventHandler(this.frmModelMaster_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnMinimize;
        public System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPackSize;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTrayName;
        private System.Windows.Forms.TextBox txtTrayCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrayCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrayName;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrayPackSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsBlock;
        private System.Windows.Forms.DataGridViewTextBoxColumn Active;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreatedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreatedOn;
    }
}