using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using Newtonsoft.Json;
using System.Web.Mvc;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using MLMBiowillBusinessEntities;
using MLMBioWill.Models;
using System.Configuration;
using MLMBiowillBusinesslogic.Master;
using MLMBiowillBusinessEntities.Common;
using MLMBiowillHelper.Logging;
using MLMBiowillHelper.Authorization;
using MLMBioWill.Common;

namespace MLMBioWill.Controllers.Master
{
    //[SessionExpired]
    public class CompanyController : BaseController
    {
        CompanyManager _CompManager;

        public CompanyController()
        {
            _CompManager = new CompanyManager();
        }

        //[AuthorizeUser(RoleModule.Company, Function.View)]
        public ActionResult Index(CompanyViewModel cViewModel)
        {

            if (TempData["cViewModel"] != null)
            {
                cViewModel = (CompanyViewModel)TempData["cViewModel"];
            }
            Set_Date_Session(cViewModel.Company);
          
            return View("Index", cViewModel);
        }

        //company/Search
        [HttpGet]
        //[AuthorizeUser(RoleModule.Company, Function.View)]
        public ActionResult Search()
        {                                       
            return View();
        }

        /// <summary>
        ///  we need to fetch the data of user from DB at the time of Logging
        ///  and uncomment the Authorized user details 
        /// </summary>
        //[AuthorizeUser(RoleModule.Company, Function.View)]
        public JsonResult GetCompanyMaster(CompanyViewModel cViewModel)
        {
            PaginationInfo pager = new PaginationInfo();

            pager = cViewModel.Pager;

            PaginationViewModel pViewModel = new PaginationViewModel();

            try
            {
                pViewModel.dt = _CompManager.GetCompanyMaster(cViewModel.Filter.CompanyId, ref pager);

                pViewModel.Pager = pager;

                Logger.Debug("Company Controller GetCompanyMaster");
            }

            catch (Exception ex)
            {
                cViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Company Controller - GetCompanyMaster" + ex.ToString());
            }

            return Json(JsonConvert.SerializeObject(pViewModel), JsonRequestBehavior.AllowGet);

        }



    }
}


#region Web API Clling Functionality commented now
//Site Ref for Calling WEB API: 
//http://www.dotnetcurry.com/aspnet/1192/aspnet-web-api-async-calls-mvc-wpf;
//https://www.codeproject.com/Articles/1157685/ASP-NET-Web-API-Keeping-It-Simple

//HttpClient Client;

//string url = "http://localhost:52074/api/CompanyAPI";
//string url = ConfigurationManager.AppSettings["WebAPiUrl"].ToString();
//public CompanyController()
//{
//    //url += "/CompanyAPI";
//    //Client = new HttpClient();
//    //Client.BaseAddress = new Uri(url);
//    //Client.DefaultRequestHeaders.Accept.Clear();
//    //Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

//}

//[HttpGet]
//public async Task<JsonResult> CompanySearch(CompanyViewModel cCompanyViewModel)
//{
//    HttpResponseMessage responseMessage = await Client.GetAsync(url);
//    var responseData = String.Empty;
//    if (responseMessage.IsSuccessStatusCode)
//    {
//        responseData = responseMessage.Content.ReadAsStringAsync().Result;

//        cCompanyViewModel.Companylist = JsonConvert.DeserializeObject<List<CompanyInfo>>(responseData);

//        //return View("Search", cCompanyViewModel);
//        return Json(responseData, JsonRequestBehavior.AllowGet);
//    }
//    return Json(responseData,JsonRequestBehavior.AllowGet);
//}

// GET: Company/Details/5
//public async Task<ActionResult> Details(int id)
//{
//    if (id > 0)
//    {
//        HttpResponseMessage responseMessage = await Client.GetAsync(url + "/" + id);
//        if (responseMessage.IsSuccessStatusCode)
//        {
//            var responseData = responseMessage.Content.ReadAsStringAsync().Result;

//            var Company = JsonConvert.DeserializeObject<CompanyInfo>(responseData);

//            return View(Company);
//        }
//    }
//    return View("Error");
//}

#endregion
