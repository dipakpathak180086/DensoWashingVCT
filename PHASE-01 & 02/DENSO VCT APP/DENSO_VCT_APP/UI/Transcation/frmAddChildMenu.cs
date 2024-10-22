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
    public partial class frmAddChildMenu : Form
    {
        #region Private Variables
        TableLayoutPanel tlp = new TableLayoutPanel();
        //string[] strLabelText = { "KB-IN \r\nHA229800-1200","KC-IN \r\nHA229800-3240","KC-EX \r\nHA229800-3250",
        //    "KC-EX(Export) \r\nHA229800-4630","TNGA-IN(70°) \r\nHA229800-4590","TNGA-IN(45°) \r\nHA229800-4580",
        //"TNGA-EX \r\nHA229800-4600","ZE-EX(Export) \r\nHA229800-4640","ZE-EX \r\nHA229800-4670"};
        string[] strLabelText = null;
        Label[] label = null;
        BL_PC_MENU blObj = null;
        private string parentPartNo = "";
        private DataTable dtAllChildDateView = null;
        public frmAddChildMenu()
        {
            InitializeComponent();
            blObj = new BL_PC_MENU();
            parentPartNo = GlobalVariable.mParentPart;
        }

        #endregion

        #region "Form Event"

        protected void l1_click(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            MessageBox.Show(lbl.Name.ToString());
        }
        private void OFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            GlobalVariable.mChildLabelTextEvent = "";
            BindView();
            this.Show();
        }
        private void OnLabelClick(object sender, EventArgs e)
        {
            var label = sender as Label;
            if (label != null)
            {
                if (GlobalVariable.mChildLabelTextEvent == label.Text)
                {
                    return;
                }
                GlobalVariable.mChildLabelTextEvent = label.Text;
                string[] strParentPart = label.Text.Split('\n');

                if (strParentPart.Length > 0)
                {

                    GlobalVariable.mChildPart = GlobalVariable.mChildPartName = "";
                    GlobalVariable.mChildPartName = strParentPart[0].Trim();
                    GlobalVariable.mChildPart = strParentPart[1].Trim();
                    for (int i = 0; i < GlobalVariable.mdicChildPart.Count; i++)
                    {
                        if (GlobalVariable.mChildPart == GlobalVariable.mdicChildPart.ElementAt(i).Value)
                        {
                            GlobalVariable.mIRunningIndex = i;
                            break;
                        }
                    }
                    frmLotEntry frm = new frmLotEntry();
                    frm.Show();
                    frm.FormClosing += OFrm_FormClosing;
                    this.Hide();
                }
            }
        }
        private void BindChildProducationData()
        {
            try
            {
                BL_PC_MENU blObj = new BL_PC_MENU();
                PL_PC_MENU plObj = new PL_PC_MENU();
                plObj.DbType = "GET_ALL_CHILD_DATA_IN_VIEW";
                plObj.Model = GlobalVariable.mParentPart;
                dtAllChildDateView = blObj.BL_ExecuteTask(plObj);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void BindChildMenu()
        {
            try
            {
                lblModel.Text = GlobalVariable.mParentPartName + " " + GlobalVariable.mParentPart;
                PL_PC_MENU plObj = new PL_PC_MENU();
                plObj.DbType = "GET_CHILD_PART";
                plObj.Model = parentPartNo;
                DataTable dt = blObj.BL_ExecuteTask(plObj);
                if (dt.Rows.Count > 0)
                {
                    dtAllChildDateView = dt.Copy();
                    GlobalVariable.mIRunningIndex = 0;
                    GlobalVariable.mdicChildPart = new Dictionary<string, string>();
                    strLabelText = new string[dt.Rows.Count];
                    label = new Label[dt.Rows.Count];
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (!GlobalVariable.mdicChildPart.ContainsKey(dt.Rows[i]["ChildPartName"].ToString()))
                        {
                            GlobalVariable.mdicChildPart.Add(dt.Rows[i]["ChildPartName"].ToString(), dt.Rows[i]["ChildPartNo"].ToString());
                            //Commented by dipak 30-11-2023 case child part duplicate.
                            // GlobalVariable.mdicChildPart.Add(dt.Rows[i]["ChildPartNo"].ToString(),dt.Rows[i]["ChildPartName"].ToString());
                        }
                        string str = dt.Rows[i]["ChildPartName"].ToString() + "\r\n" + dt.Rows[i]["ChildPartNo"].ToString();
                        strLabelText[i] = str;
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private DataTable JoinDataTables(DataTable t1, DataTable t2, params Func<DataRow, DataRow, bool>[] joinOn)
        {
            DataTable result = new DataTable();
            foreach (DataColumn col in t1.Columns)
            {
                if (result.Columns[col.ColumnName] == null)
                    result.Columns.Add(col.ColumnName, col.DataType);
            }
            foreach (DataColumn col in t2.Columns)
            {
                if (result.Columns[col.ColumnName] == null)
                    result.Columns.Add(col.ColumnName, col.DataType);
            }
            foreach (DataRow row1 in t1.Rows)
            {
                var joinRows = t2.AsEnumerable().Where(row2 =>
                {
                    foreach (var parameter in joinOn)
                    {
                        if (!parameter(row1, row2)) return false;
                    }
                    return true;
                });
                foreach (DataRow fromRow in joinRows)
                {
                    DataRow insertRow = result.NewRow();
                    foreach (DataColumn col1 in t1.Columns)
                    {
                        insertRow[col1.ColumnName] = row1[col1.ColumnName];
                    }
                    foreach (DataColumn col2 in t2.Columns)
                    {
                        insertRow[col2.ColumnName] = fromRow[col2.ColumnName];
                    }
                    result.Rows.Add(insertRow);
                }
            }
            return result;
        }
        private void BindView()
        {
            lock (this)
            {

                this.Invoke(new Action(() =>
                {
                    try
                    {
                        BindChildProducationData();
                       
                        for (int i = dgv.Rows.Count - 1; i >= 0; i--)
                        {
                            dgv.Rows.RemoveAt(i);
                        }
                        Common common = new Common();
                        GlobalVariable.mShift = common.GetShift();
                        BL_LOT_ENTRY _blObj = new BL_LOT_ENTRY();
                        PL_LOT_ENTRY _plObj = new PL_LOT_ENTRY();
                        _plObj.DbType = "GET_CHILD_VIEW_DATA";
                        _plObj.ModelNo = GlobalVariable.mParentPart;
                        _plObj.Shift = GlobalVariable.mShift;
                        DataTable dt = _blObj.BL_ExecuteTask(_plObj);
                        if (dt.Rows.Count > 0)
                        {


                            for (int i = 0; i < dtAllChildDateView.Rows.Count; i++)
                            {
                                for (int j = 0; j < dt.Rows.Count; j++)
                                {
                                    if (dt.Rows[j][0].ToString() == dtAllChildDateView.Rows[i][0].ToString())
                                    {
                                        dtAllChildDateView.Rows[i]["ShiftWiseTotal"] = dt.Rows[j]["ShiftWiseTotal"].ToString();
                                        dtAllChildDateView.Rows[i]["DayWiseTotal"] = dt.Rows[j]["DayWiseTotal"].ToString();
                                        dtAllChildDateView.AcceptChanges();
                                        break;
                                    }
                                }
                            }
                            dgv.DataSource = null;

                            dgv.DataSource = dtAllChildDateView.DefaultView;

                            for (int i = 0; i < dgv.ColumnCount; i++)
                            {
                                this.dgv.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                                if (dgv.ColumnCount - 1 == i)
                                {
                                    this.dgv.Columns[dgv.ColumnCount - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                                }

                            }


                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    dgv.ResumeLayout(true);
                }
              ));
            }
        }
        private void AddControlBox()
        {

            Height = 800;
            Width = 800;

            // tlp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            //| System.Windows.Forms.AnchorStyles.Left)
            //| System.Windows.Forms.AnchorStyles.Right)));
            pnlChildView.Controls.Add(tlp);
            tlp.AutoSize = true;
            tlp.Margin = new Padding(0, 0, 0, 0);
            // tlp.Size = new System.Drawing.Size(400, 600);
            tlp.CellBorderStyle = TableLayoutPanelCellBorderStyle.None;
            tlp.AutoScroll = true;
            pnlChildView.AutoScroll = true;
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

            tlp.ResumeLayout();
        }
        private void AddLabel(params object[] parm)
        {
            foreach (Label item in parm)
            {
                //Label label1 = new System.Windows.Forms.Label();
                item.Anchor = System.Windows.Forms.AnchorStyles.Top;
                // item.AutoSize = true;
                item.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                item.Location = new System.Drawing.Point(0, 0);
                //item.Size = new System.Drawing.Size(140, 40);
                item.TabIndex = 0;
                //item.Text = "KB-IN \r\nHA229800-1200\r\n";

                item.Click += OnLabelClick;
                item.BorderStyle = BorderStyle.FixedSingle;
                item.Margin = new Padding(20, 20, 20, 20);
                //item.DoubleClick -= OnLabelClick;
                // label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(215)))), ((int)(((byte)(238)))));
                foreach (Control c in new Control[] { item })
                {
                    c.Margin = new Padding(10, 10, 10, 10);
                    c.Dock = DockStyle.Fill;
                    //((Label)(c)).TextAlign = System.Drawing.ContentAlignment.BottomCenter;
                    c.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
                }
                item.TextAlign = ContentAlignment.MiddleCenter;
                tlp.Controls.Add(item);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //lblWelcome.TextAlign = ContentAlignment.MiddleRight;
            //lblWelcome.Text = "© Developed by SATO Argox India Pvt Ltd." + GlobalVariable.mSatoAppsLoginUser;
            BindChildMenu();
            AddControlBox();
            //BindChildProducationData();
            BindView();
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

        private void frmAddChildMenu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                picLogOut_Click(null, null);
            }
        }

        private async void timer1_Tick(object sender, EventArgs e)
        {
          //  await Task.Run(new Action(() => { BindView(); }));


        }
    }
}
