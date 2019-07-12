using InitialEnterprise.Domain.MainBoundedContext.Api;

namespace InitialEnterprise.Domain.SharedKernel.ClaimDefinitions
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
        public const string PolicyName = ClaimDefinition.CREATE;
        public ClaimRequirement ClaimRequirement => new ClaimRequirement("Currency", PolicyName);
    }
    public class CurrencyReadClaim : IClaimDefinition
    {
        public const string PolicyName = ClaimDefinition.READ;
        public ClaimRequirement ClaimRequirement => new ClaimRequirement("Currency", PolicyName);
    }
    public class CurrencyWriteClaim : IClaimDefinition
    {
        public const string PolicyName = ClaimDefinition.WRITE;
        public ClaimRequirement ClaimRequirement => new ClaimRequirement("Currency", PolicyName);
    }
    public class CurrencyDeleteClaim : IClaimDefinition
    {
        public const string PolicyName = ClaimDefinition.DELETE;
        public ClaimRequirement ClaimRequirement => new ClaimRequirement("Currency", PolicyName);
    }
    public class CurrencyQueryClaim : IClaimDefinition
    {
        public const string PolicyName = ClaimDefinition.QUERY;
        public ClaimRequirement ClaimRequirement => new ClaimRequirement("Currency", PolicyName);
    }

    public class PersonCreateClaim : IClaimDefinition
    {
        public const string PolicyName = ClaimDefinition.CREATE;
        public ClaimRequirement ClaimRequirement => new ClaimRequirement("Person", PolicyName);

    }
    public class PersonReadClaim : IClaimDefinition
    {
        public const string PolicyName = ClaimDefinition.READ;
        public ClaimRequirement ClaimRequirement => new ClaimRequirement("Person", PolicyName);
    }
    public class PersonWriteClaim : IClaimDefinition
    {
        public const string PolicyName = ClaimDefinition.WRITE;
        public ClaimRequirement ClaimRequirement => new ClaimRequirement("Person", PolicyName);
    }
    public class PersonDeleteClaim : IClaimDefinition
    {
        public const string PolicyName = ClaimDefinition.DELETE;
        public ClaimRequirement ClaimRequirement => new ClaimRequirement("Person", PolicyName);
    }
    public class PersonQueryClaim : IClaimDefinition
    {
        public const string PolicyName = ClaimDefinition.QUERY;
        public ClaimRequirement ClaimRequirement => new ClaimRequirement("Person", PolicyName);
    }

    public class UserCreateClaim : IClaimDefinition
    {
        public const string PolicyName = ClaimDefinition.CREATE;
        public ClaimRequirement ClaimRequirement => new ClaimRequirement("User", PolicyName);

    }
    public class UserReadClaim : IClaimDefinition
    {
        public const string PolicyName = ClaimDefinition.READ;
        public ClaimRequirement ClaimRequirement => new ClaimRequirement("User", PolicyName);
    }
    public class UserWriteClaim : IClaimDefinition
    {
        public const string PolicyName = ClaimDefinition.WRITE;
        public ClaimRequirement ClaimRequirement => new ClaimRequirement("User", PolicyName);
    }
    public class UserDeleteClaim : IClaimDefinition
    {
        public const string PolicyName = ClaimDefinition.DELETE;
        public ClaimRequirement ClaimRequirement => new ClaimRequirement("User", PolicyName);
    }
    public class UserQueryClaim : IClaimDefinition
    {
        public const string PolicyName = ClaimDefinition.QUERY;
        public ClaimRequirement ClaimRequirement => new ClaimRequirement("User", PolicyName);
    }

}