using DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class SingleService
    {
        private readonly EcommerceContext _context;
        public SingleService(EcommerceContext context)
        {
            _context = context; 
        }

        public List<FirstSlider> getfirstslider()
        {
            return _context.FirstSliders.ToList();
        }
        public List<Sale> getsale()
        {
            return _context.Sales.ToList();
        }
        public List<News> GetNews()
        {
            return _context.Newss.ToList();
        }

        public News getnewssing(int id)
        {
            return _context.Newss.FirstOrDefault(x => x.Id == id);
        }
        public List<Follow> GetFollows()
        {
            return _context.Follows.ToList();
        }

        
    }
}
