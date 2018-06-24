using InitialEnterprise.Infrastructure.CQRS.Command;
using InitialEnterprise.Infrastructure.IoC;
using InitialEnterprise.Infrastructure.Repository;
using Xunit;

namespace InitialEnterprise.Infrastructure.Tests.IoC
{
    public class ContainerBuilderTests
    {
      
    }

    public class TestDomainService : ITestDomainService, IInjectable
    {
        public ITestRepository testRepository;

        public TestDomainService(ITestRepository testRepository)
        {
            this.testRepository = testRepository;
        }
    }

    public interface ITestDomainService
    {
    }

    public class TestRepository : ITestRepository, IInjectable
    {
        private IUnitOfWork unitOfWork;

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