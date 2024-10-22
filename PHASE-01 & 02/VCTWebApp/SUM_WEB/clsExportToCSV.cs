using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;

namespace VCTWebApp
{
    public class clsExportToCSV
    {
        private string Quote(string text)
        {
            if (text.Contains(",") || text.Contains("\"") || text.Contains("\n"))
            {
                text = "\"" + text.Replace("\"", "\"\"") + "\""; // Escape double quotes
            }
            return text;
        }
        public void ExportTOCSV(DataTable dt, string reportName)
        {
            try
            {
               

                StringBuilder sb = new StringBuilder();

                string[] columnNames = dt.Columns.Cast<DataColumn>().
                Select(column => column.ColumnName).
                ToArray();
                sb.AppendLine(string.Join(",", columnNames));

                HttpContext.Current.Response.Output.Write(sb.ToString());

                foreach (DataRow row in dt.Rows)
                {
                    sb = null;
                    sb = new StringBuilder();
                    IEnumerable<string> fields = row.ItemArray.Select(field =>
                    string.Concat("\"", field.ToString().Replace("\"", "\"\""), "\""));
                    string[] arr = fields.ToArray();
                    sb.AppendLine(string.Join(",", arr));

                    HttpContext.Current.Response.Output.Write(sb.ToString());
                }

                //File.WriteAllText("testReport.csv", sb.ToString());
                //HttpContext.Current.Response.Output.Write(sb.ToString());

                sb = null;
                //HttpContext.Current.Response.Flush();
                //HttpContext.Current.Response.End();
                // Clear or prevent caching
                //HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.Buffer = true;
                HttpContext.Current.Response.ContentType = "text/csv";
                HttpContext.Current.Response.AppendHeader("Content-Disposition",
                string.Format("attachment; filename={0}", reportName));
                HttpContext.Current.Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate"; // HTTP 1.1.
                HttpContext.Current.Response.Headers["Pragma"] = "no-cache"; // HTTP 1.0.
                HttpContext.Current.Response.Headers["Expires"] = "0"; // Proxies.
                HttpContext.Current.Response.Flush(); // Sends all currently buffered output to the client.
                HttpContext.Current.Response.SuppressContent = true;  // Gets or sets a value indicating whether to send HTTP content to the client.
                HttpContext.Current.ApplicationInstance.CompleteRequest(); // Causes ASP.NET to bypass all events and filtering in the HTTP pipeline chain of execution and directly execute the EndRequest event.
              
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void NewExportToCSB(DataTable dt, string reportName)
        {
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ContentType = "text/csv";
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=DataExport.csv");
            HttpContext.Current.Response.Write(dt);
            HttpContext.Current.Response.Flush();
            HttpContext.Current.Response.SuppressContent = true;  // Gets or sets a value indicating whether to send HTTP content to the client.
            HttpContext.Current.ApplicationInstance.CompleteRequest();
            //HttpContext.Current.Response.End();
        }

    }
}