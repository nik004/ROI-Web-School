using System.Collections.Generic;
using System.Web.Http;
using ProductAssistant.DAL;

namespace ProductAssistant.Controllers
{
    public class ProductController : ApiController
    {
        private readonly ProductRepository _productRepository =new ProductRepository(new ProductAssistantContex("DefaultConnectionString"));
        // GET api/product
        public IEnumerable<Product> Get()
        {
            return _productRepository.GetAll();
        }

        // GET api/product/5
        public Product Get(int id)
        {
            return _productRepository.Get(id);
        }

        // POST api/product
        public void Post([FromBody]Product product)
        {
            _productRepository.Add(product);
        }

        // PUT api/product/5
        public void Put(int id, [FromBody]Product product)
        {
            if (id == product.Id)
            {
                _productRepository.Edit(product);
            }
        }

        // DELETE api/product/5
        public void Delete(int id)
        {
            _productRepository.Delete(id);
        }
    }
}
