using Bogus;

namespace NerdStore.Catalog.Domain.Tests.Extensions
{
    public static class RandomizerExtensions
    {
        public static double Double(this Randomizer randomizer, double min, double max, int decimals)
        {
            return Math.Round(
                randomizer.Double(
                    min,
                    max),
                decimals);
        }
    }
}
