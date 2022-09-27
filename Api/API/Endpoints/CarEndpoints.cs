using Microsoft.AspNetCore.Mvc;

namespace API.Endpoints
{
    public class CarEndpoints
    {
        public const string Area = "";
        public const string Base = Area + "/car";
        public const string GetAll = Base;
        public const string GetByManager = Base + "/manager/{id}";
        public const string GetSingle = Base + "/{id}";
        public const string CreateCar = Base + "/create-car";
        public const string UpdateCarDetail = Base + "/update-car-detail";
        public const string UpdateCarPrice = Base + "/update-car-price";
        public const string DeleteCar = Base + "/delete-car/{id}";
        public const string GetByRoute = Base + "/route/{id}";
    }
}
