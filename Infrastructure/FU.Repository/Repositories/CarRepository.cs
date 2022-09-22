using FU.Domain.Entities.Car;
using FU.Domain.Entities.Car.SubModel;
using FU.Domain.Entities.Route.SubModel;
using FU.Domain.Entities.Seat.SubModel;
using FU.Domain.Entities.StopPoint.SubModel;
using FU.Infras.CustomAttribute;
using FU.Repository.Base;
using FU.Repository.DbStore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FU.Repository.Repositories
{
    [RegisterScope]
    public class CarRepository : Repository<CarEntity>, ICarRepository
    {
        public CarRepository(Store store) : base(store)
        {
        }

        public Task<List<CarInfoModel>> GetCarInfos()
        {
            var query = from car in _store.Cars
                        where car.IsDeleted == false
                        join manager in _store.CarsManagers
                            on car.CarsManagerId equals manager.Id
                        where manager.IsDeleted == false
                        select new CarInfoModel(car,
                        car.Seats.Select(x => new SeatModel(x)));
            return query.ToListAsync();
        }

        public Task<CarInfoModel> GetCarInfo(Guid id)
        {
            var query = from car in _store.Cars.Include(x=>x.CarsManager)
                        where car.Id == id && car.IsDeleted == false
                        select new CarInfoModel(car,
                        car.Seats.Where(x=>x.IsDeleted==false).Select(x=>new SeatModel(x)));
            return query.FirstOrDefaultAsync();
        }
    }
}
