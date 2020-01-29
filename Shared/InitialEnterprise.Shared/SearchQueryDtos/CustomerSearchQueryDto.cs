namespace InitialEnterprise.Shared.Dtos
{
    public class CustomerSearchQueryDto
    {
        public string Id { get; set; }

        public CustomerSearchQueryDto(string id)
        {
            this.Id = id;
        }
    }
}
