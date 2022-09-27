using FU.Domain.Entities.Car.SubModel;
using FU.Domain.Entities.CarsManager.SubModel;
using FU.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FU.Service.Contract
{
    public interface IManageCarService
    {
        Task<CarsManagerInfoModel?> GetManagerAsync(Guid id);
        Task<List<CarsManagerViewModel>?> GetManagersAsync();
        Task<Guid> CreateManager(CreateManagerModel model);
        Task<Guid> UpdateManager(UpdateManagerModel model);
        Task DeleteManager(Guid id);

        Task<List<CarViewModel>> GetCarListAsync();
        Task<List<CarViewModel>> GetCarByManagerAsync(Guid managerId);
        Task<CarInfoModel> GetCarDetailAsync(Guid id);
        Task<List<CarInfoModel>> GetCarDetailsAsync();
        Task<Guid> CreateCarAsync(CreateCarWithFileModel model);
        Task<Guid> UpdateCarDetailAsync(UpdateCarDetailWithFileModel model);
        Task<Guid> UpdateCarPriceAsync(UpdateCarPriceModel model);
        Task DeleteCarAsync(Guid id);
        Task<List<CarInfoModel>> GetCarByLocationStarttimeAsync(Guid FromCityId, Guid ToCityId, DateTimeOffset Starttime);
    }
}
