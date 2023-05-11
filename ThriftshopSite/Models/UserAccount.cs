using System.ComponentModel.DataAnnotations;

namespace ThriftshopSite.Models
{
    public class UserAccount
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Role role { get; set; }    

        public enum Role
        {
            Admin,
            Employee,
            User,
        }
    }
}
