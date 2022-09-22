using FU.Domain.Entities.Car;
using FU.Domain.Entities.CarsManager;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FU.Repository.DbStore.Config
{
    public class CarsManagerConfig : IEntityTypeConfiguration<CarsManagerEntity>
    {
        public void Configure(EntityTypeBuilder<CarsManagerEntity> builder)
        {
            builder.ToTable("CarsManagers");
            builder.HasKey(o => o.Id);
        }
    }
}
