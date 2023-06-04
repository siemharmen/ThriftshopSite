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
            });

            modelBuilder.Entity<Category>().HasData(new List<Category>
            {
                new Category
                {
                    Name = "Green",
                    CategoryType = Category.Ctype.Color
                },
              new Category
                {
                    Name = "Modern",
                    CategoryType = Category.Ctype.Style
                },
               new Category
                {
                    Name = "Chair",
                    CategoryType = Category.Ctype.Sort
                },
            });
    
            var hasher = new PasswordHasher<IdentityUser>();

            modelBuilder.Entity<IdentityUser>().HasData(
                 new IdentityUser
                 {
                     Id = "8e445865-a24d-4543-a6c6-9443d048cdb9", // primary key
                     UserName = "Admin.Admin@admin.nl",
                     Email = "Admin.Admin@admin.nl",
                     NormalizedUserName = "ADMIN.ADMIN@ADMIN.NL",
                     NormalizedEmail = "ADMIN.ADMIN@ADMIN.NL",
                     PasswordHash = hasher.HashPassword(null, "Password!12"),
                     EmailConfirmed = true,
                 });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "1",
                    UserId = "8e445865-a24d-4543-a6c6-9443d048cdb9"
                }
            );

        }


        public DbSet<ThriftshopSite.Models.UserAccount>? UserAccount { get; set; }
    }
}