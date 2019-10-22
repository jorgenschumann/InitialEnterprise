using InitialEnterprise.Infrastructure.DDD.Command;
using System;

namespace InitialEnterprise.Domain.MainBoundedContext.DocumentModule.Commands
{
    public class DocumentUpdateCommand : DomainCommand
    {
        public string Description { get; set; }               

        public byte[] Data { get; set; }            

        public DocumentUpdateCommand(byte[] data, string description,  Guid userId)
        {
            Data = data;
            Description = description;          
            UserId = userId;
            TimeStamp = DateTime.Now;
        }
    }
}
