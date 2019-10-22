using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace InitialEnterprise.Shared.Dtos
{
    public abstract class DataTransferObject : IDataTransferObject
    {
        [Required]
        [JsonIgnore]
        public Guid UserId { get; set; }
    }
}