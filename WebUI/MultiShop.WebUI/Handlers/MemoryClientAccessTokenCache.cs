using MultiShop.WebUI.Services.Concrete;
using System.Collections.Concurrent;

namespace MultiShop.WebUI.Handlers
{
    public class MemoryClientAccessTokenCache : IClientAccessTokenCache
    {
        private static readonly ConcurrentDictionary<string, (string Token, DateTime Expiration)> _tokenCache = new();

        public Task<string> GetAsync(string key)
        {
            if (_tokenCache.TryGetValue(key, out var value))
            {
                if (value.Expiration > DateTime.UtcNow)
                {
                    return Task.FromResult(value.Token);
                }

                _tokenCache.TryRemove(key, out _);
            }

            return Task.FromResult<string>(null);
        }

        public Task SetAsync(string key, string token, int expiresInSeconds)
        {
            var expiration = DateTime.UtcNow.AddSeconds(expiresInSeconds);
            _tokenCache[key] = (token, expiration);
            return Task.CompletedTask;
        }
    }
}

// kendi yazdığım kod örneği ?