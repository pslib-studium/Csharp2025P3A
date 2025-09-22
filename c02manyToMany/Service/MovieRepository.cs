using c02manyToMany.Data;
using c02manyToMany.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c02manyToMany.Service
{
    internal class MovieRepository
    {
        private readonly ApplicationDbContext _context;

        public MovieRepository(ApplicationDbContext? context)
        {
            _context = context ??= new ApplicationDbContext();
        }

        public List<Movie> GetAllMovies(string? title, int? sinceYear)
        {
            IQueryable<Movie> query = _context.Movies;
            // filtry
            if (!String.IsNullOrEmpty(title))
            {
                query = query.Where(m => m.Title.Contains(title));
            }
            if (sinceYear.HasValue)
            {
                query = query.Where(m => m.ReleaseYear >= sinceYear.Value);
            }
            return query.ToList();
        }
    }
}
