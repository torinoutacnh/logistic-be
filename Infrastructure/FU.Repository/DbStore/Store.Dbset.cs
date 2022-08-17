using FU.Domain.Entities.Form;
using FU.Domain.Entities.FormAttribute;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FU.Repository.DbStore
{
    public partial class Store
    {
        public DbSet<FormEntity> Form { get; set; }
        public DbSet<FormAttributeEntity> FormAttribute { get; set; }
    }
}
