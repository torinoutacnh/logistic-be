using FU.Domain.Entities.Form;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FU.Service.Contract
{
    public interface IReportService
    {
        Task<FormEntity?> GetForm(string code);
        Task CreateForm(FormInfo info, string[] labels);
        Task<bool> UpdateFormInfo(string id, FormInfo info);
    }
}
