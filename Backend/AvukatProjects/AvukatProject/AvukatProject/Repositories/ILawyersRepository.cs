using AvukatProjectCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvukatProjectCore.Repositories
{
    public interface ILawyersRepository:IGenericRepository<Lawyers>
    {
        Task<List<Lawyers>> GetLawyersWithCategory();
        
    }
}
