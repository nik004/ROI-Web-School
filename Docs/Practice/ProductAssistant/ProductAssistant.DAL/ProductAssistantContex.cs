using System.Data.Entity;

namespace ProductAssistant.DAL
{
    public class ProductAssistantContex : DbContext
    {
        public ProductAssistantContex(string connectionStringName):base(connectionStringName)
        {
        }

        public DbSet<Product> Products { set; get; }
    }
}