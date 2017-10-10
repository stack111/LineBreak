using System;
using LineBreak;
using Xunit;

namespace UnitTests
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("a", 0, "a")]
        [InlineData("a", 1, "a")]
        [InlineData("a a", 1, "a\na")]
        [InlineData("a a a a a a", 4, "a a a\na a a")]
        [InlineData("a a a a a a ", 4, "a a a\na a a\n")]
        public void Test1(string input, int columns, string expectedOutput)
        {
            LineBreaker breaker = new LineBreaker(input);
            breaker.Break(columns);
            Assert.Equal(expectedOutput, breaker.Text);

        }
    }
}
