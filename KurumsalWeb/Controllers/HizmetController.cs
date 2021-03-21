using KurumsalWeb.Models.DataContext;
using KurumsalWeb.Models.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace KurumsalWeb.Controllers
{
    public class HizmetController : Controller
    {
        private KurumsalDBContext db = new KurumsalDBContext();
        // GET: Hizmet
        public ActionResult Index()
        {
            return View(db.Hizmet.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Hizmet hizmet, HttpPostedFileBase ResimUrl)
        {
            if (ModelState.IsValid)
            {
                if (ResimUrl != null)
                {

                    WebImage img = new WebImage(ResimUrl.InputStream);
                    FileInfo imginfo = new FileInfo(ResimUrl.FileName);

                    string logoname = ResimUrl.FileName + imginfo.Extension;
                    img.Resize(500, 500);
                    img.Save("~/Uploads/Hizmet/" + logoname);

                    hizmet.ResimURL = "/Uploads/Hizmet/" + logoname;
                }
                db.Hizmet.Add(hizmet);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(hizmet);
        }
        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                ViewBag.Uyari = "Güncellenecek Hizmet Bulunamadı";


            }
            var hizmet = db.Hizmet.Find(id);
            if (hizmet == null)
            {

                return HttpNotFound();
            }
            return View(hizmet);
        }
        [HttpPost]
        public ActionResult Edit(int? id, Hizmet hizmet, HttpPostedFileBase ResimUrl)
        {
            var h = db.Hizmet.Find(id);
            if (ModelState.IsValid)
            {
                
                if (ResimUrl != null)
                {
                    if (System.IO.File.Exists(Server.MapPath(h.ResimURL)))//daha önce yüklediğimiz rresim var mı kontrol et varsa sil
                    {
                        System.IO.File.Delete(Server.MapPath(h.ResimURL));
                    }
                    WebImage img = new WebImage(ResimUrl.InputStream);
                    FileInfo imginfo = new FileInfo(ResimUrl.FileName);

                    string logoname = ResimUrl.FileName + imginfo.Extension;
                    img.Resize(300, 200);
                    img.Save("~/Uploads/Kimlik/" + logoname);

                    h.ResimURL = "/Uploads/Kimlik/" + logoname;
                }
                db.Entry(hizmet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();

        }
    }
}