using PersonalWebsite.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;
using PersonalWebsite.Common;
using PersonalWebsite.DAL;
using System.Diagnostics;

namespace PersonalWebsite.Controllers
{
    public class PhotoController : Controller
    {
        PersonalDbContext db = new PersonalDbContext();
        
        // GET: Photo
        public ActionResult Index()

        {
            //Photo photo = new Photo { ImageUrl = "imag1.jpg" };
            //var pas = SqlHelper.GetSqlParameters(photo);
            string s = "select Id,ImageUrl from photos ";
            IDataReader sdr = DbFactory.ExcuteReader(CommandType.Text, s);
            List<Photo> photos = sdr.ToList<Photo>();
            return View();
        }
        public JsonResult GetAllInfos()
        {
            List<Photo> infos = db.Photos.ToList();
            return Json(infos, JsonRequestBehavior.AllowGet);
        }
        // GET: Photo/Edit/5
        public ActionResult Edit(int id)
        {

            if(id==0)
            {
                return View(new Photo());
            }
            else
            {
                var photo = db.Photos.Where(p=>p.Id==id).FirstOrDefault();
                return View(photo);
            }
         
        }

        // POST: Photo/Edit/5
        [HttpPost]
        public ActionResult Edit(Photo photo)
        {
            try
            {
                if (Request.Files.Count > 0)
                {
                    HttpPostedFileBase file = Request.Files[0];
                    string path = Server.MapPath("~/Uploading/Img/");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    string fileName = file.FileName;
                    string filePath = path + fileName;
                    photo.ImageUrl = filePath;
                    file.SaveAs(filePath);
                }

                // TODO: Add update logic here
                if (photo.Id==0)
                {
                    db.Photos.Add(photo);
                 
                }
                else
                {
                    var result = db.Photos.Where(p => p.Id == photo.Id).FirstOrDefault();
                    result = photo;
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Photo/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Photo/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
