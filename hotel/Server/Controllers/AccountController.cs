
using Azure;
using Hotel.Server.Data;
using Hotel.Server.Services.Email;
using Hotel.Shared.CommonFiles;
using Hotel.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Blazored.LocalStorage;
using Microsoft.EntityFrameworkCore;
using Blazored;
using Blazored.Modal;
using Blazored.Modal.Services;

namespace Hotel.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly MyDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IEmailService _emailService;
        private readonly ILocalStorageService _localStorageService;
        public AccountController(UserManager<IdentityUser> userManager,MyDbContext context,IEmailService emailService,ILocalStorageService localStorage)
        {
            _userManager = userManager;
            _context = context;
            _emailService = emailService;
            _localStorageService = localStorage;
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
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(newUser);
            var confirmationLink = Url.Action(nameof(ConfirmEmail), "Account", new { token, email = newUser.Email }, HttpContext.Request.Scheme);

            var emailDto = new EmailDto { To = newUser.Email, Subject="Confirmation Email link", Body="<a>"+confirmationLink!+"</a>" };
            _emailService.SendEmail(emailDto);


            return Ok(new RegisterResult { Successful = true });
        }


        [HttpGet("ConfirmEmail")]
        public async Task<IActionResult> ConfirmEmail(string token,string email)
        {
            var user=await _userManager.FindByEmailAsync(email);
            if (user != null)
            {
                var result = await _userManager.ConfirmEmailAsync(user, token);
                if (result.Succeeded)
                {
                    return StatusCode(StatusCodes.Status200OK);;
                }
            }
            return StatusCode(StatusCodes.Status500InternalServerError);
        }


     


        [HttpGet("forgot-password/{email}")]
        public async Task<string> ForgotPassword(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
            {
                return "User not found.";
            }
            var task = await _userManager.GeneratePasswordResetTokenAsync(user);
            var confirmationLink = Url.Action(nameof(ConfirmReset), "Account", new {token=task,email }, HttpContext.Request.Scheme);

            var emailDto = new EmailDto { To = email, Subject = "Confirmation Email link", Body = "<a>" + confirmationLink! + "</a>" };
            _emailService.SendEmail(emailDto);
            return task;

        }

   [HttpGet("ConfirmReset")]
        public async Task<IActionResult> ConfirmReset(string token, string email)
        {

            var user = await _userManager.FindByEmailAsync(email);
            if (user != null)
            {
                
                   
                  return  Redirect("/changePassword");
                  
                
            }
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpPost("reset-password/{email}")]
        public async Task<IActionResult> ResetPassword(string email,ResetPasswordRequest request)
        {

            var userTask = _userManager.FindByEmailAsync(email);
            var task = _userManager.ResetPasswordAsync(userTask.Result, request.Token, request.Password);
            await _context.SaveChangesAsync();
            return Ok("Password successfully reset.");
        }
		[HttpPost("reset-password1/{email}")]
		public async Task<IActionResult> ResetPasswordDefault(string email, ResetPasswordRequest request)
		{

			var userTask = _userManager.FindByEmailAsync(email);
            var user = await _userManager.FindByEmailAsync(email);
			var task1 = await _userManager.GeneratePasswordResetTokenAsync(user);
			var task = _userManager.ResetPasswordAsync(userTask.Result, task1, request.Password);
			await _context.SaveChangesAsync();
			return Ok("Password successfully reset.");
		}
		//public void HardResetPassword(string email, string newPassword)
		//{
		//    var userTask = _userManager.FindByEmailAsync(email);
		//    userTask.Wait();
		//    var user = userTask.Result;
		//    ChangeUserPassword(user, newPassword);
		//}

		//private string GeneratePasswordResetToken(IdentityUser user)
		//{
		//    var task = _userManager.GeneratePasswordResetTokenAsync(user);
		//    task.Wait();
		//    var token = task.Result;
		//    return token;
		//}

		//private void ChangeUserPassword(IdentityUser user, string newPassword)
		//{
		//    var token = GeneratePasswordResetToken(user);
		//    var task = _userManager.ResetPasswordAsync(user, token, newPassword);
		//    task.Wait();
		//    var result = task.Result;
		//}
	}
}