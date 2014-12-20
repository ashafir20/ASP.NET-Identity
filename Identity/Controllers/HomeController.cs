using System.Collections.Generic;
using System.Web.Mvc;

namespace Identity.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [Authorize]
        public ActionResult Index()
        {
            return View(GetData("Index"));
        }

        [Authorize(Roles = "admin")]
        public ActionResult OtherAction()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return View("Error", new string[] { "Access Denied" });
            }
            return View("Index", GetData("OtherAction"));
        }

        private Dictionary<string, object> GetData(string actionName)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict.Add("Action", actionName);
            dict.Add("User", HttpContext.User.Identity.Name);
            dict.Add("Authenticated", HttpContext.User.Identity.IsAuthenticated);
            dict.Add("Auth Type", HttpContext.User.Identity.AuthenticationType);
            dict.Add("In Users Role", HttpContext.User.IsInRole("Users"));
            return dict;
        }
    }
}