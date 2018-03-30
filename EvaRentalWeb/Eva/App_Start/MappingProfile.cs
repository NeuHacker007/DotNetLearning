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

            Mapper.CreateMap<CustomerDto, Customer>()
                .ForMember(c => c.Id, opt => opt.Ignore());

            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MovieDto, Movie>()
                .ForMember(m => m.Id, opt => opt.Ignore());

            Mapper.CreateMap<MembershipType, MembershipTypeDto>();

            Mapper.CreateMap<GenreTypes, GenreTypeDto>();

        }
    }
}