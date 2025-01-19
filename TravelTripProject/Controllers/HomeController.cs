using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProject.Models.Classes;

namespace TravelTripProject.Controllers
{
    public class HomeController : Controller
    {
        Context c = new Context();  
        public ActionResult Index()
        {
            var values = c.Blogs.Take(4).ToList();
            return View(values);
        }

        public PartialViewResult HomePartial()
        {
            var values = c.Blogs.OrderByDescending(x => x.Id).Take(2).ToList();
            return PartialView(values);
        }

        public PartialViewResult HomePartial2()
        {
            var values = c.Blogs.OrderByDescending(x => x.Id).Skip(2).FirstOrDefault();
            return PartialView(values);
        }

        public PartialViewResult HomePartial3()
        {
            var values = c.Blogs.Take(10).ToList();
            return PartialView(values); 

        }

        public PartialViewResult HomePartial4()
        {
            var values = c.Blogs.ToList();
            return PartialView(values);

        }

    }
}