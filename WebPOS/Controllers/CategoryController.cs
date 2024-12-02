using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebPOS.Data;
using WebPOS.DTO;
using WebPOS.Models;

namespace WebPOS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoryController : ControllerBase
    {
        private readonly AppDbContext _db;
        public CategoryController(AppDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _db.categories.Select(x => new { Title = x.Title, Active = x.Active, CreatedAt = x.CreatedAt, UpdateAt = x.UpdatedAt }).ToListAsync();
            if (categories == null)
            {
                return Ok("There is No Categories Yet");
            }
            return Ok(categories);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var category = await _db.categories.FindAsync(id);
            if (category == null)
            {
                return NotFound($"THIS {id} Category Not Found");
            }
            return Ok(category);
        }
        [HttpPost]
        public async Task<IActionResult> AddCategory(CategoryDto categoryDto)
        {
            if (ModelState.IsValid)
            {
                var category = new Category()
                {
                    Title = categoryDto.CategoryTitle,
                    CreatedAt = DateTime.Now,
                    Active = categoryDto.activeCategory,
                };
                await _db.categories.AddAsync(category);
                await _db.SaveChangesAsync();
                return Ok($"Category Saved Successfully");
            }
            return BadRequest(ModelState);
        }
        [HttpPost("{id}")]
        public async Task<IActionResult> UpdateCategory([FromBody] CategoryDto categoryDto, [FromRoute] int id)
        {
            //if (ModelState.IsValid) 
            //{
            var category = await _db.categories.FindAsync(id);
            if (category == null)
            {
                return NotFound("This Category Is Not Found");
            }
            category.Title = categoryDto.CategoryTitle;
            category.Active = categoryDto.activeCategory;
            category.UpdatedAt = DateTime.Now;
            await _db.SaveChangesAsync();
            //if(_db.Entry(category).State == EntityState.Modified)
            //{
            return Ok("Category Updated Successfully");
            //}
            //}
            //return BadRequest(ModelState);
        }
        [HttpPost("[action]/{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            if (ModelState.IsValid)
            {
                var category = await _db.categories.FindAsync(id);
                if (category == null)
                {
                    return NotFound("This Category Is Not Found");
                }
                _db.Remove(category);
                await _db.SaveChangesAsync();
                return Ok("This Category Deleted Successfully");
            }
            return BadRequest(ModelState);
        }
    }
}
