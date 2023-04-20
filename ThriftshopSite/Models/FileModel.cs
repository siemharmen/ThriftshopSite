namespace ThriftshopSite.Models
{
    public class FileModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContentType { get; set; }
        public byte[] Data { get; set; }
        public Product? Product { get; set; }

        public FileModel(int id, string name, string contentType, byte[] data, Product product)
        {
            Id = id;
            Name = name;
            ContentType = contentType;
            Data = data;
            Product = product;
        }

        public FileModel()
        {
        }
    }
}
