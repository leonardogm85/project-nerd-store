using Microsoft.AspNetCore.Mvc;

namespace NerdStore.WebApp.Mvc.Controllers
{
    [Route("common")]
    public class CommonController : Controller
    {
        [HttpGet("error")]
        public IActionResult Error()
        {
            return View();
        }
    }
}
