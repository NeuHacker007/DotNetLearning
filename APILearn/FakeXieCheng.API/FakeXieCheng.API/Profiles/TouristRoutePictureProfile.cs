using AutoMapper;
using FakeXieCheng.API.Dtos;
using FakeXieCheng.API.Models;

namespace FakeXieCheng.API.Profiles
{
    public class TouristRoutePictureProfile : Profile
    {
        public TouristRoutePictureProfile()
        {
            CreateMap<TouristRoutePicture, TouristRoutePicturesDto>();
        }
    }
}
