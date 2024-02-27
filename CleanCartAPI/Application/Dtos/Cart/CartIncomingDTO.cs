using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Cart
{
    public class CartIncomingDTO
    {
        public Guid UserId { get; set; }

        public Guid ProductId { get; set; }

    }
}
