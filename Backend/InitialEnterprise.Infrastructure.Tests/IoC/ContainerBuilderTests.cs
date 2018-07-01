using System;
using InitialEnterprise.Infrastructure.CQRS.Command;
using InitialEnterprise.Infrastructure.Repository;

namespace InitialEnterprise.Infrastructure.Tests.IoC
{
    public class ContainerBuilderTests
    {
    }

    public class TestDomainService : ITestDomainService
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

    public class TestRepository : ITestRepository
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
        public bool IsValid => throw new NotImplementedException();

        public object Validate()
        {
            throw new NotImplementedException();
        }
    }
}