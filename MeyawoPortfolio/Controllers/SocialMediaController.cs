using MeyawoPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeyawoPortfolio.Controllers
{
    public class SocialMediaController : Controller
    {
        DbMyPortfolioEntities db = new DbMyPortfolioEntities();
        public ActionResult Index()
        {
            var values = db.tblSocialMedia.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateSocialMedia()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateSocialMedia(tblSocialMedia socialMedia)
        {
            if (socialMedia.Title == null)
            {
                throw new Exception("Başlık Alanı Zorunludur");
            }
            if (socialMedia.SocialMediaUrl == null)
            {
                throw new Exception("Link Alanı Zorunludur");
            }
            db.tblSocialMedia.Add(socialMedia);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateSocialMedia(int id)
        {
            var social = db.tblSocialMedia.Find(id);
            return View(social);
        }
        [HttpPost]
        public ActionResult UpdateSocialMedia(tblSocialMedia p)
        {
            var social = db.tblSocialMedia.Find(p.SocialMediaID);
            social.Title = p.Title;
            social.SocialMediaUrl = p.SocialMediaUrl;
            social.Icon = p.Icon;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteSocialMedia(int id)
        {
            var social = db.tblSocialMedia.Find(id);
            db.tblSocialMedia.Remove(social);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}