using ApiBackendParkingApp.Models.DAO;
using ApiBackendParkingApp.Models.DTO;
using AutoMapper;



namespace ApiBackendParkingApp.Models.Mapping
{
    public class ParkinLotMappingProfile:Profile
    {
       public ParkinLotMappingProfile()
       {
            CreateMap<ParkingLotModelDao, ParkingLotModelDTO>()
                .ForMember(dest => dest.Parking_Lot_ID, opt => opt.MapFrom(src => src.Parking_Lot_ID))
                .ForMember(dest => dest.License_Plate, opt => opt.MapFrom(src => src.License_Plate))
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate))
                .ForMember(dest => dest.Place_Number, opt => opt.MapFrom(src => src.Place_Number))
                .ReverseMap();
       }
    }
}
