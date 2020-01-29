using System;

namespace InitialEnterprise.Shared.Dtos
{
    public interface IDataTransferObject
    {
        Guid UserId { get; set; }

        string Uri { get; set; }
    }
}