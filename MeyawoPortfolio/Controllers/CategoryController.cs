using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MeyawoPortfolio.Models;
namespace MeyawoPortfolio.Controllers
{
    public class CategoryController : Controller
    {
        DbMyPortfolioEntities db = new DbMyPortfolioEntities();
        public ActionResult Index()
        {

            var values = db.tblCategory.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateCategory(tblCategory category)
        {
            if (category.CategoryName == null)
            {
                throw new Exception("Kategori Alanı Zorunludur");
            }
            db.tblCategory.Add(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            var category = db.tblCategory.Find(id);
            return View(category);
        }
        [HttpPost]
        public ActionResult UpdateCategory(tblCategory tblCategory)
        {
            var category = db.tblCategory.Find(tblCategory.CategoryID);
            category.CategoryName = tblCategory.CategoryName;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteCategory(int id)
        {
            var category = db.tblCategory.Find(id);
            db.tblCategory.Remove(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}