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
using System.Windows.Forms;

namespace DENSO_VCT_APP
{
    public partial class frmNGMaster : Form
    {


        #region Variables

        private BL_NG_MASTER _blObj = null;
        private PL_NG_MASTER _plObj = null;
        private bool _IsUpdate = false;
        private string _partNo = string.Empty;


        #endregion

        #region Form Methods

        public frmNGMaster()
        {
            try
            {
                InitializeComponent();
                _blObj = new BL_NG_MASTER();
            }
            catch (Exception ex)
            {
                GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, ex.Message, 3);
            }
        }

        private void frmModelMaster_Load(object sender, EventArgs e)
        {
            try
            {
                // this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;

                btnDelete.Enabled = false;
              
                Clear();
                cmbModelNo.Focus();
                BindModelNo();
                BindGrid();
            }
            catch (Exception ex)
            {
                GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, ex.Message, 3); ;
            }
        }

        #endregion

        #region Button Event
        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateInput())
                {
                    _plObj = new PL_NG_MASTER();
                    _plObj.ModelNo = cmbModelNo.Text.Trim();
                    _plObj.ChildPartNo = cmbChildPartNo.Text.Trim();
                    _plObj.Lot = txtLotNo.Text.Trim();
                    _plObj.CreatedBy = GlobalVariable.mSatoAppsLoginUser;
                    _plObj.Active = chkActive.Checked;
                    //If saving data
                    if (_IsUpdate == false)
                    {
                        _plObj.DbType = "INSERT";
                        DataTable dataTable = _blObj.BL_ExecuteTask(_plObj);
                        if (dataTable.Rows.Count > 0)
                        {
                            if (dataTable.Rows[0]["RESULT"].ToString() == "Y")
                            {
                                btnReset_Click(sender, e);
                                GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, "Saved successfully!!", 1);
                                frmModelMaster_Load(null, null);
                            }
                            else
                            {
                                GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, dataTable.Rows[0][0].ToString(), 3);
                            }
                        }
                    }
                    else // if updating data
                    {
                        _plObj.DbType = "UPDATE";
                        DataTable dataTable = _blObj.BL_ExecuteTask(_plObj);
                        if (dataTable.Rows.Count > 0)
                        {
                            if (dataTable.Rows[0]["RESULT"].ToString() == "Y")
                            {
                                btnReset_Click(sender, e);
                                GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, "Updated successfully!!", 1);
                            }
                            else
                            {
                                GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, dataTable.Rows[0][0].ToString(), 3);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Violation of PRIMARY KEY"))
                {
                    GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, "Already exist!!", 3);
                }
                else
                {
                    GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, ex.Message, 3); ;
                }
            }
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                txtSearch.Text = "";
                Clear();
                frmModelMaster_Load(null, null);
               
            }
            catch (Exception ex)
            {
                GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, ex.Message, 3); ;
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbModelNo.SelectedIndex <= 0)
                {
                    GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, "Select Model can't be blank!!", 3);
                    return;
                }
                if (cmbChildPartNo.SelectedIndex <= 0)
                {
                    GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, "Select Child Part can't be blank!!", 3);
                    return;
                }
                if (string.IsNullOrEmpty(txtLotNo.Text.Trim()))
                {
                    GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, "Lot No. can't be blank!!", 3);
                    return;
                }
                if (GlobalVariable.mStoCustomFunction.ConfirmationMsg(GlobalVariable.mSatoApps, "Äre you sure to delete the record !!"))
                {
                    _plObj = new PL_NG_MASTER();
                    _blObj = new BL_NG_MASTER();
                    _plObj.ModelNo = cmbModelNo.Text.Trim();
                    _plObj.ChildPartNo = cmbChildPartNo.Text.Trim();
                    _plObj.Lot = txtLotNo.Text.Trim();
                    _plObj.DbType = "DELETE";
                    DataTable dataTable = _blObj.BL_ExecuteTask(_plObj);
                    if (dataTable.Rows.Count > 0)
                    {
                        if (dataTable.Rows[0][0].ToString().StartsWith("Y"))
                        {
                            btnReset_Click(sender, e);
                            GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, "Deleted successfully!!", 1);
                            frmModelMaster_Load(null, null);
                        }
                        else
                        {
                            GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, dataTable.Rows[0][0].ToString(), 3);
                        }
                    }


                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("conflicted with the REFERENCE constraint"))
                {
                    GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, "This is already in use!!!", 3);
                }
                else
                {
                    GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, ex.Message, 3);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //GlobalVariable.mIsDispose = false;
            this.Close();
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                GlobalVariable.ExportInCSV(dgv);
            }
            catch (Exception ex)
            {

                GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, ex.Message, 3);
            }
        }
        #endregion

        #region Methods
        private void Clear()
        {
            try
            {
                if (cmbModelNo.SelectedIndex >= 0)
                {
                    cmbModelNo.SelectedIndex = 0;
                }
                if (cmbChildPartNo.SelectedIndex >= 0)
                {
                    cmbChildPartNo.SelectedIndex = 0;
                }
                txtLotNo.Text = "";
                chkActive.Checked = false;
                btnDelete.Enabled = false;
                cmbChildPartNo.Enabled = cmbModelNo.Enabled = true;
                txtLotNo.Enabled = true;
                _IsUpdate = false;
            }
            catch (Exception ex)
            {
                GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, ex.Message, 3); ;
            }
        }



        private void BindGrid()
        {
            try
            {
                _plObj = new PL_NG_MASTER();
                _blObj = new BL_NG_MASTER();
                _plObj.DbType = "SELECT";
                DataTable dt = _blObj.BL_ExecuteTask(_plObj);
                dgv.DataSource = dt;
                lblCount.Text = "Rows Count : " + dgv.Rows.Count;
            }
            catch (Exception ex)
            {
                GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, ex.Message, 3); ;
            }
        }
        private void BindModelNo()
        {
            try
            {
                PL_NG_MASTER plObj = new PL_NG_MASTER();
                plObj.DbType = "BIND_MODEL";
                DataTable dt = _blObj.BL_ExecuteTask(plObj);
                if (dt.Rows.Count > 0)
                {
                    GlobalVariable.BindCombo(cmbModelNo, dt);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void BindChildPartNo()
        {
            try
            {
                PL_NG_MASTER plObj = new PL_NG_MASTER();
                plObj.DbType = "BIND_CHILD_PART";
                plObj.ModelNo = cmbModelNo.Text.Trim();
                DataTable dt = _blObj.BL_ExecuteTask(plObj);
                if (dt.Rows.Count > 0)
                {
                    GlobalVariable.BindCombo(cmbChildPartNo, dt);
                    
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private bool ValidateInput()
        {
            try
            {
                if (cmbModelNo.SelectedIndex <= 0)
                {
                    GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, "Model No can't be blank!!", 3);
                    cmbModelNo.Focus();
                    cmbModelNo.SelectAll();
                    return false;
                }
                if (cmbChildPartNo.SelectedIndex <= 0)
                {
                    GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, "Child Part No can't be blank!!", 3);
                    cmbChildPartNo.Focus();
                    cmbChildPartNo.SelectAll();
                    return false;
                }

                if (txtLotNo.Text.Trim().Length == 0)
                {
                    GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, "Line Desc. can't be blank!!", 3);
                    txtLotNo.Focus();
                    txtLotNo.SelectAll();
                    return false;
                }


                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        #endregion

        #region Label Event

        #endregion

        #region DataGridView Events
        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex <= -1)
                {
                    return;
                }
                Clear();
                cmbModelNo.Text = _partNo = dgv.Rows[e.RowIndex].Cells["ModelNo"].Value.ToString();
                cmbChildPartNo.Text = _partNo = dgv.Rows[e.RowIndex].Cells["ChildPartNo"].Value.ToString();
                txtLotNo.Text = dgv.Rows[e.RowIndex].Cells["LotNo"].Value.ToString();
                chkActive.Checked = Convert.ToBoolean(dgv.Rows[e.RowIndex].Cells["Status"].Value.ToString());
                btnDelete.Enabled = true;
                cmbModelNo.Enabled = cmbChildPartNo.Enabled = false;
                txtLotNo.Enabled = false;
                _IsUpdate = true;
               
            }
            catch (Exception ex)
            {
                GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, ex.Message, 3);
            }
        }

        #endregion

        #region TextBox Event

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            (dgv.DataSource as DataTable).DefaultView.RowFilter = string.Format("LotNo LIKE '%{0}%'", txtSearch.Text);
        }


      

        private void txtVatCapacity_KeyPress(object sender, KeyPressEventArgs e)
        {
            GlobalVariable.allowOnlyNumeric(sender, e);
        }







        #endregion

        private void txtPartNo_Leave(object sender, EventArgs e)
        {
            try
            {


                txtLotNo.Focus();

            }

            catch (Exception ex)
            {
                GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, ex.Message, 3); ;
            }
        }

        private void cmbModelNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbModelNo.SelectedIndex > 0)
            {
                BindChildPartNo();
            }
        }

        private void cmbChildPartNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbChildPartNo.SelectedIndex > 0)
            {
                txtLotNo.Focus();
            }
        }
    }
}
