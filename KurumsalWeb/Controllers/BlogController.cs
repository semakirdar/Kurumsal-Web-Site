using KurumsalWeb.Models.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KurumsalWeb.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        private KurumsalDBContext db = new KurumsalDBContext();
        public ActionResult Index()
        {
            return View(db.Blog.ToList());
        }
    }
}