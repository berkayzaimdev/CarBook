using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.RentACarFilterViewComponents
{
    public class _RentACarFilterComponentPartial : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync() 
        {
            return View();
        }
    }
}
