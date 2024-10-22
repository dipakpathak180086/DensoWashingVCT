using SatoLib;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;
using System.Windows.Forms;
using System.Threading;

namespace DENSOScheduler
{
    public class ClsKanbanDetails
    {
        #region Private variables
        private SatoLib.SatoCustomFunction _SatoCustomFunction = new SatoLib.SatoCustomFunction();
        private SatoLib.SqlHelper _SqlHelper = new SatoLib.SqlHelper();
        private StringBuilder _sb = new StringBuilder();
        private MyMail _MyMail = new MyMail();
        private FileStream sFileStreamCopy;
        public long _lLen = 0;
        private FileStream _fs;
        #endregion

        /// <summary>
        /// Delete updated ftpbciloutput 
        /// </summary>
        /// 
        public void FileDelete(string sFileName)
        {
            try
            {
                if (File.Exists(sFileName))
                {
                    File.Delete(sFileName);
                }
            }
            catch (Exception ex)
            {

                GlobalVariable.AppLog.LogMessage(SatoLib.EventNotice.EventTypes.evtData
                                            , "FileDelete"
                                            , ex.Message);
            }

        }
        #region MyFuncation
        /// <summary>
        /// Execute Operation 
        /// </summary>
        /// <returns></returns>
        public DataTable ExecuteTask(string sation, string model, string serial, string datetime, string status, string fileNameDate)
        {
            _SqlHelper = new SqlHelper();
            try
            {
                SqlParameter[] param = new SqlParameter[8];

                param[0] = new SqlParameter("@TYPE", SqlDbType.VarChar, 100);
                param[0].Value = "INSERT";
                param[1] = new SqlParameter("@STATION", SqlDbType.NVarChar, 10000);
                param[1].Value = sation;
                param[2] = new SqlParameter("@MODEL", SqlDbType.NVarChar, 10000);
                param[2].Value = model;
                param[3] = new SqlParameter("@SERIAL", SqlDbType.NVarChar, 10000);
                param[3].Value = serial;
                param[4] = new SqlParameter("@DATE_TIME", SqlDbType.NVarChar, 10000);
                param[4].Value = datetime;
                param[5] = new SqlParameter("@STATUS", SqlDbType.NVarChar, 10000);
                param[5].Value = status;
                param[6] = new SqlParameter("@FILE_DATE", SqlDbType.NVarChar, 10000);
                param[6].Value = fileNameDate;
                param[7] = new SqlParameter("@LINE", SqlDbType.NVarChar, 10000);
                param[7].Value = GlobalVariable.mLine;
                return _SqlHelper.ExecuteDataset(GlobalVariable.mSqlConString, CommandType.StoredProcedure, "[PRC_VCT_PERFOMANCE_DATA]", param).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable ExecuteTaskAll(PL_MODEL objPl)
        {
            _SqlHelper = new SqlHelper();
            try
            {
                SqlParameter[] param = new SqlParameter[50];

                param[0] = new SqlParameter("@TYPE", SqlDbType.VarChar, 100);
                param[0].Value = "INSERT";
                param[1] = new SqlParameter("@COLUMN01", SqlDbType.NVarChar, 10000);
                param[1].Value = objPl.Columns01;
                param[2] = new SqlParameter("@COLUMN02", SqlDbType.NVarChar, 10000);
                param[2].Value = objPl.Columns02;
                param[3] = new SqlParameter("@COLUMN03", SqlDbType.NVarChar, 10000);
                param[3].Value = objPl.Columns03;
                param[4] = new SqlParameter("@COLUMN04", SqlDbType.NVarChar, 10000);
                param[4].Value = objPl.Columns04;
                param[5] = new SqlParameter("@COLUMN05", SqlDbType.NVarChar, 10000);
                param[5].Value = objPl.Columns05;
                param[6] = new SqlParameter("@COLUMN06", SqlDbType.NVarChar, 10000);
                param[6].Value = objPl.Columns06;
                param[7] = new SqlParameter("@COLUMN07", SqlDbType.NVarChar, 10000);
                param[7].Value = objPl.Columns07;
                param[8] = new SqlParameter("@COLUMN08", SqlDbType.NVarChar, 10000);
                param[8].Value = objPl.Columns08;
                param[9] = new SqlParameter("@COLUMN09", SqlDbType.NVarChar, 10000);
                param[9].Value = objPl.Columns09;
                param[10] = new SqlParameter("@COLUMN10", SqlDbType.NVarChar, 10000);
                param[10].Value = objPl.Columns10;
                param[11] = new SqlParameter("@COLUMN11", SqlDbType.NVarChar, 10000);
                param[11].Value = objPl.Columns11;
                param[12] = new SqlParameter("@COLUMN12", SqlDbType.NVarChar, 10000);
                param[12].Value = objPl.Columns12;
                param[13] = new SqlParameter("@COLUMN13", SqlDbType.NVarChar, 10000);
                param[13].Value = objPl.Columns13;
                param[14] = new SqlParameter("@COLUMN14", SqlDbType.NVarChar, 10000);
                param[14].Value = objPl.Columns14;
                param[15] = new SqlParameter("@COLUMN15", SqlDbType.NVarChar, 10000);
                param[15].Value = objPl.Columns15;
                param[16] = new SqlParameter("@COLUMN16", SqlDbType.NVarChar, 10000);
                param[16].Value = objPl.Columns16;
                param[17] = new SqlParameter("@COLUMN17", SqlDbType.NVarChar, 10000);
                param[17].Value = objPl.Columns17;
                param[18] = new SqlParameter("@COLUMN18", SqlDbType.NVarChar, 10000);
                param[18].Value = objPl.Columns18;
                param[19] = new SqlParameter("@COLUMN19", SqlDbType.NVarChar, 10000);
                param[19].Value = objPl.Columns19;
                param[20] = new SqlParameter("@COLUMN20", SqlDbType.NVarChar, 10000);
                param[20].Value = objPl.Columns20;
                param[21] = new SqlParameter("@COLUMN21", SqlDbType.NVarChar, 10000);
                param[21].Value = objPl.Columns21;
                param[22] = new SqlParameter("@FILE_DATE", SqlDbType.NVarChar, 10000);
                param[22].Value = objPl.FileNameDate;
                param[23] = new SqlParameter("@STATION", SqlDbType.NVarChar, 10000);
                param[23].Value = objPl.Station;
                return _SqlHelper.ExecuteDataset(GlobalVariable.mSqlConString, CommandType.StoredProcedure, "[PRC_PRC_VCT_PERFOMANCE_ALL_DATA]", param).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable ExecuteTaskLogMessage(string line, string sation, string process, string fileName, string message)
        {
            _SqlHelper = new SqlHelper();
            try
            {
                SqlParameter[] param = new SqlParameter[8];

                param[0] = new SqlParameter("@LINE", SqlDbType.NVarChar, 10000);
                param[0].Value = line;
                param[1] = new SqlParameter("@STATION", SqlDbType.VarChar, 100);
                param[1].Value = sation;
                param[2] = new SqlParameter("@PROCESS", SqlDbType.NVarChar, 10000);
                param[2].Value = process;
                param[3] = new SqlParameter("@FILE_NAME", SqlDbType.NVarChar, 10000);
                param[3].Value = fileName;
                param[4] = new SqlParameter("@MESSAGE", SqlDbType.NVarChar, 10000);
                param[4].Value = message;
                param[5] = new SqlParameter("@CREATED_BY", SqlDbType.NVarChar, 10000);
                param[5].Value = "SCH";
                return _SqlHelper.ExecuteDataset(GlobalVariable.mSqlConString, CommandType.StoredProcedure, "[PRC_EXCEPTION_LOG]", param).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion




        public DataTable CSVtoDataTable(string strFilePath, char csvDelimiter)
        {
            DataTable dt = new DataTable();
            using (StreamReader sr = new StreamReader(strFilePath))
            {

                dt.Columns.Add("Columns0");
                dt.Columns.Add("Columns1");
                dt.Columns.Add("Columns2");
                dt.Columns.Add("Columns3");
                while (!sr.EndOfStream)
                {
                    string[] rows = sr.ReadLine().Split(csvDelimiter);
                    DataRow dr = dt.NewRow();
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {

                        if (i == dt.Columns.Count - 1)
                        {
                            if (rows[5].Trim() == "") { continue; }
                            dr[i] = rows[5];
                        }
                        else
                        {
                            dr[i] = rows[i];
                        }
                    }
                    dt.Rows.Add(dr);
                }

            }
            return dt;
        }
        /// <summary>
        /// All Data Bind
        /// </summary>
        /// <param name="strFilePath"></param>
        /// <param name="csvDelimiter"></param>
        /// <returns></returns>
        public DataTable CSVtoDataTableAllData(string strFilePath, char csvDelimiter)
        {
            DataTable dt = new DataTable();
            using (StreamReader sr = new StreamReader(strFilePath))
            {

                dt.Columns.Add("Columns0");
                dt.Columns.Add("Columns1");
                dt.Columns.Add("Columns2");
                dt.Columns.Add("Columns3");
                dt.Columns.Add("Columns4");
                dt.Columns.Add("Columns5");
                dt.Columns.Add("Columns6");
                dt.Columns.Add("Columns7");
                dt.Columns.Add("Columns8");
                dt.Columns.Add("Columns9");
                dt.Columns.Add("Columns10");
                dt.Columns.Add("Columns11");
                dt.Columns.Add("Columns12");
                dt.Columns.Add("Columns13");
                dt.Columns.Add("Columns14");
                dt.Columns.Add("Columns15");
                dt.Columns.Add("Columns16");
                dt.Columns.Add("Columns17");
                dt.Columns.Add("Columns18");
                dt.Columns.Add("Columns19");
                dt.Columns.Add("Columns20");
                while (!sr.EndOfStream)
                {
                    string[] rows = sr.ReadLine().Split(csvDelimiter);
                    DataRow dr = dt.NewRow();
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {

                        if (i == dt.Columns.Count - 1)
                        {
                            if (rows[5].Trim() == "") { continue; }
                            dr[i] = rows[5];
                        }
                        else
                        {
                            dr[i] = rows[i];
                        }
                    }
                    dt.Rows.Add(dr);
                }

            }
            return dt;
        }
        /// <summary>
        /// Get Uid and Serial Details 
        /// </summary>

        internal void GetVCTPath1(string paramfileName = "")
        {
            string fileName = "";
            try
            {

                string sData = string.Empty; string sKanbanbarcode = string.Empty;
                string sSno = string.Empty;

                List<FileInfo> myfiles = null;
                var directory = new DirectoryInfo(GlobalVariable.mVCTFolderPath1);
                if (paramfileName == "")
                    myfiles = directory.GetFiles().OrderByDescending(f => f.LastWriteTime).Take(1).ToList();
                else
                    myfiles = directory.GetFiles().Where(x => x.Name == paramfileName).OrderByDescending(f => f.LastWriteTime).Take(1).ToList();
                for (int iF = 0; iF < myfiles.Count; iF++)
                {


                    if (myfiles[iF].Exists)
                    {
                        fileName = Path.GetFileName(myfiles[iF].Name);
                        string day = fileName.Trim().ToUpper().Replace(".CSV", "").Substring(4, 2);
                        string month = fileName.Trim().ToUpper().Replace(".CSV", "").Substring(2, 2);
                        string year = "20" + fileName.Trim().ToUpper().Replace(".CSV", "").Substring(0, 2);
                        string extractfinalDate = year + "-" + month + "-" + day;
                        //if (File.Exists(GlobalVariable.mSatoOutPut + "\\" + DateTime.Now.ToString("yyyyMMddHHmmss").ToString() + "_" + fileName)) { File.Delete(GlobalVariable.mSatoOutPut + "\\" + DateTime.Now.ToString("yyyyMMddHHmmss").ToString() + "_" + fileName); }
                        File.Copy(myfiles[iF].FullName, GlobalVariable.mSatoOutPut + "\\(01)" + DateTime.Now.ToString("yyyyMMddHHmmss").ToString() + "_" + fileName);
                        DataTable dt = CSVtoDataTable(myfiles[iF].FullName, ',');
                        DataTable dtAllFile = CSVtoDataTableAllData(myfiles[iF].FullName, ',');
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            try
                            {
                                if (Convert.ToInt32(dt.Rows[i][1].ToString().Trim()) == 0) { continue; }
                            }
                            catch (Exception ex)
                            {
                                GlobalVariable.AppLog.LogMessage(SatoLib.EventNotice.EventTypes.evtError
                                                         , "Serial Conversion Error" + ""
                                                    , ex.Message);
                                continue;
                            }
                            string time = dt.Rows[i][2].ToString().Split(' ')[1];
                            string finalDate = extractfinalDate + " " + time;

                            ExecuteTask("1", dt.Rows[i][0].ToString(), dt.Rows[i][1].ToString(), dt.Rows[i][2].ToString().Replace("/", "-"), "OK", extractfinalDate);
                            PL_MODEL obj = new PL_MODEL();
                            obj.Station = "1";
                            obj.FileNameDate = extractfinalDate;
                            obj.Columns01 = dtAllFile.Rows[i][0].ToString();
                            obj.Columns02 = dtAllFile.Rows[i][1].ToString();
                            obj.Columns03 = dtAllFile.Rows[i][2].ToString().Replace("/", "-");
                            obj.Columns04 = dtAllFile.Rows[i][3].ToString();
                            obj.Columns05 = dtAllFile.Rows[i][4].ToString();
                            obj.Columns06 = dtAllFile.Rows[i][5].ToString();
                            obj.Columns07 = dtAllFile.Rows[i][6].ToString();
                            obj.Columns08 = dtAllFile.Rows[i][7].ToString();
                            obj.Columns09 = dtAllFile.Rows[i][8].ToString();
                            obj.Columns10 = dtAllFile.Rows[i][9].ToString();
                            obj.Columns11 = dtAllFile.Rows[i][10].ToString();
                            obj.Columns12 = dtAllFile.Rows[i][11].ToString();
                            obj.Columns13 = dtAllFile.Rows[i][12].ToString();
                            obj.Columns14 = dtAllFile.Rows[i][13].ToString();
                            obj.Columns15 = dtAllFile.Rows[i][14].ToString();
                            obj.Columns16 = dtAllFile.Rows[i][15].ToString();
                            obj.Columns17 = dtAllFile.Rows[i][16].ToString();
                            obj.Columns18 = dtAllFile.Rows[i][17].ToString();
                            obj.Columns19 = dtAllFile.Rows[i][18].ToString();
                            ExecuteTaskAll(obj);

                        }
                        //FileDelete(item);
                    }


                }

                if (paramfileName != "")
                {
                    MessageBox.Show("Uploded Successfully!!!");
                    // return;
                }

            }
            catch (Exception ex)
            {

                GlobalVariable.AppLog.LogMessage(SatoLib.EventNotice.EventTypes.evtError
                                                    , "GetVCTPath1:: " + ""
                                               , ex.Message);
                string strprocess = "";
                if (paramfileName == "") { strprocess = "AUTO"; }
                if (paramfileName != "") { strprocess = "MANUAL"; }
                ExecuteTaskLogMessage(GlobalVariable.mLine, "01", strprocess, fileName, ex.Message);
                throw ex;
            }
            finally
            {

                Thread.Sleep(1000);
            }

        }
        internal void GetVCTPath2(string paramfileName = "")
        {
            string fileName = "";
            try
            {

                string sData = string.Empty; string sKanbanbarcode = string.Empty;
                string sSno = string.Empty;
                List<FileInfo> myfiles = null;
                var directory = new DirectoryInfo(GlobalVariable.mVCTFolderPath2);
                if (paramfileName == "")
                    myfiles = directory.GetFiles().OrderByDescending(f => f.LastWriteTime).Take(1).ToList();
                else
                    myfiles = directory.GetFiles().Where(x => x.Name == paramfileName).OrderByDescending(f => f.LastWriteTime).Take(1).ToList();
                for (int iF = 0; iF < myfiles.Count; iF++)
                {
                    if (myfiles[iF].Exists)
                    {
                        fileName = Path.GetFileName(myfiles[iF].FullName);
                        string day = fileName.Trim().ToUpper().Replace(".CSV", "").Substring(4, 2);
                        string month = fileName.Trim().ToUpper().Replace(".CSV", "").Substring(2, 2);
                        string year = "20" + fileName.Trim().ToUpper().Replace(".CSV", "").Substring(0, 2);
                        string extractfinalDate = year + "-" + month + "-" + day;
                        //if (File.Exists(GlobalVariable.mSatoOutPut + "\\" + DateTime.Now.ToString("yyyyMMddHHmmss").ToString() + "_" + fileName)) { File.Delete(GlobalVariable.mSatoOutPut + "\\" + DateTime.Now.ToString("yyyyMMddHHmmss").ToString() + "_" + fileName); }
                        File.Copy(myfiles[iF].FullName, GlobalVariable.mSatoOutPut + "\\(02)" + DateTime.Now.ToString("yyyyMMddHHmmss").ToString() + "_" + fileName);
                        DataTable dt = CSVtoDataTable(myfiles[iF].FullName, ',');
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            try
                            {
                                if (Convert.ToInt32(dt.Rows[i][1].ToString().Trim()) == 0) { continue; }
                            }
                            catch (Exception ex)
                            {
                                GlobalVariable.AppLog.LogMessage(SatoLib.EventNotice.EventTypes.evtError
                                                         , "Serial Conversion Error" + ""
                                                    , ex.Message);
                                continue;
                            }
                            string time = dt.Rows[i][2].ToString().Split(' ')[1];
                            string finalDate = extractfinalDate + " " + time;
                            ExecuteTask("2", dt.Rows[i][0].ToString(), dt.Rows[i][1].ToString(), dt.Rows[i][2].ToString().Replace("/", "-"), "OK", extractfinalDate);
                            DataTable dtAllFile = CSVtoDataTableAllData(myfiles[iF].FullName, ',');
                            PL_MODEL obj = new PL_MODEL();
                            obj.Station = "2";
                            obj.FileNameDate = extractfinalDate;
                            obj.Columns01 = dtAllFile.Rows[i][0].ToString();
                            obj.Columns02 = dtAllFile.Rows[i][1].ToString();
                            obj.Columns03 = dtAllFile.Rows[i][2].ToString().Replace("/", "-");
                            obj.Columns04 = dtAllFile.Rows[i][3].ToString();
                            obj.Columns05 = dtAllFile.Rows[i][4].ToString();
                            obj.Columns06 = dtAllFile.Rows[i][5].ToString();
                            obj.Columns07 = dtAllFile.Rows[i][6].ToString();
                            obj.Columns08 = dtAllFile.Rows[i][7].ToString();
                            obj.Columns09 = dtAllFile.Rows[i][8].ToString();
                            obj.Columns10 = dtAllFile.Rows[i][9].ToString();
                            obj.Columns11 = dtAllFile.Rows[i][10].ToString();
                            obj.Columns12 = dtAllFile.Rows[i][11].ToString();
                            obj.Columns13 = dtAllFile.Rows[i][12].ToString();
                            obj.Columns14 = dtAllFile.Rows[i][13].ToString();
                            obj.Columns15 = dtAllFile.Rows[i][14].ToString();
                            obj.Columns16 = dtAllFile.Rows[i][15].ToString();
                            obj.Columns17 = dtAllFile.Rows[i][16].ToString();
                            obj.Columns18 = dtAllFile.Rows[i][17].ToString();
                            obj.Columns19 = dtAllFile.Rows[i][18].ToString();
                            obj.Columns20 = dtAllFile.Rows[i][19].ToString();
                            obj.Columns21 = dtAllFile.Rows[i][20].ToString();
                            ExecuteTaskAll(obj);
                        }
                        //FileDelete(item);
                    }



                }

                if (paramfileName != "")
                {
                    MessageBox.Show("Uploded Successfully!!!");
                    //return;
                }
            }
            catch (Exception ex)
            {

                GlobalVariable.AppLog.LogMessage(SatoLib.EventNotice.EventTypes.evtError
                                                    , "GetVCTPath2:: " + ""
                                               , ex.Message);
                string strprocess = "";
                if (paramfileName == "") { strprocess = "AUTO"; }
                if (paramfileName != "") { strprocess = "MANUAL"; }
                ExecuteTaskLogMessage(GlobalVariable.mLine, "02", strprocess, fileName, ex.Message);
                throw ex;
            }
            finally
            {
                Thread.Sleep(1000);

            }

        }





        /// <summary>
        /// Validation For Aplhanumerice
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>

        public bool IsAlphaNumeric(string str)
        {
            return (Regex.Match(str.Trim(), "^[a-zA-Z0-9-]*$").Success);
        }



    }
}
