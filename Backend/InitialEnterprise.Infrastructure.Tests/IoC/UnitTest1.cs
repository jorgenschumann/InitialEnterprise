using InitialEnterprise.Infrastructure.DDD.Annotations;
using Xunit;

namespace InitialEnterprise.Infrastructure.Tests
{
    public class ContainerBuilderTests
    {
        [Fact]
        public void Should_Initialize_Container_By_Scanning()
        {
            //arr
            var containerBuilder = new InitialEnterprise.Infrastructure.IoC.ContainerBuilder();
            
            //act
            var container = containerBuilder.Initialize();

            //assert
            Assert.NotNull(container.GetInstance<ITestDomainService>());
        }
    }

    [DomainService]
    public class TestDomainService : ITestDomainService
    {
    }

    public interface ITestDomainService
    {
    }

}
