using Xunit;

namespace DeveloperSample.Container
{
    internal interface IContainerTestInterface
    {
        int TestProp { get; }
    }

    internal class ContainerTestClass : IContainerTestInterface
    {
        public int TestProp { get => 1; }
    }

    public class ContainerTest
    {
        [Fact]
        public void CanBindAndGetService()
        {
            var container = new Container();
            container.Bind(typeof(IContainerTestInterface), typeof(ContainerTestClass));
            var testInstance = container.Get<IContainerTestInterface>();
            Assert.IsType<ContainerTestClass>(testInstance);
            Assert.Equal(1, testInstance.TestProp);
        }
    }
}