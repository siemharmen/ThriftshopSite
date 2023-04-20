namespace ThriftshopSite.Models
{
    public class ProductViewModel
    {
        public Product product { get; set; }
        public IList<FileModel> File { get; set; }
    }
}
