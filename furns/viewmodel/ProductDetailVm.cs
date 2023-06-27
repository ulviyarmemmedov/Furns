using Entities;

namespace furns.viewmodel
{
    public class ProductDetailVm
    {
        public Product SingleProduct { get; set; }
        public List<Product> SameCategory { get; set; }
        public List<Product> FeaturedProduct { get; set; }
    }
}
