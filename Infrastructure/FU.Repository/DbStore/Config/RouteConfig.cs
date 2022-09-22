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

            builder.OwnsOne(x => x.From);
            builder.OwnsOne(x => x.To);
        }
    }
}
