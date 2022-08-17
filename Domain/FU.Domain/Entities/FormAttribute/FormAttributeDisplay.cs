using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FU.Domain.Entities.FormAttribute
{
    public class FormAttributeDisplay
    {
        public int? Col { get; set; }
        public int? Row { get;  set; }

        public int? LabelCol { get;  set; }
        public int? LabelRow { get;  set; }
        public string? LabelStyle { get;  set; }
        public string? LabelClass { get;  set; }
        public Position? LabelPosition { get; set; }

        public int? ContentCol { get;  set; }
        public int? ContentRow { get;  set; }
        public string? ContentStyle { get;  set; }
        public string? ContentClass { get;  set; }

        public FormAttributeDisplay() { }
    }
}
