using Assesment.Models;
using Assesment.Models.Movies;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Assesment.Interfaces
{
    public interface IMovieService
    {
        Task<IEnumerable<Result>> SearchMovies(string userId, string search);
    }
}
