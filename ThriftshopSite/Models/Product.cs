using System.ComponentModel.DataAnnotations;

namespace ThriftshopSite.Models
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Inventory { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public ThriftShop Shop { get; set; }  
        //public List<Category> Categories { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
        public ICollection<FileModel> Posts { get; } = new List<FileModel>();

        public Product(Guid id,string name, int inventory, double price, string description,string image, ThriftShop shop, List<Category> categories)
        {
            Id = id;
            Name = name;
            Inventory = inventory;
            Price = price;
            Description = description;
            Image = image;
            Shop = shop;
            Categories = categories;
        }

        public Product(Guid id, string name, int inventory, double price, string description, string image)
        {
            Id = id;
            Name = name;
            Inventory = inventory;
            Price = price;
            Description = description;
            Image = image;
        }

        public Product()
        {
        }
    }
}
