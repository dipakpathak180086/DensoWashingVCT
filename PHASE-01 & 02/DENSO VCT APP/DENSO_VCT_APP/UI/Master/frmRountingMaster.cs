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
    public partial class frmRountingMaster : Form
    {


        #region Variables

        private BL_ROUTING_MASTER _blObj = null;
        private PL_ROUTING_MASTER _plObj = null;
        private bool _IsUpdate = false;
        private string _partNo = string.Empty;
        private long _iRowId = 0;


        #endregion

        #region Form Methods

        public frmRountingMaster()
        {
            try
            {
                InitializeComponent();
                _blObj = new BL_ROUTING_MASTER();
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
                BindGrid();
                BindModelNo();
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
                    _plObj = new PL_ROUTING_MASTER();
                    _plObj.RowId = _iRowId;
                    _plObj.ModelNo = cmbModelNo.SelectedValue.ToString().Trim();
                    _plObj.ChildPartNo = cmbChildPartNo.SelectedValue.ToString().Trim();
                    _plObj.ConveyorNo = cmbConveyor.SelectedValue.ToString().Trim();
                    _plObj.Min = Convert.ToInt32(txtMin.Text.Trim());
                    _plObj.Max = Convert.ToInt32(txtMax.Text.Trim());
                    _plObj.Avg = Convert.ToInt32(txtAvg.Text.Trim());
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
                if (cmbModelNo.SelectedIndex > 0)
                {
                    cmbModelNo.SelectedIndex = 0;
                }
                if (cmbChildPartNo.SelectedIndex > 0)
                {
                    cmbChildPartNo.SelectedIndex = 0;
                }
                if (cmbConveyor.SelectedIndex > 0)
                {
                    cmbConveyor.SelectedIndex = 0;
                }
                txtMax.Text = "";
                txtAvg.Text = "";
                txtMin.Text = "";
                chkActive.Checked = false;
                btnDelete.Enabled = false;
                txtMin.Enabled = true;
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
                _plObj = new PL_ROUTING_MASTER();
                _blObj = new BL_ROUTING_MASTER();
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
                PL_ROUTING_MASTER plObj = new PL_ROUTING_MASTER();
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
                PL_ROUTING_MASTER plObj = new PL_ROUTING_MASTER();
                plObj.DbType = "BIND_CHILD_PART";
                plObj.ModelNo = cmbModelNo.SelectedValue.ToString();
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
        private void BindConveyor()
        {
            try
            {
                PL_ROUTING_MASTER plObj = new PL_ROUTING_MASTER();
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
                if (cmbConveyor.SelectedIndex <= 0)
                {
                    GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, "Conveyor can't be blank!!", 3);
                    cmbConveyor.Focus();
                    cmbConveyor.SelectAll();
                    return false;
                }

                if (txtMin.Text.Trim().Length == 0)
                {
                    GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, "Min can't be blank!!", 3);
                    txtMin.Focus();
                    txtMin.SelectAll();
                    return false;
                }
                if (txtMax.Text.Trim().Length == 0)
                {
                    GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, "Max can't be blank!!", 3);
                    txtMax.Focus();
                    txtMax.SelectAll();
                    return false;
                }
                if (txtAvg.Text.Trim().Length == 0)
                {
                    GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, "Avg can't be blank!!", 3);
                    txtAvg.Focus();
                    txtAvg.SelectAll();
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
                cmbModelNo.SelectedValue = _partNo = dgv.Rows[e.RowIndex].Cells["ModelNo"].Value.ToString();
                cmbChildPartNo.SelectedValue = _partNo = dgv.Rows[e.RowIndex].Cells["ChildPartNo"].Value.ToString();
                cmbConveyor.SelectedValue = _partNo = dgv.Rows[e.RowIndex].Cells["ConveyorNo"].Value.ToString();
                txtMin.Text = dgv.Rows[e.RowIndex].Cells["Min"].Value.ToString();
                txtMax.Text = dgv.Rows[e.RowIndex].Cells["Max"].Value.ToString();
                txtAvg.Text = dgv.Rows[e.RowIndex].Cells["Avg"].Value.ToString();
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
            (dgv.DataSource as DataTable).DefaultView.RowFilter = string.Format("ModelNo LIKE '%{0}%'", txtSearch.Text);
        }




        private void txtVatCapacity_KeyPress(object sender, KeyPressEventArgs e)
        {
            GlobalVariable.allowOnlyNumeric(sender, e);
        }

        private void cmbModelNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbModelNo.SelectedIndex > 0)
            {

                try
                {
                    BindChildPartNo();
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }

        }





        #endregion

        private void txtPartNo_Leave(object sender, EventArgs e)
        {
            try
            {


                txtMin.Focus();

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
