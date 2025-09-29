using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace c02manyToMany.Models
{
    internal class Movie
    {
        public int MovieId { get; set; }
        public required string Title { get; set; }
        public int ReleaseYear { get; set; }
        public List<Artist> Artists { get; set; } = new List<Artist>();
        [JsonIgnore]
        // Not mapped = Ignore this property when creating the database schema
        // JsonIgnore = Ignore this property when serializing to JSON
        public List<MovieArtist> Roles { get; set; } = new List<MovieArtist>();
    }
}
