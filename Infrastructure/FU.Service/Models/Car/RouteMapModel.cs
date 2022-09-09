namespace FU.Service.Models.Car
{
    public class RouteMapModel
    {
        public Guid CarId { get; set; }
        public Guid FromId { get; set; }
        public Guid ToId { get;  set; }

        public decimal DistanceByKm { get;  set; }
        public decimal Day { get;  set; }
        public decimal Hour { get;  set; }
        public decimal Minute { get;  set; }
    }
}
