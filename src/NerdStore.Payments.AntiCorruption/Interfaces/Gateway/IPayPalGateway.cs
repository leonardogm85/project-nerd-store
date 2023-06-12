namespace NerdStore.Payments.AntiCorruption.Interfaces.Gateways
{
    public interface IPayPalGateway : IDisposable
    {
        Task<string> GetServiceKeyAsync(string apiKey, string encriptionKey);
        Task<string> GetCardHashKeyAsync(string serviceKey, string cardHolder, string cardNumber, string cardExpiresOn, string cardCvv);
        Task<bool> CommitTransactionAsync(string cardHashKey, string orderId, double amount);
    }
}
