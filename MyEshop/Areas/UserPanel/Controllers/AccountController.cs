using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;
using DataLayer.ViewModels;
using System.Web.Security;

namespace MyEshop.Areas.UserPanel.Controllers
{
    public class AccountController : Controller
    {
        MyComputerEshop_DBEntities db = new MyComputerEshop_DBEntities();
        // GET: UserPanel/Account
        public ActionResult ChanagePassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ChanagePassword(ChanagePasswordViewModel change)
        {
            if (ModelState.IsValid)
            {
                var user = db.Users.Single(u => u.UserName == User.Identity.Name);
                string oldPasswordHash =
                    FormsAuthentication.HashPasswordForStoringInConfigFile(change.OldPassword, "MD5");
                if (user.Password == oldPasswordHash)
                {
                    string hashNewPasword =
                        FormsAuthentication.HashPasswordForStoringInConfigFile(change.Password, "MD5");
                    user.Password = hashNewPasword;
                    db.SaveChanges();
                    ViewBag.Success = true;
                }
                else
                {
                    ModelState.AddModelError("OldPassword", "کلمه عبور فعلی درست نمی باشد");
                }
            }

            return View();
        }
    }
}