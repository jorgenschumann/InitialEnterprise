namespace InitialEnterprise.BlazorFrontend.Models
{
    public class UserLogin
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public bool RememberMe { get; set; } = false;
    }
}
