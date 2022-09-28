using FU.Domain.Base;
using FU.Domain.Constant;
using FU.Domain.Entities.CarRouteMapping.SubModel;
using FU.Domain.Entities.Mapping;
using FU.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FU.Domain.Entities.CarRouteMapping
{
    public class CarRouteMappingDomainService : Service
    {
        private readonly ICarRouteMappingRepository _carRouteMappingRepository;
        public CarRouteMappingDomainService(IUnitOfWork unitOfWork,
            ICarRouteMappingRepository carRouteMappingRepository) : base(unitOfWork)
        {
            _carRouteMappingRepository = carRouteMappingRepository;
        }

        /// <summary>
        /// Get CarRouteMapping
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="isIncludeDeleted"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        public async Task<List<Mapping.CarRouteMappingEntity>> GetCarRouteMapping(Expression<Func<Mapping.CarRouteMappingEntity, bool>> expression, bool isIncludeDeleted = false, params Expression<Func<Mapping.CarRouteMappingEntity, object>>[] includeProperties)
        {
            var carRouteMapping = await _carRouteMappingRepository.GetAllAsync(expression, isIncludeDeleted, includeProperties);
            return carRouteMapping;
        }
        /// <summary>
        /// Get CarRouteMapping Detail
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<CarRouteMappingInfoModel> GetCarRouteMappingDetail(Guid id)
        {
            var carRouteMapping = await _carRouteMappingRepository.GetCarRouteMappingInfo(id);
            return carRouteMapping;
        }

        /// <summary>
        /// Get CarRouteMapping Details
        /// </summary>
        /// <returns></returns>
        public async Task<List<CarRouteMappingInfoModel>> GetCarRouteMappingDetails()
        {
            var carRouteMapping = await _carRouteMappingRepository.GetCarRouteMappingInfos();
            return carRouteMapping;
        }
        /// <summary>
        /// Update Car Price
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="DomainException"></exception>
        public async Task<Guid> UpdateCarRouteMappingStarttime(UpdateCarRouteMappingStarttimeModel model)
        {
            var carRouteMappping = await _carRouteMappingRepository.GetAsync(model.CarId) ?? throw new DomainException(ShareConstant.NotFound, 404);

            carRouteMappping.UpdateStartTime(model.Starttime);
            await _carRouteMappingRepository.UpdateAsync(carRouteMappping);
            await _unitOfWork.SaveChangeAsync();

            return carRouteMappping.CarId;
        }
        /// <summary>
        /// Create CarRouteMapping
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="DomainException"></exception>
        public async Task<Guid> CreateCarRouteMappingStarttime(CreateCarRouteMappingStarttimeModel model)
        {
            var carRouteMapping = new CarRouteMappingEntity(model.CarId, model.RouteId, model.Starttime);
            await _carRouteMappingRepository.CreateAsync(carRouteMapping);
            await _unitOfWork.SaveChangeAsync();
            return carRouteMapping.Id;
        }

        /// <summary>
        /// Delete Car
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteCarRouteMapping(Guid id)
        {
            await _carRouteMappingRepository.DeleteAsync(id,true);
            await _unitOfWork.SaveChangeAsync();
        }
        /// <summary>
        /// Get CarRouteByLocationStarttime
        /// </summary>
        /// <returns></returns>
        public async Task<List<CarRouteMappingInfoModel>> GetCarRouteByLocationStarttime(Guid FromCityId, Guid ToCityId, DateTimeOffset Starttime)
        {
            var carRouteByLocationStarttime = await _carRouteMappingRepository.GetCarRouteByLocationStarttime(FromCityId, ToCityId, Starttime);
            return carRouteByLocationStarttime;
        }
    }
}
