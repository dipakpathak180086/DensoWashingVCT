namespace DENSOScheduler
{
    partial class frmGetSet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGetSet));
            this.lblTitle = new System.Windows.Forms.Label();
            this.mnuShow = new System.Windows.Forms.MenuItem();
            this.ContextMenu1 = new System.Windows.Forms.ContextMenu();
            this.MenuItem1 = new System.Windows.Forms.MenuItem();
            this.mnuExit = new System.Windows.Forms.MenuItem();
            this.lblStatus = new System.Windows.Forms.Label();
            this.mnuExitApp = new System.Windows.Forms.MenuItem();
            this.MenuItem2 = new System.Windows.Forms.MenuItem();
            this.mnuHideWindow = new System.Windows.Forms.MenuItem();
            this.ContextMenu2 = new System.Windows.Forms.ContextMenu();
            this.TrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.Label5 = new System.Windows.Forms.Label();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.lblSqlStatus = new System.Windows.Forms.Label();
            this.Panel3 = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.Label3 = new System.Windows.Forms.Label();
            this.NotifyWindow = new VbPowerPack.NotificationWindow(this.components);
            this.cbFileName = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnManaul = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbStation = new System.Windows.Forms.ComboBox();
            this.Panel2.SuspendLayout();
            this.Panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.CornflowerBlue;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(514, 18);
            this.lblTitle.TabIndex = 56;
            this.lblTitle.Text = "SCHEDULER";
            // 
            // mnuShow
            // 
            this.mnuShow.Index = 0;
            this.mnuShow.Text = "Show";
            this.mnuShow.Click += new System.EventHandler(this.mnuShow_Click);
            // 
            // ContextMenu1
            // 
            this.ContextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuShow,
            this.MenuItem1,
            this.mnuExit});
            // 
            // MenuItem1
            // 
            this.MenuItem1.Index = 1;
            this.MenuItem1.Text = "-";
            // 
            // mnuExit
            // 
            this.mnuExit.Index = 2;
            this.mnuExit.Text = "Exit";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.BackColor = System.Drawing.Color.LightBlue;
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblStatus.Font = new System.Drawing.Font("Trebuchet MS", 9.75F);
            this.lblStatus.ForeColor = System.Drawing.Color.Red;
            this.lblStatus.Location = new System.Drawing.Point(0, 235);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(514, 18);
            this.lblStatus.TabIndex = 63;
            // 
            // mnuExitApp
            // 
            this.mnuExitApp.Index = 2;
            this.mnuExitApp.Text = "Exit";
            this.mnuExitApp.Click += new System.EventHandler(this.mnuExitApp_Click);
            // 
            // MenuItem2
            // 
            this.MenuItem2.Index = 1;
            this.MenuItem2.Text = "-";
            // 
            // mnuHideWindow
            // 
            this.mnuHideWindow.Index = 0;
            this.mnuHideWindow.Text = "Hide";
            this.mnuHideWindow.Click += new System.EventHandler(this.mnuHideWindow_Click);
            // 
            // ContextMenu2
            // 
            this.ContextMenu2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuHideWindow,
            this.MenuItem2,
            this.mnuExitApp});
            // 
            // TrayIcon
            // 
            this.TrayIcon.ContextMenu = this.ContextMenu1;
            this.TrayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("TrayIcon.Icon")));
            this.TrayIcon.Visible = true;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("Trebuchet MS", 9.75F);
            this.Label5.Location = new System.Drawing.Point(12, 94);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(193, 18);
            this.Label5.TabIndex = 58;
            this.Label5.Text = "C O N N E C T I O N  S T A T U S";
            // 
            // Panel2
            // 
            this.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel2.Controls.Add(this.lblSqlStatus);
            this.Panel2.Location = new System.Drawing.Point(3, 99);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(510, 40);
            this.Panel2.TabIndex = 57;
            // 
            // lblSqlStatus
            // 
            this.lblSqlStatus.BackColor = System.Drawing.Color.White;
            this.lblSqlStatus.Font = new System.Drawing.Font("Trebuchet MS", 9.75F);
            this.lblSqlStatus.Location = new System.Drawing.Point(8, 12);
            this.lblSqlStatus.Name = "lblSqlStatus";
            this.lblSqlStatus.Size = new System.Drawing.Size(490, 17);
            this.lblSqlStatus.TabIndex = 0;
            this.lblSqlStatus.Text = "S Q L  C O N N E C T I O N";
            this.lblSqlStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Panel3
            // 
            this.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel3.Controls.Add(this.btnExit);
            this.Panel3.Controls.Add(this.btnStop);
            this.Panel3.Controls.Add(this.btnStart);
            this.Panel3.Location = new System.Drawing.Point(3, 21);
            this.Panel3.Name = "Panel3";
            this.Panel3.Size = new System.Drawing.Size(510, 70);
            this.Panel3.TabIndex = 59;
            // 
            // btnExit
            // 
            this.btnExit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExit.BackgroundImage")));
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Location = new System.Drawing.Point(149, -1);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(78, 66);
            this.btnExit.TabIndex = 15;
            this.btnExit.Tag = "Exit";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnStop
            // 
            this.btnStop.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnStop.BackgroundImage")));
            this.btnStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnStop.FlatAppearance.BorderSize = 0;
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.Location = new System.Drawing.Point(77, -1);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(66, 66);
            this.btnStop.TabIndex = 14;
            this.btnStop.Tag = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnStart.BackgroundImage")));
            this.btnStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnStart.FlatAppearance.BorderSize = 0;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Location = new System.Drawing.Point(3, -1);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(68, 66);
            this.btnStart.TabIndex = 13;
            this.btnStart.Tag = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // Label3
            // 
            this.Label3.BackColor = System.Drawing.Color.CornflowerBlue;
            this.Label3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Label3.Font = new System.Drawing.Font("Trebuchet MS", 9.75F);
            this.Label3.ForeColor = System.Drawing.Color.White;
            this.Label3.Location = new System.Drawing.Point(0, 253);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(514, 18);
            this.Label3.TabIndex = 60;
            this.Label3.Text = "DEVELOPED BY SATO ARGOX INDIA PVT LTD.";
            // 
            // NotifyWindow
            // 
            this.NotifyWindow.Blend = new VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.SystemColors.InactiveCaption, System.Drawing.SystemColors.Window);
            this.NotifyWindow.DefaultText = null;
            this.NotifyWindow.DefaultTimeout = 3000;
            this.NotifyWindow.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NotifyWindow.ForeColor = System.Drawing.Color.AliceBlue;
            this.NotifyWindow.ShowStyle = VbPowerPack.NotificationShowStyle.Fade;
            // 
            // cbFileName
            // 
            this.cbFileName.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold);
            this.cbFileName.FormattingEnabled = true;
            this.cbFileName.Location = new System.Drawing.Point(303, 144);
            this.cbFileName.Name = "cbFileName";
            this.cbFileName.Size = new System.Drawing.Size(199, 26);
            this.cbFileName.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(228, 148);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 18);
            this.label1.TabIndex = 17;
            this.label1.Text = "File Name";
            // 
            // btnManaul
            // 
            this.btnManaul.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnManaul.Location = new System.Drawing.Point(9, 195);
            this.btnManaul.Name = "btnManaul";
            this.btnManaul.Size = new System.Drawing.Size(493, 27);
            this.btnManaul.TabIndex = 18;
            this.btnManaul.Text = "Manual";
            this.btnManaul.UseVisualStyleBackColor = true;
            this.btnManaul.Click += new System.EventHandler(this.btnManaul_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(6, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 18);
            this.label2.TabIndex = 65;
            this.label2.Text = "Station";
            // 
            // cbStation
            // 
            this.cbStation.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold);
            this.cbStation.FormattingEnabled = true;
            this.cbStation.Location = new System.Drawing.Point(58, 144);
            this.cbStation.Name = "cbStation";
            this.cbStation.Size = new System.Drawing.Size(168, 26);
            this.cbStation.TabIndex = 64;
            this.cbStation.SelectedIndexChanged += new System.EventHandler(this.cbStation_SelectedIndexChanged);
            // 
            // frmGetSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(514, 271);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbStation);
            this.Controls.Add(this.btnManaul);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.cbFileName);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.Panel2);
            this.Controls.Add(this.Panel3);
            this.Controls.Add(this.Label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmGetSet";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmGetSet";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmGetSet_FormClosing);
            this.Load += new System.EventHandler(this.frmGetSet_Load);
            this.Panel2.ResumeLayout(false);
            this.Panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblTitle;
        internal System.Windows.Forms.MenuItem mnuShow;
        internal System.Windows.Forms.ContextMenu ContextMenu1;
        internal System.Windows.Forms.MenuItem MenuItem1;
        internal System.Windows.Forms.MenuItem mnuExit;
        internal System.Windows.Forms.Label lblStatus;
        internal System.Windows.Forms.MenuItem mnuExitApp;
        internal System.Windows.Forms.MenuItem MenuItem2;
        internal System.Windows.Forms.MenuItem mnuHideWindow;
        internal System.Windows.Forms.ContextMenu ContextMenu2;
        internal System.Windows.Forms.NotifyIcon TrayIcon;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Panel Panel2;
        internal System.Windows.Forms.Label lblSqlStatus;
        internal System.Windows.Forms.Panel Panel3;
        internal System.Windows.Forms.Label Label3;
        internal VbPowerPack.NotificationWindow NotifyWindow;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbFileName;
        private System.Windows.Forms.Button btnManaul;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbStation;
    }
}