
namespace InitialEnterprise.Infrastructure.Application
{
    public class SelectListItemDto<TKey, TValue>
    {
        public TKey Id { get; set; }

        public TValue Value { get; set; } 
    }
}
