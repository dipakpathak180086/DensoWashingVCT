using System;
using System.Collections.Generic;
using System.Web;
using System.Text;
using System.Linq;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;
using System.Web.Mail;
using System.IO;


/// <summary>
/// Summary description for CommonHelper
/// </summary>
public class CommonHelper
{
    public static SatoLib.SatoLogger mSatoLogger;
    public static decimal dOldMrp = 0;
    public static decimal dNewMrp = 0;
    public static string connString = "";
    public static string connStringLine01 = "";
    public static string connStringLine02 = "";
    public CommonHelper()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    /// <summary>
    /// Modified By : Naveen Kumar
    /// Added Functions for Input Tag Check and some validations
    /// </summary>
    /// <param name="msgID"></param>
    /// <returns></returns>
    #region Validations
   public static string path;
   public static string[] _strRights;
    public static DataTable dtPartMaster = new DataTable();
    public static DataTable dtPlant = new DataTable();
    public static DataTable dtWarehouse = new DataTable();
    public static DataTable dtLocationType = new DataTable();
    public static DataTable dtLine = new DataTable();
    public static DataTable dtProduct = new DataTable();
    public static DataTable dtCustomer = new DataTable();
    public static DataTable dtBindData = new DataTable();
    public static DataTable dtProductionType = new DataTable();
    public static DataTable dtLocation = new DataTable();
    public static StringBuilder sbSaveCount = new StringBuilder();
    public static StringBuilder sbDuplicateCount = new StringBuilder();
    public static DataTable dtCompany = new DataTable();
    public static DataTable ConvertCSVtoDataTable(string strFilePath)
    {
        DataTable dt = new DataTable();
        using (StreamReader sr = new StreamReader(strFilePath))
        {
            string[] headers = sr.ReadLine().Split(',');
            foreach (string header in headers)
            {
                dt.Columns.Add(header);
            }
            while (!sr.EndOfStream)
            {
                string[] rows = sr.ReadLine().Split(',');
                DataRow dr = dt.NewRow();
                for (int i = 0; i < headers.Length; i++)
                {
                    dr[i] = rows[i].Trim('"');
                }
                dt.Rows.Add(dr);
            }

        }


        return dt;
    }
    public static string GetRights(string _PageName, DataTable dtRights)
   {
       char _RtVw='0';
       char _RtSave='0';
       char  _RtEdit='0';
       char  _RtDlt='0';
       char  _RtExp='0';;
       var vrCountry = (from country in dtRights.AsEnumerable()
                        where country.Field<string>("MODULE_DESC") == _PageName
                        select country);
       var rows = vrCountry.ToList();
       if (rows.Count > 0)
       {
           _RtVw = rows[0][7].ToString() == "True" ? '1' : '0';
       }
        return (_RtVw + "^");
    }
	
    public static object insertDate(string s)
    {
        // Insert Date in yyyy.MM.dd format in database

        string strdate = null;
        string[] words = s.Split('/');
        string dd = null;
        string MM = null;
        string yyyy = null;
        dd = words[0];
        MM = words[1];
        yyyy = words[2];
        strdate = yyyy + "/" + MM + "/" + dd;
        return strdate;
    }


    public string getUniqueFileName(string filname, string filepath, string fileNameWithoutExt, string ext)
    {

        int DotPosition = filname.IndexOf(".");

        string NewFileName = filname.Replace(" ","");

        int Counter = 0;

        // int FullPath = 0;

        if ((System.IO.File.Exists(filepath + "/" + NewFileName)))
        {

            while (((System.IO.File.Exists(filepath + "/" + NewFileName))))
            {

                Counter = Counter + 1;

                NewFileName = fileNameWithoutExt + "(" + Counter + ")";

                NewFileName = NewFileName + ext;

            }

        }

        else
        {

            NewFileName = fileNameWithoutExt + ext;

        }

        return NewFileName;

    }




