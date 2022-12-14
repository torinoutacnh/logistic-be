using FU.Domain.Entities.Car;
using FU.Domain.Entities.Ticket;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FU.Repository.DbStore.Config
{
    public class TicketConfig : IEntityTypeConfiguration<TicketEntity>
    {
        public void Configure(EntityTypeBuilder<TicketEntity> builder)
        {
            builder.ToTable("Tickets");
            builder.HasKey(o => o.Id);

            builder.OwnsOne(x => x.ItemDetail)
                .Property(x=>x.Width).HasColumnName("Width");
            builder.OwnsOne(x => x.ItemDetail)
                .Property(x => x.Height).HasColumnName("Height");
            builder.OwnsOne(x => x.ItemDetail)
                .Property(x => x.Deep).HasColumnName("Deep");
            builder.OwnsOne(x => x.ItemDetail)
                .Property(x => x.Receiver).HasColumnName("Receiver");
            builder.OwnsOne(x => x.ItemDetail)
                .Property(x => x.Note).HasColumnName("Note");
            builder.OwnsOne(x => x.ItemDetail)
                .Property(x => x.WeightInKg).HasColumnName("WeightInKg");
        }
    }
}
