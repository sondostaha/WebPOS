using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebPOS.Data;
using WebPOS.DTO;
using WebPOS.Models;

namespace WebPOS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserContoller : ControllerBase
    {
        private readonly UserManager<Users> _userManager;
        private readonly IConfiguration _configuration;
        private readonly AppDbContext _db;
        public UserContoller(UserManager<Users> userManager, IConfiguration configuration, AppDbContext db)
        {
            _userManager = userManager;
            _configuration = configuration;
            _db = db;

        }
        [HttpPost]
        public async Task<IActionResult> Registration([FromForm] UserDto userDto)
        {
            if (ModelState.IsValid)
            {
                var Branch = await _db.Branches.FindAsync(userDto.AssocBranch);
                if (Branch == null)
                    return NotFound("This Branch Does Not Exist");
                    var user = new Users()
                    {
                        UserName = userDto.UserName,
                        Email = userDto.Email,
                        PhoneNumber = userDto.PhoneNumber,
                        Type = (Models.Type)userDto.Type,
                        AssocBranch = Branch.Id,
                        Permissions = userDto.Permissions,
                        GuId = userDto.GuId,
                        CId = userDto.CId,
                        Status = userDto.Status,
                        Domain = userDto.Domain,

                    };
                var result = await _userManager.CreateAsync(user, userDto.Password);
                if (result.Succeeded)
                {
                    return Ok($"Welcome {user.UserName}");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }

                }
            }
            return BadRequest(ModelState);
        }
        [HttpPost("Login")]
        public async Task<IActionResult> UserLogin(UserDtoLogin userDtoLogin)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(userDtoLogin.Email);
                if (user != null)
                {
                    if (await _userManager.CheckPasswordAsync(user, userDtoLogin.Password))
                    {
                        var claims = new List<Claim>();
                        claims.Add(new Claim(ClaimTypes.Email, user.Email));
                        claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
                        claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
                        var roles = await _userManager.GetRolesAsync(user);
                        foreach (var role in roles)
                        {
                            claims.Add(new Claim(ClaimTypes.Role, role.ToString()));
                        }
                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"]));
                        var sc = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                        var token = new JwtSecurityToken
                            (
                            claims: claims,
                            issuer: _configuration["JWT:Issuer"],
                            audience: _configuration["JWT:Audience"],
                            expires: DateTime.Now.AddHours(2),
                            signingCredentials: sc
                            );
                        var _token = new
                        {
                            token = new JwtSecurityTokenHandler().WriteToken(token),
                            expiration = token.ValidTo
                        };
                        return Ok(_token);
                    }
                    return Unauthorized("The Credintials is Not Correct please Try Again Or SignUp");
                }
            }
            return BadRequest(ModelState);
        }
    }
}
