using FU.Domain.Entities.Seat;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FU.Repository.DbStore.Config
{
    public class SeatConfig : IEntityTypeConfiguration<SeatEntity>
    {
        public void Configure(EntityTypeBuilder<SeatEntity> builder)
        {
            builder.ToTable("Seats");
            builder.HasKey(o => o.Id);

            builder.HasOne(x=>x.Car)
                .WithMany(x=>x.Seats)
                .HasForeignKey(x=>x.CarId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
