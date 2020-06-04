using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;
using System.Net.Mail;

namespace WebAPI.Controllers
{
    public class EmailController : ApiController
    {

        public IHttpActionResult SendMail(Email emailClass)
        {
            string subject = emailClass.Subject;
            string body = emailClass.Body;
            string to = emailClass.To;

            MailMessage mm = new MailMessage();
            mm.From = new MailAddress("altomis123@gmail.com");
            mm.To.Add(to);
            mm.Subject = subject;
            mm.Body = body;
            mm.IsBodyHtml = false;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.UseDefaultCredentials = true;
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.Credentials = new System.Net.NetworkCredential("altomis123@gmail.com", "Aa123456+");
            smtp.Send(mm);
            return Ok();
        }


    }
}
