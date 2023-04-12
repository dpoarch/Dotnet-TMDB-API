using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Assesment.Models.Movies;
using Assesment.Interfaces;

namespace Assesment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService movieService;

        public MovieController(IMovieService _movieService)
        {
            this.movieService = _movieService;
        }
       
        [HttpGet("{userId}/{search}")]
        public async Task<ActionResult<Result>> Index(string userId, string search)
        {
            return Ok(await movieService.SearchMovies(userId, search));
        }
    }
}
