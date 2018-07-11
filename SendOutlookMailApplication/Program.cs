using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace SendOutlookMailApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //Nuevo Correo
                MailMessage mM = new MailMessage();
                //Dirección de Correo del Remitente
                mM.From = new MailAddress("Correo_del_remitente");
                //Dirección de Correo del destinatario
                mM.To.Add("Correo_del_Destinatario");
                //Título del Correo
                mM.Subject = "Prueba de mensaje";
                //deciding for the attachment
                //mM.Attachments.Add(new Attachment(@"C:\\attachedfile.jpg"));
                //add the body of the email
                mM.Body = "Cuerpo del correo dinámico";
                mM.IsBodyHtml = true;
                //SMTP client
                SmtpClient sC = new SmtpClient("Dirección_del_servidor_SMTP");
                //port number for Hot mail
                //sC.Port = 25;
                //credentials to login in to hotmail account
                sC.Credentials = new NetworkCredential("Dirección_De_Correo_del_Remitente", "Contraseña_Del_Remitente", 
                    "Dirección_Del_Servidor_SMTP");
                //enabled SSL
                sC.EnableSsl = true;
                //Send an email
                ///ESTAS LINEAS SIRVEN PARA pasar la seguridad del servidor smtp
                ServicePointManager.ServerCertificateValidationCallback =
                    delegate (object s, X509Certificate certificate,
                             X509Chain chain, SslPolicyErrors sslPolicyErrors)
                    { return true; };
                
                sC.Send(mM);

                Console.WriteLine("Enviado");

            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }


            Console.WriteLine("fin");
            Console.ReadLine();


        }
    }
}
