namespace API.Endpoints
{
    public class CarsManagerEndpoint
    {
        public const string Area = "";
        public const string Base = Area + "/cars-manager";
        public const string GetAll = Base;
        public const string GetSingle = Base + "/{id}";
    }
}