    public static string RemoveUnnecessaryHtmlTagHtml1(string html)
    {



        //Dim acceptable As String = "link|title|p|br|a|div|font|table|tr|td|tbody|&nbsp;|b|center|col|li|ui|ol"



        string acceptable = "b|u|sup|sub|ol|ul|li|br|h2|h3|h4|h5|h6|head|hr|link|p|table|tbody|tr|td|tfoot|th|thead|title|id|style|class|span|div|p|a|img|blockquote|center|col|font";



        string stringPattern = "</?(?(?=" + acceptable + ")notag|[a-zA-Z0-9]+)(?:\\s[a-zA-Z0-9\\-]+=?(?:([\",']?).*?\\1?)?)*\\s*/?>";



        return Regex.Replace(html, stringPattern, "");



    }

    public static string RemoveUnnecessaryHtmlTagHtml(string html)
    {
        string html1 = RemoveHtmlEvent(html);
        
        string acceptable = "b|u|sup|sub|ol|ul|li|br|h2|h3|h4|h5|h6|head|hr|link|p|table|tbody|tr|td|tfoot|th|thead|title|id|style|class|span|div|p|a|img|blockquote|center|col|font";
        string stringPattern = "</?(?(?=" + acceptable + ")notag|[a-zA-Z0-9]+)(?:\\s[a-zA-Z0-9\\-]+=?(?:([\",']?).*?\\1?)?)*\\s*/?>";
        return Regex.Replace(html1, stringPattern, "");
    }
    public bool SendEmail(string To, string Cc,string Bcc, string Subject, string From, string Msg)// send mail 
    {
        try
        {
            MailMessage objMail = new MailMessage();
            objMail.To = To;
            objMail.Cc = Cc;
            objMail.Bcc = Bcc;
            objMail.Subject = Subject;
            //if (From != string.Empty)
            //{
            objMail.From = From;
            //}
            //else
            //{
            //    objMail.From = "mani.bhushan@netcreativemind.co.in";
            //}
            objMail.BodyFormat = MailFormat.Html;
            objMail.Body = Msg;

            System.Web.Mail.SmtpMail.SmtpServer = ConfigurationManager.AppSettings["SMTPSERVER"].ToString();// server name 

            SmtpMail.Send(objMail);
            return true;
        }
        catch (Exception e3)
        {
            return false;
        }


    }


    public static string splittimefromdate(string textboxvalue)
    {
        string[] firstsplist = textboxvalue.Split(' ');
        string date = firstsplist[0].ToString();
        string[] secondsplit = date.Split('/');
        string mm = secondsplit[0].ToString();
        if (Convert.ToInt32(mm) < 10)
        {
            mm = '0' + mm;
        }
        string dd = secondsplit[1].ToString();
        if (Convert.ToInt32(dd) < 10)
        {
            dd = '0' + dd;
        }
        string yyyy = secondsplit[2].ToString();


        return (dd + '/' + mm + '/' + yyyy);
    }


    public static string splittimefromdate2(string textboxvalue)
    {
        string[] firstsplist = textboxvalue.Split(' ');
        string date = firstsplist[0].ToString();
        string[] secondsplit = date.Split('/');
        string mm = secondsplit[0].ToString();
        if (Convert.ToInt32(mm) < 10)
        {
            mm = '0' + mm;
        }
        string dd = secondsplit[1].ToString();
        if (Convert.ToInt32(dd) < 10)
        {
            dd = '0' + dd;
        }
        string yyyy = secondsplit[2].ToString();
        string datefortextbox = dd + '/' + mm + '/' + yyyy;

        string time = firstsplist[1];
        string[] time1 = time.Split(':');
        string hrs = time1[0].ToString();
        string min = time1[1].ToString();

        string timeformate = firstsplist[2];

        if (timeformate.Equals("AM"))
        {
            return datefortextbox + " " + hrs + " " + min + " " + "1";
        }
        else
        {
            return (datefortextbox + " " + hrs + " " + min + " " + "2");
        }
    }


  
    public static string RemoveHtmlEvent(string htm)
    {
        string removableEvent = "onblur|onclick|ondatabinding|ondblclick|ondisposed|onfocus|oninit|onkeydown|onkeypress|onkeyup|onload|onmousedown|onmousemover|onmouseout|onmouseover|onmouseup|onprerender|onserverclick|onunload|document.getElementById()|document.getElementsByName()|document.documentElement()|document.createComment()|document.createDocumentFragment()|document.createElement()|document.createTextNode()|document.writeln()|document.write()|alert()";
        return Regex.Replace(htm, removableEvent, "");
    }

