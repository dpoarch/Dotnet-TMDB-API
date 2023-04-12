using Assesment.Data;
using Assesment.Interfaces;
using Assesment.Models;
using Assesment.Models.Movies;
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

        public async Task<IEnumerable<Result>> SearchMovies(string userId, string search)
        {
            var baseAddress = new Uri("http://api.themoviedb.org/3/");
            var token = configuration.GetValue<string>("Token:tmdbKey");
            var searchQuery = string.Format("search/movie?api_key={0}&query={1}", token, search);
            var history = abstractDbContext.History.FirstOrDefaultAsync(x => x.UserId == userId && x.Query == string.Format("{0}{1}", baseAddress.ToString(), searchQuery));
            RootObject model;
            if(history.Result == null)
            {
                System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

               
                string responseData = "";
                using (var httpClient = new HttpClient { BaseAddress = baseAddress })
                {
                    httpClient.DefaultRequestHeaders.TryAddWithoutValidation("accept", "application/json");

                    using (var response = await httpClient.GetAsync(searchQuery))
                    {
                        responseData = await response.Content.ReadAsStringAsync();

                        model = JsonConvert.DeserializeObject<RootObject>(responseData);
                    }
                }

                var map = new History();
                map.UserId = userId;
                map.Query = string.Format("{0}{1}", baseAddress.ToString(), searchQuery);
                map.MovieData = responseData;
                map.DateCreated = DateTime.Now;

                await abstractDbContext.History.AddAsync(map);
                await abstractDbContext.SaveChangesAsync();
            }
            else
            {
                model = JsonConvert.DeserializeObject<RootObject>(history.Result.MovieData);
            }

            

            return model.results;
        }
    }
}
