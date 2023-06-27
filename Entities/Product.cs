using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Product:BaseEntities
    {
        [Required]
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public decimal Price { get; set; }
        public string  Description { get; set; }
        public decimal Discount { get; set; }
        public bool IsFeatured { get; set; }
        public int ThumbnailPictureID { get; set; }
        public string SKU { get; set; }
        public string Tags { get; set; }
        public string Barcode { get; set; }
        public string Supplier { get; set; }
        public virtual List<ProductPicture> ProductPicture { get; set; }
    }
}