    public static string ReplaceUrl(string Url)
    {

        string[] Old = { "<", ">", "onmouseover", "onmousedown", "onkeyup", "alert", "onblur", "onclick", "ondatabinding", "ondblclick", "ondisposed", "onfocus", "oninit", "onkeydown", "onkeypress", "onkeyup", "onload", "onmousedown", "onmousemove", "onmouseout", "onmouseover", "onmouseup", "onprerender", "onserverclick", "onunload", "(", ")", "()", "document.getElementById()", "document.getElementsByName()", "document.documentElement()", "document.createComment()", "document.createDocumentFragment()", "document.createElement()", "document.createTextNode()", "document.writeln()", "document.write()", "alert()" };

        string[] New = { "!@#$%^&", "!@#$%^&", "!@#$%^&", "!@#$%^&", "!@#$%^&", "!@#$%^&", "!@#$%^&", "!@#$%^&", "!@#$%^&", "!@#$%^&", "!@#$%^&", "!@#$%^&", "!@#$%^&", "!@#$%^&", "!@#$%^&", "!@#$%^&", "!@#$%^&", "!@#$%^&", "!@#$%^&", "!@#$%^&", "!@#$%^&", "!@#$%^&", "!@#$%^&", "!@#$%^&", "!@#$%^&", "!@#$%^&", "!@#$%^&", "!@#$%^&", "!@#$%^&", "!@#$%^&", "!@#$%^&", "!@#$%^&", "!@#$%^&", "!@#$%^&", "!@#$%^&", "!@#$%^&", "!@#$%^&", "!@#$%^&" };

        string url1 = strReplace(HttpContext.Current.Request.Url.ToString(), Old, New);

        return url1;

    }

    public static string strReplace(string str, string[] Old, string[] New)
    {

        for (int i = 0; i < Old.Length; i++)
        {

            if (i < New.Length)
            {

                str = str.Replace(Old[i], New[i]);

            }

        }

        return str;

    }
    #endregion
    public static void ExportDataInCSV(string filepath, DataTable _dt)
    {
        string _FileName = string.Empty;
        //SaveFileDialog sdb = new SaveFileDialog();
        //sdb.InitialDirectory = @"C:\";
        //sdb.Title = "Save text Files";
        //if (sdb.ShowDialog() == DialogResult.OK)
        //    _FileName = sdb.FileName;
        //else
        //    return;
        StreamWriter _sWriter = new StreamWriter(filepath);
        string _sData = "";
        try
        {

            for (int i = 0; i < _dt.Columns.Count; i++)
            {
                if (_sData == "")
                    _sData = _dt.Columns[i].ColumnName.ToString().ToUpper();
                else
                    _sData = _sData + "," + _dt.Columns[i].ColumnName.ToString().ToUpper();
            }
            _sWriter.WriteLine(_sData);

            for (int i = 0; i < _dt.Rows.Count; i++)
            {
                _sData = "";
                for (int j = 0; j < _dt.Columns.Count; j++)
                {
                    if (_sData == "")
                        _sData = _dt.Rows[i][j].ToString().ToUpper().Replace(",", "").Replace("\t", "").Replace("\n", "").Trim();
                    else
                        _sData = _sData + "," + _dt.Rows[i][j].ToString().ToUpper().Replace(",", "").Replace("\t", "").Replace("\n", "").Trim();
                }
                _sWriter.WriteLine(_sData);
            }
           // Response.Write("<script>alert('Data exported successfully );</script>");
            //MessageBox.Show(" " + filepath + "", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }

        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            _sWriter.Close();
            _sWriter.Dispose();
        }
    }

    public static string EncryptPassword(string lPass, string Ltype)
    {
        string str1 = string.Empty;
        string str2 = string.Empty;
        int k = lPass.Length;
        str2 = "BCILBCILBCILBCILBCILBCIL";
        for (int i = 0; i < k; i++)
        {
            char ch1 = Convert.ToChar(lPass.Substring(i, 1));
            char ch2 = Convert.ToChar(str2.Substring(i, 1));
            if (Ltype == "E")
            {
                Encoding encoding1 = Encoding.GetEncoding(1252);
                int j = ch1 + ch2 + i;

                string str3 = encoding1.GetString(new byte[] { Convert.ToByte(j) });
                str1 = string.Concat(str1, str3);
            }
            else
            {
                int j = Encoding.GetEncoding(1252).GetBytes(new char[] { Convert.ToChar(ch1) })[0] - ch2 - i;

                str1 = string.Concat(str1, (ushort)j);
            }
        }
        return str1;
    }

