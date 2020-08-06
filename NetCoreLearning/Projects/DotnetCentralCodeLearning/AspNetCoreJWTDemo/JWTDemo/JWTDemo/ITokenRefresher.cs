namespace JWTDemo
{
    public interface ITokenRefresher
    {
        AuthenticationResponse Refresh(RefreshCredential refreshCredential);
    }
}