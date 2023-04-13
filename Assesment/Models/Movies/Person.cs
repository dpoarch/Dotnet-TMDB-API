using Assesment.Models.Movies.Response;
using System.Collections.Generic;

namespace Assesment.Models.Movies
{
    public class Person
    {

        public int page { get; set; }
        public List<PersonResponse> results { get; set; }
        public int total_pages { get; set; }
        public int total_results { get; set; }
    }
}
