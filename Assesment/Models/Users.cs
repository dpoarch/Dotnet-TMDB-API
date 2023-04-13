using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assesment.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
