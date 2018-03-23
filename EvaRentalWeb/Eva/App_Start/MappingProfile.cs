using AutoMapper;
using Eva.Dtos;
using Eva.Models;

namespace Eva.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>();

        }
    }
}