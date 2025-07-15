using AutoMapper;
using CrushApp.Data.Models;
using CrushApp.Data.DTOs;

namespace CrushApp.Data.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            // Map from CreateDto → Entity
            CreateMap<UserCreateDto, User>();

            // Map from UpdateDto → Entity (for patching)
            CreateMap<UserUpdateDto, User>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            // Map from Entity → ReadDto (for responses)
            CreateMap<User, UserReadDto>();
        }
    }
}
