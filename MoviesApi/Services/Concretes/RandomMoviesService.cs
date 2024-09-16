using Microsoft.AspNetCore.Mvc;
using MoviesApi.Dtos;
using MoviesApi.Entities;
using MoviesApi.Services.Abstracts;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace MoviesApi.Services.Concretes
{
    public class RandomMoviesService : IRandomMoviesService
    {
        private readonly HttpClient _httpClient;
        private readonly Random _random;

        public RandomMoviesService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _random = new Random();
        }

        public async Task<Movie> GetRandomMovieAsync()
        {
            var randomLetter = (char)_random.Next('a', 'z' + 1);

            //var response = await _httpClient.GetAsync($"http://www.omdbapi.com/?s={randomLetter}&apikey=a581e938");
            var response = await _httpClient.GetAsync($"http://www.omdbapi.com/?t={randomLetter}&apikey=a581e938");
            response.EnsureSuccessStatusCode();

            //if (response.IsSuccessStatusCode)
            //{
            //    var jsonResponse = await response.Content.ReadAsStringAsync();
            //    var movieResponse = JsonConvert.DeserializeObject<List<Movie>>(jsonResponse);
            //    var movie = movieResponse.FirstOrDefault();
            //    return movie;
            //}

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var movieResponse = JsonConvert.DeserializeObject<Movie>(jsonResponse);
                return movieResponse;
            }

            return null;
        }
    }
}
