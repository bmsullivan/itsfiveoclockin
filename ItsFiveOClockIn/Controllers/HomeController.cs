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

            var zones = new Dictionary<string, string>
                            {
                                {"UTC-11", "Pago Pago"},
                                {"Hawaiian Standard Time", "Honolulu"},
                                {"Alaskan Standard Time", "Anchorage"},
                                {"Pacific Standard Time", "Seattle"},
                                {"Mountain Standard Time", "Phoenix"},
                                {"Central Standard Time", "Dallas"},
                                {"Eastern Standard Time", "New York"},
                                {"Atlantic Standard Time", "Santiago"},
                                {"E. South America Standard Time", "Rio de Janeiro"},
                                {"Mid-Atlantic Standard Time", "Fernando de Noronha"},
                                {"Azores Standard Time", "Ponta Delgada"},
                                {"GMT Standard Time", "Dublin"},
                                {"W. Europe Standard Time", "Munich"},
                                {"E. Europe Standard Time", "Athens"},
                                {"Arabic Standard Time", "Baghdad"},
                                {"Russia TZ 3 Standard Time", "Moscow"},
                                {"Pakistan Standard Time", "Islamabad"},
                                {"Central Asia Standard Time", "Astana"},
                                {"SE Asia Standard Time", "Bangkok"},
                                {"Taipei Standard Time", "Beijing"},
                                {"Tokyo Standard Time", "Tokyo"},
                                {"E. Australia Standard Time", "Sydney"},
                                {"Russia TZ 10 Standard Time", "Vladivostok"},
                                {"New Zealand Standard Time", "Auckland"},
                                {"Aleutian Standard Time", "Unalaska" },
                                {"Greenland Standard Time", "Nuuk" }
                            };

            string city = "";
            foreach (var timeZoneInfo in fives)
            {
                if (zones.ContainsKey(timeZoneInfo.StandardName))
                {
                    city = zones[timeZoneInfo.StandardName];
                    break;
                }
            }

            return View("Index", "_Layout", city);
        }
    }
}