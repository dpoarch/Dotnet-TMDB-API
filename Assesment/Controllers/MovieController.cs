using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Assesment.Models.Movies;
using Assesment.Interfaces;
using Assesment.Models.Movies.Requests;
using Assesment.Models.Movies.Response;

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
       
        [HttpPost("Search")]
        public async Task<ActionResult<ResultResponse>> Index([FromBody] MovieRequest request)
        {
            var response = await movieService.SearchMovies(request);
            if (!response.IsSuccess)
            {
                return BadRequest(response.Message);
            }
            return Ok(response.Response);
        }
    }
}
