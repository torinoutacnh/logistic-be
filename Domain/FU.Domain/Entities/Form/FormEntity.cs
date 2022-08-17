using FU.Domain.Base;
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

        public virtual ICollection<FormAttributeEntity> Attributes { get; }

        private FormEntity() { }

        public FormEntity(FormInfo info)
        {
            Info = info ?? throw new ArgumentNullException(nameof(info));
            Attributes = new HashSet<FormAttributeEntity>();
        }

        public FormEntity UpdateInfo(FormInfo info)
        {
            this.Info = info ?? throw new ArgumentNullException(nameof(info));
            return this;
        }
    }
}
