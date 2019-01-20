namespace InitialEnterprise.Domain.SharedKernel.ClaimDefinitions
{
    public abstract class ClaimDefinition
    {
        protected const string READ = "Read";
        protected const string WRITE = "Write";
        protected const string QUERY = "Query";
        protected const string CREATE = "Create";
    }

    public class CurrencyClaims : ClaimDefinition
    {
        public const string CurrencyRead = READ;
        public const string CurrencyQuery = QUERY;
        public const string CurrencyWrite = WRITE;
    }

    public class PaymentClaims : ClaimDefinition
    {
        public const string PaymentRead = READ;
        public const string PaymentWrite = WRITE;
    }

    public class PersonClaims : ClaimDefinition
    {
        public const string PersonRead = READ;
        public const string PersonWrite = WRITE;
        public const string PersonCreate = CREATE;
    }

    public class UserClaims : ClaimDefinition
    {
        public const string UserRead = READ;
        public const string UserWrite = WRITE;
    }
}