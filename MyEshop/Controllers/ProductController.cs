using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace MyEshop.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        MyEshop_DBEntities db = new MyEshop_DBEntities();
        public ActionResult ShowGroups()
        {
            return PartialView(db.Product_Groups.ToList());
        }


        public ActionResult LastProduct()
        {
            return PartialView(db.Products.OrderByDescending(p=> p.CreateDate).Take(12));
        }

        [Route("ShowProduct/{id}")]
        public ActionResult ShowProduct(int id)
        {
            var product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
    }
}