using CapstoneAPI.Models;

namespace CapstoneAPI.Controllers
{
    public interface IAuthenticate
    {
        string Login(string email, string password);
        bool NewRegister(Register r);
        bool ChangePassword(string email, string oldpwd, string newpwd);
        string GetSecurityQuestion(string EmailId);
        bool ForgotPassword(string EmailId, string Answer, string NewPassword);
        Register ShowUserInfo(string EmailId);
        bool UpdateUserDetails(string EmailId, Register r);
    }
}
