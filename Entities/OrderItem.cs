using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class OrderItem:BaseEntities
    {
        public int OrderID { get; set; }
        [NotMapped]
        public string ProductName { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public decimal ItemPrice { get; set; }
        public int Quantity { get; set; }
    }
}
