using AutoMapper;
using AvukatProjectCore.DTOs;
using AvukatProjectCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvukatProjectService.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Users, UsersDto>().ReverseMap();
            CreateMap<Lawyers, LawyersDto>().ReverseMap();
            CreateMap<Answers, AnswersDto>().ReverseMap();
            CreateMap<Questions, QuestionsDto>().ReverseMap();
            CreateMap<BaseEntity, BaseDto>().ReverseMap();
            CreateMap<About, AboutDto>().ReverseMap();
            CreateMap<Lawyers, LawyersWithCategoryDto>();
            CreateMap<Category, CategoryWithLawyerDto>();
        }
    }
}