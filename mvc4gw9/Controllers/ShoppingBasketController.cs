using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using mvc4gw9.Models;

namespace mvc4gw9.Controllers
{
    public class ShoppingBasketController : Controller
    {

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Add(int nomenclatureId, string currentParameters)
        {
            ViewBag.Id = nomenclatureId;
            ViewBag.Parameters = currentParameters;
            ViewBag.FeaturesSet = DAL.GetFeaturesSetId(nomenclatureId, currentParameters);

            return View(DAL.GetProductInStores(nomenclatureId, ViewBag.FeaturesSet));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Add(int NomenclatureId, int FeaturesSet, int Amount)
        {
            int a = NomenclatureId;
            int b = FeaturesSet;
            int c = Amount;
            return RedirectToAction("Index", "Home");
        }

    }
}
