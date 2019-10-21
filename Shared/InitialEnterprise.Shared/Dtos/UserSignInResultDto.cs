namespace InitialEnterprise.Shared.Dtos
{
    public class UserSignInResultDto
    {       
        public bool Success { get; set; }
        public UserDto User { get; set; }
        public string Token { get; set; }        
    } 
}
