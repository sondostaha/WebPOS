//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using WebPOS.Data;
//using WebPOS.DTO;
//using WebPOS.Models;

//namespace WebPOS.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class IngrediantController : ControllerBase
//    {
//        private readonly AppDbContext _db;
//        public IngrediantController(AppDbContext db)
//        {
//            _db = db;
//        }
//        [HttpGet]
//        public async Task<IActionResult> GetIngrediants()
//        {
//            var ingred = await _db.ingrediants.Select(x => new
//            {
//                Ingediant = x.ingrediant,
//            }).ToListAsync();
//            if (ingred.Any()) 
//            {
//                return Ok(ingred);
//            }
//            return Ok("There Is No Ingrediants");
//        }
//        [HttpGet("{id}")]
//        public async Task<IActionResult> GetIngrediant(int id)
//        {
//            var ingrd = await _db.ingrediants.FindAsync(id);
//            if(ingrd == null)
//            {
//                return NotFound("This Ingrediant Does Not Exist");
//            }
//            return Ok(ingrd);
//        }
//        [HttpPost]
//        public async Task<IActionResult> AddIngrediat(IngredientDto ingrediantsDto)
//        {
//            var ingrad =new Ingrediants()
//            {
//                ingrediant =ingrediantsDto.ingrediant,
//            };
//            await _db.ingrediants.AddAsync(ingrad);
//            await _db.SaveChangesAsync();
//            return Ok("this ingrediant Added Successfully");
//        }
//        [HttpPost("{id}")]
//        public async Task<IActionResult> UpdateIngrediant(IngredientDto ingrediantDto,int id)
//        {
//            var ingrd = await _db.ingrediants.FindAsync(id);
//            if (ingrd == null)
//                return NotFound("This Ingrediant Does Not Exist");
//            ingrd.ingrediant = ingrediantDto.ingrediant;
//            await _db.SaveChangesAsync();
//            if (_db.Entry(ingrd).State == EntityState.Modified)
//                return Ok("Ingrediant Updated Successfully");
//            return BadRequest("Somthing Goes Wrong Pleas Try Again");
//        }
//        [HttpPost("[action]/{id}")]
//        public async Task<IActionResult> Delete(int id)
//        {
//            var ingrd = await _db.ingrediants.FindAsync(id);
//            if (ingrd == null)
//                return NotFound("This Ingrediant Does Not Exist");
//             _db.Remove(ingrd);
//            await _db.SaveChangesAsync();
//            return Ok();
//        }
//    }
//}
