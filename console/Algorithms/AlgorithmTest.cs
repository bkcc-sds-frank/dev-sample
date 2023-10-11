using System;
using Xunit;

namespace DeveloperSample.Algorithms
{
    public class AlgorithmTest
    {
        [Fact]
        public void CanGetFactorial()
        {
            Assert.Throws<ArgumentException>(() => Algorithms.GetFactorial(-1));
            Assert.Equal(1, Algorithms.GetFactorial(0));
            Assert.Equal(1, Algorithms.GetFactorial(1));
            Assert.Equal(2, Algorithms.GetFactorial(2));
            Assert.Equal(6, Algorithms.GetFactorial(3));
            Assert.Equal(24, Algorithms.GetFactorial(4));
            Assert.Equal(120, Algorithms.GetFactorial(5));
            Assert.Throws<ArgumentException>(() => Algorithms.GetFactorial(13));
        }

        [Fact]
        public void CanFormatSeparators()
        {
            Assert.Equal("", Algorithms.FormatSeparators(""));
            Assert.Equal("a", Algorithms.FormatSeparators("a"));
            Assert.Equal("a and b", Algorithms.FormatSeparators("a", "b"));
            Assert.Equal("a, b and c", Algorithms.FormatSeparators("a", "b", "c"));
            Assert.Equal("a, b, c and d", Algorithms.FormatSeparators("a", "b", "c", "d"));
            Assert.Equal("a, b, c, d and e", Algorithms.FormatSeparators("a", "b", "c", "d", "e"));
        }
    }
}