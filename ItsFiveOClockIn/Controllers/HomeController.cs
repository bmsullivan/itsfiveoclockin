using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ItsFiveOClockIn.Controllers
{
    using System.Linq;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var fives = TimeZoneInfo.GetSystemTimeZones().Where(t => TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.UtcNow, t.Id).Hour == 17);
            var offset = 16 + TimeZoneInfo.Local.BaseUtcOffset.Hours - DateTime.Now.Hour;
            if (DateTime.Now.IsDaylightSavingTime())
                offset += 1;
            
            if (offset < -11)
            {
                offset += 24;
            }

            if (offset > 12)
                offset -= 24;

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

            var zones = new Dictionary<string, List<string>>
                            {
                                {"E. Europe Standard Time", new List<string>{"Athens", "Tel Aviv", "Helsinki", "Minsk"}},
                                {"Central European Standard Time", new List<string>{"Prague", "Amsterdam", "Vienna", "Madrid", "Brussels"}},
                                {"GMT Standard Time", new List<string>{"London", "Dublin", "Algiers", "Lisbon"}},
                                {"Greenwich Standard Time", new List<string>{"Reykjavik", "Accra"}},
                                {"Azores Standard Time", new List<string>{"Ponta Delgada"}}
                            };

            return View("Index", "_Layout", places[offset]);
        }
    }
}