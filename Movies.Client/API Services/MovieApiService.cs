using Movies.Client.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Movies.Client.API_Services
{
    public class MovieApiService : IMovieApiService
    {
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
            List<Movie> movies =  new List<Movie>() {
                    new Movie {
                        Id = 1,
                        Genre = "Action",
                        ImageUrl = "Images",
                        Owner = "Bhuvan",
                        Rating = "5",
                        ReleaseDate = DateTime.Today,
                        Title = "Bahadhoor Gandu" }
            };

            return await Task.FromResult(movies);
        }

        public Task<Movie> UpdateMovie(Movie movie)
        {
            throw new NotImplementedException();
        }
    }
}
