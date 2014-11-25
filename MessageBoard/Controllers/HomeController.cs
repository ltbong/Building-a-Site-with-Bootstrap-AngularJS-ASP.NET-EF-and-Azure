using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using MessageBoard.Models;
using MessageBoard.Services;

namespace MessageBoard.Controllers
{
    public class HomeController : Controller
    {
        private IMailService _mail;

        public HomeController(IMailService mailService)
        {
            _mail = mailService;
        }
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult Contact(ContactModel contactModel)
        {
            var svc = new MailService();
            var msg = string.Format("Comment From:  {1}{0}Email:{2}{0}Website:  {3}{0}Comment{4}{0}"
                , Environment.NewLine
                , contactModel.Name
                , contactModel.Email
                , contactModel.Website
                , contactModel.Comment);

            svc.SendMail("noreply@jjb.com", "someone@jjb.com", "Website Contact", msg);

            ViewBag.MailSent = true;

            if (_mail.SendMail("noreply@jjbl.com", "foo@jjb1.com", "Website Contract", msg))
            {
                ViewBag.MailSent = true;
            }

            return View();
        }

        [Authorize]
        public ActionResult MyMessages()
        {
            return View();
        }

        [Authorize]
        public ActionResult Moderation()
        {
            return View();
        }
    }
}
