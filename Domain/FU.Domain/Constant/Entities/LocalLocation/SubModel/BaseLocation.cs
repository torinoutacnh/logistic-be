using FU.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FU.Domain.Entities.LocalLocation.SubModel
{
    public abstract class BaseLocation : Entity
    {
        public string Name { get; protected set; }
        public uint Code { get; protected set; }
        public string CodeName { get; protected set; }
        public string Division { get; protected set; }

        protected BaseLocation() { }

        protected BaseLocation(string name, uint code, string codeName, string division)
        {
            Name = name;
            Code = code;
            CodeName = codeName;
            Division = division;
        }

        public BaseLocation ToBase()
        {
            return this;
        }
    }
}
