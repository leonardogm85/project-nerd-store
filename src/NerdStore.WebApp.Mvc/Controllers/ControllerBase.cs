using Microsoft.AspNetCore.Mvc;

namespace NerdStore.WebApp.Mvc.Controllers
{
    public abstract class ControllerBase : Controller
    {
        protected readonly Guid ClientId = Guid.Parse("D2A38981-0099-4DB4-A5D5-18BF7A472985");
    }
}
