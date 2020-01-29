using Newtonsoft.Json;
using System;

namespace InitialEnterprise.Shared.Dtos
{
    public abstract class DataTransferObject : IDataTransferObject
    {     
        [JsonIgnore]
        public Guid UserId { get; set; }

        public string Uri { get; set; }
    }
}