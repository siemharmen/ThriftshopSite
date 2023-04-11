using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThriftshopSite.Models
{
    public class CategoryProduct
    {
        public string CategoriesName { get; set; }
        public Guid ProductsId { get; set; }

        public CategoryProduct(string categoriesName, Guid productsId)
        {
            CategoriesName = categoriesName;
            ProductsId = productsId;
        }

        public CategoryProduct()
        {
        }
    }
}
