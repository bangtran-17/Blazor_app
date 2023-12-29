using Hotel.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly UserManager<IdentityUser> _userManager;

        public AccountController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var newUser = new IdentityUser { UserName = model.UserName, Email = model.Email };
                
            var result = await _userManager.CreateAsync(newUser, model.Password!);
            //await _userManager.AddToRoleAsync(newUser, "employee");
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(x => x.Description);

                return Ok(new RegisterResult { Successful = false, Errors = errors });

            }

            return Ok(new RegisterResult { Successful = true });
        }

        [HttpPost("employee")]
        public async Task<IActionResult> RegisterEmployee([FromBody] RegisterModel model)
        {
            var newUser = new IdentityUser { UserName = model.UserName, Email = model.Email };

            var result = await _userManager.CreateAsync(newUser, model.Password!);
            await _userManager.AddToRoleAsync(newUser, "employee");
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(x => x.Description);

                return Ok(new RegisterResult { Successful = false, Errors = errors });

            }

            return Ok(new RegisterResult { Successful = true });
        }
    }
}