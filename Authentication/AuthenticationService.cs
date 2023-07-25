using IdentityGama.Interface.Authentication;
using IdentityGama.Utils;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Threading.Tasks;

namespace IdentityGama.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfigurationRoot _configuration;

        public AuthenticationService()
        {
            _httpClient = new HttpClient();
            _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
        }

        public async Task<bool> IsAuthenticatedAsync(string? token)
        {
            if (string.IsNullOrWhiteSpace(token)) 
                return false;
            var validationUrl = $"{_configuration["URLIdentityServer"]}/valid-token";
            var request = new HttpRequestMessage(HttpMethod.Head, validationUrl);
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
