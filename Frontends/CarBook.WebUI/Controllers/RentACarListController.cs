using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Controllers
{
    public class RentACarListController : Controller
    {
        public IActionResult Index()
        {
            var book_pick_date = TempData["bookpickdate"];
            var book_off_date = TempData["bookoffdate"];
            var time_pick = TempData["timepickdate"];
            var time_off = TempData["timeoff"];
            var locationID = TempData["LocationID"];

            ViewBag.bookpickdate = book_pick_date;
            ViewBag.bookoffdate = book_off_date;
            ViewBag.timepick = time_pick;
            ViewBag.timeoff = time_off;
            ViewBag.locationID = locationID;
            return View();
        }
    }
}
