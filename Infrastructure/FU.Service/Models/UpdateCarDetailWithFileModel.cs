using FU.Domain.Entities.Car;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FU.Service.Models
{
    public class UpdateCarDetailWithFileModel
    {
        public Guid Id { get; set; }
        public string CarModel { get; set; }
        public string CarColor { get; set; }
        public IFormFile? ImagePath { get; set; }
        public string Tel { get; set; }
        public string CarNumber { get; set; }
        public CarServiceType ServiceType { get; set; }
    }
}
