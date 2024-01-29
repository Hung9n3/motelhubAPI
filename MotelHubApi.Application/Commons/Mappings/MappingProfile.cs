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

        CreateMap<Area, BaseAreaModel>();
        CreateMap<Area, GetAreaByOwnerDto>()
            .ForMember(des => des.RoomCount, opt => opt.MapFrom(src => src.Rooms == null ? 0 : src.Rooms.Count));
        #endregion

        #region Room
        CreateMap<CreateRoomCommand, Room>();
        CreateMap<UpdateRoomCommand, Room>();
        CreateMap<DeleteRoomCommand, Room>();

        CreateMap<Room, BaseRoomModel>();
        CreateMap<Room, GetRoomsByAreaDto>()
            .ForMember(des => des.OwnerName, options => options.MapFrom(src => src.Owner == null ? string.Empty : src.Owner.Fullname));

        #endregion

        #region MeterReading
        CreateMap<CreateMeterReadingCommand, MeterReading>();

        CreateMap<MeterReading, BaseMeterReadingModel>();
        #endregion

        #region Photo
        CreateMap<CreatePhotoCommand, Photo>();

        CreateMap<Photo, BasePhotoModel>();
        #endregion

        #region Bill
        CreateMap<CreateBillCommand, Bill>();

        CreateMap<Bill, BaseBillModel>();
        #endregion

        #region Contract
        CreateMap<CreateContractCommand, Contract>();

        CreateMap<Contract, BaseContractModel>();
        #endregion
    }
}

