using AvukatProjectCore.Model;
using AvukatProjectCore.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvukatProjectRepository.Repositories
{
    public class LawyersRepository : GenericRepository<Lawyers>, ILawyersRepository
    {
        public LawyersRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Lawyers>> GetLawyersWithCategory()
        {
            return await _context.Lawyers.Include(x=> x.Category).ToListAsync();

        }
    }
}
