namespace DENSO_VCT_APP
{
    partial class frmMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenu));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlMaster = new System.Windows.Forms.Panel();
            this.btnNGMaster = new System.Windows.Forms.Button();
            this.btnAddModel = new System.Windows.Forms.Button();
            this.btnManagePassword = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnAddLotEntry = new System.Windows.Forms.Button();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnMini = new System.Windows.Forms.Button();
            this.picMasterConfig = new System.Windows.Forms.PictureBox();
            this.picLogOut = new System.Windows.Forms.PictureBox();
            this.btnStationMaster = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.pnlMaster.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMasterConfig)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogOut)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pnlMaster);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.lblWelcome);
            this.panel1.Location = new System.Drawing.Point(8, 56);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1077, 691);
            this.panel1.TabIndex = 8;
            // 
            // pnlMaster
            // 
            this.pnlMaster.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlMaster.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMaster.Controls.Add(this.btnStationMaster);
            this.pnlMaster.Controls.Add(this.btnNGMaster);
            this.pnlMaster.Controls.Add(this.btnAddModel);
            this.pnlMaster.Controls.Add(this.btnManagePassword);
            this.pnlMaster.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlMaster.Location = new System.Drawing.Point(681, 3);
            this.pnlMaster.Name = "pnlMaster";
            this.pnlMaster.Size = new System.Drawing.Size(386, 645);
            this.pnlMaster.TabIndex = 141;
            this.pnlMaster.Visible = false;
            // 
            // btnNGMaster
            // 
            this.btnNGMaster.Location = new System.Drawing.Point(25, 344);
            this.btnNGMaster.Name = "btnNGMaster";
            this.btnNGMaster.Size = new System.Drawing.Size(338, 66);
            this.btnNGMaster.TabIndex = 3;
            this.btnNGMaster.Text = "Add NG Lot";
            this.btnNGMaster.UseVisualStyleBackColor = true;
            this.btnNGMaster.Click += new System.EventHandler(this.btnNGMaster_Click);
            // 
            // btnAddModel
            // 
            this.btnAddModel.Location = new System.Drawing.Point(25, 16);
            this.btnAddModel.Name = "btnAddModel";
            this.btnAddModel.Size = new System.Drawing.Size(338, 66);
            this.btnAddModel.TabIndex = 0;
            this.btnAddModel.Text = "Add Model";
            this.btnAddModel.UseVisualStyleBackColor = true;
            this.btnAddModel.Click += new System.EventHandler(this.btnAddModel_Click);
            // 
            // btnManagePassword
            // 
            this.btnManagePassword.Location = new System.Drawing.Point(25, 416);
            this.btnManagePassword.Name = "btnManagePassword";
            this.btnManagePassword.Size = new System.Drawing.Size(338, 66);
            this.btnManagePassword.TabIndex = 2;
            this.btnManagePassword.Text = "Admin \r\n(Manage password)\r\n";
            this.btnManagePassword.UseVisualStyleBackColor = true;
            this.btnManagePassword.Click += new System.EventHandler(this.btnManagePassword_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnAddLotEntry);
            this.panel2.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(38, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(386, 645);
            this.panel2.TabIndex = 140;
            // 
            // btnAddLotEntry
            // 
            this.btnAddLotEntry.Location = new System.Drawing.Point(23, 19);
            this.btnAddLotEntry.Name = "btnAddLotEntry";
            this.btnAddLotEntry.Size = new System.Drawing.Size(338, 79);
            this.btnAddLotEntry.TabIndex = 1;
            this.btnAddLotEntry.Text = "Add Lot Entry";
            this.btnAddLotEntry.UseVisualStyleBackColor = true;
            this.btnAddLotEntry.Click += new System.EventHandler(this.btnAddLotEntry_Click);
            // 
            // lblWelcome
            // 
            this.lblWelcome.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblWelcome.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.ForeColor = System.Drawing.Color.Purple;
            this.lblWelcome.Location = new System.Drawing.Point(0, 671);
            this.lblWelcome.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(1075, 18);
            this.lblWelcome.TabIndex = 139;
            this.lblWelcome.Text = "test";
            this.lblWelcome.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(58)))), ((int)(((byte)(86)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Cambria", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.AliceBlue;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1093, 51);
            this.label1.TabIndex = 180;
            this.label1.Text = "LOT ENTRY APPLICATION";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(877, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Master Config";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(966, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 182;
            this.label3.Text = "Minimize";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(1052, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 183;
            this.label4.Text = "Stop";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(7, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(115, 46);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 262;
            this.pictureBox1.TabStop = false;
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
            this.btnMini.Location = new System.Drawing.Point(970, 7);
            this.btnMini.Name = "btnMini";
            this.btnMini.Size = new System.Drawing.Size(39, 33);
            this.btnMini.TabIndex = 181;
            this.btnMini.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMini.UseVisualStyleBackColor = false;
            this.btnMini.Click += new System.EventHandler(this.btnMini_Click);
            // 
            // picMasterConfig
            // 
            this.picMasterConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picMasterConfig.Image = global::DENSO_VCT_APP.Properties.Resources.iconfinder_AB_testing_3380369;
            this.picMasterConfig.Location = new System.Drawing.Point(891, 7);
            this.picMasterConfig.Name = "picMasterConfig";
            this.picMasterConfig.Size = new System.Drawing.Size(39, 33);
            this.picMasterConfig.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMasterConfig.TabIndex = 18;
            this.picMasterConfig.TabStop = false;
            this.picMasterConfig.Click += new System.EventHandler(this.picMasterConfig_Click);
            // 
            // picLogOut
            // 
            this.picLogOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picLogOut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picLogOut.Image = ((System.Drawing.Image)(resources.GetObject("picLogOut.Image")));
            this.picLogOut.Location = new System.Drawing.Point(1049, 7);
            this.picLogOut.Name = "picLogOut";
            this.picLogOut.Size = new System.Drawing.Size(39, 33);
            this.picLogOut.TabIndex = 16;
            this.picLogOut.TabStop = false;
            this.picLogOut.Click += new System.EventHandler(this.picLogOut_Click);
            // 
            // btnStationMaster
            // 
            this.btnStationMaster.Location = new System.Drawing.Point(25, 88);
            this.btnStationMaster.Name = "btnStationMaster";
            this.btnStationMaster.Size = new System.Drawing.Size(338, 66);
            this.btnStationMaster.TabIndex = 4;
            this.btnStationMaster.Text = "Station Master";
            this.btnStationMaster.UseVisualStyleBackColor = true;
            this.btnStationMaster.Click += new System.EventHandler(this.btnConveyorMaster_Click);
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(58)))), ((int)(((byte)(86)))));
            this.ClientSize = new System.Drawing.Size(1093, 752);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnMini);
            this.Controls.Add(this.picMasterConfig);
            this.Controls.Add(this.picLogOut);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Calibri", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MAIN MENU";
            this.Load += new System.EventHandler(this.frmModelMaster_Load);
            this.panel1.ResumeLayout(false);
            this.pnlMaster.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMasterConfig)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogOut)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.PictureBox picLogOut;
        private System.Windows.Forms.PictureBox picMasterConfig;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnMini;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnAddLotEntry;
        private System.Windows.Forms.Button btnAddModel;
        private System.Windows.Forms.Button btnManagePassword;
        private System.Windows.Forms.Panel pnlMaster;
        private System.Windows.Forms.Button btnNGMaster;
        private System.Windows.Forms.Button btnStationMaster;
    }
}