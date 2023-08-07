using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductManagementSystemNet.DBEntity;
using ProductManagementSystemTest.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagementSystemTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController] 
    public class CategoryController : ControllerBase
    {
        private readonly AppDbContext _dbContext;

        public CategoryController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Categories>> GetCategories()
        {
            var categories = _dbContext.Categories.ToList();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Categories>> GetCategory(int id)
        {
            var category = await _dbContext.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpPost]
        public ActionResult<Categories> AddCategory(Categories category)
        {
            _dbContext.Categories.Add(category);
            _dbContext.SaveChanges();
            return Ok(category);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, Categories updatedCategory)
        {
            var category = await _dbContext.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            // Update the properties of the category with the values from updatedCategory
            category.Name = updatedCategory.Name;
            category.Description = updatedCategory.Description;

            await _dbContext.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _dbContext.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            _dbContext.Categories.Remove(category);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }
    }
}
