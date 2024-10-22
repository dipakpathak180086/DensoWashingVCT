using COMMON;
using SUM_BL;
using SUM_PL;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VCTWebApp.pages.Master.UserManagment
{
    public partial class GroupRights : System.Web.UI.Page
    {
        clsExportToCSV objclsExportToCSV = new clsExportToCSV();
        protected void Page_Init(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("~/Login.aspx?Session=Null");
            }
        }
        public enum MessageType { Success, Error, Info, Warning };
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    ddlGroup.Focus();
                    GetGroups();
                }
            }
            catch (Exception ex)
            {
                ShowMessageWithUpdatePanel(ex.ToString(), MessageType.Error);
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  GroupRights _Page_Load() ", " User-  " + Session["UserName"].ToString() + " " + ex.Message);
            }
        }

        private void GetGroups()
        {
            BL_GroupMaster blobj = new BL_GroupMaster();
            PL_GroupMaster plobj = new PL_GroupMaster();
            DataTable dt = new DataTable();
            ddlGroup.DataSource = null;
            dt = blobj.ShowDetails(plobj);
            ddlGroup.DataSource = dt;
            ddlGroup.DataTextField = "GROUPNAME";
            ddlGroup.DataValueField = "GroupID";
            ddlGroup.DataBind();
            ddlGroup.Items.Insert(0, "-- Select Group --");
        }

        private void GetGroupRights()
        {
            BL_GroupMaster blobj = new BL_GroupMaster();
            PL_GroupMaster plobj = new PL_GroupMaster();
            plobj.GroupID = ddlGroup.SelectedValue.ToString().Trim();
            DataTable dt = new DataTable();
            if (plobj.GroupID == "")
                gvGroupRights.DataSource = null;
            else
            {
                gvGroupRights.DataSource = null;
                dt = blobj.GetGroupRights(plobj);
                if (dt.Rows.Count > 0)
                {
                    gvGroupRights.DataSource = Session["GROUP_RIGHTS"] = dt;
                    gvGroupRights.DataBind();
                    btnExport.Enabled = true;
                    Session["Rights"] = dt;
                }
                else
                {
                    gvGroupRights.DataSource = null;
                    gvGroupRights.DataBind();
                    btnExport.Enabled = false;
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {

                int iCnt = 0;
                bool bView = false;
                string ModuelName = string.Empty;
                BL_GroupMaster blobj = new BL_GroupMaster();
                PL_GroupMaster plobj = new PL_GroupMaster();
                OperationResult oResutl = OperationResult.Error;
                DataTable dt = (DataTable)Session["Rights"];
                int iRowCnt = gvGroupRights.Rows.Count;
                if (iRowCnt == 0 || dt == null)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ShowNullMsg", "ShowNullMsg();", true);
                    return;
                }
                plobj.GroupID = ddlGroup.SelectedValue.ToString();
                foreach (GridViewRow gvRow in gvGroupRights.Rows)
                {
                    if (gvRow.RowType == DataControlRowType.DataRow)
                    {
                        ModuelName = ((Label)gvRow.FindControl("lblPageName")).Text.ToString();
                        bView = ((CheckBox)gvRow.FindControl("chkView")).Checked;
                        dt.Rows[iCnt]["VIEW_RIGHTS"] = bView;
                        iCnt++;
                        dt.AcceptChanges();
                    }
                }
                plobj.GroupID = ddlGroup.SelectedValue.ToString();
                oResutl = blobj.SaveUpdateGroupRights(dt, plobj);
                if (oResutl == OperationResult.UpdateSuccess)
                {
                    ShowMessageWithUpdatePanel("Group Rights Updated Successfully.", MessageType.Success);
                }
                else if (oResutl == OperationResult.UpdateError)
                {
                    ShowMessageWithUpdatePanel("Error on Update Occured", MessageType.Error);
                }
                GetGroupRights();
                UpdatePanel1.Update();
            }
            catch (Exception ex)
            {
                ShowMessageWithUpdatePanel(ex.ToString(), MessageType.Error);
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  GroupRights _btnSubmit_Click() ", " User-  " + Session["UserName"].ToString() + " " + ex.Message);
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                gvGroupRights.DataSource = null;
                gvGroupRights.DataBind();
                btnExport.Enabled = false;
            }
            catch (Exception ex)
            {
                ShowMessageWithUpdatePanel(ex.ToString(), MessageType.Error);
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  GroupRights _btnClear_Click() ", " User-  " + Session["UserName"].ToString() + " " + ex.Message);
            }
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/Default.aspx");
            }
            catch (Exception ex)
            {
                ShowMessageWithUpdatePanel(ex.ToString(), MessageType.Error);
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  GroupRights _BtnBack_Click() ", " User-  " + Session["UserName"].ToString() + " " + ex.Message);
            }

        }

        #region GRIDVIEW EVENTS
        /// <summary>
        /// Checkbox checked/unchecked javascript event addition
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvGroupRights_RowCreated(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow &&
                   (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate))
                {
                    CheckBox chkView = (CheckBox)e.Row.Cells[2].FindControl("chkView");
                    CheckBox chkHView = (CheckBox)this.gvGroupRights.HeaderRow.FindControl("chkHView");
                    chkView.Attributes["onclick"] = string.Format("javascript:ChildViewClick(this,'{0}');", chkHView.ClientID);
                }
            }
            catch (Exception ex)
            {
                ShowMessageWithUpdatePanel(ex.ToString(), MessageType.Error);
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  GroupRights _gvGroupRights_RowCreated() ", " User-  " + Session["UserName"].ToString() + " " + ex.Message);
            }
        }

        /// <summary>
        /// Group rights page index changing event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvGroupRights_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                DataTable dt = (DataTable)Session["Rights"];
                gvGroupRights.PageIndex = e.NewPageIndex;
                gvGroupRights.DataSource = dt;
                gvGroupRights.DataBind();
            }
            catch (Exception ex)
            {
                ShowMessageWithUpdatePanel(ex.ToString(), MessageType.Error);
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  GroupRights _gvGroupRights_PageIndexChanging() ", " User-  " + Session["UserName"].ToString() + " " + ex.Message);
            }
        }
        #endregion

        #region SELECTEDINDEXCHANGED EVENT
        /// <summary>
        /// Page level rights are displayed based on group selected.
        /// </summary>
        protected void ddlGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlGroup.SelectedIndex != 0)
                    GetGroupRights();
            }
            catch (Exception ex)
            {
                ShowMessageWithUpdatePanel(ex.ToString(), MessageType.Error);
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  GroupRights _ddlGroup_SelectedIndexChanged() ", " User-  " + Session["UserName"].ToString() + " " + ex.Message);
            }
        }
        #endregion

        protected void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvGroupRights.Rows.Count > 0)
                {
                    Response.Clear();
                    DataTable dt = (DataTable)Session["GROUP_RIGHTS"];
                    objclsExportToCSV.ExportTOCSV(dt, "GROUP_RIGHTS.csv");
                }
                else
                {
                    ShowMessageWithUpdatePanel("There is no data for being exported.", MessageType.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                ShowMessageWithUpdatePanel(ex.ToString(), MessageType.Error);
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  GroupRights _btnExport_Click() ", " User-  " + Session["UserName"].ToString() + " " + ex.Message);
            }
        }
        protected void ShowMessageWithUpdatePanel(string Message, MessageType type)
        {
            if ((!ClientScript.IsStartupScriptRegistered("JSScript")))
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type.ToString() + "');", true);
        }
        protected void ShowMessage(string Message, MessageType type)
        {
            if ((!ClientScript.IsStartupScriptRegistered("JSScript")))
                ClientScript.RegisterStartupScript(this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type.ToString() + "');", true);
        }
    }
}