using System.Collections.Generic;

namespace Assesment.Models.Movies.Response
{
    public class ResultResponse
    {
        public List<MovieResponse> movies { get; set; }
        public List<PersonResponse> persons { get; set; }
    }
}
