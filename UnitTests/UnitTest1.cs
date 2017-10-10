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
        [InlineData("a a a a a a ", 4, "a a a\na a a\n")]
        [InlineData("a a ab a a a", 4, "a a ab\na a a")]
        [InlineData("a a ab a a abc a", 4, "a a ab\na a abc\na")]
        [InlineData("a a ab\n a a a", 4, "a a ab\n a a\na")]
        public void PositiveTests(string input, int columns, string expectedOutput)
        {
            LineBreaker breaker = new LineBreaker(input);
            Assert.Equal(expectedOutput, breaker.Break(columns));
        }

        /// <summary>
        /// I'm not sure if these are valid tests, based on the example line breaks are only supported by \n
        /// not \r. That said it may be valid case for the future so I will leave it here.
        /// </summary>
        [Theory]
        [InlineData("a a ab\r\n a a a", 4, "a a ab\r\n a a\r\na")]
        public void SpecialPostiveTests(string input, int columns, string expectedOutput)
        {
            LineBreaker breaker = new LineBreaker(input);
            Assert.Equal(expectedOutput, breaker.Break(columns));

        }

        [Fact]
        public void NegativeTest()
        {
            LineBreaker breaker = new LineBreaker("");
            Assert.Throws<ArgumentOutOfRangeException>(() => breaker.Break(-1)); 
        }
    }
}
