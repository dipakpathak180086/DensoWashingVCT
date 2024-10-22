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
    public partial class frmModelMaster : Form
    {


        #region Variables

        private BL_MODEL_MASTER _blObj = null;
        private PL_MODEL_MASTER _plObj = null;
        private bool _IsUpdate = false;
        private string _rowId = "0";


        #endregion

        #region Form Methods

        public frmModelMaster()
        {
            try
            {
                InitializeComponent();
                _blObj = new BL_MODEL_MASTER();
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
                //if (GlobalVariable.UserGroup.ToUpper() != "ADMIN")
                //{
                //    Common common = new Common();
                //    common.SetModuleChildSectionRights(this.Text, _IsUpdate, btnSave, btnDelete);
                //}
                Clear();
                txtModelNo.Focus();

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
                    _plObj = new PL_MODEL_MASTER();
                    _plObj.RowId =Convert.ToInt32( _rowId);
                    _plObj.ModelNo = txtModelNo.Text.Trim();
                    _plObj.ModelName = txtModelName.Text.Trim();
                    _plObj.ChildPartNo = txtChildPartNo.Text.Trim();
                    _plObj.ChildPartName = txtChildPartName.Text.Trim();
                    _plObj.LotLength = Convert.ToInt32( txtLotLen.Text.Trim());
                    _plObj.LotQtyLength =Convert.ToInt32( txtQtyLen.Text.Trim());
                    _plObj.CreatedBy = "ADMIN";
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
                if (string.IsNullOrEmpty(txtModelNo.Text))
                {
                    GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, "Crate Code. can't be blank!!", 3);
                    return;
                }
                if (GlobalVariable.mStoCustomFunction.ConfirmationMsg(GlobalVariable.mSatoApps, "Äre you sure to delete the record !!"))
                {
                    _plObj = new PL_MODEL_MASTER();
                    _blObj = new BL_MODEL_MASTER();
                    _plObj.Line = txtModelNo.Text.Trim();
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
                txtModelNo.Text = "";
                txtModelName.Text = "";
                txtChildPartNo.Text = "";
                txtChildPartName.Text = "";
                txtQtyLen.Text = "";
                txtLotLen.Text = "";
                chkActive.Checked = true;
                btnDelete.Enabled = false;
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
                _plObj = new PL_MODEL_MASTER();
                _blObj = new BL_MODEL_MASTER();
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

        private bool ValidateInput()
        {
            try
            {
                if (txtModelNo.Text.Trim().Length == 0)
                {
                    GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, "Model No can't be blank!!", 3);
                    txtModelNo.Focus();
                    txtModelNo.SelectAll();
                    return false;
                }
                if (txtModelName.Text.Trim().Length == 0)
                {
                    GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, "Model Name can't be blank!!", 3);
                    txtModelName.Focus();
                    txtModelName.SelectAll();
                    return false;
                }
                if (txtChildPartNo.Text.Trim().Length == 0)
                {
                    GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, "Child Part No. can't be blank!!", 3);
                    txtChildPartNo.Focus();
                    txtChildPartNo.SelectAll();
                    return false;
                }
                if (txtChildPartName.Text.Trim().Length == 0)
                {
                    GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, "Child Part Name can't be blank!!", 3);
                    txtChildPartName.Focus();
                    txtChildPartName.SelectAll();
                    return false;
                }
                if (txtLotLen.Text.Trim().Length == 0)
                {
                    GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, "Lot Lenght can't be blank!!", 3);
                    txtLotLen.Focus();
                    txtLotLen.SelectAll();
                    return false;
                }
                if (Convert.ToInt32( txtLotLen.Text.Trim())== 0)
                {
                    GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, "Lot Lenght can't be Zero!!", 3);
                    txtLotLen.Focus();
                    txtLotLen.SelectAll();
                    return false;
                }
                if (txtQtyLen.Text.Trim().Length == 0)
                {
                    GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, "Lot Qty Length can't be blank!!", 3);
                    txtQtyLen.Focus();
                    txtQtyLen.SelectAll();
                    return false;
                }
                if (Convert.ToInt32( txtQtyLen.Text.Trim()) == 0)
                {
                    GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, "Lot Qty Length can't be Zero!!", 3);
                    txtQtyLen.Focus();
                    txtQtyLen.SelectAll();
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
                _rowId = dgv.Rows[e.RowIndex].Cells["RowId"].Value.ToString();
                txtModelNo.Text = dgv.Rows[e.RowIndex].Cells["ModelNo"].Value.ToString();
                txtModelName.Text = dgv.Rows[e.RowIndex].Cells["ModelName"].Value.ToString();
                txtChildPartNo.Text  = dgv.Rows[e.RowIndex].Cells["ChildPartNo"].Value.ToString();
                txtChildPartName.Text = dgv.Rows[e.RowIndex].Cells["ChildPartName"].Value.ToString();
                txtLotLen.Text  = dgv.Rows[e.RowIndex].Cells["LotNoLength"].Value.ToString();
                txtQtyLen.Text = dgv.Rows[e.RowIndex].Cells["LotQtyLength"].Value.ToString();
                chkActive.Checked = Convert.ToBoolean(dgv.Rows[e.RowIndex].Cells["Status"].Value.ToString());
                btnDelete.Enabled = true;
                //txtModelNo.Enabled = false;
                //txtModelName.Enabled = false;
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
            (dgv.DataSource as DataTable).DefaultView.RowFilter = string.Format("ChildPartNo LIKE '%{0}%'", txtSearch.Text);
        }


        private void txtPartNo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    
                }
            }

            catch (Exception ex)
            {
                GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, ex.Message, 3); ;
            }
        }

        private void TxtAllowNumeric_KeyPress(object sender, KeyPressEventArgs e)
        {
            GlobalVariable.allowOnlyNumeric(sender, e);
        }







        #endregion

        private void txtPartNo_Leave(object sender, EventArgs e)
        {
            try
            {

                

            }

            catch (Exception ex)
            {
                GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, ex.Message, 3); ;
            }
        }

       
    }
}
