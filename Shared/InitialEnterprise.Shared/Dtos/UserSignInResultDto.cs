namespace InitialEnterprise.Shared.Dtos.User
{
    public class UserSignInResultDto
    {       
        public bool Success { get; set; }
        public UserDto User { get; set; }
        public string Token { get; set; }        
    } 
}
