using System.Data.Entity;

namespace Crm.Data
{
    public class CrmContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Operation> Operations { get; set; }
    }
}
