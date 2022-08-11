using API.Application.Application.Model;
using Application.Domain.Entities;
using AutoMapper;

namespace API.Application.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, GetUserResponse>();
            CreateMap<Photo, PhotoResponse>();
        }
    }
}
