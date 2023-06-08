using System.Text.RegularExpressions;

namespace NerdStore.Core.Domain
{
    public static class AssertionConcern
    {
        public static void AssertArgumentEquals(object object1, object object2, string message)
        {
            if (!object1.Equals(object2))
            {
                throw new DomainException(message);
            }
        }

        public static void AssertArgumentFalse(bool value, string message)
        {
            if (value)
            {
                throw new DomainException(message);
            }
        }

        public static void AssertArgumentLength(string value, int maximum, string message)
        {
            var length = value.Trim().Length;

            if (length > maximum)
            {
                throw new DomainException(message);
            }
        }

        public static void AssertArgumentLength(string value, int minimum, int maximum, string message)
        {
            var length = value.Trim().Length;

            if (length < minimum || length > maximum)
            {
                throw new DomainException(message);
            }
        }

        public static void AssertArgumentMatches(string pattern, string value, string message)
        {
            var regex = new Regex(pattern);

            if (!regex.IsMatch(value))
            {
                throw new DomainException(message);
            }
        }

        public static void AssertArgumentNotEmpty(string value, string message)
        {
            if (value is null || value.Trim().Length == 0)
            {
                throw new DomainException(message);
            }
        }

        public static void AssertArgumentNotEquals(object object1, object object2, string message)
        {
            if (object1.Equals(object2))
            {
                throw new DomainException(message);
            }
        }

        public static void AssertArgumentNotNull(object object1, string message)
        {
            if (object1 is null)
            {
                throw new DomainException(message);
            }
        }

        public static void AssertArgumentRange(decimal value, decimal minimum, decimal maximum, string message)
        {
            if (value < minimum || value > maximum)
            {
                throw new DomainException(message);
            }
        }

        public static void AssertArgumentRange(double value, double minimum, double maximum, string message)
        {
            if (value < minimum || value > maximum)
            {
                throw new DomainException(message);
            }
        }

        public static void AssertArgumentRange(float value, float minimum, float maximum, string message)
        {
            if (value < minimum || value > maximum)
            {
                throw new DomainException(message);
            }
        }

        public static void AssertArgumentRange(int value, int minimum, int maximum, string message)
        {
            if (value < minimum || value > maximum)
            {
                throw new DomainException(message);
            }
        }

        public static void AssertArgumentRange(long value, long minimum, long maximum, string message)
        {
            if (value < minimum || value > maximum)
            {
                throw new DomainException(message);
            }
        }

        public static void AssertArgumentTrue(bool value, string message)
        {
            if (!value)
            {
                throw new DomainException(message);
            }
        }

        public static void AssertArgumentGreaterThan(decimal value, decimal comparer, string message)
        {
            if (value <= comparer)
            {
                throw new DomainException(message);
            }
        }

        public static void AssertArgumentGreaterThan(double value, double comparer, string message)
        {
            if (value <= comparer)
            {
                throw new DomainException(message);
            }
        }

        public static void AssertArgumentGreaterThan(float value, float comparer, string message)
        {
            if (value <= comparer)
            {
                throw new DomainException(message);
            }
        }

        public static void AssertArgumentGreaterThan(int value, int comparer, string message)
        {
            if (value <= comparer)
            {
                throw new DomainException(message);
            }
        }

        public static void AssertArgumentGreaterThan(long value, long comparer, string message)
        {
            if (value <= comparer)
            {
                throw new DomainException(message);
            }
        }

        public static void AssertArgumentGreaterOrEqualsThan(decimal value, decimal comparer, string message)
        {
            if (value < comparer)
            {
                throw new DomainException(message);
            }
        }

        public static void AssertArgumentGreaterOrEqualsThan(double value, double comparer, string message)
        {
            if (value < comparer)
            {
                throw new DomainException(message);
            }
        }

        public static void AssertArgumentGreaterOrEqualsThan(float value, float comparer, string message)
        {
            if (value < comparer)
            {
                throw new DomainException(message);
            }
        }

        public static void AssertArgumentGreaterOrEqualsThan(int value, int comparer, string message)
        {
            if (value < comparer)
            {
                throw new DomainException(message);
            }
        }

        public static void AssertArgumentGreaterOrEqualsThan(long value, long comparer, string message)
        {
            if (value < comparer)
            {
                throw new DomainException(message);
            }
        }

        public static void AssertArgumentLowerThan(decimal value, decimal comparer, string message)
        {
            if (value >= comparer)
            {
                throw new DomainException(message);
            }
        }

        public static void AssertArgumentLowerThan(double value, double comparer, string message)
        {
            if (value >= comparer)
            {
                throw new DomainException(message);
            }
        }

        public static void AssertArgumentLowerThan(float value, float comparer, string message)
        {
            if (value >= comparer)
            {
                throw new DomainException(message);
            }
        }

        public static void AssertArgumentLowerThan(int value, int comparer, string message)
        {
            if (value >= comparer)
            {
                throw new DomainException(message);
            }
        }

        public static void AssertArgumentLowerThan(long value, long comparer, string message)
        {
            if (value >= comparer)
            {
                throw new DomainException(message);
            }
        }

        public static void AssertArgumentLowerOrEqualsThan(decimal value, decimal comparer, string message)
        {
            if (value > comparer)
            {
                throw new DomainException(message);
            }
        }

        public static void AssertArgumentLowerOrEqualsThan(double value, double comparer, string message)
        {
            if (value > comparer)
            {
                throw new DomainException(message);
            }
        }

        public static void AssertArgumentLowerOrEqualsThan(float value, float comparer, string message)
        {
            if (value > comparer)
            {
                throw new DomainException(message);
            }
        }

        public static void AssertArgumentLowerOrEqualsThan(int value, int comparer, string message)
        {
            if (value > comparer)
            {
                throw new DomainException(message);
            }
        }

        public static void AssertArgumentLowerOrEqualsThan(long value, long comparer, string message)
        {
            if (value > comparer)
            {
                throw new DomainException(message);
            }
        }
    }
}
