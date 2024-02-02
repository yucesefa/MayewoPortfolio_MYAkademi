using MeyawoPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeyawoPortfolio.Controllers
{
    public class PricingController : Controller
    {
        DbMyPortfolioEntities db = new DbMyPortfolioEntities();
        public ActionResult Index()
        {
            var values = db.tblPricing.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreatePricing()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreatePricing(tblPricing p)
        {
            db.tblPricing.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeletePricing(int id)
        {
            var value = db.tblPricing.Find(id);
            db.tblPricing.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdatePricing(int id)
        {
            var values = db.tblPricing.Find(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdatePricing(tblPricing p)
        {
            var values = db.tblPricing.Find(p.ID);
            values.Title = p.Title;
            values.Description = p.Description;
            values.Price = p.Price;
            values.PriceDescription = p.PriceDescription;
            values.ImageUrl = p.ImageUrl;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}