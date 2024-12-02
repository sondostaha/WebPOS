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
    public class AreaController : ControllerBase
    {
        private readonly AppDbContext _db;
        public AreaController(AppDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public async Task<IActionResult> GetAreas()
        {
            var areas = await _db.areas.Select(x => new
            {
                Name = x.AreaName,
                Cost = x.Cost,
                Branch = x.Branches,
                CreatedAt = x.CreatedAt,
                UpdatedAt = x.UpdatedAt,
            }).ToListAsync();
            if (areas.Any())
                return Ok(areas);
            return Ok("There Is No Available Areas");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetArea(int id)
        {
            var area = await _db.areas.Where(x => x.Id == id).Select(x => new
            {
                Name = x.AreaName,
                Cost = x.Cost,
                Branch = x.Branches,
                CreatedAt = x.CreatedAt,
                UpdatedAt = x.UpdatedAt,
            }).FirstAsync();
            if (area == null)
                return NotFound("This Area Does Not Exist");
            return Ok(area);
        }
        [HttpPost]
        public async Task<IActionResult> AddArea(AreaDto areaDto)
        {
            var branch = await _db.Branches.FindAsync(areaDto.BranchId);
            if (branch == null)
                return NotFound("This Branch Does Not Exist");
            var area = new Areas()
            {
                AreaName = areaDto.AreaName,
                Cost = areaDto.Cost,
                BranchId = branch.Id,
                CreatedAt = DateTime.Now,
            };
            await _db.areas.AddAsync(area);
            await _db.SaveChangesAsync();
            return Ok("Area Saved Successfully");
        }
        [HttpPost("{id}")]
        public async Task<IActionResult> UpdateArea([FromForm] AreaDto areaDto, int id)
        {
            var area = await _db.areas.FindAsync(id);
            if (area == null)
                return NotFound("This Area Does Not Exist");
            var branch = await _db.Branches.FindAsync(areaDto.BranchId);
            if (branch == null)
                return NotFound("This Branch Does Not Exist");
            area.AreaName = areaDto.AreaName ?? area.AreaName;
            area.Cost = areaDto.Cost ?? area.Cost;
            area.BranchId = branch.Id;
            area.UpdatedAt = DateTime.Now;
            await _db.SaveChangesAsync();
            return Ok("Area Updated Successfully");
        }
        [HttpPost("[action]/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var area = await _db.areas.FindAsync(id);
            if (area == null)
                return NotFound("This Area Does Not Exist");
            _db.Remove(area);
            await _db.SaveChangesAsync();
            return Ok("Area Deleted Successfully");
        }
    }
}
