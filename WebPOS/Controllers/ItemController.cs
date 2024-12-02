//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Http.HttpResults;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using System;
//using WebPOS.Data;
//using WebPOS.DTO;
//using WebPOS.Models;

//namespace WebPOS.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    //[Authorize]
//    public class ItemController : ControllerBase
//    {
//        private AppDbContext _db;
//        public ItemController(AppDbContext db)
//        {
//            _db = db;
//        }
//        [HttpGet]
//        public async Task<IActionResult> GetItems()
//        {
//            var items = await _db.items.Select(x => new
//            {
//                ItemName = x.Title,
//                Category = x.category,
//                Price = x.Price,
//                Ingrediants = x.itemIngrediants,
//                CreatedAt = x.CreatedAt,
//                ReadyByDefault = x.ReadyByDefault.ToString(),
//                Active = x.Active,
//                ActiveKiosk = x.ActiveKiosk,
//                Photo = x.Photo,
//            }).ToListAsync();
        
//            return Ok(items);
//        }

//        [HttpGet("{id}")]
//        public async Task<IActionResult> Item(int id)
//        {
//            var item = await _db.items.Where(x => x.Id == id).Select(x => new
//            {
//                ItemName = x.Title,
//                Category = x.category,
//                Price = x.Price,
//                Ingrediants = x.itemIngrediants,
//                CreatedAt = x.CreatedAt,
//                ReadyByDefault = x.ReadyByDefault.ToString(),
//                Active = x.Active,
//                ActiveKiosk = x.ActiveKiosk,
//                Photo = x.Photo,
//            }).FirstAsync();
//            if (item == null) 
//            {
//                return NotFound("This Item Does Not Exist");
//            }
//            return Ok(item);
//        }
//        [HttpPost]
//        public async Task<IActionResult> AddItem(ItemsDto itemsDto,List<ItemIngrediatsDto> itemIngrediatsDto)

//        {

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    var category = await _db.categories.FindAsync(itemsDto.categoryId);

//                    if (category == null)
//                    {

//                        return NotFound("This Category Does Not Exist");

//                    }

//                    var item = new Items()
//                    {
//                        Title = itemsDto.Title,
//                        Price = itemsDto.Price,
//                        ReadyByDefault = (Models.ReadyByDefault)itemsDto.ready_by_default,
//                        CreatedAt = DateTime.Now,
//                        categoryId = category.Id,
//                        Active = itemsDto.Active,
//                        ActiveKiosk = itemsDto.ActiveKiosk,
//                        itemIngrediants = new List<ItemIngrediants>() { },

//                    };
//                    if (itemsDto.Photo != null)
//                    {
//                        var streem = new MemoryStream();
//                        await itemsDto.Photo.CopyToAsync(streem);
//                        item.Photo = streem.ToArray();
//                    }
//                    if (itemIngrediatsDto.Count > 0)
//                    {
//                        Console.WriteLine($"From If Count {itemIngrediatsDto.ToArray()}");
//                        foreach (var ingrd in itemIngrediatsDto)
//                        {
//                            var checkIng = await _db.ingrediants.FindAsync(ingrd.IngrediatId);
//                            if (checkIng == null)
//                                return NotFound("This Ingrediat Does Not Exist");
//                            ItemIngrediants ing = new()
//                            {
//                                IngrediantId = ingrd.IngrediatId,
//                                Quentity =ingrd.QuentityOfIngrediat,
//                                CreatedAt= DateTime.Now,
//                            };
//                             item.itemIngrediants.Add(ing);
//                        }

//                    }
//                    Console.WriteLine($"before Save  {itemIngrediatsDto.ToArray()}");

//                    await _db.items.AddAsync(item);
//                    await _db.SaveChangesAsync();
//                    //itemIngrediatsDto.i
//                    return Ok("Item Added Successfully");
//                }
//                catch(Exception ex)
//                    {
//                        return BadRequest(ex.Message );
//                    }
              
//            }
//            return BadRequest(ModelState);

//        }


//        [HttpPost("{id}")]
//        public async Task<IActionResult> UpdateItem( ItemsDto itemsDto,List<ItemIngrediatsDto> itemIngrediatsDto, [FromRoute] int id)
//        {
//            if (ModelState.IsValid)
//            {
//                var category = await _db.categories.FindAsync(itemsDto.categoryId);
//                if (category == null)
//                {
//                    return NotFound("This Caategory Does Not Exist");
//                }
//                var item = await _db.items.FindAsync(id);
//                if (item == null)
//                {
//                    return NotFound($"This Item Does Not Exist");
//                }

//                item.Title = itemsDto.Title;
//                item.Price = itemsDto.Price;

//                item.ReadyByDefault = (Models.ReadyByDefault)itemsDto.ready_by_default;
//                item.CreatedAt = DateTime.Now;
//                item.categoryId = category.Id;
//                item.Active = itemsDto.Active;
//                item.ActiveKiosk = itemsDto.ActiveKiosk;
//                item.UpdateAt = DateTime.Now;
//                if (itemIngrediatsDto.Count > 0)
//                {
//                    item.itemIngrediants.Clear();
//                    item.itemIngrediants = new List<ItemIngrediants>();

//                    foreach (var ingrd in itemIngrediatsDto)
//                    {
//                        ItemIngrediants itemIngrediants = new()
//                        {
//                            IngrediantId = ingrd.IngrediatId,
//                            Quentity = ingrd.QuentityOfIngrediat,
//                            UpdatedAt = DateTime.Now,
//                        };
//                        item.itemIngrediants.Add(itemIngrediants);
//                    }
//                }
//                await _db.SaveChangesAsync();
//                //if (_db.Entry(item).State == EntityState.Modified)
//                //{
//                    return Ok("Item Updated Successully");

//                //}
//            }
//            return BadRequest(ModelState);
//        }
//        [HttpPost("[action]/{id}")]
//        public async Task<IActionResult> Delete(int id)
//        {
//            var item = await _db.items.FindAsync(id);
//            if (item == null)
//            {
//                return NotFound("This Item Does Not Exist");
//            }
//             _db.Remove(item);
//            await _db.SaveChangesAsync();
//            return Ok("Item Deleted Successfully");
//        }
//    }
//}
