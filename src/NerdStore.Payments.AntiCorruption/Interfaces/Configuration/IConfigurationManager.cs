namespace NerdStore.Payments.AntiCorruption.Interfaces.Configuration
{
    public interface IConfigurationManager : IDisposable
    {
        string GetValue(string key);
    }
}
