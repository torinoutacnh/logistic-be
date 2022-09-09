using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FU.Service.Models.Car
{
    public class RouteInfoModel
    {
        public Guid Id { get; set; }
        public Guid CarId { get; set; }
        public Guid FromId { get; set; }
        public Guid ToId { get; set; }

        public decimal DistanceByKm { get; set; }
        public decimal Day { get; set; }
        public decimal Hour { get; set; }
        public decimal Minute { get; set; }
    }
}
