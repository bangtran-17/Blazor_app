using Hotel.Shared.Models;

namespace Hotel.Client.Services
{
    public interface IAuthService
    {
        Task<RegisterResult> Register(RegisterModel registerModel);
        Task<LoginResult> Login(LoginModel loginModel);
        Task Logout();
        Task<string> ForgotPassword(string email);
        Task ResetPassword(ResetPasswordRequest request,string email);
		Task ResetPassword1(ResetPasswordRequest request, string email);
	}
}

