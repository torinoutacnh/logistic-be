namespace API.Endpoints
{
    public class CarSeatEndpoints
    {
        public const string Area = "";
        public const string Base = Area + "/seat";
        public const string GetAllByCar = Base + "/Car/{id}";
        public const string GetSingle = Base + "/{id}";
        public const string CreateSeat = Base + "/create-seat/{id}";
        public const string CreateSeats = Base + "/create-seat-list/{id}";
        public const string UpdateSeatInfo = Base + "/update-seat-info/{id}";
        public const string UpdateSeatStatus = Base + "/update-seat-status";
        public const string DeleteSeat = Base + "/delete-seat/{id}";
    }
}
