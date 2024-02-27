using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Order
{
    public class OrderIncomingDTO
    {
        public Guid UserId { get; set; }

        public List<Guid> Products { get; set; } = new List<Guid>();

    }
}
