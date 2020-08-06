namespace JWTDemo
{
    public class UserCredential
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class RefreshCredential
    {
        public string JwtToken { get; set; }
        public string RefreshToken { get; set; }
    }
}