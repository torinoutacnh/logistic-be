using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FU.Domain.Entities.FormAttribute
{
    public class FormAttributeInfo
    {
        public string Label { get;private set; }
        public string? DefaultValue { get;private set; }
        public string? MapCode { get;private set; }

        private FormAttributeInfo() { }

        public FormAttributeInfo(string label,string? defaultValue = null,string? map = null)
        {
            Label = label ?? throw new ArgumentNullException(nameof(label));
            DefaultValue = defaultValue;
            MapCode = map;
        }

        public FormAttributeInfo SetValue(string value)
        {
            DefaultValue = value;
            return this;
        }

        public FormAttributeInfo Update(string? label = null, string? defaultValue = null, string? map = null)
        {
            Label = label ?? Label;
            DefaultValue = defaultValue ?? DefaultValue;
            MapCode = map ?? MapCode;
            return this;
        }
    }
}
