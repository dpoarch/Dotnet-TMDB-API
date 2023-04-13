using Assesment.Models;
using Assesment.Models.Movies;
using Assesment.Models.Movies.Requests;
using Assesment.Models.Movies.Response;
using Assesment.Models.Shared;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Assesment.Interfaces
{
    public interface IMovieService
    {
        Task<TransactionResponse<ResultResponse>> SearchMovies(MovieRequest request);
    }
}
