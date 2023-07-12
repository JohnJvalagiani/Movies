using Microsoft.Extensions.Options;
using Movies.Application.Services.Interfaces;
using Movies.Domain.Entities;
using Movies.Infrastructure.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Movies.Application.Services.Implementation
{
    public class TmdbApiService : ITmdbApiService
    {
        private readonly string _baseAPIUrl= "https://api.themoviedb.org/3/search/movie";
        private readonly ApiKeyConfiguration _apiKeyConfig;
        private readonly IHttpClientFactory _httpClientFactory;
        public TmdbApiService(IOptions<ApiKeyConfiguration> apiKeyConfig, IHttpClientFactory httpClientFactory)
        {
            _apiKeyConfig = apiKeyConfig.Value;
            _httpClientFactory = httpClientFactory;
        }
        public async Task<MovieList> SearchMovies(string searchQuery)
        {
                var httpClient = new HttpClient();
                var requestUrl = $"{_baseAPIUrl}?query={Uri.EscapeDataString(searchQuery)}&api_key={_apiKeyConfig.ApiKey}";
                var response = await httpClient.GetAsync(requestUrl);
                var responseBody = await response.Content.ReadAsStringAsync();
                var movieList=JsonConvert.DeserializeObject<MovieList>(responseBody);
                return movieList;
        }
    }
}
