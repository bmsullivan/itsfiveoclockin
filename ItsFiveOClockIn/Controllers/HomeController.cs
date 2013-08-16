using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ItsFiveOClockIn.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var offset = 17 + TimeZoneInfo.Local.BaseUtcOffset.Hours - DateTime.Now.Hour;
            if (DateTime.Now.IsDaylightSavingTime())
                offset -= 1;
            
            if (offset < -11)
            {
                offset += 24;
            }

            var places = new Dictionary<int, string>()
            {
                {-11, "Pago Pago"},
                {-10, "Honolulu"},
                {-9, "Anchorage"},
                {-8, "Seattle"},
                {-7, "Phoenix"},
                {-6, "Dallas"},
                {-5, "New York"},
                {-4, "Santiago"},
                {-3, "Rio de Janeiro"},
                {-2, "Fernando de Noronha"},
                {-1, "Ponta Delgada"},
                {0, "Dublin"},
                {1, "Munich"},
                {2, "Athens"},
                {3, "Baghdad"},
                {4, "Moscow"},
                {5, "Islamabad"},
                {6, "Astana"},
                {7, "Bangkok"},
                {8, "Beijing"},
                {9, "Tokyo"},
                {10, "Sydney"},
                {11, "Vladivostok"},
                {12, "Auckland"}
            };

            return View("Index", "_Layout", places[offset]);
        }
    }
}