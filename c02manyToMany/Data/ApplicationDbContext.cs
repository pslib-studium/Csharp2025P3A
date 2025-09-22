using c02manyToMany.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace c02manyToMany.Data
{
    internal class ApplicationDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Artist> Artists { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=TheMovieBase.sqlite");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            const int qtId = 1;
            const int bpId = 2;
            const int ldId = 3;
            const int outhId = 1;
            Artist quent = new() { ArtistId = qtId, FirstName = "Quentin", LastName = "Tarantino" };
            Artist pitt = new() { ArtistId = bpId, FirstName = "Brad", LastName = "Pitt" };
            Artist leo = new() { ArtistId = ldId, FirstName = "Leonardo", LastName = "DiCaprio" };
            Movie outh = new() { MovieId = outhId, Title = "Once Upon a Time in Hollywood", ReleaseYear = 2019 };
            modelBuilder.Entity<Artist>(ent =>
            {
                ent.HasMany(a => a.Movies)
                   .WithMany(m => m.Artists)
                   .UsingEntity<MovieArtist>();
                ent.HasData(
                    quent,
                    pitt,
                    leo
                );
            });
            modelBuilder.Entity<Movie>(ent =>
            {
                ent.HasData(
                    outh,
                    new Movie { MovieId = 2, Title = "Inglourious Basterds", ReleaseYear = 2009 },
                    new Movie { MovieId = 3, Title = "Django Unchained", ReleaseYear = 2012 }
                );
            });
            modelBuilder.Entity<MovieArtist>(ent =>
            {
                ent.HasKey(ma => new { ma.MovieId, ma.ArtistId });
                ent.HasData(
                    new MovieArtist { MovieId = outhId, ArtistId = qtId },
                    new MovieArtist { MovieId = outhId, ArtistId = bpId },
                    new MovieArtist { MovieId = outhId, ArtistId = ldId }
                );
            });
        }
    }
}
