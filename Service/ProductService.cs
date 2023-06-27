using DataAccess;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Service
{
    public class ProductService
    {
        private readonly EcommerceContext _context;
        public ProductService(EcommerceContext context)
        {
            _context = context;

        }

        public List<Product> GetProducts()
        {
            return _context.Products.Include("ProductPicture.Picture").ToList();
        }

        public Product GetProductById(int id)
        {
            return _context.Products.Include("ProductPicture.Picture").FirstOrDefault(x => x.Id == id);
        }
        public List<Product> SameCategoryProduct(int id)
        {
            var single = GetProductById(id);
            return _context.Products.Include("ProductPicture.Picture").Where(x=>x.CategoryId==single.CategoryId && x.Id!=id).ToList();
        }
        public List<Product> FeaturedProducts(int id)
        {
            
            return _context.Products.Include("ProductPicture.Picture").Where(x => x.IsFeatured && x.Id!=id).ToList();
        }
        public List<Product> GetProductByIds(List<int> ids)
        {

            return _context.Products.Where(x=>ids.Contains(x.Id)).ToList();  
        }
        public List<Product> SearchProduct(int? id,string? searchname,int? min,int? max,int? sort)
        {
            IQueryable<Product> products = _context.Products.AsQueryable(); 
            if (id.HasValue)
            {
                products = products.Where(x => x.CategoryId == id);
            }
            if (!string.IsNullOrWhiteSpace(searchname))
            {
                products = products.Where(x => x.Name.Contains(searchname));
            }
            if(min!=null && max!=null)
            {
                products = products.Where(x => ((x.Discount>0)?(x.Price-(x.Price/100*x.Discount)):x.Price) > min && ((x.Discount > 0) ? (x.Price - (x.Price / 100 * x.Discount)) : x.Price) < max);
            }
            if(sort!=null)
            {
                if (sort == 1)
                 products = products.OrderBy(x => x.Price);
                else if(sort==2)
                    products = products.OrderBy(x => x.Name);
                else if (sort == 3)
                    products = products.OrderByDescending(x => x.Name);
                else if (sort == 4)
                    products = products.OrderByDescending(x => x.Price);

            }
            return products.Include("ProductPicture.Picture").OrderByDescending(x=>x.Id).ToList();
        }
        public int getproductcount()
        {
           return _context.Products.Count();
            
            
        }

    
    }
}