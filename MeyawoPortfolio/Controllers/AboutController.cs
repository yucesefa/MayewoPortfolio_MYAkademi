using MeyawoPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeyawoPortfolio.Controllers
{
    public class AboutController : Controller
    {
        DbMyPortfolioEntities db = new DbMyPortfolioEntities();
        public ActionResult Index()
        {

            var values = db.tblAbout.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateAbout()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateAbout(tblAbout about)
        {
            if (about.Title == null)
            {
                throw new Exception("Başlık Alanı Zorunludur");
            }
            if (about.Header == null)
            {
                throw new Exception("İsim Alanı Zorunludur");
            }
            if (about.Description == null)
            {
                throw new Exception("Açıklama Alanı Zorunludur");
            }
            db.tblAbout.Add(about);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateAbout(int id)
        {
            var about = db.tblAbout.Find(id);
            return View(about);
        }
        [HttpPost]
        public ActionResult UpdateAbout(tblAbout P)
        {
            var about = db.tblAbout.Find(P.AboutID);
            about.Title = P.Title;
            about.Header = P.Header;
            about.Description = P.Description ;
            about.ImageUrl = P.ImageUrl;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteAbout(int id)
        {
            var about = db.tblAbout.Find(id);
            db.tblAbout.Remove(about);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}