using FU.Domain.Entities.FormAttribute;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FU.Repository.DbStore.Config
{
    public class FormAttributeConfig : IEntityTypeConfiguration<FormAttributeEntity>
    {
        public void Configure(EntityTypeBuilder<FormAttributeEntity> builder)
        {
            builder.ToTable("FormAttribute");
            builder.HasKey(o => o.Id);

            builder.OwnsOne(o => o.Info);
            builder.OwnsOne(o => o.Display);
            builder.OwnsOne(o => o.Modify)
                .Property(o=>o.DropDownValues)
                .HasConversion(
                    o => string.Join(",", o),
                    o => o.Split(new[] { ',' }));

            builder.HasOne(o => o.Form)
                .WithMany(o => o.Attributes)
                .HasForeignKey(o => o.FormId)
                .IsRequired();
        }
    }
}
