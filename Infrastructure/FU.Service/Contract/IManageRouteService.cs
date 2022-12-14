using FU.Domain.Entities.LocalLocation.SubModel;
using FU.Domain.Entities.Route.SubModel;
using FU.Domain.Entities.Seat.SubModel;
using FU.Domain.Entities.StopPoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FU.Service.Contract
{
    public interface IManageRouteService
    {
        Task<List<CityViewModel>> GetCitiesAsync();
        Task<List<DistrictViewModel>> GetDistrictsByCityAsync(Guid id);
        Task<List<WardViewModel>> GetWardsByDistrictAsync(Guid id);

        Task<Guid> CreateStopPoint(Guid carid, CreateStopPointModel model);
        Task<List<Guid>> CreateStopPoints(Guid carid, ICollection<CreateStopPointModel> models);
        Task<Guid> UpdateStopPointLocation(Guid carid, Location model);
        Task<Guid> UpdateStopPointDetailLocation(Guid carid, DetailLocation model);
        Task DeleteStopPoint(Guid id);

        Task<Guid> CreateRoute(Guid carid, CreateCarRouteModel model);
        Task<List<Guid>> CreateRoutes(Guid carid, params CreateCarRouteModel[] models);
        Task<Guid> UpdateRoute(Guid carid, UpdateCarRouteModel model);
        Task DeleteRoute(Guid id);

        Task<Guid> CreateSeat(Guid carid, CreateCarSeatModel model);
        Task<List<Guid>> CreateSeats(Guid carid, CreateCarSeatModel[] models);
        Task<Guid> UpdateSeatDetail(Guid carid, UpdateCarSeatDetailModel model);
        Task<Guid> UpdateSeatStatus(UpdateCarSeatStatusModel model);
        Task DeleteSeat(Guid id);
    }
}
