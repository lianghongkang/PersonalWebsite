using PersonalWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PersonalWebsite.Controllers
{
    public class PersonalInformationController : Controller
    {
        PersonalDbContext db = new PersonalDbContext();
        // GET: PersonalInformation
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetAllInfos()
        {
            List<PersonalInformation> infos = db.infos.ToList();
            return Json(infos,JsonRequestBehavior.AllowGet);
        }

       
        // GET: PersonalInformation/Edit/5
        //public ActionResult Edit(int id)
        //{
            
        //    PersonalInformation info = db.infos.Where(p => p.Id == id).FirstOrDefault();
        //    if(info!=null) return View(info);
        //    else
        //    {
        //        return   View();
        //    }
        //}

        // POST: PersonalInformation/Edit/5
        [HttpPost]
        public ActionResult Edit(PersonalInformation info)
        {
            try
            {
                var result = db.infos.Find(info.Id);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult Create(PersonalInformation info)
        {
            try
            {
                db.infos.Add(info);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }
    }
}