    public static string GetMessage(string msgID)
    {
        string strMsg = string.Empty;
        try
        {
            DataSet ds = new DataSet();
            ds.ReadXml(GetXMLFileName());
            DataView dv = ds.Tables[0].DefaultView;
            dv.RowFilter = "msgID='" + msgID + "'";
            if (dv.ToTable().Rows.Count > 0)
            {
                strMsg = "[ "+dv.ToTable().Rows[0]["msgCode"].ToString() + " ]  -  " + dv.ToTable().Rows[0]["msgDesc"].ToString();
            }
            ds.Dispose();
        }
        catch (Exception ex)
        {
            throw;
        }
        return strMsg;
    }
    public static string GetXMLFileName()
    {
        return null;
        //HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["MsgFile"].ToString());
    }
    public static string SqlDateFormat(string strDate)
    {
        DateTime sDate = new DateTime();
        if (IsDateTime(strDate))
        {
            if (!string.IsNullOrEmpty(strDate))
            {
                bool suc = DateTime.TryParse(strDate, out sDate);
                if (!suc)
                {
                    sDate = Convert.ToDateTime(strDate.Split('/')[1] + "/" + strDate.Split('/')[0] + "/" + strDate.Split('/')[2]);
                }
            }
        }
        return sDate.ToString("MM/dd/yyyy");
    }
    public static string SqlDateTimeFormat(string strDate)
    {
        DateTime sDate = new DateTime();
        if (IsDateTime(strDate))
        {
            bool suc = DateTime.TryParse(strDate, out sDate);
            if (!suc)
            {
                sDate = Convert.ToDateTime(strDate.Split(' ')[0].Split('/')[1] + "/" + strDate.Split(' ')[0].Split('/')[0] + "/" + strDate.Split(' ')[0].Split('/')[2] + strDate.Split(' ')[1]);
            }
            else
            {
               string stempdate= sDate.ToString("MM/dd/yyyy hh:mm:ss");
               return stempdate;
            }
        }
        return sDate.ToString("MM/dd/yyyy hh:mm:ss").Replace("01/01/0001 00:00:00","Null");
    }
    public static bool IsDateTime(string txtDate)
    {
        DateTime tempDate;

        return DateTime.TryParse(txtDate, out tempDate) ? true : false;
    }
    public static bool IsAmount(string str)
    {
        return System.Text.RegularExpressions.Regex.IsMatch( str, @"^-?\d+([\.]{1}\d*)?$");
    }
    public static void DisabledAutoComplete()
    {
        // write in form tag for globle
    }
    public bool IngnorSpecialChar(TextBox txt)
    {
        bool msg = false;
        string strchar = "`~!@#$%^&*()_-+=;'<>";
        if (!txt.Text.Contains(strchar))
        {
            msg = true;
        }
        return msg;
    }
     
    public bool IngnorSpecialChar(DropDownList ddl)
    {
        bool msg = false;
        string strchar = "`~!@#$%^&*()_-+=;'<>";
        if (!ddl.Text.Contains(strchar))
        {
            msg = true;
        }
        return msg;
    }

    public string CreateDynamicQuery()
    {
        string TableName = "EmployeeMaster";

        List<string> columns = new List<string>();
        columns.Add("EmpId");
        columns.Add("EmpName");
        columns.Add("EmpLocation");
        columns.Add("EmpAddressID");

        //With Where Condition
        Dictionary<string, string> wherecondition = new Dictionary<string, string>();
        wherecondition.Add("EmpId", "1001");
        wherecondition.Add("DeptId", "HR1");

        //you can comment the above wherecondition.Add(); and pass empty Dictionary<string,string> for Without whereCondition
        //Also validate TableName

        return DynamicSelectSQL(columns, TableName, wherecondition);
    }

