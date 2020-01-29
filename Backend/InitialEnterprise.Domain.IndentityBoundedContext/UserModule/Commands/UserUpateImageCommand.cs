using InitialEnterprise.Infrastructure.DDD.Command;

namespace InitialEnterprise.Domain.IndentityBoundedContext.UserModule.Commands
{
    public class UserUpdateImageCommand : DomainCommand
    {
        public byte[] Image { get; set; }
    }
}