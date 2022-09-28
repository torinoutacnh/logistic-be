using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FU.Domain.Entities.LocalLocation.SubModel
{
    public class WardViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public uint Code { get; set; }
        public string CodeName { get; set; }
        public string Division { get; set; }

        public WardViewModel(WardEntity model)
        {
            Id = model.Id;
            Name = model.Name;
            Code = model.Code;
            CodeName = model.CodeName;
            Division = model.Division;
        }
    }
}
