using FU.Domain.Entities.Car;
using FU.Domain.Entities.CarsManager;
using FU.Domain.Entities.LocalLocation;
using FU.Domain.Entities.Route;
using FU.Domain.Entities.StopPoint;
using FU.Domain.Entities.Ticket;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FU.Repository.DbStore
{
    public partial class Store
    {
        public DbSet<CarsManagerEntity> CarsManagers { get; set; }
        public DbSet<CarEntity> Cars { get; set; }
        public DbSet<SeatEntity> Seats { get; set; }
        public DbSet<DistrictEntity> Cities { get; set; }
        public DbSet<DistrictEntity> Districts { get; set; }
        public DbSet<WardEntity> Wards { get; set; }
        public DbSet<RouteEntity> Routes { get; set; }
        public DbSet<StopPointEntity> StopPoints { get; set; }
        public DbSet<TicketEntity> Tickets { get; set; }
    }
}
