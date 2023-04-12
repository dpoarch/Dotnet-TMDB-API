using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assesment.Models
{
    public class History
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public string Query { get; set; }
        public string MovieData { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
