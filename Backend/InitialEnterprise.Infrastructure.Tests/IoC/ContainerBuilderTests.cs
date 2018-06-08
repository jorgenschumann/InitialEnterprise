using InitialEnterprise.Domain.SharedKernel;
using InitialEnterprise.Infrastructure.DDD.Annotations;
using InitialEnterprise.Infrastructure.IoC;
using Xunit;

namespace InitialEnterprise.Infrastructure.Tests
{
    public class ContainerBuilderTests
    {
        [Fact]
        public void Should_Initialize_Container_By_Scanning()
        {
            //arr
            var containerBuilder = new ContainerBuilder();
            
            //act
            var container = containerBuilder.Initialize();
            var service = container.GetInstance<ITestDomainService>() as TestDomainService;
            var handler = container.GetInstance<TestCommandHandler>();
       
            //assert          
            Assert.NotNull(service);
            Assert.NotNull(service.testRepository);

            Assert.NotNull(handler);
            Assert.NotNull(handler.testDomainService);           
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
       
    public class TestCommandHandler : ICommandHandler<TestCommand>
    {
        public ITestDomainService testDomainService;
        public TestCommandHandler(ITestDomainService testDomainService)
        {
            this.testDomainService = testDomainService;
        }

        public void Handle(TestCommand command)
        {
            throw new System.NotImplementedException();
        }
    }

    public class TestCommand : ICommand
    {
        public bool IsValid => throw new System.NotImplementedException();

        public object Validate()
        {
            throw new System.NotImplementedException();
        }
    }
}
