using MeyawoPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeyawoPortfolio.Controllers
{
    public class FutureController : Controller
    {
        DbMyPortfolioEntities db = new DbMyPortfolioEntities();
        public ActionResult Index()
        {
            var values = db.tblFuture.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateFuture()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateFuture(tblFuture future)
        {
            if (future.NameSurname == null)
            {
                throw new Exception("İsim Alanı Zorunludur");
            }
            if (future.Header == null)
            {
                throw new Exception("Başlık Alanı Zorunludur");
            }
            db.tblFuture.Add(future);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateFuture(int id)
        {
            var future = db.tblFuture.Find(id);
            return View(future);
        }
        [HttpPost]
        public ActionResult UpdateFuture(tblFuture future)
        {
            var feature = db.tblFuture.Find(future.FutureID);
            feature.Header =future.Header;
            feature.NameSurname =future.NameSurname;
            feature.Title =future.Title;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteFuture(int id)
        {
            var future = db.tblFuture.Find(id);
            db.tblFuture.Remove(future);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}