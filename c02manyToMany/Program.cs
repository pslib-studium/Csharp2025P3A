// See https://aka.ms/new-console-template for more information
using c02manyToMany.Data;
using c02manyToMany.Models;
using c02manyToMany.Service;
using Microsoft.EntityFrameworkCore;

ApplicationDbContext context = new ApplicationDbContext();
context.Database.EnsureDeleted();
context.Database.EnsureCreated();
Console.WriteLine("Database created!");
var repo = new MovieRepository(context);

List<Movie> movies = repo.GetAllMovies(null, null, MovieSort.None,2,1);

foreach (var movie in movies)
{
    Console.WriteLine($"{movie.Title} ({movie.ReleaseYear})");
    foreach (var role in movie.Roles)
    {
        Console.WriteLine($"   {role.Artist.FirstName} {role.Artist.LastName} ({role.Kind})");
    }
}
