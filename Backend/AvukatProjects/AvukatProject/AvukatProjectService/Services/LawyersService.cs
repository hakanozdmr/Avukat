using AutoMapper;
using AvukatProjectCore.DTOs;
using AvukatProjectCore.Model;
using AvukatProjectCore.Repositories;
using AvukatProjectCore.Services;
using AvukatProjectCore.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvukatProjectService.Services
{
    public class LawyersService : Service<Lawyers>, ILawyersService
    {
        private readonly ILawyersRepository _lawyersRepository;
        private readonly IMapper _mapper;

        public LawyersService(IGenericRepository<Lawyers> repository, IUnıtOfWorks unitOfWork, IMapper mapper, ILawyersRepository lawyersRepository) : base(repository, unitOfWork)
        {
            _mapper = mapper;
            _lawyersRepository = lawyersRepository;
        }

        public async Task<CustomResponseDto<List<LawyersWithCategoryDto>>> GetLawyersWithCategory()
        {
            var lawyer = await _lawyersRepository.GetLawyersWithCategory();
            var lawyersDto=_mapper.Map<List<LawyersWithCategoryDto>>(lawyer);
            return CustomResponseDto<List<LawyersWithCategoryDto>>.Success(200,lawyersDto);


        }
    }
}
