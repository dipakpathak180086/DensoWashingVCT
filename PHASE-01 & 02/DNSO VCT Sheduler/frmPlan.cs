using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.IO;
using SatoLib;

namespace DENSOScheduler
{
    public partial class frmPlan : Form
    {
        SqlHelper _SqlHelper = new SqlHelper();
        SatoLib.SatoCustomFunction _SatoCustomFunction = new SatoCustomFunction();
        public frmPlan()
        {
            InitializeComponent();
        }
        private void tabNewPlan_Click(object sender, EventArgs e)
        {
           
        }
        private void frmPlan_Load(object sender, EventArgs e)
        {
            GetZone();
            FillListView();
            GetPlanID(); 
        }
        private void GetPlanID()
        {
            string strSql = "select SCHEDULED_PLAN from DEALER_SCHEDULED";
            DataSet dss = _SqlHelper.ExecuteDataset(GlobalVariable.mSqlConString,
                                           CommandType.Text, strSql);         
            int max = 0;
            if (dss.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dss.Tables[0].Rows.Count; i++)
                {
                    int temp = Convert.ToInt32(dss.Tables[0].Rows[i]["SCHEDULED_PLAN"].ToString().Replace("PLAN", "0"));
                    if (max < temp)
                        max = temp;
                }

                txtPlanName.Text = "PLAN" + (max + 1).ToString().PadLeft(3, '0');

            }
            else
            {
                txtPlanName.Text = "PLAN001";
            }
        }
        private void GetZone()
        {
            string strSql = "select distinct DEALER_ZONE from DEALER_MASTER";
            DataSet dss = _SqlHelper.ExecuteDataset(GlobalVariable.mSqlConString,
                                            CommandType.Text,strSql);
            _SatoCustomFunction.FillComboFromDataTable(dss.Tables[0], "DEALER_ZONE", cbZone);
            cbZone.Items.Add("ALL");
        }
        private void FillListView()
        {
            string strqury = "select DEALER_CODE,DEALER_NAME,DEALER_ADDRESS,DEALER_CITY  FROM DEALER_MASTER";
            DataSet ds = _SqlHelper.ExecuteDataset(GlobalVariable.mSqlConString,
                                       CommandType.Text, strqury);                          
            if (ds.Tables[0].Rows.Count > 0)
            {
                ListViewItem lvitem;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    lvitem = new ListViewItem(ds.Tables[0].Rows[i][0].ToString());
                    lvitem.SubItems.Add(ds.Tables[0].Rows[i][1].ToString());
                    lvitem.SubItems.Add(ds.Tables[0].Rows[i][2].ToString());
                    lvitem.SubItems.Add(ds.Tables[0].Rows[i][3].ToString());
                    lv1.Items.Add(lvitem);
                }
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbInterval.Text.Trim() == "")
                {
                    MessageBox.Show("Please select Interval");
                    return;
                }
            
            else
            {
                try
                    {
                        string dealercode = null;

                        for (int i = 0; i < lv1.Items.Count; i++)
                        {
                            if (lv1.Items[i].Checked)
                            {
                                if (DealerExist())
                                {
                                    return;
                                }
                                dealercode += ""+lv1.Items[i].SubItems[0].Text.ToString()+""+",";                               
                            }
                        }
                        if (dealercode!=null)
                        {
                            try
                            {
                                string str = "insert into DEALER_SCHEDULED(DEALER_CODE,SCHEDULED_TIME,SCHEDULED_PLAN)values ('" + dealercode.Remove(dealercode.Length - 1, 1) + "','" + cmbInterval.Text.Trim() + "','" + txtPlanName.Text.Trim() + "')";                                
                                _SqlHelper.ExecuteNonQuery(GlobalVariable.mSqlConString,
                                       CommandType.Text, str);      
                                MessageBox.Show("Plan save successfully");
                                foreach (ListViewItem var in lv1.Items)
                                {
                                    var.Checked = false;
                                }
                                GetPlanID();
                                cmbInterval.SelectedIndex = -1;
                                return;
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                        MessageBox.Show("Please select any dealer code first");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
            }
        }     
        private bool DealerExist()
        {
            string ExistingDealers = null;

            string strqryy = "select DEALER_CODE from DEALER_SCHEDULED";
            DataSet dss = _SqlHelper.ExecuteDataset(GlobalVariable.mSqlConString,
                                     CommandType.Text, strqryy);                    
            if (dss.Tables[0].Rows.Count==0)
            {
                return false;              
            }
            for (int Z = 0; Z < dss.Tables[0].Rows.Count; Z++)
            {
                ExistingDealers += dss.Tables[0].Rows[Z]["DEALER_CODE"].ToString() + ",";
            }
            ExistingDealers = ExistingDealers.Remove(ExistingDealers.Length - 1, 1);
            string[] tempDB = ExistingDealers.Split(',');             

            string dealercode = null;
            for (int i = 0; i < lv1.Items.Count; i++)
            {
                if (lv1.Items[i].Checked)
                {
                    dealercode += ""+lv1.Items[i].SubItems[0].Text.ToString()+""+",";                                   
                }
            }
            if (dealercode != null)
            {
                dealercode = dealercode.Remove(dealercode.Length - 1, 1);                  
            }
            string[] tempChecked = dealercode.Split(',');
            for (int i = 0; i < tempChecked.Length; i++)
            {
                for (int j = 0; j < tempDB.Length; j++)
                {
                    if (tempChecked[i] == tempDB[j])
                    {
                        string qry = "select SCHEDULED_PLAN from DEALER_SCHEDULED where DEALER_CODE like '%" + tempDB[j] + "%'";
                         dss = _SqlHelper.ExecuteDataset(GlobalVariable.mSqlConString,
                                   CommandType.Text, qry);                               
                        MessageBox.Show("Duplicate Item :" + tempDB[j]+"  where plan no:-"+dss.Tables[0].Rows[0][0].ToString());
                        return true;
                    }
                }
            }
            return false;
        }
        
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void tabMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabMain.SelectedTab.Text == "Edit Plan")
            {
                FillComboFromDB();               
            }
        }
        private void FillComboFromDB()
        {
            cmbSelectPlan.Items.Clear();
            string strqr = "select SCHEDULED_PLAN from DEALER_SCHEDULED";
            DataSet ds = _SqlHelper.ExecuteDataset(GlobalVariable.mSqlConString,
                                             CommandType.Text, strqr);         

            int i = 0;
            while (i < ds.Tables[0].Rows.Count)
            {
                cmbSelectPlan.Items.Add(ds.Tables[0].Rows[i]["SCHEDULED_PLAN"].ToString());
                i++;
            }
        }       

