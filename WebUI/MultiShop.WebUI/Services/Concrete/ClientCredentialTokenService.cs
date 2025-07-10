using IdentityModel.Client;
using Microsoft.Extensions.Options;
using MultiShop.WebUI.Services.Interfaces;
using MultiShop.WebUI.Settings;

namespace MultiShop.WebUI.Services.Concrete
{
    public class ClientCredentialTokenService : IClientCredentialTokenService
    {
        private readonly ServiceApiSettings _serviceApiSettings;
        private readonly HttpClient _httpClient;
        private readonly IClientAccessTokenCache _clientAccessTokenCache; //identitymodel 4 ? 
        private readonly ClientSettings _clientSettings;

        public ClientCredentialTokenService(IOptions<ServiceApiSettings> serviceApiSettings, HttpClient httpClient, IClientAccessTokenCache clientAccessTokenCache, IOptions<ClientSettings> clientSettings)
        {
            _serviceApiSettings = serviceApiSettings.Value;
            _httpClient = httpClient;
            _clientAccessTokenCache = clientAccessTokenCache;
            _clientSettings = clientSettings.Value;
        }

        public async Task<string> GetToken()   //deneme kodum !!
        {
            var token = await _clientAccessTokenCache.GetAsync("multishoptoken");
            if (token != null)
            {
                return token;
            }

            var discoveryEndPoint = await _httpClient.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
            {
                Address = _serviceApiSettings.IdentityServerUrl,
                Policy = new DiscoveryPolicy
                {
                    RequireHttps = false
                }
            });

            var clientCredentialTokenRequest = new ClientCredentialsTokenRequest
            {
                ClientId = _clientSettings.MultiShopVisitorClient.ClientId,
                ClientSecret = _clientSettings.MultiShopVisitorClient.ClientSecret,
                Address = discoveryEndPoint.TokenEndpoint
            };

            var tokenResponse = await _httpClient.RequestClientCredentialsTokenAsync(clientCredentialTokenRequest);

            if (tokenResponse.IsError)
                throw new Exception("Token alınamadı: " + tokenResponse.Error);

            await _clientAccessTokenCache.SetAsync("multishoptoken", tokenResponse.AccessToken, tokenResponse.ExpiresIn);

            return tokenResponse.AccessToken;
        }


        //public async Task<string> GetToken() //kurstaki orjinal kod
        //{
        //    var token1 = await _clientAccessTokenCache.GetAsync("multishoptoken");
        //    if(token1 != null)
        //    {
        //        //return currentToken.AccessToken; // ??

        //    }
        //    var discoveryEndPoint = await _httpClient.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
        //    {
        //        Address = _serviceApiSettings.IdentityServerUrl,
        //        Policy = new DiscoveryPolicy
        //        {
        //            RequireHttps = false
        //        }
        //    });

        //    var clientCredentialTokenRequest = new ClientCredentialsTokenRequest
        //    {
        //        ClientId = _clientSettings.MultiShopVisitorClient.ClientId,
        //        ClientSecret = _clientSettings.MultiShopVisitorClient.ClientSecret,
        //        Address = discoveryEndPoint.TokenEndpoint
        //    };

        //    var token2 = await _httpClient.RequestClientCredentialsTokenAsync(clientCredentialTokenRequest);
        //    //await _clientAccessTokenCache.SetAsync("multishoptoken", token2.AccessToken, token2.ExpiresIn);
        //    return token2.AccessToken;

        //}


    }

    public interface IClientAccessTokenCache  // burası paket olmadığından tanımlı ? düzelt ? kendim yazdım ?
    {
        Task<string> GetAsync(string key);
        Task SetAsync(string key, string token, int expiresInSeconds);
    }
}
