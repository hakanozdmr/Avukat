using AutoMapper;
using AvukatProjectCore.DTOs;
using AvukatProjectCore.Model;
using AvukatProjectCore.Services;
using AvukatProjectRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AvukatProject.API.Controllers
{
   
    public class UsersController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IService<Users> _service;
        private readonly AppDbContext _context;
       

        public UsersController(IMapper mapper, IService<Users> service, AppDbContext context)
        {
            _mapper = mapper;
            _service = service;
            _context = context;

        }
        [HttpGet]
        public async Task<IActionResult> All()
        {
            
            var users = await _service.GetAllAsync();
            var usersDtos=_mapper.Map<List<UsersDto>>(users.ToList());
            return CreateActionResult(CustomResponseDto<List<UsersDto>>.Success(200,usersDtos));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {

            var users = await _service.GetByIdAsync(id);
            var usersDtos = _mapper.Map<UsersDto>(users);
            return CreateActionResult(CustomResponseDto<UsersDto>.Success(200, usersDtos));
        }
        [HttpPost]
        public async Task<IActionResult> Save(UsersDto usersDto)
        {

            var users = await _service.AddAsync(_mapper.Map<Users>(usersDto));
            var usersDtos = _mapper.Map<UsersDto>(users);
            return CreateActionResult(CustomResponseDto<UsersDto>.Success(201, usersDtos));
        }
        [HttpPut]
        public async Task<IActionResult> Update(UsersDto usersDto)
        {

            await _service.UpdateAsync(_mapper.Map<Users>(usersDto));
            return CreateActionResult(CustomResponseDto<UsersDto>.Success(204));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var users = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(users);
            return CreateActionResult(CustomResponseDto<UsersDto>.Success(204));
        }
       
    }
}
