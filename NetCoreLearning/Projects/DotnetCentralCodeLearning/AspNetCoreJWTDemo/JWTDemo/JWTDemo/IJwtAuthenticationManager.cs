namespace JWTDemo
{
    public interface IJwtAuthenticationManager
    {
        string Authenticate(string userName, string password);
    }
}