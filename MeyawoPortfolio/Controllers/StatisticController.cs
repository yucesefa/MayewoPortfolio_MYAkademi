using MeyawoPortfolio.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace MeyawoPortfolio.Controllers
{
    public class StatisticController : Controller
    {
        DbMyPortfolioEntities db = new DbMyPortfolioEntities();
        public ActionResult Index()
        {
            ViewBag.CategoryCount = db.tblCategory.Count();
            ViewBag.ProjectCount = db.tblProject.Count();
            ViewBag.MessageCount = db.tblContact.Count();
            ViewBag.AspProjectCount = db.tblProject.Where(x => x.ProjectCategory == 3).Count();
            ViewBag.isNotReadMessageCount = db.tblContact.Where(x => x.IsRead == false).Count();
            ViewBag.lastProjectName = db.LastProjectName().FirstOrDefault();
            ViewBag.SocialMediaCount = db.tblSocialMedia.Count();
            ViewBag.PricingCount = db.tblPricing.Count();
            ViewBag.FirstPricingProject=db.FirstPricing().FirstOrDefault();
            ViewBag.TestimonialCount = db.tblTestimonial.Count();
            ViewBag.MessageForFlutter = db.tblContact.Where(x => x.MessageCategory == 1).Count();
            return View();


        }
        
    }
}