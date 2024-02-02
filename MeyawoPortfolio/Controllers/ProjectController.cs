using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MeyawoPortfolio.Models;
namespace MeyawoPortfolio.Controllers
{
    public class ProjectController : Controller
    {
        DbMyPortfolioEntities db = new DbMyPortfolioEntities();
        public ActionResult Index()
        {
            var values = db.tblProject.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateProject()
        {
            List<SelectListItem> values = (from x in db.tblCategory.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()
                                           }).ToList();
            ViewBag.v = values;
            return View();
        }
        [HttpPost]
        public ActionResult CreateProject(tblProject project)
        {
            if (project.Title == null)
            {
                throw new Exception("Başlık Alanı Zorunludur");
            }
            if (project.Description == null)
            {
                throw new Exception("Açıklama Alanı Zorunludur");
            }
            if (project.ImageUrl == null)
            {
                throw new Exception("Resim Alanı Zorunludur");
            }
            if (project.ProjectUrl == null)
            {
                throw new Exception("Link Alanı Zorunludur");
            }
            if (project.ProjectCategory == null)
            {
                throw new Exception("Kategori Alanı Zorunludur");
            }
            db.tblProject.Add(project);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateProject(int id)
        {
            var project = db.tblProject.Find(id);
            List<SelectListItem> values = (from x in db.tblCategory.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()
                                           }).ToList();
            ViewBag.v = values;
            return View(project);
        }
        [HttpPost]
        public ActionResult UpdateProject(tblProject p)
        {
            var project = db.tblProject.Find(p.ProjectID);
            project.Title = p.Title;
            project.Description = p.Description;
            project.ImageUrl = p.ImageUrl;
            project.ProjectUrl = p.ProjectUrl;
            project.ProjectCategory = p.ProjectCategory;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteProject(int id)
        {
            var project = db.tblProject.Find(id);
            db.tblProject.Remove(project);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}