   string DynamicSelectSQL(List<string> NoofColumns, string TableName, Dictionary<string, string> WhereCondition)
    {
        string SqlQuery = string.Empty;

        if (NoofColumns.Count == 0)
            return null; //Columns are not supplied

        SqlQuery += "select ";

        foreach (string key in NoofColumns)
        {
            SqlQuery += key + ",";
        }

        SqlQuery = SqlQuery.Remove(SqlQuery.Length - 1);
        SqlQuery += " from " + TableName;

        if (WhereCondition.Count == 0)
            return SqlQuery;

        SqlQuery += " where ";
        foreach (KeyValuePair<string, string> key in WhereCondition)
        {
            SqlQuery += key.Key + " = '" + key.Value + "'" + " and ";
        }

        SqlQuery = SqlQuery.Remove(SqlQuery.LastIndexOf("and"));

        return SqlQuery;
    }
   string DynamicInsertSQL(List<string> NoofColumns, string TableName, Dictionary<string, string> WhereCondition)
   {
       string SqlQuery = string.Empty;

       if (NoofColumns.Count == 0)
           return null; //Columns are not supplied

       SqlQuery += " Insert ";

       foreach (string key in NoofColumns)
       {
           SqlQuery += key + ",";
       }

       SqlQuery = SqlQuery.Remove(SqlQuery.Length - 1);
       SqlQuery += " from " + TableName;

       if (WhereCondition.Count == 0)
           return SqlQuery;

       SqlQuery += " where ";
       foreach (KeyValuePair<string, string> key in WhereCondition)
       {
           SqlQuery += key.Key + " = '" + key.Value + "'" + " and ";
       }

       SqlQuery = SqlQuery.Remove(SqlQuery.LastIndexOf("and"));

       return SqlQuery;
   }
   string DynamicUpdateSQL(List<string> NoofColumns, string TableName, Dictionary<string, string> WhereCondition)
   {
       string SqlQuery = string.Empty;

       if (NoofColumns.Count == 0)
           return null; //Columns are not supplied

       SqlQuery += "select ";

       foreach (string key in NoofColumns)
       {
           SqlQuery += key + ",";
       }

       SqlQuery = SqlQuery.Remove(SqlQuery.Length - 1);
       SqlQuery += " from " + TableName;

       if (WhereCondition.Count == 0)
           return SqlQuery;

       SqlQuery += " where ";
       foreach (KeyValuePair<string, string> key in WhereCondition)
       {
           SqlQuery += key.Key + " = '" + key.Value + "'" + " and ";
       }

       SqlQuery = SqlQuery.Remove(SqlQuery.LastIndexOf("and"));

       return SqlQuery;
   }
   string DynamicDeleteSQL(List<string> NoofColumns, string TableName, Dictionary<string, string> WhereCondition)
   {
       string SqlQuery = string.Empty;

       if (NoofColumns.Count == 0)
           return null; //Columns are not supplied

       SqlQuery += "select ";

       foreach (string key in NoofColumns)
       {
           SqlQuery += key + ",";
       }

       SqlQuery = SqlQuery.Remove(SqlQuery.Length - 1);
       SqlQuery += " from " + TableName;

       if (WhereCondition.Count == 0)
           return SqlQuery;

       SqlQuery += " where ";
       foreach (KeyValuePair<string, string> key in WhereCondition)
       {
           SqlQuery += key.Key + " = '" + key.Value + "'" + " and ";
       }

       SqlQuery = SqlQuery.Remove(SqlQuery.LastIndexOf("and"));

       return SqlQuery;
   }

   public static bool CheckSessionAlive()
   {
       bool msg = true;
       if (HttpContext.Current.Session["username"] == null)
       {
           msg = false;
       }
       return msg;
   }


