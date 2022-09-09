namespace API.Endpoints
{
    public class CarsManagerEndpoint
    {
        public const string Area = "";
        public const string Base = Area + "/cars-manager";
        public const string GetAll = Base;
        public const string GetSingle = Base + "/{id}";
        public const string CreateManager = Base + "/create-manager";
        public const string UpdateManager = Base + "/update-manager";
        public const string DeleteManager = Base + "/delete-manager/{id}";
    }
}
