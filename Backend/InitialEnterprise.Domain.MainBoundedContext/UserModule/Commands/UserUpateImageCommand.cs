using InitialEnterprise.Infrastructure.DDD.Command;

namespace InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Commands
{
    public class UserUpdateImageCommand : DomainCommand
    {
        public byte[] Image { get; set; }
    }
}