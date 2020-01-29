namespace InitialEnterprise.Frontend.Settings
{
    public class ApiSettings
    { 
        public string IndentityUrl{ get; set; }
        public string MainUrl { get; set; }
        public string SalesUrl { get; set; }

        public ApiSettings()
        {
            IndentityUrl = "https://localhost:5001/api";
            MainUrl = "https://localhost:5002/api";
            SalesUrl = "https://localhost:5003/api";
        }
    }
}


