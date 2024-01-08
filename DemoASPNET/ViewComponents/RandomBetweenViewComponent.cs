using Microsoft.AspNetCore.Mvc;

namespace DemoASPNET.ViewComponents
{
    public class RandomBetweenViewComponent : Microsoft.AspNetCore.Mvc.ViewComponent
    {

        public async Task<IViewComponentResult>  InvokeAsync(int min, int max)
        {

            TempData["min"] = min;
            TempData["max"] = max;
            TempData["random"] = new Random().Next(min,max);

            return View();

        }
    }
}
