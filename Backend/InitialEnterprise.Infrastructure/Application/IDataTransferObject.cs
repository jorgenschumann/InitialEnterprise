using System.ComponentModel.DataAnnotations;

namespace InitialEnterprise.Infrastructure.Application
{
    public interface IDataTransferObject
    {
         int UserId { get; set; }
    }

    public class BaseDataTransferObject : IDataTransferObject
    {
        [Required]
        public int UserId { get; set; }
    }
}
