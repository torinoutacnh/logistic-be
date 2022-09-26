﻿using FU.Domain.Entities.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FU.Domain.Entities.CarRouteMapping.SubModel
{
    public class CarRouteMappingViewModel
    {
        public Guid CarId { get; private set; }
        public Guid RouteId { get; private set; }
        public DateTimeOffset Starttime { get; private set; }

        public CarRouteMappingViewModel(CarRouteMappingEntity carRouteMappingEntity)
        {
            CarId = carRouteMappingEntity.CarId;
            RouteId = carRouteMappingEntity.RouteId;
            Starttime = carRouteMappingEntity.Starttime;
        }
    }
}