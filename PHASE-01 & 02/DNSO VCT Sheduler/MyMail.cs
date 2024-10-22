using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net;
using System.Net.Mime;

namespace DENSOScheduler
{
    class MyMail
    {
        public void SendMail()
        {
            var fromAddress = new MailAddress("spdbarcode@heromotocorp.com", "From Name");
            var toAddress = new MailAddress("nishant0net@gmail.com", "To Name");
            const string fromPassword = "bcil@420";
            const string subject = "Subject";
            const string body = "Body";
            var smtp = new SmtpClient { Host = "pdchm201.hero-motocorp.com", Port = 1352, EnableSsl = true, DeliveryMethod = SmtpDeliveryMethod.Network, UseDefaultCredentials = false, Credentials = new NetworkCredential(fromAddress.Address, fromPassword) };
            using (var message = new MailMessage(fromAddress, toAddress) { Subject = subject, Body = body })
            { smtp.Send(message); }
        }
        public void SendMail1()
        {
            try
            {
                SmtpClient client = new SmtpClient("pdchm201.hero-motocorp.com", 25);
                MailMessage msg = new MailMessage("spdbarcode@heromotocorp.com", "nishant@barcodeindia.com,nishant0net@gmail.com");
                msg.Subject = "sdfdsf";
                msg.Body = "sdfsdfdsfd";
                client.UseDefaultCredentials = true;
                client.Send(msg);
            }
            catch (Exception)
            {

            }

        }
        public string SendMail(string SenderId
                               , string SenderPassword
                               , string RecptMailId
                               , string SmtpHost
                               , int SmtpPort
                               , string _Body
                               , ArrayList Attachments
                               , string sSubject
                               , string sCCRecptMailId
                               )
        {
            try
            {
                SmtpClient client = new SmtpClient(SmtpHost, SmtpPort);
                MailMessage msg = new MailMessage(SenderId, RecptMailId);
                if (!string.IsNullOrEmpty(sCCRecptMailId))
                {
                    msg.CC.Add(sCCRecptMailId);
                }
                //msg.From(SenderId);
                //msg.To(RecptMailId);
                msg.Subject = sSubject;
                foreach (string attach in Attachments)
                {
                    Attachment attached = new Attachment(attach, MediaTypeNames.Application.Octet);
                    msg.Attachments.Add(attached);
                }
                msg.Body = _Body;
                //client.UseDefaultCredentials = false ;
                //client.EnableSsl = true;
                //client.UseDefaultCredentials = true;
                //NetworkCredential nc= new NetworkCredential("dipak5pathak@gmail.com", "");
                // NetworkCredential netCredit = new NetworkCredential("p.khandelwal@yahoo.com", "pass#word1", "DOMAIN");

                //Get SMTP to authenticate the credentials
                //  client.Credentials = netCredit;
                //client.Credentials = nc;
              client.Send(msg);
                return "1";
            }
            catch (Exception ex)
            {
                GlobalVariable.AppLog.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "SatoApps" + "  ::  SendMail()  ", ex.Message);
                return "-1";
            }
        }
        public string SendMail(string SenderId
                                , string SenderPassword
                                , string RecptMailId
                                , string SmtpHost
                                , int SmtpPort
                                , string _Body
                                , ArrayList Attachments
                                , string sSubject
                                )
        {
            try
            {
                SmtpClient client = new SmtpClient(SmtpHost, SmtpPort);
                MailMessage msg = new MailMessage(SenderId, RecptMailId);
                //msg.From(SenderId);
                //msg.To(RecptMailId);
                msg.Subject = sSubject;
                if (Attachments != null)
                {
                    foreach (string attach in Attachments)
                    {
                        Attachment attached = new Attachment(attach, MediaTypeNames.Application.Octet);
                        msg.Attachments.Add(attached);
                    }
                }
                msg.Body = _Body;
                //client.UseDefaultCredentials = false ;
                //client.EnableSsl = true;
                //client.UseDefaultCredentials = true;
                //NetworkCredential nc= new NetworkCredential("dipak5pathak@gmail.com", "dipakp1234");
                // NetworkCredential netCredit = new NetworkCredential("p.khandelwal@yahoo.com", "pass#word1", "DOMAIN");

                //Get SMTP to authenticate the credentials
                //  client.Credentials = netCredit;
                //client.Credentials = nc;
                client.Send(msg);
                return "1";
            }
            catch (Exception ex)
            {
                GlobalVariable.AppLog.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "SatoApps" + "  ::  SendMail()  ", ex.Message);
                return "-1";
            }
        }


    }
}
