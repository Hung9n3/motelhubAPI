using System.Reflection;
using AutoMapper;

namespace MotelHubApi;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        #region User
        CreateMap<RegisterDto, User>();

        #endregion

        #region Area
        CreateMap<CreateAreaCommand, Area>();
        CreateMap<UpdateAreaCommand, Area>();
        CreateMap<DeleteAreaCommand, Area>();

        CreateMap<Area, GetAreaByOwnerDto>()
            .ForMember(des => des.RoomCount, opt => opt.MapFrom(src => src.Rooms == null ? 0 : src.Rooms.Count));
        #endregion

        #region Room
        CreateMap<CreateRoomCommand, Room>();

        CreateMap<Room, GetRoomsByAreaDto>()
            .ForMember(des => des.OwnerName, options => options.MapFrom(src => src.Owner == null ? string.Empty : src.Owner.Fullname));

        #endregion
    }
}

