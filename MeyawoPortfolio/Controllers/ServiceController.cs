using MeyawoPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeyawoPortfolio.Controllers
{
    public class ServiceController : Controller
    {
        DbMyPortfolioEntities db = new DbMyPortfolioEntities();
        public ActionResult Index()
        {
            var values = db.tblService.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateService()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateService(tblService service)
        {
            if (service.Title == null)
            {
                throw new Exception("Başlık Alanı Zorunludur");
            }
            if (service.Description == null)
            {
                throw new Exception("Açıklama Alanı Zorunludur");
            }
            if (service.ImageUrl == null)
            {
                throw new Exception("Resim Alanı Zorunludur");
            }
            db.tblService.Add(service);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateService(int id)
        {
            var service = db.tblService.Find(id);
            return View(service);
        }
        [HttpPost]
        public ActionResult UpdateService(tblService p)
        {
            var service = db.tblService.Find(p.ServiceID);
            service.Title= p.Title;
            service.Description= p.Description;
            service.ImageUrl= p.ImageUrl;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteService(int id)
        {
            var service = db.tblService.Find(id);
            db.tblService.Remove(service);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}