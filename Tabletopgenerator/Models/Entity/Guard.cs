namespace Tabletopgenerator.Models.Entity
{
    public static class Guard
    {
        public static void AgainstNull(object argument, string argumentName)
        {
            if (argument == null)
            {
                throw new ArgumentNullException(nameof(argumentName));
            }
        }

        public static void CustomError(object argument, string argumentName, string page, int linenumber)
        {
            throw new ArgumentException("Something went wrong see " + page + " On line: " + linenumber, argumentName);
        }

        public static void AgainstNullOrWhiteSpace(string argument, string argumentName)
        {
            if (string.IsNullOrWhiteSpace(argument))
            {
                throw new ArgumentException("Argument cannot be null or whitespace.", argumentName);
            }
        }

        public static void AgainstOutOfRank(int argument, int min, int max, string argumentName)
        {
            if (argument < min || argument > max)
            {
                throw new ArgumentOutOfRangeException(argumentName, $"Argument must me between{min} and {max}");
            }
        }

        public static void AgainstSmallerThenZero(int argument, string argumentName)
        {
            if (argument < 0)
            {
                throw new ArgumentException("Argument cannot be smaller then 0", argumentName);
            }
        }

        public static void AgainstZeroOrNegative(int argument, string argumentName)
        {
            if ((argument < 0) || (argument == 0))
            {
                throw new ArgumentException("Argument cannot be negative or 0", argumentName);
            }
        }

        public static void AgainstZeroOrNegative(int? argument, string argumentName)
        {
            if ((argument < 0) || (argument == 0))
            {
                throw new ArgumentException("Argument cannot be negative or 0", argumentName);
            }
        }

        public static void AgainstDuplication(bool Isduplicate)
        {
            if (Isduplicate)
            {
                throw new ArgumentException("Argument already exist!");
            }
        }
    }
}
