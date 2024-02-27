using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Product
{
    public class ProductOutgoingDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public int Quantity { get; set; }

        public float Price { get; set; }
    }
}
