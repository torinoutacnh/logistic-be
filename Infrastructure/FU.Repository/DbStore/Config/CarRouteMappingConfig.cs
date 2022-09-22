using FU.Domain.Entities.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FU.Repository.DbStore.Config
{
    public class CarRouteMappingConfig : IEntityTypeConfiguration<CarRouteMapping>
    {
        public void Configure(EntityTypeBuilder<CarRouteMapping> builder)
        {
            builder.ToTable("CarRouteMapping");
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Car)
                            .WithMany(x => x.CarRouteMappings)
                            .HasForeignKey(x => x.CarId)
                            .IsRequired()
                            .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Route)
                            .WithMany(x => x.CarRouteMappings)
                            .HasForeignKey(x => x.RouteId)
                            .IsRequired()
                            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
