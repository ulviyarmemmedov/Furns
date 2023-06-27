using furns.viewmodel;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace furns.Controllers
{
    public class SingleController : Controller
    {

        private readonly SingleService _sing;
        public SingleController(SingleService sing)
        {
            _sing = sing;
        }
        public IActionResult Detal(int? id)
        {
            if (id == null) return NotFound(); 
            SingleVM vm = new SingleVM()
            {
                Newss = _sing.getnewssing(id.Value)
            };
            return View(vm);
        }
    }
}
