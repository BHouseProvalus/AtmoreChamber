using System.Web.Mvc;

namespace AtmoreChamber.Controllers
{
    public class AboutAtmoreController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult OurHistory()
        {
            return View();
        }

        public ActionResult OurCommunity()
        { 
            return View();
        }

        public ActionResult RelocationandHelpfulResources()
        {
            return View();
        }

        public ActionResult InformationRequest()
        {
            return View();
        }

        //    public ActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
