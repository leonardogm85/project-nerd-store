using NerdStore.Payments.AntiCorruption.Interfaces.Configuration;

namespace NerdStore.Payments.AntiCorruption.Configuration
{
    public sealed class ConfigurationManager : IConfigurationManager
    {
        public string GetValue(string key)
        {
            return new(Enumerable
                .Repeat("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", 10)
                .Select(v => v[Random.Shared.Next(v.Length)])
                .ToArray());
        }

        public void Dispose()
        {
            // TODO: Implement ConfigurationManager Dispose
        }
    }
}
