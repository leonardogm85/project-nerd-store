using NerdStore.Payments.AntiCorruption.Interfaces.Configuration;

namespace NerdStore.Payments.AntiCorruption.Configuration
{
    public sealed class ConfigurationManager : IConfigurationManager
    {
        public string GetValue(string key)
        {
            return Enumerable
                .Repeat("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", 10)
                .Select(v => v[Random.Shared.Next(v.Length)])
                .Cast<string>()
                .Aggregate(string.Concat);
        }

        public void Dispose()
        {
            // TODO: Implement
        }
    }
}
