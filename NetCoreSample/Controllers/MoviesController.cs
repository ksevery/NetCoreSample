using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CommonLibrary;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCoreSample.Clients;
using NetCoreSample.Models;

namespace NetCoreSample.Controllers
{
    public class MoviesController : Controller
    {
        private readonly HashSet<HttpStatusCode> SuccessStatusCodes = new HashSet<HttpStatusCode>()
        {
            HttpStatusCode.OK,
            HttpStatusCode.Created,
            HttpStatusCode.NotModified,
            HttpStatusCode.Accepted
        };

        public MoviesController(IMoviesApiClient client, IDependencyClass someClass)
        {
            this.Client = client;
        }

        public IMoviesApiClient Client { get; private set; }

        // GET: Movies
        public async Task<ActionResult> Index()
        {
            var data = await this.Client.GetMovies();
            return View(data);
        }

        // GET: Movies/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var data = await this.GetMovie(id);
            return View(data);
        }

        // GET: Movies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Movie movie)
        {
            var result = await this.Client.CreateMovie(movie);
            if (this.IsSuccessStatusCode(result))
            {
                return RedirectToAction(nameof(Index));
            }
            
            // Return to Create view if there is an error - possibly passing in the error
            return View();
        }

        // GET: Movies/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var data = await this.GetMovie(id);

            return View(data);
        }

        // POST: Movies/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Movie movie)
        {
            var result = await this.Client.UpdateMovie(id, movie);
            if (this.IsSuccessStatusCode(result))
            {
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        // GET: Movies/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var data = await this.GetMovie(id);

            return View(data);
        }

        // POST: Movies/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, Movie movie)
        {
            var result = await this.Client.DeleteMovie(id);
            if (this.IsSuccessStatusCode(result))
            {
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private async Task<Movie> GetMovie(int id)
        {
            var data = await this.Client.GetMovie(id);

            return data;
        } 

        private bool IsSuccessStatusCode(HttpStatusCode statusCode)
        {
            return SuccessStatusCodes.Contains(statusCode);
        }
    }
}