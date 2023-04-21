namespace ThriftshopSite.Models
{
    public class ProductViewModel
    {
        public Product product { get; set; }
        public FileModel File { get; set; }
        public IList<FileModel> Files { get; set; }
    }
}
    