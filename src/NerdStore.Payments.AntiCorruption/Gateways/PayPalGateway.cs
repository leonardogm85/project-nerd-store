using NerdStore.Payments.AntiCorruption.Interfaces.Gateways;

namespace NerdStore.Payments.AntiCorruption.Gateways
{
    public sealed class PayPalGateway : IPayPalGateway
    {
        public async Task<string> GetServiceKeyAsync(string apiKey, string encriptionKey)
        {
            var key = new string(Enumerable
                .Repeat("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", 10)
                .Select(v => v[Random.Shared.Next(v.Length)])
                .ToArray());

            return await Task.FromResult(key);
        }

        public async Task<string> GetCardHashKeyAsync(string serviceKey, string cardHolder, string cardNumber, string cardExpiresOn, string cardCvv)
        {
            var key = new string(Enumerable
                .Repeat("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", 10)
                .Select(v => v[Random.Shared.Next(v.Length)])
                .ToArray());

            return await Task.FromResult(key);
        }

        public async Task<bool> CommitTransactionAsync(string cardHashKey, string orderId, double amount)
        {
            var confirmed = Random
                .Shared
                .Next(2) == 0;

            return await Task.FromResult(confirmed);
        }

        public void Dispose()
        {
            // TODO: Implement PayPalGateway Dispose
        }
    }
}
