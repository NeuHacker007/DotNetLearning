namespace JwtTokenServerAPI
{
    public interface IJwtAuthenticationManager
    {
        /// <summary>
        /// Use to Get JWT Token
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>Jwt Token</returns>
        string Authenticate(string username, string password);
    }
}