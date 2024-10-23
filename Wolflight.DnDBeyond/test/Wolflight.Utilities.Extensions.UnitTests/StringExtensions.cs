#pragma warning disable CA1861 // Avoid constant arrays as arguments
namespace Wolflight.Utilities.Extensions
{
    public class StringExtensions
    {
        public class ToCsvMethod
        {
            [Theory]
            [InlineData(new string[] { }, "")]
            [InlineData(new string[] { "1" }, "1")]
            [InlineData(new string[] { "1", "2" }, "1, 2")]
            public void ReturnsCorrectValueForStrings(IEnumerable<string> input, string expected) => Assert.Equal(expected, input.ToCsv());

            [Theory]
            [InlineData(new int[] { }, "")]
            [InlineData(new int[] { 1 }, "1")]
            [InlineData(new int[] { 1, 2 }, "1, 2")]
            public void ReturnsCorrectValueForIntegers(IEnumerable<int> input, string expected) => Assert.Equal(expected, input.ToCsv());

            [Theory]
            [InlineData(new int[] { }, "")]
            [InlineData(new int[] { 1 }, "1")]
            [InlineData(new int[] { 1, 2 }, "1, 2")]
            public void ReturnsCorrectValueForObjects(IEnumerable<int> input, string expected)
            {
                IEnumerable<ToStringObject> inputObjects;

                inputObjects = input.Select((x) => new ToStringObject(x));

                Assert.Equal(expected, inputObjects.ToCsv());
            }

            private class ToStringObject(int value)
            {
                private readonly int value = value;

                public override string ToString()
                {
                    return value.ToString();
                }
            }
        }

    }
}
