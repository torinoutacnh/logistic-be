using FU.Domain.Base;
using FU.Domain.Constant;
using FU.Domain.Entities.FormAttribute;
using FU.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FU.Domain.Entities.Form
{
    public sealed class FormDomainService: Service
    {
        private readonly IFormRepository _formRepository;
        private readonly IFormAttributeRepository _formAttributeRepository;

        public FormDomainService(IUnitOfWork unitOfWork,
            IFormRepository formRepository,
            IFormAttributeRepository formAttributeRepository) : base(unitOfWork)
        {
            _formRepository = formRepository;
            _formAttributeRepository = formAttributeRepository;
        }

        /// <summary>
        /// Create form with default attributes
        /// </summary>
        /// <param name="info">
        ///     Form basic information
        /// </param>
        /// <param name="labels">
        ///     List of strings to create default attribute
        /// </param>
        /// <returns></returns>
        /// <exception cref="DomainException"></exception>
        public async Task Create(FormInfo info, string[] labels)
        {
            var oldform = await _formRepository.GetAsync(x => x.Info.Code == info.Code);
            if (oldform != null) throw new DomainException(FormConstant.Existed, 400);

            var form = new FormEntity(info);
            var attrs = new List<FormAttributeEntity>();
            foreach (var label in labels)
            {
                var attr = new FormAttributeEntity(form.Id, label);
                attrs.Add(attr);
            }

            await _formRepository.CreateAsync(form);
            await _formAttributeRepository.CreateRangeAsync(attrs.ToArray());
            await _unitOfWork.SaveChangeAsync();
        }

        /// <summary>
        /// Update form info
        /// </summary>
        /// <param name="formRepository"></param>
        /// <param name="unitOfWork"></param>
        /// <param name="formid"></param>
        /// <param name="info"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="DomainException"></exception>
        public async Task UpdateInfo(string formid, FormInfo info)
        {
            var id = Guid.ParseExact(formid,"N");
            var oldform = await _formRepository.GetAsync(x => x.Id == id);
            if (oldform == null) throw new DomainException(FormConstant.NotExist, 404);

            var checkCode = (await _formRepository.GetAllAsync(x => x.Info.Code == info.Code && x.Id != id)).Any();
            if (checkCode) throw new DomainException(FormConstant.CodeExisted, 400);

            oldform.UpdateInfo(info);

            await _formRepository.UpdateAsync(oldform);
            await _unitOfWork.SaveChangeAsync();
        }

        /// <summary>
        /// Delete form
        /// </summary>
        /// <param name="id"></param>
        /// <param name="isPhysical"></param>
        /// <returns></returns>
        /// <exception cref="DomainException"></exception>
        public async Task Delete(string id, bool isPhysical = false)
        {
            var guid = Guid.ParseExact(id, "N");
            var oldform = await _formRepository.GetAsync(guid, true);
            if (oldform == null) throw new DomainException(FormConstant.NotExist, 404);

            await _formRepository.DeleteAsync(guid, isPhysical);
            await _unitOfWork.SaveChangeAsync();
        }
    }
}
