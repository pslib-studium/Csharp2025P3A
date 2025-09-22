using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c02manyToMany.Models
{
    internal class MovieArtist
    {
        [ForeignKey(nameof(Movie))]
        public int MovieId { get; set; }

        public Movie Movie { get; set; } = null!;

        [ForeignKey(nameof(Artist))]
        public int ArtistId { get; set; }

        public Artist Artist { get; set; } = null!;
    }
}
