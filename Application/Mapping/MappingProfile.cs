using Application.Models.SubRequestModel;
using Application.Models.SubResponseModel;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<User, UserVM>().ReverseMap();
            CreateMap<User, RequestUser>().ReverseMap();

 
        }
    }
}
