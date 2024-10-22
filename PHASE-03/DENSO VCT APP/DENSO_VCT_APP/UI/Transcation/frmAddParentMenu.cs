using DENSO_VCT_BL;
using DENSO_VCT_COMMON;
using DENSO_VCT_PL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DENSO_VCT_APP
{
    public partial class frmAddParentMenu : Form
    {
        #region Private Variables
        TableLayoutPanel tlp = new TableLayoutPanel();
        //string[] strLabelText = { "KB-IN \r\nHA229800-1200","KC-IN \r\nHA229800-3240","KC-EX \r\nHA229800-3250",
        //    "KC-EX(Export) \r\nHA229800-4630","TNGA-IN(70°) \r\nHA229800-4590","TNGA-IN(45°) \r\nHA229800-4580",
        //"TNGA-EX \r\nHA229800-4600","ZE-EX(Export) \r\nHA229800-4640","ZE-EX \r\nHA229800-4670"};
        string[] strLabelText = null;
        Label[] label = null;
        int iIndex = 0;
        BL_PC_MENU blObj = null;
        public frmAddParentMenu()
        {
            InitializeComponent();
            blObj = new BL_PC_MENU();
        }
        #endregion

        #region "Form Event"

        protected void l1_click(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            MessageBox.Show(lbl.Name.ToString());
        }
        private void OnLabelClick(object sender, EventArgs e)
        {
            var label = sender as Label;
            if (label != null)
            {
                if (GlobalVariable.mParentLabelTextEvent == label.Text)
                {
                    return;
                }
                GlobalVariable.mParentLabelTextEvent = label.Text;
                string[] strParentPart = label.Text.Split('\n');

                if (strParentPart.Length > 0)
                {
                    GlobalVariable.mParentPart= GlobalVariable.mParentPartName = "";
                    GlobalVariable.mParentPartName = strParentPart[0].Trim();
                    GlobalVariable.mParentPart = strParentPart[1].Trim();
                    frmAddChildMenu frm = new frmAddChildMenu();
                    frm.Show();
                    frm.FormClosing += OFrm_FormClosing;
                    this.Hide();
                }
            }
        }
        private void OFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            GlobalVariable.mParentLabelTextEvent = "";
            this.Show();
        }
        private void BindParentMenu()
        {
            try
            {
                PL_PC_MENU plObj = new PL_PC_MENU();
                plObj.DbType = "GET_PARENT_PART";
                DataTable dt = blObj.BL_ExecuteTask(plObj);
                if (dt.Rows.Count > 0)
                {
                    strLabelText = new string[dt.Rows.Count];
                    label = new Label[dt.Rows.Count];
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string str = dt.Rows[i]["ModelName"].ToString() + "\r\n" + dt.Rows[i]["ModelNo"].ToString();
                        strLabelText[i] = str;
                    }
                    AddControlBox();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void AddControlBox()
        {

            Height = 800;
            Width = 800;

            // tlp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            //| System.Windows.Forms.AnchorStyles.Left)
            //| System.Windows.Forms.AnchorStyles.Right)));
            panel2.Controls.Add(tlp);
            tlp.AutoSize = true;
            tlp.Margin = new Padding(0, 0, 0, 0);
            // tlp.Size = new System.Drawing.Size(400, 600);
            tlp.CellBorderStyle = TableLayoutPanelCellBorderStyle.None;
            //tlp.AutoScroll = true;
            //Controls.Add(tlp);


            tlp.ColumnCount = 3;
            for (int i = 0; i < 5; i++)
            {

                tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
                //ColumnStyle columnStyle = new ColumnStyle(SizeType.Absolute, 50F);
                //tlp.ColumnStyles[i].SizeType = SizeType.Absolute;
                //tlp.ColumnStyles[i].Width = 50F;
            }
            tlp.RowCount = 10;
            for (int i = 0; i < tlp.RowCount; i++)
            {

                tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100f));

            }


            tlp.SuspendLayout();
            for (int iLabel = 0; iLabel < label.Length; iLabel++)
            {
                label[iLabel] = new Label();
                label[iLabel].Text = strLabelText[iLabel].ToString();
            }
            for (int jRow = 0; jRow < label.Count<Label>(); jRow++)
            {

                AddLabel(label[jRow]);


            }
            //for (int iCol = 0; iCol < 50; iCol++)
            //{
            //    for (int jRow = 0; jRow < tlp.ColumnCount; jRow++)
            //    {

            //        if (iCol <= label.Count<Label>() - 1)
            //        {
            //            AddLabel(label[jRow]);
            //            iCol++;
            //        }

            //    }
            //}
            //    panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            //   | System.Windows.Forms.AnchorStyles.Left)
            //   | System.Windows.Forms.AnchorStyles.Right)));
            //    tlp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            //| System.Windows.Forms.AnchorStyles.Left)
            //| System.Windows.Forms.AnchorStyles.Right)));
            //tlp.Location = new Point((panel2.Width - tlp.Width) / 2, (panel2.Height - tlp.Height) / 2);

            // tlp.Dock = DockStyle.Fill;
            tlp.ResumeLayout();
        }
        private void AddLabel(params object[] parm)
        {
          
            foreach (Label item in parm)
            {
                iIndex++;
                //Label label1 = new System.Windows.Forms.Label();
                item.Anchor = System.Windows.Forms.AnchorStyles.Top;
                item.AutoSize = true;
                item.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                item.Location = new System.Drawing.Point(0, 0);
                //item.Size = new System.Drawing.Size(140, 40);
                item.TabIndex = 0;
                //item.Text = "KB-IN \r\nHA229800-1200\r\n";
                item.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                item.Click += OnLabelClick;
                item.BorderStyle = BorderStyle.FixedSingle;
                //item.DoubleClick -= OnLabelClick;
                // label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(215)))), ((int)(((byte)(238)))));
                switch (iIndex)
                {
                    case 1:
                        item.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(215)))), ((int)(((byte)(238)))));
                        break;
                    case 2:
                        item.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
                        break;
                    case 3:
                        item.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(224)))), ((int)(((byte)(180)))));
                        break;
                    case 4:
                        item.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(209)))), ((int)(((byte)(142)))));
                        break;
                    case 5:
                        item.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(177)))), ((int)(((byte)(131)))));
                        break;
                    case 6:
                        item.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(90)))), ((int)(((byte)(17)))));
                        break;
                    case 7:
                        item.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(217)))), ((int)(((byte)(102)))));
                        break;
                    case 8:
                        item.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
                        break;
                    case 9:
                        item.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(201)))), ((int)(((byte)(255)))));
                        break;

                    default:
                        break;
                }
               
                foreach (Control c in new Control[] { item })
                {
                    
                    c.Margin = new Padding(10, 10, 10, 10);
                    c.Dock = DockStyle.Fill;
                   
                    
                }
                tlp.Controls.Add(item);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //lblWelcome.TextAlign = ContentAlignment.MiddleRight;
            //lblWelcome.Text = "© Developed by SATO Argox India Pvt Ltd." + GlobalVariable.mSatoAppsLoginUser;
            BindParentMenu();
            
               

        }

        private void picLogOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMini_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        #endregion

        private void frmAddParentMenu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                picLogOut_Click(null, null);
            }
        }
    }
}