        private void cmbSelectPlan_SelectedIndexChanged(object sender, EventArgs e)
        {
            lv2.Items.Clear();
            FillLvFromDB();
        }
        private void FillLvFromDB()
        {
            string strr = "select DEALER_CODE,SCHEDULED_TIME FROM DEALER_SCHEDULED where SCHEDULED_PLAN='" + cmbSelectPlan.Text.Trim() + "'";
            DataSet dss = _SqlHelper.ExecuteDataset(GlobalVariable.mSqlConString,
                                 CommandType.Text, strr);                               
            if (dss.Tables[0].Rows.Count > 0)
            {
                string[] temp = dss.Tables[0].Rows[0][0].ToString().Split(',');
                
                ListViewItem lvitem;
                for (int i = 0; i < temp.Length; i++)
                {
                    lvitem = new ListViewItem(temp[i]);
                    lvitem.Text = temp[i];
                    lvitem.SubItems.Add(dss.Tables[0].Rows[0]["SCHEDULED_TIME"].ToString());
                    lv2.Items.Add(lvitem);
                    lvitem.Checked = true;

                }
            }
        }

        private void btnExit2_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string dealercode = null;

                for (int i = 0; i < lv2.Items.Count; i++)
                {
                    if (lv2.Items[i].Checked)
                    {
                        dealercode += "" + lv2.Items[i].SubItems[0].Text.ToString() + "" + ",";                        
                    }
                }
                if (dealercode!=null)
                {
                    try
                    {
                        string str = "update DEALER_SCHEDULED set DEALER_CODE='" + dealercode.Remove(dealercode.Length - 1, 1) + "' where SCHEDULED_PLAN='" + cmbSelectPlan.Text.Trim() + "'";                        
                        _SqlHelper.ExecuteNonQuery(GlobalVariable.mSqlConString,
                               CommandType.Text, str);                   
                        MessageBox.Show("Plan Updated successfully");
                        lv2.Items.Clear();
                        FillLvFromDB();
                        return;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

                MessageBox.Show("Please select a plan first");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string delete = "delete from DEALER_SCHEDULED where SCHEDULED_PLAN='" + cmbSelectPlan.Text.Trim() + "'";
                _SqlHelper.ExecuteNonQuery(GlobalVariable.mSqlConString,
                               CommandType.Text, delete);            
                MessageBox.Show("delete successfully");
                lv2.Items.Clear();
                FillComboFromDB(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            


        }

        private void cbZone_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strqury = "";
            if (cbZone.Text.Trim ()==""||cbZone.Text.Trim ()=="ALL")
                strqury= "select DEALER_CODE,DEALER_NAME,DEALER_ADDRESS,DEALER_CITY  FROM DEALER_MASTER";
            else
            strqury= "select DEALER_CODE,DEALER_NAME,DEALER_ADDRESS,DEALER_CITY  FROM DEALER_MASTER WHERE DEALER_ZONE='"+ cbZone.Text.Trim () +"'";
            DataSet ds = _SqlHelper.ExecuteDataset(GlobalVariable.mSqlConString,
                                       CommandType.Text, strqury);
            _SatoCustomFunction.FillListView(ds.Tables[0], lv1);           
        }             
    }
}
