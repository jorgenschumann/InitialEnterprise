using System.ComponentModel.DataAnnotations;

namespace InitialEnterprise.Infrastructure.Application
{
    public class BaseDataTransferObject : IDataTransferObject
    {
        [Required]
        public int UserId { get; set; }
    }
}
