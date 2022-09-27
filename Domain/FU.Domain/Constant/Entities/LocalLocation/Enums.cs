using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FU.Domain.Entities.LocalLocation
{
    public enum DivisionType
    {
        [Description("tỉnh")]
        District = 0,
        [Description("phường")]
        Ward = 1,
        [Description("xã")]
        Commune = 2,
        [Description("thị trấn")]
        Town = 3,
    }
}
