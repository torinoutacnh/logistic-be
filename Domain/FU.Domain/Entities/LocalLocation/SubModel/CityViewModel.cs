using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FU.Domain.Entities.LocalLocation.SubModel
{
    public class CityViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public uint Code { get; set; }
        public string CodeName { get; set; }
        public string Division { get; set; }

        public CityViewModel(CityEntity city)
        {
            Id = city.Id;
            Name = city.Name;
            Code = city.Code;
            CodeName = city.CodeName;
            Division = city.Division;
        }
    }
}
