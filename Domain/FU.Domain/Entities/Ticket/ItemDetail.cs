using FU.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FU.Domain.Entities.Ticket
{
    public class ItemDetail : ValueObject
    {
        public decimal Deep { get; set; }
        public decimal Height { get; set; }
        public decimal Width { get; set; }

        public decimal WeightInKg { get; set; }

        public string Receiver { get; set; }
        public string? Note { get; set; }

        public ItemDetail() { }

        public ItemDetail(decimal deep, decimal height, decimal width, decimal weightInKg, string receiver,string? note)
        {
            Deep = deep;
            Height = height;
            Width = width;
            WeightInKg = weightInKg;
            Receiver = receiver;
            Note = note;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return new object[] { Deep,Height,Width,WeightInKg,Receiver};
        }
    }
}
