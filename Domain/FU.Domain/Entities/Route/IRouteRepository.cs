using FU.Domain.Base;
using FU.Domain.Entities.Route.SubModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FU.Domain.Entities.Route
{
    public interface IRouteRepository:IRepository<RouteEntity>
    {
        bool ValidateLocation(Location model);
        bool ValidateLocations(params Location[] models);
        Task<List<RouteModel>> GetAllRoutes();

    }
}
