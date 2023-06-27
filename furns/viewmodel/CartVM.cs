using Entities;

namespace furns.viewmodel
{
    public class CartVM
    {
        public List<Product> Products { get; set; }
        public List<int> Propid { get; set; }

        public Order order { get; set; }    
    }
}
