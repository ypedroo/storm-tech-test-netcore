using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Todo.ValueObjects;


namespace Todo.Services
{
    public class GravatarApiClient
    {
        private readonly HttpClient _httpClient;
        private const string DefaultGravatarImage = "http://www.gravatar.com/avatar";

        public GravatarApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<(string, string)> GetProfile(string email)
        {
            try
            {
                var emailHash = Gravatar.GetHash(email);
                var response = await _httpClient.GetFromJsonAsync<Response>($"{emailHash}.json");
                var entry = response?.Entry.FirstOrDefault();
                if (entry == null) return ("", "");
                var name = entry.DisplayName;
                var photo = entry.Photos != null && entry.Photos.Any() &&
                            !string.IsNullOrWhiteSpace(entry.Photos.First().Value)
                    ? entry.Photos.First().Value
                    : "";
                return (name, photo);
            }
            catch (Exception ex)
            {
                if (ex is HttpRequestException or TaskCanceledException)
                    return ("", DefaultGravatarImage);

                throw; 
            }
            
        }
    }
}