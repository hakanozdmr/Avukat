using AvukatProjectCore.DTOs;
using AvukatProjectCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvukatProjectCore.Services
{
    public interface ILawyersService:IService<Lawyers>
    {
        Task<CustomResponseDto<List<LawyersWithCategoryDto>>> GetLawyersWithCategory();
    }
}
