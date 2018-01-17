using NetCoreSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace NetCoreSample.Clients
{
    public interface IMoviesApiClient
    {
        Task<IEnumerable<Movie>> GetMovies();

        Task<IEnumerable<Movie>> GetMovies(string title);

        Task<Movie> GetMovie(int id);

        Task<HttpStatusCode> CreateMovie(Movie movie);

        Task<HttpStatusCode> UpdateMovie(int id, Movie movie);

        Task<HttpStatusCode> DeleteMovie(int id);
    }
}
