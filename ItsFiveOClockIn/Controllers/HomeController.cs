using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ItsFiveOClockIn.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var now = DateTime.Now;

            var offset = 10 - now.Hour;

            if (offset < -11)
            {
                offset += 24;
            }

            var places = new Dictionary<int, string>()
            {
                {-10, "Anchorage"},
                {-9, "Whitehorse"},
                {-8, "Seattle"},
                {-7, "Phoenix"},
                {-6, "Dallas"},
                {-5, "New York"},
                {-4, "Buenos Aires"},
                {-3, "Rio de Janeiro"},
                {-2, "Ponta Delgada"},
                {-1, "Reykjavik"},
                {0, "Dublin"},
                {1, "Munich"},
                {2, "Athens"},
                {3, ""}
            };

            return View(offset);
        }
    }
}