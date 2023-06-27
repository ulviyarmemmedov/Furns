using Entities;
using furns.Models;
using furns.viewmodel;
using Microsoft.AspNetCore.Mvc;
using Service;
using System.Diagnostics;

namespace furns.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ProductService _Productser;
        private readonly CategoryService _Category;
        private readonly SingleService _sing;
        private readonly RegisService _reg;
        public HomeController(ILogger<HomeController> logger,ProductService productser, CategoryService category, SingleService sing, RegisService reg)
        {
            _logger = logger;
            _Productser = productser;
            _Category = category;
            _sing = sing;
            _reg = reg; 
        }

        public IActionResult Index()
        {
            ProductFeaturedVM vm = new ProductFeaturedVM()
            {
                Products = _Productser.GetProducts(),
                Categories = _Category.GetCategory(),
                firstSlider = _sing.getfirstslider(),
                Sales = _sing.getsale(),
                Newss=_sing.GetNews(),
                Follows=_sing.GetFollows()
            };
                return View(vm);
        }
        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Contact(CustomerReview vm)
        {
            if (vm == null) return NotFound();
            _reg.addReview(vm);
            return RedirectToAction("index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
