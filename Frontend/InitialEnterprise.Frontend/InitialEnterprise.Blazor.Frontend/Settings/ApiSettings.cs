
namespace InitialEnterprise.Blazor.Frontend.Settings
{
    public class ApiSettings
    {    
        //public ApiSettings(IConfiguration configuration)
        //{
        //   // configuration.GetSection(nameof(ApiSettings)).Bind(this);
        //}

        public string Url { get; set; }

        public ApiSettings()
        {
            Url = "http://localhost:55555/api";
        }
    }
}
