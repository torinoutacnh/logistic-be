using AutoMapper;
using FU.Domain.Entities.Car;
using FU.Domain.Entities.Car.SubModel;
using FU.Domain.Entities.CarsManager;
using FU.Service.Models.CarsManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FU.Service.AutoMapperProfile
{
    public class CarsManagerProfile: Profile
    {
        public CarsManagerProfile()
        {
            CreateMap<CarEntity, CarViewModel>();
            CreateMap<CarsManagerEntity, CarsManagerInfoModel>();
            CreateMap<CarsManagerEntity, CarsManagerMapModel>()
                .ForMember(x=>x.Cars,o=>o.MapFrom(y=>y.Cars));
        }
    }
}
