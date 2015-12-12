using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using mvc4gw9.Models;

namespace mvc4gw9.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("ShowGroup");
        }

        public ActionResult ShowGroup(int GroupId = 1)
        {
            Navigation navigation = new Navigation();
            //navigation.Branches = DAL.GetGroup(GroupId);
            navigation.Path = DAL.GetPath(GroupId);
            navigation.Branches = DAL.GetBranches(GroupId);
            if (DAL.HasSubgroup(GroupId))
            {
                return View(navigation);
            }
            else
            {
                return RedirectToAction("ShowProducts", new { GroupId = GroupId });
            }
        }

        public ActionResult ShowProducts(int GroupId)
        {
            ViewBag.Path = DAL.GetPath(GroupId);
            ViewBag.Branches = DAL.GetBranches(GroupId);
            return View(DAL.GetProducts(GroupId));
        }

        public ActionResult ShowProduct(int nomenclatureId, string featuresSetId)
        {
            Product product = new Product();
            product = DAL.GetProduct(nomenclatureId, Convert.ToInt32(featuresSetId));
            return View(product);
        }

        
        public ActionResult product_changeImage(string filename)
        {
            return PartialView("product_changeImage", filename);
        }


        public PartialViewResult product_changeParameter(int nomenclatureId, string parameter, string value, string currentParameters)
        {
            Product product= new Product();

            product = DAL.GetProduct(nomenclatureId, DAL.GetNewFeaturesSetId(nomenclatureId, parameter, value, currentParameters));

            return PartialView("product_changeParameter", product);
        }

    }
}
