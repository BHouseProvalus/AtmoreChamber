using AtmoreChamber.Models;
using System.Linq;
using System.Web.Mvc;

namespace AtmoreChamber.Controllers
{
    public class CalendarController : Controller
    {
        private ApplicationDbContext dc = new ApplicationDbContext();
        //public CalendarController()
        //{
        //    dc = new ApplicationDbContext();
        //}

        // GET: Event
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetEvents()
        {
            using (ApplicationDbContext dc = new ApplicationDbContext())
            {
                var events = dc.Event.ToList();
                return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }

        [HttpPost]
        public JsonResult SaveEvent(Event e)
        {
            var status = false;
            using (ApplicationDbContext dc = new ApplicationDbContext())
            {
                if (e.EventID > 0)
                {
                    //Update the event
                    var v = dc.Event.Where(a => a.EventID == e.EventID).FirstOrDefault();
                    if (v != null)
                    {
                        v.Subject = e.Subject;
                        v.Start = e.Start;
                        v.End = e.End;
                        v.Description = e.Description;
                        v.IsFullDay = e.IsFullDay;
                        v.ThemeColor = e.ThemeColor;
                    }
                }
                else
                {
                    dc.Event.Add(e);
                }
                dc.SaveChanges();
                status = true;
            }
            return new JsonResult { Data = new { status = status } };
        }

        [HttpPost]
        public JsonResult DeleteEvent(int eventID)
        {
            var status = false;
            using (ApplicationDbContext dc = new ApplicationDbContext())
            {
                var v = dc.Event.Where(a => a.EventID == eventID).FirstOrDefault();
                if (v != null)
                {
                    dc.Event.Remove(v);
                    dc.SaveChanges();
                    status = true;
                }
            }
            return new JsonResult { Data = new { status = status } };
        }

    }
}