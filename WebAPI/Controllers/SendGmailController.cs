using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAPI.Models;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class SendGmailController : Controller
    {
        // GET: SendGmail
        public ActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult Index(Email email)
        //{
        //    HttpClient hc = new HttpClient();
        //    hc.BaseAddress = new Uri("http://localhost:49497/api/email") ;

        //    var cweb = hc.PostAsJsonAsync<Email>("Email", email);
        //    cweb.Wait();

        //    var sendmail = cweb.Result;
        //    if (sendmail.IsSuccessStatusCode)
        //    {
        //        ViewBag.messege = "mail to " + email.To.ToString();
        //    }
        //    return View();
        //}

        public void Post([FromBody]Email email)
        {
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("http://localhost:49497/api/email");

            var cweb = hc.PostAsJsonAsync<Email>("Email", email);
            cweb.Wait();

            var sendmail = cweb.Result;
            if (sendmail.IsSuccessStatusCode)
            {
                ViewBag.messege = "mail to " + email.To.ToString();
            }
        }
    }
}