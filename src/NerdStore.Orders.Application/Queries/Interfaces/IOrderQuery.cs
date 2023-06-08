using NerdStore.Orders.Application.Queries.ViewModels;

namespace NerdStore.Orders.Application.Queries
{
    public interface IOrderQuery
    {
        Task<CartViewModel?> GetDraftOrderByClientIdAsync(Guid clientId);

        Task<IEnumerable<OrderViewModel>> GetPaidAndCanceledOrdersByClientIdAsync(Guid clientId);
    }
}
