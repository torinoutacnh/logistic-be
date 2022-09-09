using FU.Domain.Base;
using FU.Domain.Constant;
using FU.Domain.Entities.CarsManager.SubModel;
using FU.Domain.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FU.Domain.Entities.CarsManager
{
    public class CarsManagerDomainService : Service
    {
        private readonly ICarsManagerRepository _carsManagerRepository;

        public CarsManagerDomainService(IUnitOfWork unitOfWork, ICarsManagerRepository carsManagerRepository) : base(unitOfWork)
        {
            _carsManagerRepository = carsManagerRepository;
        }

        #region Car Manager

        /// <summary>
        /// Get CarsManagers
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="isIncludeDeleted"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        public async Task<List<CarsManagerEntity>> GetCarsManagers(Expression<Func<CarsManagerEntity, bool>> expression, bool isIncludeDeleted = false, params Expression<Func<CarsManagerEntity, object>>[] includeProperties)
        {
            return await _carsManagerRepository.GetAllAsync(expression, isIncludeDeleted, includeProperties);
        }

        /// <summary>
        /// Get CarsManagers To Another type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="func"></param>
        /// <param name="expression"></param>
        /// <param name="isIncludeDeleted"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        public async Task<List<T>> GetCarsManagersTo<T>(Func<CarsManagerEntity,T> func,Expression<Func<CarsManagerEntity, bool>> expression, bool isIncludeDeleted = false, params Expression<Func<CarsManagerEntity, object>>[] includeProperties)
        {
            var managers = await _carsManagerRepository.GetAllToAsync(func, expression, isIncludeDeleted, includeProperties);

            return managers;
        }

        /// <summary>
        /// Get Cars Manager By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<CarsManagerEntity?> GetCarsManagerById (Guid id)
        {
            var manager = await _carsManagerRepository.GetAsync(id, false, x => x.Cars);
            return manager;
        }

        /// <summary>
        /// Create Manager
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<Guid> CreateManager(CreateCarsManagerModel model)
        {
            var manager = new CarsManagerEntity(model.Name, model.Description, model.LogoPath);
            await _carsManagerRepository.CreateAsync(manager);
            await _unitOfWork.SaveChangeAsync();
            return manager.Id;
        }

        /// <summary>
        /// Update Manager
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="DomainException"></exception>
        public async Task<Guid> UpdateManager(UpdateCarsManagerModel model)
        {
            var manager = await _carsManagerRepository.GetAsync(model.Id) ?? throw new DomainException(ShareConstant.NotFound, 404);

            manager.Update(model.Name, model.Description, model.LogoPath);

            await _carsManagerRepository.UpdateAsync(manager);
            await _unitOfWork.SaveChangeAsync();
            return manager.Id;
        }

        /// <summary>
        /// Delete Manager
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteManager(Guid id)
        {
            await _carsManagerRepository.DeleteAsync(id);
            await _unitOfWork.SaveChangeAsync();
        }
        #endregion


    }
}
