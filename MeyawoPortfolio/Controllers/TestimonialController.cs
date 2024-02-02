using MeyawoPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeyawoPortfolio.Controllers
{
    public class TestimonialController : Controller
    {
        DbMyPortfolioEntities db = new DbMyPortfolioEntities(); 
        public ActionResult Index()
        {
            var values = db.tblTestimonial.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateTestimonial()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateTestimonial(tblTestimonial testimonial)
        {
            if (testimonial.NameSurname == null)
            {
                throw new Exception("İsim Alanı Zorunludur");
            }
            if (testimonial.Description == null)
            {
                throw new Exception("Açıklama Alanı Zorunludur");
            }
            db.tblTestimonial.Add(testimonial);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateTestimonial(int id)
        {
            var testimonial = db.tblTestimonial.Find(id);
            return View(testimonial);
        }
        [HttpPost]
        public ActionResult UpdateTestimonial(tblTestimonial p)
        {
            var testimonial = db.tblTestimonial.Find(p.TestimonialID);
            testimonial.NameSurname = p.NameSurname;
            testimonial.Description = p.Description;
            testimonial.ImageUrl = p.ImageUrl;
            testimonial.Status = p.Status;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteTestimonial(int id)
        {
            var testimonial = db.tblTestimonial.Find(id);
            db.tblTestimonial.Remove(testimonial);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}