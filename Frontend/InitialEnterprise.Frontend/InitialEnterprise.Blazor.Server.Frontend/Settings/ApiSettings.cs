
using Microsoft.Extensions.Configuration;

namespace InitialEnterprise.Blazor.Frontend.Settings
{
    public class ApiSettings
    {
        public ApiSettings(IConfiguration configuration)
        {
            configuration.GetSection(nameof(ApiSettings)).Bind(this);
        }

        public string Url { get; set; }
    }
}
