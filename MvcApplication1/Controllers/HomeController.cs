using System.Web.Mvc;

namespace Hilvilla.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        
     
        public ActionResult Index()
        {
                    
            return View();
            
        }
        
    }
}
