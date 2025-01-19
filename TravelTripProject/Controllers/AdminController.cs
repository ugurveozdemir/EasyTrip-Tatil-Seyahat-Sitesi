using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProject.Models.Classes;

namespace TravelTripProject.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        Context c = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var values = c.Blogs.ToList();
            return View(values);
        }
        [Authorize]
        [HttpGet]
        public ActionResult NewBlog()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult NewBlog(Blog p)
        {
            c.Blogs.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize]
        public ActionResult DeleteBlog(int id)
        {
            var blog = c.Blogs.Find(id);
            c.Blogs.Remove(blog);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize]
        [HttpGet]
        public ActionResult UpdateBlog(int id)
        {
            var blog = c.Blogs.Find(id);
            return View("UpdateBlog", blog);
        }
        [Authorize]
        [HttpPost]
        public ActionResult UpdateBlog(Blog p)
        {
            var blog = c.Blogs.Find(p.Id);
            blog.Title = p.Title;
            blog.Description = p.Description;
            blog.ImageUrl = p.ImageUrl;
            blog.Date = p.Date;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize]
        public ActionResult Comments()
        {
            var values = c.Comments.ToList();
            return View(values);
        }
        [Authorize]
        public ActionResult DeleteComment(int id)
        {
            var comment = c.Comments.Find(id);
            c.Comments.Remove(comment);
            c.SaveChanges();
            return RedirectToAction("Comments");
        }

    } 


}