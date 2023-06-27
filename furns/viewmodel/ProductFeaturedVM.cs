using Entities;

namespace furns.viewmodel
{
    public class ProductFeaturedVM
    {
        public List<Product> Products { get; set; }

        public List<Category> Categories { get; set; }
        public List<FirstSlider> firstSlider { get; set; }
        public List<Sale> Sales { get; set; }
        public List<News> Newss { get; set; }

        public List<Follow> Follows { get; set; }

    }
}
