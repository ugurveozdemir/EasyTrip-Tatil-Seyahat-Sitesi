using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProject.Models.Classes;

namespace TravelTripProject.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        Context c = new Context();
        BlogComment bc = new BlogComment();
        public ActionResult Index()
        {
            bc.Value1 = c.Blogs.ToList();
            bc.Value3 = c.Blogs.OrderByDescending(x => x.Id).Take(3).ToList();
            return View(bc);
        }

        public ActionResult BlogDetails(int id)
        {
            bc.Value1 = c.Blogs.Where(x => x.Id == id).ToList();
            bc.Value2 = c.Comments.Where(x => x.BlogId == id).ToList();
            bc.Value3 = c.Blogs.OrderByDescending(x => x.Id).Take(3).ToList();
            return View(bc);
        }
        [HttpGet]
        public PartialViewResult MakeComment(int id)
        {
            ViewBag.blogid = id;

            return PartialView();
        }   

        [HttpPost]
        public PartialViewResult MakeComment(Comment y)
        {
            c.Comments.Add(y);
            c.SaveChanges();
            return PartialView();
        }
    }
}