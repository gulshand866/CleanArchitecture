using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Cart
    {
        [Key]
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public List<Guid> Products { get; set; } = new List<Guid>();
    }
}
