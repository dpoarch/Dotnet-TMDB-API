using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assesment.Models
{
    public class History
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Query { get; set; }
        public string MovieData { get; set; }
        public string PersonData { get; set; }
        public DateTime DateCreated { get; set; }

        [ForeignKey("UserId")]
        public virtual Users Users { get; set; }
    }
}
