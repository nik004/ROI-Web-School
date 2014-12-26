using System.Collections.Generic;
using System.Data.Entity;

namespace ProductAssistant.DAL
{
    public class ProductRepository
    {
        private readonly ProductAssistantContex _contex;

        public ProductRepository(ProductAssistantContex contex)
        {
            _contex = contex;
        }

        public IEnumerable<Product> GetAll()
        {
            return _contex.Products;
        }

        public Product Get(int productId)
        {
            return _contex.Products.Find(productId);
        }

        public void Add(Product product)
        {
            _contex.Products.Add(product);
            _contex.SaveChanges();
        }

        public void Edit(Product product)
        {
            _contex.Entry(product).State = EntityState.Modified;
            _contex.SaveChanges();
        }

        public void Delete(int productId)
        {
            var product = _contex.Products.Find(productId);
            if (product != null)
            {
                _contex.Products.Remove(product);
                _contex.SaveChanges();
            }
        }
    }
}
