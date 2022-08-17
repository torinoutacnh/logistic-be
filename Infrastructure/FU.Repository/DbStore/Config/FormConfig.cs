using FU.Domain.Entities.Form;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FU.Repository.DbStore.Config
{
    public class FormConfig : IEntityTypeConfiguration<FormEntity>
    {
        public void Configure(EntityTypeBuilder<FormEntity> builder)
        {
            builder.ToTable("Form");
            builder.HasKey(o => o.Id);

            builder.OwnsOne(o => o.Info);
        }
    }
}
