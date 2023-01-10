using CapstoneAPI.Models;
using System.Security.Cryptography;

namespace CapstoneAPI.Controllers
{
    public class AuthenticateImpl : IAuthenticate
    {
        readonly CapstoneAPIDbContext db;
        public AuthenticateImpl(CapstoneAPIDbContext db)
        {
            this.db = db;
        }

        public bool ChangePassword(string email, string oldpwd, string newpwd)
        {
            try
            {
                var olddata = db.Register.Where(x => x.EmailId == email && x.Password ==
                oldpwd).FirstOrDefault();
                if (olddata == null)
                {
                    throw new Exception("Invalid Email or Password");
                }
                else
                {
                    olddata.Password = newpwd;
                    var res = db.SaveChanges();
                    if (res > 0)
                        return true;
                }

            }
            catch
            {
                return false;
            }
            return false;

        }
        public string Login(string email, string password)
        {
            try
            {
                var olddata = db.Register.Where(x => x.EmailId == email && x.Password == password).FirstOrDefault();
                if (olddata == null)
                {
                    string abc = "";
                    return abc;
                }
                else
                {
                    return olddata.UserType;
                }
            }
            catch
            {
                return "";
            }
        }
        public bool NewRegister(Register r)
        {
            try
            {
                if(r.UserType=="Customer")
                {
                    r.Company = "";
                    r.WebsiteUrl = "";
                }
                db.Register.Add(r);
                var res = db.SaveChanges();
                if (res > 0)
                    return true;
            }
            catch
            {
                return false;
            }
            return false;
        }

        public string GetSecurityQuestion(string EmailId)
        {
            try
            {
                var olddata = db.Register.Where(x => x.EmailId == EmailId).FirstOrDefault();
                if (olddata == null)
                {
                    return "";
                }
                else
                {
                    return olddata.SecurityQuestion;
                }
            }
            catch
            {
                return "";
            }
            return "";
        }
        public bool ForgotPassword(string EmailId, string Answer, string NewPassword)
        {
            try
            {
                var olddata = db.Register.Where(x => x.EmailId == EmailId && x.SecurityAnswer == Answer).FirstOrDefault();
                if (olddata == null)
                {
                    return false;
                }
                else
                {
                    olddata.Password = NewPassword;
                    var res = db.SaveChanges();
                    if (res > 0)
                    {
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
            return false;
        }

        public Register ShowUserInfo(string EmailId)
        {
            return db.Register.Where(x => x.EmailId == EmailId).FirstOrDefault();
        }

        public bool UpdateUserDetails(string EmailId, Register r)
        {
            try
            {
                var oldData = db.Register.Where(x => x.EmailId == EmailId).FirstOrDefault();
                if (oldData == null)
                {
                    return false;
                }
                oldData.Name= r.Name;
                oldData.Country = r.Country;
                oldData.MobNo = r.MobNo;
                oldData.SecurityQuestion = r.SecurityQuestion;
                oldData.SecurityAnswer = r.SecurityAnswer;

                var res = db.SaveChanges();
                if (res > 0)
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
            return false;
        }
    }
}
