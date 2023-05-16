using System.ComponentModel.DataAnnotations;

namespace ThriftshopSite.Models
{
    public class ThriftShop
    {
        [Key]
        public string Name { get; set; }
        public string Location { get; set; }
        public bool IsApproved { get; set; }

        public ThriftShop(string name, string location)
        {
            Name = name;
            Location = location;
            IsApproved = false;
        }

        public ThriftShop()
        {
        }
    }
}
