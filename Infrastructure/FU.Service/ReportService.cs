using FU.Domain.Base;
using FU.Domain.Entities.Form;
using FU.Domain.Entities.FormAttribute;
using FU.Infras.CustomAttribute;
using FU.Infras.Utils;
using FU.Service.Contract;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace FU.Service
{
    [RegisterTransient]
    public class ReportService: Domain.Base.Service, IReportService
    {
        private readonly IServiceProvider _serviceProvider;

        public ReportService(IServiceProvider serviceProvider):base(serviceProvider.GetRequiredService<IUnitOfWork>())
        {
            _serviceProvider = serviceProvider;
        }

        /// <summary>
        /// Get form model from db
        /// </summary>
        /// <param name="code"></param>
        /// <returns name="FormEntity"></returns>
        public Task<FormEntity?> GetForm(string code)
        {
            var repo = _serviceProvider.GetRequiredService<IFormRepository>();
            return repo.GetAsync(x=>x.Info.Code==code, false, x=>x.Attributes);
        }

        /// <summary>
        /// Create form without attributes
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public Task CreateForm(FormInfo info, string[] labels)
        {
            var formRepo = _serviceProvider.GetRequiredService<IFormRepository>();
            var attrRepo = _serviceProvider.GetRequiredService<IFormAttributeRepository>();
            var uof = _serviceProvider.GetRequiredService<IUnitOfWork>();

            var form = new FormEntity(info);
            var attrs = new List<FormAttributeEntity>();
            foreach(var label in labels)
            {
                var attr = new FormAttributeEntity(form.Id, label);
                attrs.Add(attr);
            }
            formRepo.CreateAsync(form);
            attrRepo.CreateRangeAsync(attrs.ToArray());
            return uof.SaveChangeAsync();
        }

        /// <summary>
        /// Update form info
        /// </summary>
        /// <param name="id"></param>
        /// <param name="info"></param>
        /// <returns></returns>
        public async Task<bool> UpdateFormInfo(string id, FormInfo info)
        {
            var repo = _serviceProvider.GetRequiredService<IFormRepository>();

            var form = await repo.GetAsync(x => x.Id == Guid.ParseExact(id, "N"));
            if (form != null) {
                await repo.UpdateAsync(form.UpdateInfo(info));
                return true;
            }
            return false;
        }
    }
}