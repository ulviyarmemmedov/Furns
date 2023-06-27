using Entities;

namespace furns.viewmodel
{
    public class searchVM
    {
        public List<Product> Products { get; set; }
        public List<Category> Category { get; set; }
        public int? categoryid { get; set; }
        public int? maxprice { get; set; }
    }
}
