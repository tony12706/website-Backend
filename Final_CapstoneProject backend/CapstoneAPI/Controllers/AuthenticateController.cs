using CapstoneAPI.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CapstoneAPI.Controllers
{
    [Route("api/Authenticate")]
    [ApiController]
    [EnableCors(PolicyName = "CapstoneProject")]
    public class AuthenticateController : ControllerBase
    {
        readonly CapstoneAPIDbContext db;
        readonly IAuthenticate auth;

        public AuthenticateController(CapstoneAPIDbContext db, IAuthenticate auth)
        {
            this.db = db;
            this.auth = auth;
        }

        [HttpPut]
        [Route("/api/Authenticate/UpdatePwd/{email}/{oldp}/{newp}")]
        public bool ChangePassword(string email, string oldp, string newp)
        {
            oldp = EncodePasswordToBase64(oldp);
            newp = EncodePasswordToBase64(newp);
            return auth.ChangePassword(email, oldp, newp);
        }

        [HttpGet]
        [Route("/api/Authenticate/Login/{email}/{pwd}")]
        public string Login(string email, string pwd)
        {
            pwd = EncodePasswordToBase64(pwd);
            return auth.Login(email, pwd);
        }

        [HttpPost]
        [Route("/api/Authenticate/NewRegister")]
        public bool NewRegister([FromBody] Register r)
        {
            r.Password = EncodePasswordToBase64(r.Password);
            return auth.NewRegister(r);
        }

        [HttpGet]
        [Route("/api/Authenticate/GetSecurityQuestion/{email}")]
        public string GetSecurityQuestion(string email)
        {
            return auth.GetSecurityQuestion(email);
        }

        [HttpPut]
        [Route("/api/Authenticate/ForgotPwd/{email}/{answer}/{newp}")]
        public bool Forgotpassword(string email, string answer, string newp)
        {
            newp= EncodePasswordToBase64(newp);
            return auth.ForgotPassword(email, answer, newp);
        }

        [HttpGet]
        [Route("/api/Authenticate/ShowUserInfo/{email}")]
        public Register ShowUserInfo(string email)
        {
            return auth.ShowUserInfo(email);
        }

        [HttpPut]
        [Route("/api/Authenticate/UpdateUserDetails/{email}")]
        public bool UpdateUserDetails(string email, [FromBody] Register r)
        {
            return auth.UpdateUserDetails(email, r);
        }

        public string EncodePasswordToBase64(string password)
        {
            try
            {
                byte[] encData_byte = new byte[password.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(password);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        }

    }

}
