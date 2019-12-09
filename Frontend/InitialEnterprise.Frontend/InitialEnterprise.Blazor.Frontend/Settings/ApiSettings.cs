namespace InitialEnterprise.Blazor.Frontend.Settings
{
    public class ApiSettings
    { 
        public string Url { get; set; }

        public ApiSettings()
        {
            Url = "http://localhost:55555/api";
        }
    }
}


