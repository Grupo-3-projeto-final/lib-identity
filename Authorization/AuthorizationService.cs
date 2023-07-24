using IdentityGama.Interface.Authorization;
using IdentityGama.Utils;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;

namespace IdentityGama.Authorization
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly HttpClient _httpClient;

        public AuthorizationService()
        {
            _httpClient = new HttpClient();

        }

        public async Task<bool> IsAuthorizedAsync(string? token, string? role)
        {
            if (string.IsNullOrEmpty(token) || string.IsNullOrEmpty(role))
                return false;
            string validationUrl = $"{Configuration.ValueAppSettings("URLIdentityServer")}/valid-role-token";
            var request = new HttpRequestMessage(HttpMethod.Head, validationUrl);
            request.Headers.Add("Role", role);
            request.Headers.Add("Authorization", token);

            try
            {
                var response = await _httpClient.SendAsync(request);
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

    }
}
