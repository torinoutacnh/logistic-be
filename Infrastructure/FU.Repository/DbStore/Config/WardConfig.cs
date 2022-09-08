using FU.Domain.Entities.LocalLocation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FU.Repository.DbStore.Config
{
    public class WardConfig : IEntityTypeConfiguration<WardEntity>
    {
        public void Configure(EntityTypeBuilder<WardEntity> builder)
        {
            builder.ToTable("Wards");
            builder.HasKey(o => o.Id);

            builder.HasIndex(x => x.Name).IsUnique();
            builder.HasIndex(x => x.Code).IsUnique();
            builder.HasIndex(x => x.CodeName).IsUnique();
            builder.HasIndex(x => x.PhoneCode).IsUnique();

            builder.HasOne(o => o.District)
                .WithMany(o => o.Wards)
                .HasForeignKey(o => o.DistrictId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
