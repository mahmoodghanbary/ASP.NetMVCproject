using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;
using DataLayer.ViewModels;
using System.Web.Security;

namespace MyEshop.Controllers
{
    public class AccountController : Controller
    {
        MyComputerEshop_DBEntities db =new MyComputerEshop_DBEntities();
        // GET: Account
        [Route("Register")]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [Route("Register")]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel register)
        {
            if (ModelState.IsValid)
            {
                if (!db.Users.Any(u => u.Email == register.Email.Trim().ToLower()))
                {
                    Users user=new Users()
                    {
                        Email = register.Email.Trim().ToLower(),
                        Password = FormsAuthentication.HashPasswordForStoringInConfigFile(register.Password,"MD5"),
                        ActiveCode = Guid.NewGuid().ToString(),
                        IsActive = false,
                        RegisterDate = DateTime.Now,
                        RoleID = 1,
                        UserName = register.UserName
                    };
                    db.Users.Add(user);
                    db.SaveChanges();

                    //Send Active Email
                        //ToDo
                    //End Send Active Email
                    return View("SuccessRegister", user);
                }
                else
                {
                    ModelState.AddModelError("Email","ایمیل وارد شده تکراری است");
                }
            }

            return View(register);
        }
        public ActionResult Login()
        {
            return View();
        }
    }
}