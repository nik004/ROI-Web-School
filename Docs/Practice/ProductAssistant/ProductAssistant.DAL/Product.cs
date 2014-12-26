using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductAssistant.DAL
{
    [Table("dbo.Product")]
    public class Product
    {
        [Key]
        public int Id { set; get; }

        public string Name { set; get; }
        public double Price { set; get; }
        public string Category { set; get; }
    }
}
