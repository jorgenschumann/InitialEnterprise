using System;
using System.ComponentModel.DataAnnotations;

namespace InitialEnterprise.Infrastructure.Application
{
    public abstract class DataTransferObject : IDataTransferObject
    {
        [Required]
        public Guid UserId { get; set; }
    }
}