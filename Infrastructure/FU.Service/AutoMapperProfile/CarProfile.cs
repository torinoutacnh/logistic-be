using AutoMapper;
using FU.Domain.Entities.Car;
using FU.Domain.Entities.Route;
using FU.Domain.Entities.StopPoint;
using FU.Infras.Utils;
using FU.Service.Models.Car;

namespace FU.Service.AutoMapperProfile
{
    public class CarProfile:Profile
    {
        public CarProfile()
        {
            CreateMap<CarEntity, CarInfoModel>();
            CreateMap<CarEntity, CarMapModel>()
                .ForMember(x => x.StopPoints, o => o.MapFrom(y => y.StopPoints))
                .ForMember(x => x.Seats, o => o.MapFrom(y => y.Seats))
                .ForMember(x => x.Routes, o => o.MapFrom(y => y.Routes));
            CreateMap<RouteEntity, RouteMapModel>();
            CreateMap<RouteEntity, RouteInfoModel>();
            CreateMap<SeatEntity, SeatMapModel>();
            CreateMap<SeatEntity, SeatInfoModel>();
            CreateMap<StopPointEntity, StopPointMapModel>();
            CreateMap<StopPointEntity, StopPointInfoModel>();
        }
    }
}
