using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c02manyToMany.Models
{
    internal class Artist
    {
        public int ArtistId { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string? MiddleName { get; set; }
        public List<Movie> Movies { get; set; } = new List<Movie>();
    }
}
