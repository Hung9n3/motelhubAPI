using AutoMapper;

namespace MotelHubApi;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        #region User
        CreateMap<RegisterDto, User>();

        CreateMap<BaseUserModel, User>();

        CreateMap<User, BaseUserModel>();
        #endregion

        #region Area
        CreateMap<BaseAreaModel, Area>();
        CreateMap<CreateAreaCommand, Area>();
        CreateMap<UpdateAreaCommand, Area>()
            .ForMember(des => des.Photos, opt => opt.Ignore())
            .ForMember(des => des.Rooms, opt => opt.Ignore())
            ;
        CreateMap<DeleteAreaCommand, Area>();

        CreateMap<Area, BaseAreaModel>();
        CreateMap<Area, GetAreaByIdDto>();
        CreateMap<Area, GetAreaByOwnerDto>()
            .ForMember(des => des.RoomCount, opt => opt.MapFrom(src => src.Rooms == null ? 0 : src.Rooms.Count))
            .ForMember(des => des.EmptyRoom, opt => opt.MapFrom(src => src.Rooms == null ? 0 : src.Rooms.Where(x => x.OwnerId > 0).Count()))
            ;
        #endregion 

        #region Room
        CreateMap<BaseRoomModel, Room>();
        CreateMap<CreateRoomCommand, Room>();
        CreateMap<UpdateRoomCommand, Room>()
            .ForMember(des => des.AreaId, opt => opt.Ignore())
            .ForMember(des => des.Photos, opt => opt.Ignore())
            .ForMember(des => des.MeterReadings, opt => opt.Ignore())
            .ForMember(des => des.Members, opt => opt.Ignore())
            ;
        CreateMap<DeleteRoomCommand, Room>();

        CreateMap<Room, BaseRoomModel>();
        CreateMap<Room, GetRoomByIdDto>();

        #endregion

        #region MeterReading
        CreateMap<BaseMeterReadingModel, MeterReading>();
        CreateMap<CreateMeterReadingCommand, MeterReading>();

        CreateMap<MeterReading, BaseMeterReadingModel>();
        CreateMap<MeterReading, GetMeterReadingByIdDto>();
        CreateMap<MeterReading, GetMeterReadingByRoomDto>();
        #endregion

        #region Photo
        CreateMap<BasePhotoModel, Photo>();
        CreateMap<CreatePhotoCommand, Photo>();

        CreateMap<Photo, BasePhotoModel>();
        CreateMap<Photo, GetPhotoByUserDto>();
        #endregion

        #region Bill
        CreateMap<BaseBillModel, Bill>();
        CreateMap<CreateBillCommand, Bill>();
        CreateMap<UpdateBillCommand, Bill>();

        CreateMap<Bill, BaseBillModel>();
        CreateMap<Bill, GetBillByIdDto>();
        #endregion

        #region Contract
        CreateMap<BaseContractModel, Contract>();
        CreateMap<CreateContractCommand, Contract>();
        CreateMap<UpdateContractCommand, Contract>()
            .ForMember(des => des.Photos, opt => opt.Ignore())
            .ForMember(x => x.RoomId, opt => opt.Ignore());

        CreateMap<Contract, BaseContractModel>();
        CreateMap<Contract, GetContractByIdDto>();
        #endregion

        #region RatingAndReview
        CreateMap<BaseRatingAndReviewModel, RatingAndReview>();
        CreateMap<CreateRatingAndReviewCommand, RatingAndReview>();
        CreateMap<UpdateRatingAndReviewCommand, RatingAndReview>();

        CreateMap<RatingAndReview, BaseRatingAndReviewModel>();
        CreateMap<RatingAndReview, GetRatingAndReviewByIdDto>();
        #endregion

        #region Appointment
        CreateMap<BaseAppointmentModel, Appointment>();
        CreateMap<CreateAppointmentCommand, Appointment>();
        CreateMap<UpdateAppointmentCommand, Appointment>();

        CreateMap<Appointment, BaseAppointmentModel>();
        CreateMap<Appointment, GetAppointmentByIdDto>();
        #endregion
    }
}

