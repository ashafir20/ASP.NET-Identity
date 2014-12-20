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
            Dictionary<string, object> data
                = new Dictionary<string, object>();
            data.Add("Placeholder", "Placeholder");
            return View(data);
        }
    }
}