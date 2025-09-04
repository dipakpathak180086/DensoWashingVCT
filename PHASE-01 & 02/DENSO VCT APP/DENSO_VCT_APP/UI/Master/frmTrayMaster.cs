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
    public partial class frmTrayMaster : Form
    {


        #region Variables

        private BL_TRAY_MASTER _blObj = null;
        private PL_TRAY_MASTER _plObj = null;
        private bool _IsUpdate = false;
        private string _partNo = string.Empty;


        #endregion

        #region Form Methods

        public frmTrayMaster()
        {
            try
            {
                InitializeComponent();
                _blObj = new BL_TRAY_MASTER();
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
                txtTrayCode.Focus();
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
                    _plObj = new PL_TRAY_MASTER();
                    _plObj.TrayCode = txtTrayCode.Text.Trim();
                    _plObj.TrayName = txtTrayName.Text.Trim();
                    _plObj.PackSize =Convert.ToInt32( txtPackSize.Text.Trim());
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
                txtTrayCode.Text = "";
                txtTrayName.Text = "";
                txtPackSize.Text = "";
                chkActive.Checked = false;
                btnDelete.Enabled = false;
                txtTrayCode.Enabled = true;
                txtPackSize.Enabled = true;
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
                _plObj = new PL_TRAY_MASTER();
                _blObj = new BL_TRAY_MASTER();
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
                if (string.IsNullOrEmpty(txtTrayCode.Text.Trim()))
                {
                    GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, "Tray Code can't be blank!!", 3);
                    txtTrayCode.Focus();
                    txtTrayCode.SelectAll();
                    return false;
                }
                if (string.IsNullOrEmpty(txtTrayName.Text.Trim()))
                {
                    GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, "Tray Name can't be blank!!", 3);
                    txtTrayName.Focus();
                    txtTrayName.SelectAll();
                    return false;
                }

                if (txtPackSize.Text.Trim().Length == 0)
                {
                    GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, "Pack Size can't be blank!!", 3);
                    txtPackSize.Focus();
                    txtPackSize.SelectAll();
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
                txtTrayCode.Text = _partNo = dgv.Rows[e.RowIndex].Cells["TrayCode"].Value.ToString();
                txtTrayName.Text = _partNo = dgv.Rows[e.RowIndex].Cells["TrayName"].Value.ToString();
                txtPackSize.Text = dgv.Rows[e.RowIndex].Cells["TrayPackSize"].Value.ToString();
                chkActive.Checked = Convert.ToBoolean(dgv.Rows[e.RowIndex].Cells["Active"].Value.ToString());
                btnDelete.Enabled = true;
                txtTrayCode.Enabled = false;
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
            (dgv.DataSource as DataTable).DefaultView.RowFilter = string.Format("TrayCode LIKE '%{0}%'", txtSearch.Text);
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


                txtPackSize.Focus();

            }

            catch (Exception ex)
            {
                GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, ex.Message, 3); ;
            }
        }

        private void txtPackSize_KeyPress(object sender, KeyPressEventArgs e)
        {
            GlobalVariable.allowOnlyNumeric(sender, e);
        }
    }
}
