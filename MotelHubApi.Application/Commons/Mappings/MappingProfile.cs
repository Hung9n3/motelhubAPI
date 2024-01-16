using System.Reflection;
using AutoMapper;

namespace MotelHubApi;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        #region Room
        CreateMap<CreateRoomCommand, Room>();

        CreateMap<Room, GetRoomsByAreaDto>()
            .ForMember(des => des.OwnerName, options => options.MapFrom(src => src.Owner == null ? string.Empty : src.Owner.Fullname));

        #endregion
    }
}

