namespace DENSOScheduler
{
    partial class frmPlan
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
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabNewPlan = new System.Windows.Forms.TabPage();
            this.cbZone = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtPlanName = new System.Windows.Forms.TextBox();
            this.cmbInterval = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSID = new System.Windows.Forms.Label();
            this.lv1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.tabEditPlan = new System.Windows.Forms.TabPage();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnExit2 = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.cmbSelectPlan = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lv2 = new System.Windows.Forms.ListView();
            this.DEALERCODE = new System.Windows.Forms.ColumnHeader();
            this.SCHEDULED_TIME = new System.Windows.Forms.ColumnHeader();
            this.tabMain.SuspendLayout();
            this.tabNewPlan.SuspendLayout();
            this.tabEditPlan.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabNewPlan);
            this.tabMain.Controls.Add(this.tabEditPlan);
            this.tabMain.Font = new System.Drawing.Font("Trebuchet MS", 9.75F);
            this.tabMain.Location = new System.Drawing.Point(3, -5);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(484, 378);
            this.tabMain.TabIndex = 0;
            this.tabMain.SelectedIndexChanged += new System.EventHandler(this.tabMain_SelectedIndexChanged);
            // 
            // tabNewPlan
            // 
            this.tabNewPlan.BackColor = System.Drawing.Color.AliceBlue;
            this.tabNewPlan.Controls.Add(this.cbZone);
            this.tabNewPlan.Controls.Add(this.label4);
            this.tabNewPlan.Controls.Add(this.label2);
            this.tabNewPlan.Controls.Add(this.btnExit);
            this.tabNewPlan.Controls.Add(this.btnSave);
            this.tabNewPlan.Controls.Add(this.txtPlanName);
            this.tabNewPlan.Controls.Add(this.cmbInterval);
            this.tabNewPlan.Controls.Add(this.label1);
            this.tabNewPlan.Controls.Add(this.lblSID);
            this.tabNewPlan.Controls.Add(this.lv1);
            this.tabNewPlan.Location = new System.Drawing.Point(4, 27);
            this.tabNewPlan.Name = "tabNewPlan";
            this.tabNewPlan.Padding = new System.Windows.Forms.Padding(3);
            this.tabNewPlan.Size = new System.Drawing.Size(476, 347);
            this.tabNewPlan.TabIndex = 0;
            this.tabNewPlan.Text = "New Plan";
            this.tabNewPlan.Click += new System.EventHandler(this.tabNewPlan_Click);
            // 
            // cbZone
            // 
            this.cbZone.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbZone.FormattingEnabled = true;
            this.cbZone.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24"});
            this.cbZone.Location = new System.Drawing.Point(293, 273);
            this.cbZone.Name = "cbZone";
            this.cbZone.Size = new System.Drawing.Size(141, 26);
            this.cbZone.TabIndex = 27;
            this.cbZone.SelectedIndexChanged += new System.EventHandler(this.cbZone_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(248, 275);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 18);
            this.label4.TabIndex = 26;
            this.label4.Text = "ZONE";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(206, 312);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 18);
            this.label2.TabIndex = 25;
            this.label2.Text = "Hrs.";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(383, 303);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 32);
            this.btnExit.TabIndex = 24;
            this.btnExit.Text = "EXIT";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(275, 303);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 32);
            this.btnSave.TabIndex = 23;
            this.btnSave.Text = "SAVE";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtPlanName
            // 
            this.txtPlanName.Enabled = false;
            this.txtPlanName.Location = new System.Drawing.Point(133, 276);
            this.txtPlanName.Name = "txtPlanName";
            this.txtPlanName.Size = new System.Drawing.Size(66, 23);
            this.txtPlanName.TabIndex = 22;
            // 
            // cmbInterval
            // 
            this.cmbInterval.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInterval.FormattingEnabled = true;
            this.cmbInterval.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24"});
            this.cmbInterval.Location = new System.Drawing.Point(134, 309);
            this.cmbInterval.Name = "cmbInterval";
            this.cmbInterval.Size = new System.Drawing.Size(66, 26);
            this.cmbInterval.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 312);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 18);
            this.label1.TabIndex = 20;
            this.label1.Text = "SCHEDULE INTERVAL";
            // 
            // lblSID
            // 
            this.lblSID.AutoSize = true;
            this.lblSID.Location = new System.Drawing.Point(6, 279);
            this.lblSID.Name = "lblSID";
            this.lblSID.Size = new System.Drawing.Size(75, 18);
            this.lblSID.TabIndex = 18;
            this.lblSID.Text = "PLAN NAME";
            // 
            // lv1
            // 
            this.lv1.CheckBoxes = true;
            this.lv1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lv1.FullRowSelect = true;
            this.lv1.GridLines = true;
            this.lv1.Location = new System.Drawing.Point(6, 6);
            this.lv1.Name = "lv1";
            this.lv1.Size = new System.Drawing.Size(464, 266);
            this.lv1.TabIndex = 0;
            this.lv1.UseCompatibleStateImageBehavior = false;
            this.lv1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "DEALER CODE";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "DEALER NAME";
            this.columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "DEALER ADDRESS";
            this.columnHeader3.Width = 121;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "DEALER CITY";
            this.columnHeader4.Width = 100;
            // 
            // tabEditPlan
            // 
            this.tabEditPlan.BackColor = System.Drawing.Color.AliceBlue;
            this.tabEditPlan.Controls.Add(this.btnDelete);
            this.tabEditPlan.Controls.Add(this.btnExit2);
            this.tabEditPlan.Controls.Add(this.btnUpdate);
            this.tabEditPlan.Controls.Add(this.cmbSelectPlan);
            this.tabEditPlan.Controls.Add(this.label3);
            this.tabEditPlan.Controls.Add(this.lv2);
            this.tabEditPlan.Location = new System.Drawing.Point(4, 27);
            this.tabEditPlan.Name = "tabEditPlan";
            this.tabEditPlan.Padding = new System.Windows.Forms.Padding(3);
            this.tabEditPlan.Size = new System.Drawing.Size(476, 347);
            this.tabEditPlan.TabIndex = 1;
            this.tabEditPlan.Text = "Edit Plan";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(104, 311);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 30);
            this.btnDelete.TabIndex = 27;
            this.btnDelete.Text = "DELETE";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnExit2
            // 
            this.btnExit2.Location = new System.Drawing.Point(201, 311);
            this.btnExit2.Name = "btnExit2";
            this.btnExit2.Size = new System.Drawing.Size(75, 30);
            this.btnExit2.TabIndex = 26;
            this.btnExit2.Text = "CANCEL";
            this.btnExit2.UseVisualStyleBackColor = true;
            this.btnExit2.Click += new System.EventHandler(this.btnExit2_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(3, 311);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(80, 30);
            this.btnUpdate.TabIndex = 25;
            this.btnUpdate.Text = "UPDATE";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // cmbSelectPlan
            // 
            this.cmbSelectPlan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSelectPlan.FormattingEnabled = true;
            this.cmbSelectPlan.Location = new System.Drawing.Point(145, 12);
            this.cmbSelectPlan.Name = "cmbSelectPlan";
            this.cmbSelectPlan.Size = new System.Drawing.Size(81, 26);
            this.cmbSelectPlan.TabIndex = 24;
            this.cmbSelectPlan.SelectedIndexChanged += new System.EventHandler(this.cmbSelectPlan_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 18);
            this.label3.TabIndex = 23;
            this.label3.Text = "SELECT PLAN NAME:-";
            // 
            // lv2
            // 
            this.lv2.CheckBoxes = true;
            this.lv2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.DEALERCODE,
            this.SCHEDULED_TIME});
            this.lv2.FullRowSelect = true;
            this.lv2.GridLines = true;
            this.lv2.Location = new System.Drawing.Point(3, 39);
            this.lv2.Name = "lv2";
            this.lv2.Size = new System.Drawing.Size(464, 266);
            this.lv2.TabIndex = 1;
            this.lv2.UseCompatibleStateImageBehavior = false;
            this.lv2.View = System.Windows.Forms.View.Details;
            // 
            // DEALERCODE
            // 
            this.DEALERCODE.Text = "DEALER CODE";
            this.DEALERCODE.Width = 186;
            // 
            // SCHEDULED_TIME
            // 
            this.SCHEDULED_TIME.Text = "SCHEDULED TIME";
            this.SCHEDULED_TIME.Width = 258;
            // 
            // frmPlan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(488, 375);
            this.Controls.Add(this.tabMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmPlan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmPlan";
            this.Load += new System.EventHandler(this.frmPlan_Load);
            this.tabMain.ResumeLayout(false);
            this.tabNewPlan.ResumeLayout(false);
            this.tabNewPlan.PerformLayout();
            this.tabEditPlan.ResumeLayout(false);
            this.tabEditPlan.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabNewPlan;
        private System.Windows.Forms.TabPage tabEditPlan;
        private System.Windows.Forms.ListView lv1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Label lblSID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbInterval;
        private System.Windows.Forms.TextBox txtPlanName;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView lv2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnExit2;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.ComboBox cmbSelectPlan;
        private System.Windows.Forms.ColumnHeader DEALERCODE;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ComboBox cbZone;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ColumnHeader SCHEDULED_TIME;
    }
}