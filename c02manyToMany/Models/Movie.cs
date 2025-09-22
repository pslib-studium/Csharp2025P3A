using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c02manyToMany.Models
{
    internal class Movie
    {
        public int MovieId { get; set; }
        public required string Title { get; set; }
        public int ReleaseYear { get; set; }
        public List<Artist> Artists { get; set; } = new List<Artist>();
    }
}
