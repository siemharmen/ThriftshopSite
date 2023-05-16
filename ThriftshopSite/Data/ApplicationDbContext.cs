using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ThriftshopSite.Models;

namespace ThriftshopSite.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ThriftShop> ThriftShops { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryProduct> CategoryProducts { get; set; }
        public DbSet<FileModel> Files { get; set; }
        public DbSet<EmployeeThriftshop> EmployeeThriftShops { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CategoryProduct>().HasKey(o => new { o.ProductsId, o.CategoriesName });

            modelBuilder.Entity<IdentityRole>().HasData(new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = "1",
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Id = "2",
                    Name = "Employee",
                    NormalizedName = "Thriftshop Employee"
                },
                  new IdentityRole
                {
                    Id = "3",
                    Name = "User",
                    NormalizedName = "User"
                }
            });            //modelBuilder.Entity<Product>().HasData(
            //  new Product(Guid.NewGuid(),"Grey chair", 2, 1.6,"a chair",new ThriftShop("weezel", "bakkerstreet"), new List<Category>(){new Sort("test")})

            //);
        }


        public DbSet<ThriftshopSite.Models.UserAccount>? UserAccount { get; set; }
    }
}