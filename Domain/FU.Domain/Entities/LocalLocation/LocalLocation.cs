using FU.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FU.Domain.Entities.LocalLocation
{
    public abstract class LocalLocation : Entity
    {
        public string Name { get; protected set; }
        public uint Code { get; protected set; }
        public string CodeName { get; protected set; }
        public string Division { get; protected set; }
        public uint PhoneCode { get; protected set; }

        protected LocalLocation() { }

        protected LocalLocation(string name, uint code, string codeName, string division, uint phoneCode)
        {
            Name = name;
            Code = code;
            CodeName = codeName;
            Division = division;
            PhoneCode = phoneCode;
        }
    }
}
