using InitialEnterprise.Infrastructure.CQRS.Command;
using InitialEnterprise.Infrastructure.DDD;
using InitialEnterprise.Infrastructure.IoC;
using InitialEnterprise.Infrastructure.Repository;
using SimpleInjector.Lifestyles;
using Xunit;

namespace InitialEnterprise.Infrastructure.Tests.IoC
{
    public class ContainerBuilderTests
    {
        [Fact]
        public void Should_Initialize_Container_By_Scanning()
        {
            //arr
            var containerBuilder = new InjectionContainerBuilder(new AsyncScopedLifestyle());

            //act
            var container = containerBuilder.Initialize();
            var service = container.GetInstance<ITestDomainService>() as TestDomainService;
          
            //assert          
            Assert.NotNull(service);
            Assert.NotNull(service.testRepository);
        }
    }

  
    public class TestDomainService : ITestDomainService, IInjectable
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

    public class TestRepository : ITestRepository, IInjectable
    {
        IUnitOfWork unitOfWork;
        public TestRepository(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
    }

    public interface ITestRepository
    {
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
