using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using WebPOS.Data;
using WebPOS.DTO;
using WebPOS.Models;

namespace WebPOS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BranchContoller : ControllerBase
    {
        private readonly AppDbContext _db;
        public BranchContoller(AppDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public async Task<IActionResult> GetBranches()
        {
            var branches = await _db.Branches.Select(x => new
            {
                Title = x.Title,
                Address = x.Address,
                HasSeats = x.HasSeats,

                DispatcherAcceptRequired = x.DispatcherAcceptRequired,
                BranchSettings = x.BranchSettings,
            }).ToListAsync();
            if (branches.Any())
                return Ok(branches);
            return Ok("There Is No Branches Added Yet");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBranch(int id)
        {
            var branch = await _db.Branches.Where(x => x.Id == id).Select(x => new
            {
                Title = x.Title,
                Address = x.Address,
                HasSeats = x.HasSeats,

                DispatcherAcceptRequired = x.DispatcherAcceptRequired,
                BranchSettings = x.BranchSettings,
            }).FirstAsync();
            if (branch == null)
                return NotFound("This Branch Does Not Exist");
            return Ok(branch);
        }
        [HttpPost]
        public async Task<IActionResult> AddBranch(BranchDto branchDto)
        {
            var branch = new Branches()
            {
                Title = branchDto.Title,
                Address = branchDto.Address,
                HasSeats = branchDto.HasSeats,

                DispatcherAcceptRequired = branchDto.DispatcherAcceptRequired,
                BranchSettings = branchDto.BranchSettings,
            };
            await _db.Branches.AddAsync(branch);
            await _db.SaveChangesAsync();
            return Ok("Branch Added Successfully");
        }
        [HttpPost("{id}")]
        public async Task<IActionResult> UpdateBranch(BranchDto branchDto, int id)
        {
            var branch = await _db.Branches.FindAsync(id);
            if (branch == null) return NotFound("This Branch Does Not Exist");
            branch.Title = branchDto.Title ?? branch.Title;
            branch.Address = branchDto.Address ?? branch.Address;
            branch.HasSeats = branchDto.HasSeats;

            branch.DispatcherAcceptRequired = branchDto.DispatcherAcceptRequired ?? branch.DispatcherAcceptRequired;
            branch.BranchSettings = branchDto.BranchSettings ?? branch.BranchSettings;
            await _db.SaveChangesAsync();
            return Ok("Branch Updated Sucessfully");
        }
        [HttpPost("[action]/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var branch = await _db.Branches.FindAsync(id);
            if (branch == null) return NotFound("This Branch Does Not Exist");
            _db.Remove(branch);
            await _db.SaveChangesAsync();
            return Ok("Branch Deleted Successfully");
        }
    }
}
