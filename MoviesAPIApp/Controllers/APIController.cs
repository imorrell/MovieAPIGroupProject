using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MoviesAPIApp.Models;

namespace MoviesAPIApp.Controllers
{
    public class APIController : Controller
    {
        public async Task<IActionResult> DisplayMoviesByTitle(string title)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://www.omdbapi.com/");
            //client.DefaultRequestHeaders.Add("apikey", "ea9c912e");

            var response = await client.GetAsync($"?apikey=ea9c912e&s={title}");
            //Install Microsoft.AspNet.WebApI.Client Nuget Package
            //var movies = await response.Content.ReadAsStringAsync();
            var movies = await response.Content.ReadAsAsync<Searchobject>();
            return View(movies);
        }

        public async Task<IActionResult> SearchByTitle(string title)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://www.omdbapi.com/");
            //client.DefaultRequestHeaders.Add("apikey", "ea9c912e");

            var response = await client.GetAsync($"?apikey=ea9c912e&t={title}");
            //Install Microsoft.AspNet.WebApI.Client Nuget Package
            //var movies = await response.Content.ReadAsStringAsync();
            var movies = await response.Content.ReadAsAsync<Search>();
            return View(movies);
        }



        public IActionResult Index()
        {
            return View();
        }
    }
}