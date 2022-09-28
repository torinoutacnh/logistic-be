using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FU.Domain.Entities.CarRouteMapping.SubModel
{
    public class GetCarRouteByLocationStarttimeModel
    {
        public Guid FromCityId { get; set; }
        public Guid ToCityId { get; set; }
        public DateTimeOffset Starttime { get; set; }

        public GetCarRouteByLocationStarttimeModel(Guid fromCityId, Guid toCityId, DateTimeOffset starttime)
        {
            FromCityId = fromCityId;
            ToCityId = toCityId;
            Starttime = starttime;
        }
    }
}
