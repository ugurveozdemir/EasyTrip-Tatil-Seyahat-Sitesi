using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web.Mvc;
using System.Web.Security;
using TravelTripProject.Models.Classes;
using DbContext = TravelTripProject.Models.Classes.Context;

namespace TravelTripProject.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        DbContext c = new DbContext();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin ad)
        {
            var values = c.Admins.FirstOrDefault(x => x.UserName == ad.UserName && x.Password == ad.Password);
            if (values != null)
            {
                FormsAuthentication.SetAuthCookie(values.UserName, false);
                Session["AdminUserName"] = values.UserName.ToString();
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                return View();
            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }

    }
}