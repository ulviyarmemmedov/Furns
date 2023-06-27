using furns.viewmodel;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace furns.Controllers
{

    public class ProductController : Controller
    {
        private readonly ProductService _proser;
        private readonly CategoryService _cat;
        public ProductController(ProductService proser, CategoryService cat)
        {
            _proser = proser;
            _cat = cat;
        }
       
        public IActionResult Shop(int? id, string name,int? min,int? max,int? sort)
        {
            searchVM vm = new searchVM()
            {
                Products = _proser.SearchProduct(id, name,min,max,sort),
                Category = _cat.GetCategory(),
                categoryid = id,
                maxprice = _proser.getproductcount()
            };
            return View(vm);
        }
        public IActionResult Detaling(int? id)
        {
            if (id == null) return NotFound();
            var singleProduct = _proser.GetProductById(id.Value);
            if (singleProduct == null) return NotFound();
            ProductDetailVm vm = new ProductDetailVm()
            {
                SingleProduct = singleProduct,
                SameCategory = _proser.SameCategoryProduct(id.Value),
                FeaturedProduct = _proser.FeaturedProducts(id.Value )

            };
            return View(vm);
        }


    }
}
