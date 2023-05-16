using System.ComponentModel.DataAnnotations;

namespace ThriftshopSite.Models
{
    public class EmployeeThriftshop
    {
        [Key]
        public Guid Id { get; set; }
        public UserAccount Account { get; set; }
        public ThriftShop ThriftShop { get; set; }

        public EmployeeThriftshop(UserAccount account, ThriftShop thriftShop)
        {
            Account = account;
            ThriftShop = thriftShop;
        }

        public EmployeeThriftshop()
        {
        }
    }
}
