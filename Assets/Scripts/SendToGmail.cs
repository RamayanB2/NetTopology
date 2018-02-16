using UnityEngine;
using System.Collections;
using System;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

public class SendtoGmail
{
    //Funciona para mandar imagens localizadas na maquina para emails de gmail apenas
    //é PRECISO CRIAR UMA CONTA gmail nova só para fazer isso
    public void SendImageToGmail(string file_path)
    {
        MailMessage mail = new MailMessage();

         string attachmentPath = @file_path;
        System.Net.Mail.Attachment attachment = new System.Net.Mail.Attachment(attachmentPath);
        mail.Attachments.Add(attachment);

        mail.From = new MailAddress("NetTopology");
        mail.To.Add("ramayanb2@gmail.com");
        mail.Subject = "Test Mail";
        mail.Body = "This is for testing SMTP mail from GMAIL";

        SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
        smtpServer.Port = 587;
        smtpServer.Credentials = new System.Net.NetworkCredential("wolfmugengames@gmail.com", "Wmg123!@#") as ICredentialsByHost;
        smtpServer.EnableSsl = true;
        ServicePointManager.ServerCertificateValidationCallback =
            delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
            { return true; };
        smtpServer.Send(mail);
        Debug.Log("success");

    }
}