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
    public partial class frmLotEntryReport : Form
    {

        #region Variables

        private BL_LOT_ENTRY_REPORT _blObj = null;
        private PL_LOT_ENTRY_REPORT _plObj = null;
        private Common _comObj = null;
        private string _packType = string.Empty;
        private DataTable dtBindGrid = new DataTable();
        #endregion

        #region Form Methods

        public frmLotEntryReport()
        {
            try
            {
                InitializeComponent();
                _blObj = new BL_LOT_ENTRY_REPORT();
                _plObj = new PL_LOT_ENTRY_REPORT();
            }
            catch (Exception ex)
            {
                GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, ex.Message, 3);
            }
        }

        private void frmReprinting_Load(object sender, EventArgs e)
        {
            try
            {
                //this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
                lblModelNo.Text = GlobalVariable.mParentPart;
                lblChildPart.Text = GlobalVariable.mChildPart;
                lblChildName.Text = GlobalVariable.mChildPartName;
                lblModelName.Text = GlobalVariable.mParentPartName;
                BindLot();
            }
            catch (Exception ex)
            {
                GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, ex.Message, 3); 
            }
        }

        #endregion

        #region Button Event
        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {

                Clear();

            }
            catch (Exception ex)
            {
                GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, ex.Message, 3);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            try
            {


                _plObj = new PL_LOT_ENTRY_REPORT();
                _plObj.DbType = "SELECT";
                _plObj.FromDate = dpFromDate.Value.ToString("yyyy-MM-dd");
                _plObj.ToDate = dpToDate.Value.ToString("yyyy-MM-dd");
                _plObj.Model_No = GlobalVariable.mParentPart;
                _plObj.Child_No = GlobalVariable.mChildPart;
                _plObj.Lot_No = cmbLot.Text.Trim();
                DataTable dataTable = _blObj.BL_ExecuteTask(_plObj);
                if (dataTable.Rows.Count > 0)
                {
                    dgv.DataSource = dataTable.DefaultView;
                    for (int i = 0; i < dgv.ColumnCount; i++)
                    {
                        this.dgv.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                        if (dgv.ColumnCount - 1 == i)
                        {
                            this.dgv.Columns[dgv.ColumnCount - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        }

                    }

                }
                else
                {
                    GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, "No Data Found !!!", 2);
                    for (int i = dgv.Rows.Count - 1; i >= 0; i--)
                    {
                        dgv.Rows.RemoveAt(i);
                    }
                }



            }
            catch (Exception ex)
            {
                GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, ex.Message, 3);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            GlobalVariable.ExportInCSV(dgv);
        }
        #endregion

        #region Methods


        private void Clear()
        {
            try
            {
                for (int i = dgv.Rows.Count - 1; i >= 0; i--)
                {
                    dgv.Rows.RemoveAt(i);
                }
                dpFromDate.Value = dpFromDate.Value = DateTime.Now;
                lblChildName.Text = lblChildPart.Text = lblModelName.Text = lblModelNo.Text = "XXXXXXXXXXXXXXXXX";


            }
            catch (Exception ex)
            {
                GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, ex.Message, 3);
            }
        }





        private bool ValidateInput()
        {
            try
            {
                //if (dpFromDate.Value > dpToDate.Value)
                //{
                //    GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, "From date can not be greater than To date!!", 3);
                //    dpToDate.Focus();
                //    return false;
                //}


                return true;
            }
            catch (Exception ex) { throw ex; }
        }
        private void BindLot()
        {
            try
            {
                PL_LOT_ENTRY_REPORT plObj = new PL_LOT_ENTRY_REPORT();
                plObj.DbType = "BIND_LOT";
                plObj.Model_No = GlobalVariable.mParentPart;
                plObj.Child_No = GlobalVariable.mChildPart;
                DataTable dt = _blObj.BL_ExecuteTask(plObj);
                if (dt.Rows.Count > 0)
                {
                    GlobalVariable.BindCombo(cmbLot, dt);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void BindDataSerchByLotNo()
        {
            try
            {
                PL_LOT_ENTRY_REPORT plObj = new PL_LOT_ENTRY_REPORT();
                plObj.DbType = "SELECT_BY_LOT";
                plObj.Model_No = GlobalVariable.mParentPart;
                plObj.Child_No = GlobalVariable.mChildPart;
                plObj.Lot_No = txtSerchByLot.Text.Trim();
                DataTable dt = _blObj.BL_ExecuteTask(plObj);
                if (dt.Rows.Count > 0)
                {
                    dgv.DataSource = dt.DefaultView;
                }
                else
                {
                    GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps,"No data found!!", 3);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region Label Event

        #endregion

        #region DataGridView Events


        #endregion

        #region TextBox Event
        private void dpToDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dpToDate_CloseUp(object sender, EventArgs e)
        {


        }
        private void cmbLot_KeyPress(object sender, KeyPressEventArgs e)
        {
            GlobalVariable.mStoCustomFunction.AutoCompleteCombo(cmbLot, e);
        }
        private void dpFromDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        private void dpToDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        private void cbPartNo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }




        private void txtFromLabel_KeyPress(object sender, KeyPressEventArgs e)
        {
            GlobalVariable.allowOnlyNumeric(sender, e);
        }

        private void txtToLabel_KeyPress(object sender, KeyPressEventArgs e)
        {
            GlobalVariable.allowOnlyNumeric(sender, e);
        }





        #endregion

        private void lblChildPart_Click(object sender, EventArgs e)
        {

        }

        private void txtSerchByLot_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    BindDataSerchByLotNo();
                }
            }
            catch (Exception ex)
            {

                GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, ex.Message, 3);
            }
        }
    }
}
