using MVC.Global;
using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class StoreController : Controller
    {
        // GET: Store
        public ActionResult Index()
        {
            IEnumerable<StoreModel> storeList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Store").Result;
            storeList = response.Content.ReadAsAsync< IEnumerable<StoreModel >>().Result;
            return View(storeList);
        }
    }
}