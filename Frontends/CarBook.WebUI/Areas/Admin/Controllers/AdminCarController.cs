using CarBook.Dto.BrandDtos;
using CarBook.Dto.CarDtos;
using CarBook.Dto.CarFeatureDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Route("Admin/AdminCar")]
    [Area("Admin")]
    public class AdminCarController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminCarController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7160/api/Cars/GetCarWithBrand");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarWithBrandDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(List<ResultCarFeatureByCarIdDto> dtos)
        {
            foreach(var dto in dtos)
            {
                if(dto.Available)
                {
                    var client = _httpClientFactory.CreateClient();
                    var jsonData = JsonConvert.SerializeObject(dto);
                    StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                    await client.PutAsync("https://localhost:7160/api/Cars", stringContent);
                }
                else 
                {
                }
            }

            return View();
        }
    }
}
