using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Order:BaseEntities
    {
        public string CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerAddress { get; set; }
        public string? OrderCode { get; set; }
        public int? PaymentMethod { get; set; }
        public decimal? TotalAmmount { get; set; }
        public decimal? Discount { get; set; }
        public decimal? DeliveryCharges { get; set; }
        public DateTime? PlacedOn { get; set; }
        public string? TransactionId { get; set; }
        public virtual List<OrderItem> OrderItem { get; set; }
        public virtual List<OrderHistory> OrderHistory { get; set; }




    }
}
