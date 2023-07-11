using Microsoft.Extensions.Options;
using Movies.API.Models;
using Movies.Application.Models;
using Movies.Application.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Application.Services.Implementation
{
    public class TmdbApiService : ITmdbApiService
    {
        private readonly ApiKeyConfiguration _apiKeyConfig;
        private readonly IHttpClientFactory _httpClientFactory;
        public TmdbApiService(IOptions<ApiKeyConfiguration> apiKeyConfig, IHttpClientFactory httpClientFactory)
        {
            _apiKeyConfig = apiKeyConfig.Value;
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IEnumerable<MovieResponse>> SearchMovies(string title, int year)
        {
            var url = "https://api.themoviedb.org/3/search/movie";
            var query = "Jack Reacher";
            var apiKey = "38e17ed9fec400f7d0444bee8e27c35f";

            var httpClient = new HttpClient();

            // Construct the request URL with query parameters
            var requestUrl = $"{url}?query={Uri.EscapeDataString(query)}&api_key={apiKey}";

            // Send GET request
            var response = await httpClient.GetAsync(requestUrl);

            // Check if the request was successful
            if (response.IsSuccessStatusCode)
            {
                // Read the response content
                var responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseBody);
            }
            else
            {
                Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
            }
            return new List<MovieResponse> { };
        }
    }
}
