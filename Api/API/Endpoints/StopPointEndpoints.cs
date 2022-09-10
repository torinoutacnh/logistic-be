namespace API.Endpoints
{
    public class StopPointEndpoints
    {
        public const string Area = "";
        public const string Base = Area + "/stop-point";
        public const string GetAllByCar = Base + "/Car/{id}";
        public const string GetSingle = Base + "/{id}";
        public const string CreateStopPoint = Base + "/create-point/{carid}";
        public const string CreateStopPoints = Base + "/create-point-list/{carid}";
        public const string UpdateStopPointLocation = Base + "/update-point-location/{carid}";
        public const string UpdateStopPointDetail = Base + "/update-point-detail/{carid}";
        public const string DeleteStopPoint = Base + "/delete-point/{id}";
    }
}
