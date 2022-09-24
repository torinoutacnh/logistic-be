using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FU.Service.Models
{
    public class UpdateCarRouteMappingWithFileModel
    {
        public Guid CarId { get; private set; }
        public Guid RouteId { get; private set; }
        public DateTimeOffset Starttime { get; private set; }
    }
}
