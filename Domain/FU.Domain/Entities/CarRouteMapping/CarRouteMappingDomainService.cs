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
        public async Task<List<CarRouteMappingEntity>> GetCarRouteMapping(Expression<Func<CarRouteMappingEntity, bool>> expression, bool isIncludeDeleted = false, params Expression<Func<CarRouteMappingEntity, object>>[] includeProperties)
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
    }
}
