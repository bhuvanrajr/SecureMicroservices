using IdentityModel.Client;
using Movies.Client.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Movies.Client.API_Services
{
    public class MovieApiService : IMovieApiService
    {

        IHttpClientFactory _httpClientFactory = null;
        public MovieApiService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public Task<Movie> CreateMovie(Movie movie)
        {
            throw new NotImplementedException();
        }

        public Task DeleteMovie(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Movie> GetMovie(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Movie>> GetMovies()
        {
            //var apiClientCredentials = new ClientCredentialsTokenRequest
            //{
            //    Address = "https://localhost:5005/connect/token",
            //    ClientId = "movieClient",
            //    ClientSecret = "secret",
            //    Scope = "movieAPI"
            //};


            //var httpclient = new HttpClient();
            //var discoveryDoc = await httpclient.GetDiscoveryDocumentAsync("https://localhost:5005");
            //if(discoveryDoc.IsError)
            //{
            //    return null;
            //}


            //var tokenResponse = await httpclient.RequestClientCredentialsTokenAsync(apiClientCredentials);
            //if(tokenResponse.IsError)
            //{
            //    return null;
            //}

            //var apiClient = new HttpClient();
            //apiClient.SetBearerToken(tokenResponse.AccessToken);


            //var result = await apiClient.GetAsync("https://localhost:5001/api/movies");
            //result.EnsureSuccessStatusCode();

            var client = _httpClientFactory.CreateClient("MoviesAPIClient");

            var result = await client.SendAsync(new HttpRequestMessage(HttpMethod.Get, "/movies"));
            result.EnsureSuccessStatusCode();
            var content = await result.Content.ReadAsStringAsync();

            List<Movie> movies = JsonConvert.DeserializeObject<List<Movie>>(content);
            return movies;
        }

        public Task<Movie> UpdateMovie(Movie movie)
        {
            throw new NotImplementedException();
        }
    }
}
