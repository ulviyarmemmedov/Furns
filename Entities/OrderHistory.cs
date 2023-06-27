using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class OrderHistory:BaseEntities
    {
        public int OrderId { get; set; }
        public int OrderStatus { get; set; }
        public string Note { get; set; }
    }
}
