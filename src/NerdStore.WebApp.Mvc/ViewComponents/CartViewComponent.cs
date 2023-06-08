using Microsoft.AspNetCore.Mvc;
using NerdStore.Orders.Application.Queries;

namespace NerdStore.WebApp.Mvc.ViewComponents
{
    public class CartViewComponent : ViewComponent
    {
        private readonly IOrderQuery _orderQuery;

        // TODO: Get authenticated client

        protected readonly Guid ClientId = Guid.Parse("D2A38981-0099-4DB4-A5D5-18BF7A472985");

        public CartViewComponent(IOrderQuery orderQuery)
        {
            _orderQuery = orderQuery;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var order = await _orderQuery.GetDraftOrderByClientIdAsync(ClientId);

            if (order is null)
            {
                return View(0);
            }

            return View(order.Items.Count);
        }
    }
}
