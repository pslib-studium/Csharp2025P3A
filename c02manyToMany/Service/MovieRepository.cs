using c02manyToMany.Data;
using c02manyToMany.Models;
using Microsoft.EntityFrameworkCore;
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

        public List<Movie> GetAllMovies(
            string? title, 
            int? sinceYear, 
            MovieSort order = MovieSort.None,
            int? page = null,
            int? size = null
            )
        {
            IQueryable<Movie> query = _context.Movies
                //.Include(m => m.Artists)
                .Include(m => m.Roles).ThenInclude(ma => ma.Artist);
            // filtry
            if (!String.IsNullOrEmpty(title))
            {
                query = query.Where(m => m.Title.Contains(title));
            }
            if (sinceYear.HasValue)
            {
                query = query.Where(m => m.ReleaseYear >= sinceYear.Value);
            }
            // řazení
            query = order switch
            {
                MovieSort.TitleAsc => query.OrderBy(m => m.Title),
                MovieSort.TitleDesc => query.OrderByDescending(m => m.Title),
                MovieSort.YearAsc => query.OrderBy(m => m.ReleaseYear),
                MovieSort.YearDesc => query.OrderByDescending(m => m.ReleaseYear),
                _ => query // bez řazení = default
            };
            int count = query.Count();
            // stránkování
            if (page.HasValue && size.HasValue && page > 0 && size > 0)
            {
                int skip = (page.Value - 1) * size.Value;
                if (skip < count)
                {
                    query = query.Skip(skip).Take(size.Value);
                }
            }
            return query.ToList();         
        }
        public Movie? Get(int id)
        {
            var item = _context.Movies
                .Where(m => m.MovieId == id)
                .SingleOrDefault();
            //.First() - _1,2,3,
            //.FirstOrDefault(); - 0
            //.Last()
            //.LastOrDefault();
            //.Single() - 1
            //.SingleOrDefault() - 0,1
            //.Query()
            //.ToList()
            //.ToArray();
            //if (item == null) return 404;
            return item;
        }
    }

    enum MovieSort
    {
        None,
        TitleAsc,
        TitleDesc,
        YearAsc,
        YearDesc
    }
}