    /// <summary>
    /// Generate random digit code
    /// </summary>
    /// <param name="length">Length</param>
    /// <returns>Result string</returns>
    public static string GenerateRandomDigitCode(int length)
    {
        var random = new Random();
        string str = string.Empty;
        for (int i = 0; i < length; i++)
            str = String.Concat(str, random.Next(10).ToString());
        return str;
    }
    /// <summary>
    /// Gets query string value by name
    /// </summary>
    /// <param name="name">Parameter name</param>
    /// <returns>Query string value</returns>
    public static string QueryString(string name)
    {
        string result = string.Empty;
        if (HttpContext.Current != null && HttpContext.Current.Request.QueryString[name] != null)
            result = HttpContext.Current.Request.QueryString[name].ToString();
        return result;
    }
    public static void ShowMessage(string msg,string sClientID)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("<script type='text/javascript'>");
        sb.Append("alert("+msg+");");
        if (sClientID != string.Empty)
        {
            sb.Append("document.getElementByID('" + sClientID + "').focus();");
        }
        sb.Append("</script>");
        HttpContext.Current.Response.Write(sb.ToString());

    }
    public enum MessageType
    {
        Info,
        Success,
        Warning,
        Error
    }
    public static void HideMessage(HtmlGenericControl msginfo,HtmlGenericControl msgsuccess,HtmlGenericControl msgwarning,HtmlGenericControl msgerror)
    {
        msginfo.InnerHtml = "";
        msginfo.Style.Add("display", "none");
        msgsuccess.InnerHtml = "";
        msgsuccess.Style.Add("display", "none");
        msgwarning.InnerHtml = "";
        msgwarning.Style.Add("display", "none");
        msgerror.InnerHtml = "";
        msgerror.Style.Add("display", "none");
    }
    public static void ShowMessage(string msg, HtmlGenericControl sMsgPlaceHolder,string sType,WebControl FocusControl)
    {
        if (sMsgPlaceHolder != null)
        {
            sMsgPlaceHolder.InnerHtml = "";
            StringBuilder sb = new StringBuilder();

            sb.Append("<button type='button' class='close' data-dismiss='alert' aria-hidden='true'> &times;</button>");
             
            switch (sType)
            {
                case "Info":
                    sb.Append("<h4> <i class='icon fa fa-info'></i>Alert!</h4> ");
                    sb.AppendLine(msg);
                    HtmlGenericControl msginfo = new HtmlGenericControl();
                    msginfo.Style.Add("display", "");
                    //sb.AppendLine("</div>");
                    // setTimeout 
                    break;
                case "Success":
                    sb.Append("<h4> <i class='icon fa fa-check'></i>Alert!</h4>\n");
                    sb.AppendLine(msg);
                    //sb.AppendLine("</div>");
                    break;
                case "Warning":
                    sb.Append("<h4> <i class='icon fa fa-warning'></i>Alert!</h4> ");
                    sb.AppendLine(msg);
                    //sb.AppendLine("</div>");
                    break;
                case "Error":
                    sb.Append("<h4> <i class='icon fa fa-ban'></i>Alert!</h4> ");
                    sb.AppendLine(msg);
                    //sb.AppendLine("</div>");
                    break;
            }
            sMsgPlaceHolder.Style.Add("display", "");
            sMsgPlaceHolder.InnerHtml = sb.ToString();
            FocusControl.Focus();
            sb.Length = 0;
        }
    }
    public static void ShowMessage(string msg, HtmlGenericControl sMsgPlaceHolder, string sType)
    {
        if (sMsgPlaceHolder != null)
        {
            sMsgPlaceHolder.InnerHtml = "";
            StringBuilder sb = new StringBuilder();

            sb.Append("<button type='button' class='close' data-dismiss='alert' aria-hidden='true'> &times;</button>");
             
            switch (sType)
            {
                case "Info":
                    sb.Append("<h4> <i class='icon fa fa-info'></i>Alert!</h4> ");
                    sb.AppendLine(msg);
                    HtmlGenericControl msginfo = new HtmlGenericControl();
                    msginfo.Style.Add("display", "");
                    //sb.AppendLine("</div>");
                    // setTimeout 
                    break;
                case "Success":
                    sb.Append("<h4> <i class='icon fa fa-check'></i>Alert!</h4> ");
                    sb.AppendLine(msg);
                    //sb.AppendLine("</div>");
                    break;
                case "Warning":
                    sb.Append("<h4> <i class='icon fa fa-warning'></i>Alert!</h4> ");
                    sb.AppendLine(msg);
                    //sb.AppendLine("</div>");
                    break;
                case "Error":
                    sb.Append("<h4> <i class='icon fa fa-ban'></i>Alert!</h4> ");
                    sb.AppendLine(msg);
                    //sb.AppendLine("</div>");
                    break;
            }
            sMsgPlaceHolder.Style.Add("display", "");

            sMsgPlaceHolder.InnerHtml = sb.ToString();
            
            sb.Length = 0;
        }
    }
    public static void ShowMessageWithUpdatePanel(string msg, HtmlGenericControl sMsgPlaceHolder, string sType)
    {
        if (sMsgPlaceHolder != null)
        {
            sMsgPlaceHolder.InnerHtml = "";
            StringBuilder sb = new StringBuilder();

            sb.Append("<button type='button' class='close' data-dismiss='alert' aria-hidden='true'> &times;</button>");

            switch (sType)
            {
                case "Info":
                    sb.Append("<h4> <i class='icon fa fa-info'></i>Alert!</h4> ");
                    sb.AppendLine(msg);
                    HtmlGenericControl msginfo = new HtmlGenericControl();
                    msginfo.Style.Add("display", "");
                    //sb.AppendLine("</div>");
                    // setTimeout 
                    break;
                case "Success":
                    sb.Append("<h4> <i class='icon fa fa-check'></i>Alert!</h4> ");
                    sb.AppendLine(msg);
                    //sb.AppendLine("</div>");
                    break;
                case "Warning":
                    sb.Append("<h4> <i class='icon fa fa-warning'></i>Alert!</h4> ");
                    sb.AppendLine(msg);
                    //sb.AppendLine("</div>");
                    break;
                case "Error":
                    sb.Append("<h4> <i class='icon fa fa-ban'></i>Alert!</h4> ");
                    sb.AppendLine(msg);
                    //sb.AppendLine("</div>");
                    break;
            }
            sMsgPlaceHolder.Style.Add("display", "");

            sMsgPlaceHolder.InnerHtml = sb.ToString();

            sb.Length = 0;

        }
    }
    public static  string Encryp(string sPlainText)
    {
        byte[] Bytes = System.Text.Encoding.Unicode.GetBytes(sPlainText);
        string encryptData= Convert.ToBase64String(Bytes);
        return encryptData;
    }

    public static string Decrypt(string sEncryptedText)
    {
        byte[] Byte = Convert.FromBase64String(sEncryptedText);
        string originalData = System.Text.Encoding.Unicode.GetString(Byte);
        return originalData;
    }

    public static void BindDropDown(DropDownList DDL,DataTable DT)
    {
        if (DT.Rows.Count > 0)
        {
            DataRow dr = DT.NewRow();
            dr[0] = "0";
            dr[1] = "";
            DT.Rows.InsertAt(dr, 0);
            DDL.DataTextField = DT.Columns[1].ToString();
            DDL.DataValueField = DT.Columns[0].ToString();
            DDL.DataSource = DT;
            DDL.DataBind();
            DDL.SelectedIndex = 0;
        }
        
    }
    public static void BindDropDown(DropDownList DDL, DataTable DT, string value, string text)
    {
        if (DT.Rows.Count > 0)
        {
            DataRow dr = DT.NewRow();
            dr[0] = "";
            dr[1] = "";
            DT.Rows.InsertAt(dr, 0);
            DDL.DataTextField = text;
            DDL.DataValueField = value;
            DDL.DataSource = DT;
            DDL.DataBind();
            DDL.SelectedIndex = 0;
        }
       
    }

    public static void BindDropDownWithoutEmptyField(DropDownList DDL, DataTable DT, string value, string text)
    {
        if (DT!=null && DT.Rows.Count > 0)
        {
            DDL.DataTextField = text;
            DDL.DataValueField = value;
            DDL.DataSource = DT;
            DDL.DataBind();
            DDL.SelectedIndex = -1;
        }
        else
        {
            DDL.DataSource = null;
            DDL.SelectedIndex = -1;
        }
    }

    public static void BindGrid(GridView grd, DataTable DT)
    {
        grd.DataSource = null;
        grd.DataSource = DT;
        grd.DataBind();
    }

    public static DataTable GetPermission(string PageName)
    {
        DataTable DT = new DataTable();


        return DT;
    
    }


    public static string GetRFID_Tag_No(string _GateName)
    {
        string _RFID_TAG_NO = string.Empty;
        string _RFID_TAG_SR_NO = string.Empty;
        try
        {


            StringBuilder sb = new StringBuilder();

            sb.AppendLine(" select TAGID,RFID_TAG_NO,GATE from T_RFID_TAG where GATE='" + _GateName + "' ");
            Datautility DU = new Datautility();
            DataTable DT = DU.GetDataTable(sb.ToString());

            if (DT.Rows.Count > 0)
            {
                _RFID_TAG_NO = DT.Rows[0]["RFID_TAG_NO"].ToString();

                if (_RFID_TAG_NO != string.Empty)
                {
                    sb.Length = 0;
                    sb.AppendLine(" select id,RFID_NO from M_RFID_TAG where RFID_TAG_NO='" + _RFID_TAG_NO + "' AND DEPOTID='" + HttpContext.Current.Session["DEPOTID"].ToString() + "' ");
                   
                    DataTable DT_Tag = DU.GetDataTable(sb.ToString());
                    if (DT_Tag.Rows.Count > 0)
                    {
                        _RFID_TAG_SR_NO = DT_Tag.Rows[0]["RFID_NO"].ToString();
                    }
                    else
                    {
                        _RFID_TAG_SR_NO = "Exception - RFID TAG not found in mapping table  ";
                    }
                     
                }

                sb.Length = 0;
                sb.AppendLine(" delete from T_RFID_TAG where GATE='" + _GateName + "' AND RFID_TAG_NO='" + _RFID_TAG_NO + "' ");
                DU.ExecuteSQL(sb.ToString());
               

                DU._CloseConnection();
                DU.Dispose();

            }
            else
            {
                _RFID_TAG_SR_NO = "Exception - Please Scan RFID TAG ";
            }
        }
        catch (Exception ex)
        {
            _RFID_TAG_SR_NO = ex.ToString();
            CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "DNH" + "  ::  RcvReceivingGateEntry btnGetRfidTagNo_Click() ", " User-  " + ex.Message);
            throw ex;
        }

        return _RFID_TAG_SR_NO;
    }

    public static string GetWeightFromMachine()
    {
        string _Weight = string.Empty;
        try
        {


            StringBuilder sb = new StringBuilder();

            sb.AppendLine(" select WEIGHT from T_WEIGHBRIDGE_WEIGHT  ");
            Datautility DU = new Datautility();
            DataTable DT = DU.GetDataTable(sb.ToString());

            if (DT.Rows.Count > 0)
            {
                _Weight = DT.Rows[0]["WEIGHT"].ToString();

                sb.Length = 0;
                sb.AppendLine(" delete from T_WEIGHBRIDGE_WEIGHT ");
                DU.ExecuteSQL(sb.ToString());

                DU._CloseConnection();
                DU.Dispose();
            }
            else
            {
                _Weight = "0";
            }
        }
        catch (Exception ex)
        {
            _Weight = ex.ToString();
            CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "DNH" + "  ::  COMMON CLASS GetWeightFromMachine() ", " User-  " + ex.Message);
            throw ex;
        }

        return _Weight;
    }


    public static string Encryptdata(string password)
    {
        string strmsg = string.Empty;
        byte[] encode = new byte[password.Length];
        encode = Encoding.UTF8.GetBytes(password);
        strmsg = Convert.ToBase64String(encode);
        return strmsg;
    }
    public static string Decryptdata(string encryptpwd)
    {
        string decryptpwd = string.Empty;
        UTF8Encoding encodepwd = new UTF8Encoding();
        Decoder Decode = encodepwd.GetDecoder();
        byte[] todecode_byte = Convert.FromBase64String(encryptpwd);
        int charCount = Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
        char[] decoded_char = new char[charCount];
        Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
        decryptpwd = new String(decoded_char);
        return decryptpwd;
    }

    public static string EncodePasswordToBase64(string password)
    {
        try
        {
            byte[] encData_byte = new byte[password.Length];
            encData_byte = System.Text.Encoding.UTF8.GetBytes(password);
            string encodedData = Convert.ToBase64String(encData_byte);
            return encodedData;
        }
        catch (Exception ex)
        {
            throw new Exception("Error in base64Encode" + ex.Message);
        }
    }
    //this function Convert to Decord your Password
    public static string DecodeFrom64(string encodedData)
    {
        System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
        System.Text.Decoder utf8Decode = encoder.GetDecoder();
        byte[] todecode_byte = Convert.FromBase64String(encodedData);
        int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
        char[] decoded_char = new char[charCount];
        utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
        string result = new String(decoded_char);
        return result;
    }


}
