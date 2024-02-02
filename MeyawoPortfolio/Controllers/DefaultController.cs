using MeyawoPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeyawoPortfolio.Controllers
{
    public class DefaultController : Controller
    {
        DbMyPortfolioEntities db = new DbMyPortfolioEntities();
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult HeadPartial()
        {
            return PartialView();
        }
        public PartialViewResult NavbarPartial()
        {
            return PartialView();
        }
        public PartialViewResult HeaderPartial()
        {
            var values = db.tblFuture.ToList();
            return PartialView(values);
        }
       
        public PartialViewResult AboutPartial()
        {
            var values = db.tblAbout.ToList();
            return PartialView(values);
      
        }
        public PartialViewResult ServicePartial()
        {
            var values = db.tblService.ToList();
            return PartialView(values);
        }
        public PartialViewResult PortfolyoPartial()
        {
            var values = db.tblProject.ToList();
            return PartialView(values);
        }
        public PartialViewResult PricingPartial()
        {
            var values = db.tblPricing.ToList();
            return PartialView(values);
        }
        public PartialViewResult TestimonialPartial()
        {
            var values = db.tblTestimonial.ToList();
            return PartialView(values);
        }
        public PartialViewResult FooterPartial()
        {
            var values = db.tblSocialMedia.ToList();
            return PartialView(values);
        }
        public PartialViewResult ContactPartial()
        {
            return PartialView();
        }
    }
}