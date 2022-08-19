using FU.Domain.Base;
using FU.Domain.Constant;
using FU.Domain.Entities.FormAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FU.Domain.Entities.Form
{
    public class FormEntity : Entity
    {
        public FormInfo Info { get; private set; }

        public virtual ICollection<FormAttributeEntity> Attributes { get; private set; }

        private FormEntity() { }

        public FormEntity(FormInfo info)
        {
            Info = info ?? throw new ArgumentNullException(nameof(info));
            Attributes = new HashSet<FormAttributeEntity>();
        }

        public FormEntity(FormInfo info, FormAttributeEntity[] attributes)
        {
            Info = info ?? throw new ArgumentNullException(nameof(info));
            Attributes = attributes ?? throw new ArgumentNullException(nameof(attributes));
        }

        public void UpdateAttributes(params FormAttributeEntity[] attributes)
        {
            Attributes = attributes ?? throw new ArgumentNullException(nameof(attributes));
        }

        public void UpdateInfo(FormInfo info)
        {
            Info = info ?? throw new ArgumentNullException(nameof(info));
        }
    }
}
