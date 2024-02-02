using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MeyawoPortfolio.Models;
namespace MeyawoPortfolio.Controllers
{
    public class ContactController : Controller
    {
        DbMyPortfolioEntities db = new DbMyPortfolioEntities();
        public ActionResult Index()
        {
            var values = db.tblContact.OrderByDescending(x=>x.ContactID).ToList();
            return View(values);
        }
        public ActionResult MessageDetail(int id)
        {
            var value = db.tblContact.Find(id);
            return View(value);
        }
        public ActionResult MarkAsRead(int id)
        {
            var message = db.tblContact.Find(id);
            message.IsRead = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteMessage(int id)
        {
            var message = db.tblContact.Find(id);
            db.tblContact.Remove(message);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult CreateContact(tblContact contact)
        {
            if (ModelState.IsValid)
            {
                contact.IsRead = false;
                contact.SendDate = DateTime.Now;
                contact.MessageCategory = 1;
                db.tblContact.Add(contact);
                db.SaveChanges();
                return RedirectToAction("Index", "Default");
            }
            return View(contact);
        }
    }
}