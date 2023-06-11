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
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }
        
        public async Task<Category> GetSingleCategoryByIdWithLawyerAsync(int categoryId)
        {
            return await _context.Categories.Include(x => x.Lawyers).Where(x => x.Id == categoryId).SingleOrDefaultAsync();
        }
    }
}
