using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FU.Domain.Entities.Form
{
    public class FormInfo
    {
        public string Name { get; private set; }
        public string Code { get; private set; }
        public string Number { get; private set; }

        private FormInfo() { }

        public FormInfo(string name,string code,string number)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Code = code ?? throw new ArgumentNullException(nameof(code));
            Number = number ?? throw new ArgumentNullException(nameof(number));
        }
    }
}
