using InitialEnterprise.Infrastructure.Api.Auth;

namespace InitialEnterprise.Domain.SharedKernel.ClaimModule.Aggreate
{
    public class ClaimDefinition
    {
        public const string READ = "Read";
        public const string WRITE = "Write";
        public const string QUERY = "Query";
        public const string CREATE = "Create";
        public const string DELETE = "Delete";
    }

    public interface IClaimDefinition
    {        
        ClaimRequirement ClaimRequirement { get; }
    }

    public class ClaimQuery : IClaimDefinition
    {
        public const string PolicyName = ClaimDefinition.QUERY;
        public ClaimRequirement ClaimRequirement => new ClaimRequirement("Claim", PolicyName);      
    }


    public class CurrencyCreateClaim : IClaimDefinition
    {
        public const string PolicyName = "Currency" + ClaimDefinition.CREATE;
        public ClaimRequirement ClaimRequirement => new ClaimRequirement("Currency", ClaimDefinition.CREATE);
    }
    public class CurrencyReadClaim : IClaimDefinition
    {
        public const string PolicyName = "Currency" + ClaimDefinition.READ;
        public ClaimRequirement ClaimRequirement => new ClaimRequirement("Currency", ClaimDefinition.READ);
    }
    public class CurrencyWriteClaim : IClaimDefinition
    {
        public const string PolicyName = "Currency" + ClaimDefinition.WRITE;
        public ClaimRequirement ClaimRequirement => new ClaimRequirement("Currency", ClaimDefinition.WRITE);
    }
    public class CurrencyDeleteClaim : IClaimDefinition
    {
        public const string PolicyName = "Currency" + ClaimDefinition.DELETE;
        public ClaimRequirement ClaimRequirement => new ClaimRequirement("Currency", ClaimDefinition.DELETE);
    }
    public class CurrencyQueryClaim : IClaimDefinition
    {
        public const string PolicyName = "Currency" + ClaimDefinition.QUERY;
        public ClaimRequirement ClaimRequirement => new ClaimRequirement("Currency", ClaimDefinition.QUERY);
    }


    public class PersonCreateClaim : IClaimDefinition
    {
        public const string PolicyName = "Person" + ClaimDefinition.CREATE;
        public ClaimRequirement ClaimRequirement => new ClaimRequirement("Person", ClaimDefinition.CREATE);

    }
    public class PersonReadClaim : IClaimDefinition
    {
        public const string PolicyName = "Person" + ClaimDefinition.READ;
        public ClaimRequirement ClaimRequirement => new ClaimRequirement("Person", ClaimDefinition.READ);
    }
    public class PersonWriteClaim : IClaimDefinition
    {
        public const string PolicyName = "Person" + ClaimDefinition.WRITE;
        public ClaimRequirement ClaimRequirement => new ClaimRequirement("Person", ClaimDefinition.WRITE);
    }
    public class PersonDeleteClaim : IClaimDefinition
    {

        public const string PolicyName = "Person" + ClaimDefinition.DELETE;
        public ClaimRequirement ClaimRequirement => new ClaimRequirement("Person", ClaimDefinition.DELETE);
    }
    public class PersonQueryClaim : IClaimDefinition
    {
        public const string PolicyName = "Person" + ClaimDefinition.QUERY;
        public ClaimRequirement ClaimRequirement => new ClaimRequirement("Person", ClaimDefinition.QUERY);
    }


    public class UserCreateClaim : IClaimDefinition
    {
        public const string PolicyName = "User" + ClaimDefinition.CREATE;
        public ClaimRequirement ClaimRequirement => new ClaimRequirement("User", PolicyName);

    }
    public class UserReadClaim : IClaimDefinition
    {
        public const string PolicyName = "User" + ClaimDefinition.READ;
        public ClaimRequirement ClaimRequirement => new ClaimRequirement("User", ClaimDefinition.READ);
    }
    public class UserWriteClaim : IClaimDefinition
    {
        public const string PolicyName = "User" + ClaimDefinition.WRITE;
        public ClaimRequirement ClaimRequirement => new ClaimRequirement("User", ClaimDefinition.WRITE);
    }
    public class UserDeleteClaim : IClaimDefinition
    {
        public const string PolicyName = "User" + ClaimDefinition.DELETE;
        public ClaimRequirement ClaimRequirement => new ClaimRequirement("User", ClaimDefinition.DELETE);
    }
    public class UserQueryClaim : IClaimDefinition
    {
        public const string PolicyName = "User" + ClaimDefinition.QUERY;
        public ClaimRequirement ClaimRequirement => new ClaimRequirement("User", ClaimDefinition.QUERY);
    }


    public class CountryCreateClaim : IClaimDefinition
    {
        public const string PolicyName = "Country" + ClaimDefinition.CREATE;
        public ClaimRequirement ClaimRequirement => new ClaimRequirement("Country", PolicyName);

    }
    public class CountryReadClaim : IClaimDefinition
    {
        public const string PolicyName = "Country" + ClaimDefinition.READ;
        public ClaimRequirement ClaimRequirement => new ClaimRequirement("Country", ClaimDefinition.READ);
    }
    public class CountryWriteClaim : IClaimDefinition
    {
        public const string PolicyName = "Country" + ClaimDefinition.WRITE;
        public ClaimRequirement ClaimRequirement => new ClaimRequirement("Country", ClaimDefinition.WRITE);
    }
    public class CountryDeleteClaim : IClaimDefinition
    {
        public const string PolicyName = "Country" + ClaimDefinition.DELETE;
        public ClaimRequirement ClaimRequirement => new ClaimRequirement("Country", ClaimDefinition.DELETE);
    }
    public class CountryQueryClaim : IClaimDefinition
    {
        public const string PolicyName = "Country" + ClaimDefinition.QUERY;
        public ClaimRequirement ClaimRequirement => new ClaimRequirement("Country", ClaimDefinition.QUERY);
    }


    public class CustomerCreateClaim : IClaimDefinition
    {
        public const string PolicyName = "Customer" + ClaimDefinition.CREATE;
        public ClaimRequirement ClaimRequirement => new ClaimRequirement("Customer", PolicyName);

    }
    public class CustomerReadClaim : IClaimDefinition
    {
        public const string PolicyName = "Customer" + ClaimDefinition.READ;
        public ClaimRequirement ClaimRequirement => new ClaimRequirement("Customer", ClaimDefinition.READ);
    }
    public class CustomerWriteClaim : IClaimDefinition
    {
        public const string PolicyName = "Customer" + ClaimDefinition.WRITE;
        public ClaimRequirement ClaimRequirement => new ClaimRequirement("Customer", ClaimDefinition.WRITE);
    }
    public class CustomerDeleteClaim : IClaimDefinition
    {
        public const string PolicyName = "Customer" + ClaimDefinition.DELETE;
        public ClaimRequirement ClaimRequirement => new ClaimRequirement("Customer", ClaimDefinition.DELETE);
    }
    public class CustomerQueryClaim : IClaimDefinition
    {
        public const string PolicyName = "Customer" + ClaimDefinition.QUERY;
        public ClaimRequirement ClaimRequirement => new ClaimRequirement("Customer", ClaimDefinition.QUERY);
    }

}