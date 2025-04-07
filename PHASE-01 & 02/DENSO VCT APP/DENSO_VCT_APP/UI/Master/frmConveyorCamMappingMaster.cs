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
    public partial class frmConveyorCamMappingMaster : Form
    {


        #region Variables

        private BL_CONVEYOR_CAM_MAPPING_MASTER _blObj = null;
        private PL_CONVEYOR_CAM_MAPPING_MASTER _plObj = null;
        private bool _IsUpdate = false;
        private string _partNo = string.Empty;
        private long _iRowId = 0;

        #endregion

        #region Form Methods

        public frmConveyorCamMappingMaster()
        {
            try
            {
                InitializeComponent();
                _blObj = new BL_CONVEYOR_CAM_MAPPING_MASTER();
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
                cmbConveyor.Focus();
                BindGrid();
                BindCamera();
                BindConveyor();
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
                    _plObj = new PL_CONVEYOR_CAM_MAPPING_MASTER();
                    _plObj.RowId = Convert.ToInt64(_iRowId);
                    _plObj.CamId = cmbCamera.Text.ToString().Trim();
                    _plObj.CamIP = lblCameraIP.Text.Trim();
                    _plObj.Conveyor = cmbConveyor.SelectedValue.ToString().Trim();
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
                chkActive.Checked = false;
                btnDelete.Enabled = false;
                if (cmbCamera.SelectedIndex > 0 || cmbConveyor.SelectedIndex > 0)
                    cmbCamera.SelectedIndex = cmbConveyor.SelectedIndex = 0;
                lblCameraIP.Text = "XXXXXXXX";
                _IsUpdate = false;
            }
            catch (Exception ex)
            {
                GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, ex.Message, 3); ;
            }
        }

        private void BindConveyor()
        {
            try
            {
                PL_CONVEYOR_CAM_MAPPING_MASTER plObj = new PL_CONVEYOR_CAM_MAPPING_MASTER();
                plObj.DbType = "BIND_CONVEYOR";
                DataTable dt = _blObj.BL_ExecuteTask(plObj);
                if (dt.Rows.Count > 0)
                {
                    GlobalVariable.BindCombo(cmbConveyor, dt);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void BindCamera()
        {
            try
            {
                PL_CONVEYOR_CAM_MAPPING_MASTER plObj = new PL_CONVEYOR_CAM_MAPPING_MASTER();
                plObj.DbType = "BIND_CAM_IP";
                DataTable dt = _blObj.BL_ExecuteTask(plObj);
                if (dt.Rows.Count > 0)
                {
                    GlobalVariable.BindCombo(cmbCamera, dt);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void BindGrid()
        {
            try
            {
                _plObj = new PL_CONVEYOR_CAM_MAPPING_MASTER();
                _blObj = new BL_CONVEYOR_CAM_MAPPING_MASTER();
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
                if (cmbConveyor.SelectedIndex <= 0)
                {
                    GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, "Select Conveyor !!", 3);
                    cmbConveyor.Focus();
                    cmbConveyor.SelectAll();
                    return false;
                }
                if (cmbCamera.SelectedIndex <= 0)
                {
                    GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, "Select Scanner !!", 3);
                    cmbCamera.Focus();
                    cmbCamera.SelectAll();
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
                _iRowId = Convert.ToInt64(dgv.Rows[e.RowIndex].Cells["RowId"].Value.ToString());
                cmbConveyor.SelectedValue= dgv.Rows[e.RowIndex].Cells["ConveyorCode"].Value.ToString();
                cmbCamera.Text= _partNo = dgv.Rows[e.RowIndex].Cells["CamID"].Value.ToString();
                lblCameraIP.Text = dgv.Rows[e.RowIndex].Cells["CamIP"].Value.ToString();
                chkActive.Checked = Convert.ToBoolean(dgv.Rows[e.RowIndex].Cells["Active"].Value.ToString());
                btnDelete.Enabled = true;
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



        private void txtCameraIP_KeyPress(object sender, KeyPressEventArgs e)
        {
            GlobalVariable.allowOnlyIP(sender, e);
        }





        #endregion

        private void cmbCamera_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbCamera.SelectedIndex>0)
            {
                lblCameraIP.Text = cmbCamera.SelectedValue.ToString();
            }
        }
    }
}
