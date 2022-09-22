using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FU.Service.Models
{
    public class CreateManagerModel
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public IFormFile? LogoPath { get; set; }
    }
}
