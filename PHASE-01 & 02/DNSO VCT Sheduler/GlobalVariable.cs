using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DENSOScheduler
{
    static class GlobalVariable
    {
        public static string mSatoApps = "SatoApps Scheduler";        
        //public static string[] mMailInterval=new string[5];
        public static ArrayList mBarcodeTempPartTime =new ArrayList();
        public static ArrayList mAllTempPartTime = new ArrayList();
        public static ArrayList mBarcodeCorrectionTime = new ArrayList();
        public static ArrayList mPackingTime = new ArrayList();
        public static ArrayList mPackingTimeDailyBasis = new ArrayList();
        public static ArrayList mFtpUploadTime = new ArrayList();
        public static ArrayList mUidMailTime = new ArrayList();
        public static ArrayList mUidDownloadTime = new ArrayList();
        public static string mAccessUser = "";
        public static string[] mMailId=new string[5];
        public static string mSqlConString = "";
        public static string mDbServer = "";
        public static string mDb = "";
        public static string mDbUser = "";
        public static string mDbPassword = "";
        public static string mAndonSqlConString = "";
        public static string mAndonDbServer = "";
        public static string mAndonDb = "";
        public static string mAndonDbUser = "";
        public static string mAndonDbPassword = "";
        public static string mSapServer = "";
        public static string mSapUser = "";
        public static string mSapPassword = "";
        public static string mSapClient = "";
        public static string mSapSysNo = "";
        public static string mSapLng = "";
        public static string mLotusDbLoc = "";
        public static string mSenderId = "";
        public static string mSenderPassword = "";
        public static string mSmtpHost = "";
        public static int mSmtpPort = 25;
        public static SatoLib.SatoLogger AppLog;
        public static bool boolPrepackArchive ;
        public static string ArchiveMessage = "";
        public static bool boolCompltion;
        public static bool boolTaskPackingTrans;
        public static int mVCTDataUploadTime = 0;
        public static string mLine = "";

        public static bool mErrorSendMail = false;
        public static bool mSendMail = false;
        public static bool mTempPartSendMail = false;
        public static bool mAppExit = false;

        public static bool mMsgFtpUpload = false;
        public static bool mMsgFtpDownload = false;
        public static bool boolTaskFtpUpload;
        public static bool boolTaskFtpDownload;
        public static string mUidRecptMailId = "";
 

        public static string mPrePackDb = "";
        public static string mSqlPrePackConString="";
        public static string mSatoOutPut = Application.StartupPath + @"\" + "SatoOutPut";
        
        public static string mVCTFolderPath1 = "";
        public static string mVCTFolderPath2 = "";

        // public static SAPLogonCtrl.Connection mSapConn;
    }
}
