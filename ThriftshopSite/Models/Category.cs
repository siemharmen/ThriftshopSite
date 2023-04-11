using System.ComponentModel.DataAnnotations;

namespace ThriftshopSite.Models
{
    public class Category
    {
        [Key]
        public string Name { get; set; }
        public Ctype CategoryType { get; set; }
        public virtual ICollection<Product>? Products { get; set; }


        public enum Ctype
        {
            Color,
            Sort,
            Style
        }
        public Category(string name, Ctype categoryType)
        {
            Name = name;
            CategoryType = categoryType;

        }

        public Category()
        {
        }

        public IEnumerable<Ctype> getCtypes()
        {
            IEnumerable<Ctype> aa = Enum.GetValues(typeof(Ctype)).Cast<Ctype>();
            return aa;

        }
    }
}

