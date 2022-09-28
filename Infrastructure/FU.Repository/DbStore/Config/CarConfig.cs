using FU.Domain.Entities.Car;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FU.Repository.DbStore.Config
{
    public class CarConfig : IEntityTypeConfiguration<CarEntity>
    {
        public void Configure(EntityTypeBuilder<CarEntity> builder)
        {
            builder.ToTable("Cars");
            builder.HasKey(o => o.Id);

            builder.HasOne(o=>o.CarsManager)
                .WithMany(o=>o.Cars)
                .HasForeignKey(o=>o.CarsManagerId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
