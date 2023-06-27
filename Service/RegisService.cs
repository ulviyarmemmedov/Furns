using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entities;

namespace Service
{
    public class RegisService
    {
        private readonly EcommerceContext _context;
            public RegisService(EcommerceContext context)
        {
            _context = context;
        }

        public void adduser(Fuser vm)
        {
            
            _context.Fusers.Add(vm);
            
            _context.SaveChanges();
        }
        public Fuser getUser(string username,string pass)
        {
            return _context.Fusers.FirstOrDefault(x => x.FullName == username && x.Password == pass);
        }

        public Fuser getuserbyname(string name)
        {
            return _context.Fusers.FirstOrDefault(x => x.FullName == name);
        }

        public void addReview(CustomerReview vm)
        {
            _context.CustomerReviews.Add(vm);
            _context.SaveChanges();
        }

    }
}
