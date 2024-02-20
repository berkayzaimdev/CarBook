using CarBook.Dto.BrandDtos;
using CarBook.Dto.RentACarDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUI.Controllers
{
    public class RentACarListController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RentACarListController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
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

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7160/api/RentACars?locationID={int.Parse(locationID.ToString())}&available={true}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<FilterRentACarDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
