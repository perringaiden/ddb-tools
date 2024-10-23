namespace Wolflight.Utilities.Extensions
{
    public static class StringExtensions
    {
        public static string ToCsv<T>(this IEnumerable<T> values)
        {
            return string.Join(", ", values.Select((x) => x?.ToString()));
        }
    }
}
