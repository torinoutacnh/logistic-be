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
    public class DistrictConfig : IEntityTypeConfiguration<DistrictEntity>
    {
        public void Configure(EntityTypeBuilder<DistrictEntity> builder)
        {
            builder.ToTable("Districts");
            builder.HasKey(o => o.Id);

            builder.HasIndex(x => x.Code).IsUnique();

            builder.HasOne(o=>o.City)
                .WithMany(o=>o.Districts)
                .HasForeignKey(o=>o.CityId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
