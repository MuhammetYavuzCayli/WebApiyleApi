using System.Web.Mvc;

namespace WebApiyleApi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            /*using (MyContext context = new MyContext())
            {
                
                 User user = new User()
                {
                    Name = "İlk Kişi",
                    Location = "Türkiye"
                };
                context.User.Add(user);
                 

            context.SaveChanges();
            }
            */
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
