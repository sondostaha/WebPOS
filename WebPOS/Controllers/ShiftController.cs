using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebPOS.Data;
using WebPOS.DTO;
using WebPOS.Models;
using System.Security.Claims;
using WebPOS.Controllers;
using WebPOS.Migrations;
using Azure;

namespace WebPOS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ShiftController : ControllerBase
    {


        private readonly AppDbContext _db;
        private readonly UserManager<Users> _user;
        private readonly ISystemLogService _systemLogContoller;
        public ShiftController(AppDbContext db, UserManager<Users> usr, ISystemLogService systemLogContoller)
        {
            _db = db;
            _user = usr;
            _systemLogContoller = systemLogContoller;
        }
        [HttpPost]
        public async Task<IActionResult> OpenShift([FromForm] ShiftDto shiftDto)
        {
            //try
            //{
                var chechUser = await _user.FindByIdAsync(shiftDto.UserId);
                if (chechUser == null)
                    return NotFound("This User Does Not Exist");

                var user_id = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var user = await _db.users.FindAsync(user_id);
                string message = $"User {user_id.ToString()} tried to open shift for user {shiftDto.UserId} ";
                var systemLog = await _systemLogContoller.AddLog(message, user_id);
                if (systemLog == null)
                {
                    return BadRequest();
                }
                var checkShit = _db.shifts.Where(x => x.UserId == shiftDto.UserId).ToListAsync();
                if (checkShit != null && chechUser.Status.ToString() == Models.Status.Active.ToString())
                {
                   
                    string response = "user still have an active shift";
                    return NotFound(response);
                    
                }

                DateTime dateTime = DateTime.Now.ToLocalTime();
                string formattedTime = dateTime.ToString("tt");
                var shift = new Shifts()
                {
                    Shift = formattedTime,
                    UserId = shiftDto.UserId,
                    CreatorId = user_id,
                    Status = (Models.Status)shiftDto.Status,
                    Location = user.AssocBranch,
                };
                ; await _db.shifts.AddAsync(shift);
                await _db.SaveChangesAsync();

                return Ok($"Shift Opened Successfully{shift}");
            //}
            //catch (Exception ex)
            //{
            //    return BadRequest(ex.Message);
            //}

        }
    }

}

