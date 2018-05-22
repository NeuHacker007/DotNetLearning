using AngularWebApi.Dtos;
using AngularWebApi.Models;
using AutoMapper;

namespace AngularWebApi.App_Start
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Tasks, TasksDto>();
            CreateMap<TasksDto, Tasks>()
                .ForMember(t => t.Id, opt => opt.Ignore());
        }
    }
}