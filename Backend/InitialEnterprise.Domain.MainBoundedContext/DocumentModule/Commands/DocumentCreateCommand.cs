using InitialEnterprise.Infrastructure.DDD.Command;
using System;

namespace InitialEnterprise.Domain.MainBoundedContext.DocumentModule.Commands
{
    public class DocumentCreateCommand : DomainCommand
    {
        public string Description { get; set; }

        public string Extension { get; set; }
     
        public byte[] Data { get; set; }

        public string ContentType { get; set; }

        public DocumentCreateCommand(byte[] data, string description, string extension,  string contentType, Guid userId)
        {
            Data = data;
            Description = description;
            Extension = extension;           
            ContentType = contentType;
            UserId = userId;
            TimeStamp = DateTime.Now;
        }
    }
}
