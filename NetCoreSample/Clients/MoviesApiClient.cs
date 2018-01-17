using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using NetCoreSample.Models;
using Newtonsoft.Json;
using Serilog;

namespace NetCoreSample.Clients
{
    public class MoviesApiClient : IMoviesApiClient
    {
        private HttpClient client;

        public MoviesApiClient(string baseUrl, HttpClient client)
        {
            this.BaseUrl = new Uri(baseUrl);
            this.client = client;
        }

        public Uri BaseUrl { get; private set; }
        
        public async Task<HttpStatusCode> CreateMovie(Movie movie)
        {
            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(movie), Encoding.UTF8, "application/json");
                var result = await this.client.PostAsync(BaseUrl + "/api/movies", content);

                return result.StatusCode;
            }
            catch (HttpRequestException ex)
            {
                Log.Error(ex, "Error during Movie POST request");
                return HttpStatusCode.BadRequest;
            }
        }

        public async Task<HttpStatusCode> DeleteMovie(int id)
        {
            var result = await this.client.DeleteAsync(this.BaseUrl + $"/api/movies/{id}");

            return result.StatusCode;
        }

        public async Task<Movie> GetMovie(int id)
        {
            var result = await this.client.GetAsync(BaseUrl + $"/api/movies/{id}");

            var resultJson = await result.Content.ReadAsStringAsync();

            var resultObject = JsonConvert.DeserializeObject<Movie>(resultJson);

            return resultObject;
        }

        public async Task<IEnumerable<Movie>> GetMovies()
        {
            var result = await this.client.GetAsync(BaseUrl + "/api/movies");

            var resultJson = await result.Content.ReadAsStringAsync();

            var resultObjects = JsonConvert.DeserializeObject<IEnumerable<Movie>>(resultJson);

            return resultObjects;
        }

        public async Task<IEnumerable<Movie>> GetMovies(string title)
        {
            var result = await this.client.GetAsync(BaseUrl + $"/api/movies/search/{title}");

            var resultJson = await result.Content.ReadAsStringAsync();

            var resultObjects = JsonConvert.DeserializeObject<IEnumerable<Movie>>(resultJson);

            return resultObjects;
        }

        public async Task<HttpStatusCode> UpdateMovie(int id, Movie movie)
        {
            var content = new StringContent(JsonConvert.SerializeObject(movie), Encoding.UTF8, "application/json");

            var result = await this.client.PutAsync(BaseUrl + $"/api/movies/{id}", content);

            return result.StatusCode;
        }
    }
}
