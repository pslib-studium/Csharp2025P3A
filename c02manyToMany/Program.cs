// See https://aka.ms/new-console-template for more information
using c02manyToMany.Data;
using Microsoft.EntityFrameworkCore;

ApplicationDbContext context = new ApplicationDbContext();
context.Database.EnsureDeleted();
context.Database.EnsureCreated();
Console.WriteLine("Database created!");
foreach (var movie in context.Movies.Include(m => m.Artists))
{
    Console.WriteLine($"{movie.Title} ({movie.ReleaseYear})");
    foreach (var artist in movie.Artists)
    {
        Console.WriteLine($"\t{artist.FirstName} {artist.LastName}");
    }
}
