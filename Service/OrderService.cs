using DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class OrderService
    {
        private readonly EcommerceContext _context;
        public OrderService(EcommerceContext context)
        {
            _context = context; 
        }

        public void getaddorderitem(Order or)
        {
            _context.Orders.Add(or);
            _context.SaveChanges();
        }
        public Order GetOrder(int id)
        {
            return _context.Orders.FirstOrDefault(x => x.CustomerID == id.ToString());
        }
        public void getaddorderitem(OrderItem item)
        {
            _context.OrderItems.Add(item);
            _context.SaveChanges();
        }
    }
}
