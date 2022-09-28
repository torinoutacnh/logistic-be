using Microsoft.AspNetCore.Mvc;

namespace API.Endpoints
{
    public class CarRouteMappingEndPoints
    {
        public const string Area = "";
        public const string Base = Area + "/carRouteMapping";
        public const string GetAll = Base;
        public const string GetSingle = Base + "/car/{id}";
        public const string UpdateStarttime = Base + "/update-start-time";
        public const string CreateStarttime = Base + "/create-start-time";
        public const string DeleteStarttime = Base + "/delete-carRouteMapping/{id}";
        public const string GetCarRouteByLocationStarttime = Base + "/get-car-route-by-location-starttime";
    }
}