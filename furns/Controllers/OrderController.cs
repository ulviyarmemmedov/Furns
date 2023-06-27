using Entities;
using furns.viewmodel;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service;
using System.Security.Claims;
using System.Net;

namespace furns.Controllers
{
    public class OrderController : Controller
    {
        private readonly ProductService _pro;
        private readonly RegisService _reg;
        private readonly OrderService _ord;
        public OrderController(ProductService pro, RegisService reg,OrderService ord)
        {
            _pro = pro;
            _reg = reg;
            _ord = ord;
        }
        static List<int> deleteitem = new List<int>();
        [Authorize]
        public IActionResult ceckout(int? id)
        {
            string cookieValue = Request.Cookies["cart"];

            if (!string.IsNullOrEmpty(cookieValue))
            {
                List<int> proId = cookieValue.Split("-").Select(x => int.Parse(x)).ToList();
                foreach (var item in proId)
                {
                    deleteitem.Add(item);
                }
                Response.Cookies.Delete("cart");
                
            }
           
                if (id != null)
                {
                    deleteitem.Remove(id.Value);
                }
                List<Product> prolist = _pro.GetProductByIds(deleteitem);
                CartVM vm = new CartVM()
                {
                    Products = prolist,
                    Propid = deleteitem
                };
                return View(vm);
            

           
        }
        [Authorize]
        [HttpPost]
        public IActionResult ceckout(CartVM vm)
        {


            Fuser customer=  _reg.getuserbyname(User.FindFirst(ClaimTypes.Name)?.Value);
            Order nese = _ord.GetOrder(customer.Id);
          
                vm.order.CustomerID = customer.Id.ToString();
                vm.order.OrderCode = "sdgds";
                vm.order.PaymentMethod = 1;
                vm.order.Discount = 0;
                vm.order.DeliveryCharges = 0;
                DateTime currentTime = DateTime.Parse("6/19/2022 12:34:12 AM");
                vm.order.PlacedOn = currentTime;

                _ord.getaddorderitem(vm.order);

            OrderItem orderItem = new OrderItem();
            string cookieValue = Request.Cookies["cart"];
            if (!string.IsNullOrEmpty(cookieValue))
            {
                List<int> proId = cookieValue.Split("-").Select(x => int.Parse(x)).ToList();
                List<Product> prolist = _pro.GetProductByIds(proId);

                foreach (var item in prolist)
                {
                    int quantity=proId.Where(x=>x==item.Id).Count();
                    decimal price;
                    if (item.Discount>0)
                    {
                         price = item.Price - (item.Price / 100 * item.Discount);
                    }
                    else
                    {
                        price = item.Price;
                    }
                    orderItem.Id = 0;
                    orderItem.OrderID = nese.Id;
                    orderItem.ProductId = item.Id;
                    orderItem.ItemPrice = price;
                    orderItem.Quantity = quantity;
                    _ord.getaddorderitem(orderItem);

                }
            
            }

            Response.Cookies.Delete("cart");
            deleteitem.Clear();

            return RedirectToAction("index","home");
        }
        public IActionResult singout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("index","home");
        }

    }
}
