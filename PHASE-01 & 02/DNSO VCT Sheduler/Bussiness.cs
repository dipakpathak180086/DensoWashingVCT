using SatoLib;
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace DENSOScheduler
{
    internal class Bussiness
    {
        private ArrayList alAttachments;
        private SatoLib.SatoCustomFunction _SatoCustomFunction = new SatoLib.SatoCustomFunction();
        private SatoLib.SqlHelper _SqlHelper = new SqlHelper();
        private MyMail _MyMail = new MyMail();
        /// <summary>
        /// Get Application Information
        /// </summary>
        /// <returns></returns>
        public int PopulateSettingFile()
        {
            FileInfo _fi = new FileInfo(Application.StartupPath + "\\SatoScheduler.ini");
            StreamReader _sr = default(StreamReader);
            string strLine = null;
            try
            {
                if (_fi.Exists == true)
                {
                    _fi = null;
                    string[] _strArr = null;
                    _sr = new StreamReader(Application.StartupPath + "\\SatoScheduler.ini");
                    while (!_sr.EndOfStream)
                    {
                        strLine = _sr.ReadLine();
                        _strArr = strLine.Split('=');
                        switch (_strArr[0])
                        {

                            case "SQL_DATABASE_NAME":
                                GlobalVariable.mDb = _strArr[1].ToString().Trim();
                                break;
                            case "SQL_SERVER_NAME":
                                GlobalVariable.mDbServer = _strArr[1].ToString().Trim();
                                break;
                            case "SQL_USER_NAME":
                                GlobalVariable.mDbUser = _strArr[1].ToString().Trim();
                                break;
                            case "SQL_PASSWORD":
                                GlobalVariable.mDbPassword = _strArr[1].ToString().Trim();
                                break;
                            case "VCT_UPLOAD_MIN":
                                GlobalVariable.mVCTDataUploadTime = (Convert.ToInt32(_strArr[1].ToString().Trim()) * 60 * 1000);
                                break;
                         

                            case "AUTO_SCEDULER_RESTART_TIME":
                                break;
                                
                            case "VCT_FOLDER_PATH1":
                                GlobalVariable.mVCTFolderPath1 = _strArr[1].ToString().Trim();
                                break;
                            case "VCT_FOLDER_PATH2":
                                GlobalVariable.mVCTFolderPath2 = _strArr[1].ToString().Trim();
                                break;
                            case "VCT_LINE":
                                GlobalVariable.mLine = _strArr[1].ToString().Trim();
                                break;



                        }
                    }
                    GlobalVariable.mSqlConString = "Data Source=" + GlobalVariable.mDbServer + "; Initial Catalog=" + GlobalVariable.mDb + ";User ID=" + GlobalVariable.mDbUser + "; Password=" + GlobalVariable.mDbPassword + "; pooling=true";
                    _sr.Close();
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        /// <summary>
        /// Check Connection
        /// </summary>
        /// <returns></returns>
        public bool ConnectToDatabase()
        {
            try
            {
                SqlConnection _sCon = new SqlConnection();
                _sCon.ConnectionString = GlobalVariable.mSqlConString;
                _sCon.Open();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool ConnectAndonToDatabase()
        {
            try
            {
                SqlConnection _sCon = new SqlConnection();
                _sCon.ConnectionString = GlobalVariable.mAndonSqlConString;
                _sCon.Open();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public void GiveAccess(string sPassword)
        {
            _SqlHelper = new SqlHelper();
            try
            {
                SqlParameter[] param = new SqlParameter[3];

                param[0] = new SqlParameter("@PASSWORD", SqlDbType.VarChar, 100);
                param[0].Value = sPassword;
                DataTable dataTable = _SqlHelper.ExecuteDataset(GlobalVariable.mSqlConString, CommandType.StoredProcedure, "[PRC_ACCESS_USER]", param).Tables[0];
                if (dataTable.Rows.Count > 0)
                {
                    if (dataTable.Rows[0]["RESULT"].ToString() == "Y")
                    {
                        GlobalVariable.mAccessUser = dataTable.Rows[0]["MSG"].ToString();
                    }
                    else
                    {
                        throw new Exception(dataTable.Rows[0]["MSG"].ToString());
                    }


                }
            }
            catch (ArgumentNullException ex)
            {

                throw ex;
            }
        }


    }
}
