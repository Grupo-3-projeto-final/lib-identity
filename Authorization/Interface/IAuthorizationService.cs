namespace IdentityGama.Interface.Authorization
{
    public interface IAuthorizationService
    {
        Task<bool> IsAuthorizedAsync(string? token, string? role);
    }
}