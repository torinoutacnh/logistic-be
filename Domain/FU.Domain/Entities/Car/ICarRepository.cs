using FU.Domain.Base;
using FU.Domain.Entities.Car.SubModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FU.Domain.Entities.Car
{
    public interface ICarRepository:IRepository<CarEntity>
    {
        Task<CarInfoModel> GetCarInfo(Guid id);
        Task<List<CarInfoModel>> GetCarInfos();
    }
}
