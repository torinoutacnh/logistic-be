using FU.Domain.Entities.LocalLocation;
using FU.Domain.Entities.StopPoint;
using FU.Infras.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FU.Repository.DbStore.Config
{
    public class StopPointConfig : IEntityTypeConfiguration<StopPointEntity>
    {
        public void Configure(EntityTypeBuilder<StopPointEntity> builder)
        {
            builder.ToTable("StopPoints");
            builder.HasKey(o => o.Id);

            builder.OwnsOne(o => o.Location)
                .Property(x=>x.CityId).HasColumnName("CityId");
            builder.OwnsOne(o => o.Location)
                .Property(x => x.DistrictId).HasColumnName("DistrictId");
            builder.OwnsOne(o => o.Location)
                .Property(x => x.WardId).HasColumnName("WardId");
            builder.OwnsOne(o => o.Location)
                .Property(x => x.Street).HasColumnName("Street");
            builder.OwnsOne(o => o.Location)
                .Property(x => x.HouseNumber).HasColumnName("HouseNumber");

            builder.OwnsOne(o => o.DetailLocation)
               .Property(x => x.Longitude).HasColumnName("Longitude");
            builder.OwnsOne(o => o.DetailLocation)
               .Property(x => x.Latitude).HasColumnName("Latitude");

            builder.HasOne(x=>x.Car)
                .WithMany(x=>x.StopPoints)
                .HasForeignKey(x=>x.CarId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
