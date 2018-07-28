using System.Web.Mvc;
using WebApiyleApi.Classes;
using WebApiyleApi.Models;

namespace WebApiyleApi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {            
            ViewBag.Title = "Home Page";
            return View();
        }
    }
}
