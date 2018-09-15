
namespace InitialEnterprise.Domain.MainBoundedContext.Api
{
    public class ApplicationDefinitions
    {
        public const string SwaggerTitle = "InitialEnterprise API V1";
        public const string SwaggerVersion = "v1";
        public const string HostingEnvironmentTest = "Test";
    }

    public class ApplicationConfigKeys
    {
        public const string InitialEnterpriseConnectionString = "InitialEnterprise";
        public const string InitialEnterpriseInMemoryConnectionString= "InitialEnterpriseInMemory";
        public const string UseLoadTest = "UseLoadTest";
    }

    public class ApplictionConfigSections
    {
        public const string Logging = "Logging";
    }
}
