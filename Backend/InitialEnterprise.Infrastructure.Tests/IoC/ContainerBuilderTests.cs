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
            var service = container.GetInstance<ITestDomainService>() as TestDomainService;

            //assert          
            Assert.NotNull(service);
            Assert.NotNull(service.testRepository);
        }
    }

    [DomainService]
    public class TestDomainService : ITestDomainService
    {
        public ITestRepository testRepository;
        public TestDomainService(ITestRepository  testRepository)
        {
            this.testRepository = testRepository;
        }
    }

    public interface ITestDomainService
    {
    }

    [DomainRepository]
    public class TestRepository : ITestRepository
    {
    }

    public interface ITestRepository
    {
    }

}
