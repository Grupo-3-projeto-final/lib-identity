namespace IdentityGama.Interface.Authentication
{
    public interface IAuthenticationService
    {
        Task<bool> IsAuthenticatedAsync(string? token);
    }
}