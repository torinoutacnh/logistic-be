using FU.Domain.Entities.Car;
using FU.Domain.Entities.Route;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FU.Repository.DbStore.Config
{
    public class RouteConfig : IEntityTypeConfiguration<RouteEntity>
    {
        public void Configure(EntityTypeBuilder<RouteEntity> builder)
        {
            builder.ToTable("Routes");
            builder.HasKey(o => o.Id);

            builder.HasOne(o => o.Car)
                .WithMany(o => o.Routes)
                .HasForeignKey(o => o.CarId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(o => o.FromPoint)
               .WithMany(o => o.FromRoutes)
               .HasForeignKey(o => o.FromId)
               .IsRequired()
               .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(o => o.ToPoint)
               .WithMany(o => o.ToRoutes)
               .HasForeignKey(o => o.ToId)
               .IsRequired()
               .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
