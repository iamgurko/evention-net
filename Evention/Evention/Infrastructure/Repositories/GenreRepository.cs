using System.Collections.Generic;
using System.Linq;
using Evention.Core.Dtos;
using Evention.Core.Models;
using Evention.Core.Repositories;

namespace Evention.Infrastructure.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly ApplicationDbContext _context;

        public GenreRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Genre> GetGenres()
        {
            return _context.Genres.ToList();
        }
    }
}