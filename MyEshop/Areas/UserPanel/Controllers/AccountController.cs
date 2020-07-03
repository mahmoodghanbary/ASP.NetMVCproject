using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyEshop.Areas.UserPanel.Controllers
{
    public class AccountController : Controller
    {
        // GET: UserPanel/Account
        public ActionResult ChanagePassword()
        {
            return View();
        }
    }
}