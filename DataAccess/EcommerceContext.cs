using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class EcommerceContext:DbContext
    {
        public EcommerceContext(DbContextOptions<EcommerceContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<ProductPicture> ProductPictures { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<OrderHistory> OrderHistories { get; set; }
        public DbSet<Fuser> Fusers { get; set; }
        public DbSet<FirstSlider> FirstSliders { get; set; }
        public DbSet<Follow> Follows { get; set; }
        public DbSet<News> Newss { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<CustomerReview> CustomerReviews { get; set; }



    }
}