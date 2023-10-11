using Xunit;

namespace DeveloperSample.ClassRefactoring
{
    public class ClassRefactorTest
    {
        [Theory]
        [InlineData(SwallowLoad.None)]
        [InlineData(SwallowLoad.Coconut)]
        public void SwallowAfricanHasCorrectSpeed(SwallowLoad load)
        {
            double expected = default;
            switch(load)
            {
                case SwallowLoad.Coconut: expected = 18; break;
                default: expected = 22; break;
            }

            var swallow = SwallowFactory.CreateSwallow(SwallowType.African);
            swallow.ApplyLoad(load);
            Assert.Equal(expected, swallow.GetAirspeedVelocity());
        }

        [Theory]
        [InlineData(SwallowLoad.None)]
        [InlineData(SwallowLoad.Coconut)]
        public void SwallowEuropeanHasCorrectSpeed(SwallowLoad load)
        {
            double expected = default;
            switch (load)
            {
                case SwallowLoad.Coconut: expected = 16; break;
                default: expected = 20; break;
            }

            var swallow = SwallowFactory.CreateSwallow(SwallowType.European);
            swallow.ApplyLoad(load);
            Assert.Equal(expected, swallow.GetAirspeedVelocity());
        }
    }
}