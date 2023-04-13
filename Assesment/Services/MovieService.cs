using Assesment.Data;
using Assesment.Interfaces;
using Assesment.Models;
using Assesment.Models.Movies;
using Assesment.Models.Movies.Requests;
using Assesment.Models.Movies.Response;
using Assesment.Models.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Assesment.Services
{
    public class MovieService : IMovieService
    {
        IConfiguration configuration;
        private readonly AbstractDbContext abstractDbContext;
        public MovieService(IConfiguration _configuration, AbstractDbContext abstractDbContext)
        {
            this.configuration = _configuration;
            this.abstractDbContext = abstractDbContext;
        }

        public async Task<TransactionResponse<ResultResponse>> SearchMovies(MovieRequest request)
        {
            var baseAddress = new Uri("http://api.themoviedb.org/3/");
            var token = configuration.GetValue<string>("Token:tmdbKey");
            var searchQuery = string.Format("search/movie?api_key={0}&query={1}", token, request.search);
            var users = abstractDbContext.Users.FirstOrDefaultAsync(x => x.Id == request.userId);
            Movie movie;
            Person person;
            if (users.Result != null)
            {
                var history = abstractDbContext.History.FirstOrDefault(x => x.UserId == request.userId && x.Query == request.search);
                if (history == null)
                {
                    System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };


                    string responseData = "";
                    string personData = "";
                    var httpClient = new HttpClient { BaseAddress = baseAddress };
                    httpClient.DefaultRequestHeaders.TryAddWithoutValidation("accept", "application/json");
                    var response = await httpClient.GetAsync(searchQuery);
                    responseData = await response.Content.ReadAsStringAsync();
                    movie = JsonConvert.DeserializeObject<Movie>(responseData);

                    //search persons
                    var newHttpClient = new HttpClient { BaseAddress = baseAddress };
                    newHttpClient.DefaultRequestHeaders.TryAddWithoutValidation("accept", "application/json");
                    searchQuery = string.Format("search/person?api_key={0}&query={1}", token, request.search);
                    var personResponse = await newHttpClient.GetAsync(searchQuery);
                    personData = await personResponse.Content.ReadAsStringAsync();
                    person = JsonConvert.DeserializeObject<Person>(personData);

                    var map = new History();
                    map.UserId = request.userId;
                    map.Query = request.search;
                    map.MovieData = responseData;
                    map.PersonData = personData;
                    map.DateCreated = DateTime.Now;

                    await abstractDbContext.History.AddAsync(map);
                    await abstractDbContext.SaveChangesAsync();
                }
                else
                {
                    movie = JsonConvert.DeserializeObject<Movie>(history.MovieData);
                    person = JsonConvert.DeserializeObject<Person>(history.PersonData);
                }

                var resultResponse = new ResultResponse()
                {
                    movies = movie.results,
                    persons = person.results
                };

                return new TransactionResponse<ResultResponse>
                {
                    Response = resultResponse
                };
            }

            return new TransactionResponse<ResultResponse>()
            {
                IsSuccess = false,
                Message = "User does not exist!"
            };

        }
    }
}
