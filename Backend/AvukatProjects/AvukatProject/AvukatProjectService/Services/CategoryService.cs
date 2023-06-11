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
    public class CategoryService : Service<Category>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(IGenericRepository<Category> repository, IUnıtOfWorks unitOfWork, ICategoryRepository categoryRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<CategoryWithLawyerDto>> GetSingleCategoryByIdWithLawyerAsync(int categoryId)
        {
            var category = await _categoryRepository.GetSingleCategoryByIdWithLawyerAsync(categoryId);
            var categoryDto=_mapper.Map<CategoryWithLawyerDto>(category);
            return CustomResponseDto<CategoryWithLawyerDto>.Success(200, categoryDto);

        }
    }
}
