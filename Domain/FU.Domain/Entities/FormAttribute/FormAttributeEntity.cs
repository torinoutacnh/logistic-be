using FU.Domain.Base;
using FU.Domain.Entities.Form;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FU.Domain.Entities.FormAttribute
{
    public class FormAttributeEntity : Entity
    {
        public FormAttributeInfo Info { get; private set; }
        public FormAttributeModify Modify { get; private set; }
        public FormAttributeDisplay? Display { get; private set; }

        public Guid FormId { get; }
        public virtual FormEntity Form { get; }

        private FormAttributeEntity() { }

        public FormAttributeEntity(Guid formid, FormAttributeInfo info,  FormAttributeModify modify, FormAttributeDisplay? display = null)
        {
            FormId = formid;
            Info = info;
            Modify = modify;
            Display = display?? new FormAttributeDisplay();
        }

        public FormAttributeEntity(Guid formid, string label)
        {
            FormId = formid;
            Info = new FormAttributeInfo(label);
            Modify = new FormAttributeModify(ControlType.TextInput, DataType.Text);
            Display = new FormAttributeDisplay();
        }
    }
}
