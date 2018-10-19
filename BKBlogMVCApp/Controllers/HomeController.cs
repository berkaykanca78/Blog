using BKBlogMVCApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using System.Configuration;
using System.Net.Mail;

namespace BKBlogMVCApp.Controllers
{
    public class HomeController : Controller
    {
        private BlogContext context = new BlogContext();
        // GET: Home
        public ActionResult Index(int? PagedNo)
        {
            int pageIndex = PagedNo ?? 1;
            var bloglar = context.Bloglar
                                .Where(i => i.Onay == true && i.Anasayfa == true)
                                .OrderByDescending(i => i.Id)
                                .Select(i=>new BlogModel()
                                {
                                    Id=i.Id,
                                    Baslik =i.Baslik.Length>100?i.Baslik.Substring(0,100)+"...":i.Baslik,
                                    Aciklama=i.Aciklama,
                                    EklenmeTarihi=i.EklenmeTarihi,
                                    Anasayfa=i.Anasayfa,
                                    Onay=i.Onay,
                                    Resim=i.Resim
                                });
            var liste = bloglar.ToPagedList(pageIndex, 5);
            return View(liste);
        }

        // GET: Home
        [HttpGet]
        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Contact(EpostaModel model)
        {
            string server = ConfigurationManager.AppSettings["server"];
            int port = int.Parse(ConfigurationManager.AppSettings["port"]);
            bool ssl = ConfigurationManager.AppSettings["ssl"].ToString() == "1" ? true : false;
            string from = ConfigurationManager.AppSettings["from"];
            string password = ConfigurationManager.AppSettings["password"];
            string fromname = ConfigurationManager.AppSettings["fromname"];
            string to = ConfigurationManager.AppSettings["to"];
            string copyto = ConfigurationManager.AppSettings["epostacopy"];
            var client = new SmtpClient();
            client.Host = server;
            client.Port = port;
            client.EnableSsl = ssl;
            client.UseDefaultCredentials = true;
            client.Credentials = new System.Net.NetworkCredential(from, password);
            var email = new MailMessage();
            email.From = new MailAddress(from, fromname);
            email.To.Add(to);
            //email.To.Add("brkyknc@hotmail.com");

            if (string.IsNullOrEmpty(copyto) == false)
            {
                string[] mails = copyto.Split(',');
                foreach (var item in mails)
                {
                    email.Bcc.Add(item);
                }
            }

            email.Subject = model.konu;
            email.IsBodyHtml = true;
            email.Body = $"ad soyad : {model.adsoyad} \n konu: {model.konu} \n mesaj: {model.mesaj} \n eposta : {model.email} ";
            try
            {
                client.Send(email);
                ViewData["result"] = true;
            }
            catch (Exception)
            {
                ViewData["result"] = false;
            }
            return View();
        }
    }
}