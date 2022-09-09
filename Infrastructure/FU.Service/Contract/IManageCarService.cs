using FU.Domain.Entities.Car.SubModel;
using FU.Domain.Entities.CarsManager.SubModel;
using FU.Service.Models.Car;
using FU.Service.Models.CarsManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FU.Service.Contract
{
    public interface IManageCarService
    {
        Task<CarsManagerMapModel?> GetManagerAsync(Guid id);
        Task<List<CarsManagerInfoModel>?> GetManagersAsync();
        Task<Guid> CreateManager(CreateCarsManagerModel model);
        Task<Guid> UpdateManager(UpdateCarsManagerModel model);
        Task DeleteManager(Guid id);

        Task<CarMapModel> GetCarAsync(Guid id);
        Task<List<CarInfoModel>> GetCarsAsync();
        Task<Guid> CreateCarAsync(CreateCarModel model);
        Task<Guid> UpdateCarDetailAsync(UpdateCarDetailModel model);
        Task<Guid> UpdateCarPriceAsync(UpdateCarPriceModel model);
        Task DeleteCarAsync(Guid id);
    }
}
