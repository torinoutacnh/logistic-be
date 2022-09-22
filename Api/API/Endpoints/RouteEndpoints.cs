using Microsoft.AspNetCore.Mvc;

namespace API.Endpoints
{
    public class RouteEndpoints
    {
        public const string Area = "";
        public const string Base = Area + "/route";
        public const string GetAll = Base;
        public const string GetByCar = Base + "/car/{id}";
        public const string GetSingle = Base + "/{id}";
        public const string CreateRoute = Base + "/create-route/{id}";
        public const string CreateRoutes = Base + "/create-routes/{id}";
        public const string UpdateRoute = Base + "/update-route";
        public const string DeleteRoute = Base + "/delete-route/{id}";
    }
}
