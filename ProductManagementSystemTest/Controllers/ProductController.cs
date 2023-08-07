using Microsoft.AspNetCore.Mvc;
using ProductManagementSystemNet.DBEntity;
using ProductManagementSystemTest.Model;

namespace ProductManagementSystemNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext _dbContext;

        public ProductController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/Product
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            var products = _dbContext.Products.ToList();
            return Ok(products);
        }

        // GET: api/Product/5
        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct(int id)
        {
            var product = _dbContext.Products.Find(id);
            if (product == null)
                return NotFound();

            return Ok(product);
        }

        // POST: api/Product
        [HttpPost]
        public ActionResult<Product> AddProduct(Product product)
        {
            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }

        // PUT: api/Product/5
        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, Product product)
        {
            if (id != product.Id)
                return BadRequest();

            var existingProduct = _dbContext.Products.Find(id);
            if (existingProduct == null)
                return NotFound();

            existingProduct.Name = product.Name; // Update other properties as needed
            existingProduct.Price = product.Price;

            _dbContext.SaveChanges();
            return NoContent();
        }

        // DELETE: api/Product/5
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = _dbContext.Products.Find(id);
            if (product == null)
                return NotFound();

            _dbContext.Products.Remove(product);
            _dbContext.SaveChanges();
            return NoContent();
        }

        private bool ProductExists(int id)
        {
            return _dbContext.Products.Any(p => p.Id == id);
        }
    }
}
