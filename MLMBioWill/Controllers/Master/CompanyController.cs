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

namespace MLMBioWill.Controllers.Master
{
    public class CompanyController : Controller
    {

        //Site Ref for Calling WEB API: 
        //http://www.dotnetcurry.com/aspnet/1192/aspnet-web-api-async-calls-mvc-wpf;
        //https://www.codeproject.com/Articles/1157685/ASP-NET-Web-API-Keeping-It-Simple

        HttpClient Client;

        //string url = "http://localhost:52074/api/CompanyAPI";
        string url = ConfigurationManager.AppSettings["WebAPiUrl"].ToString();
        public CompanyController()
        {
            url += "/CompanyAPI";
            Client = new HttpClient();
            Client.BaseAddress = new Uri(url);
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }
        [HttpGet]
        public async Task<ActionResult> Index(CompanyViewModel cCompanyViewModel)
        {
            HttpResponseMessage responseMessage = await Client.GetAsync(url);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                cCompanyViewModel.Companylist = JsonConvert.DeserializeObject<List<CompanyInfo>>(responseData);

                return View("Search",cCompanyViewModel);
            }
            return View("Error");
        }

        //// GET: Company
        //public ActionResult Index()
        //{
        //    return View();
        //}

        // GET: Company/Details/5
        public async Task<ActionResult> Details(int id)
        {
            HttpResponseMessage responseMessage = await Client.GetAsync(url + "/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                var Company = JsonConvert.DeserializeObject<CompanyInfo>(responseData);

                return View(Company);
            }
            return View("Error");
        }

        // GET: Company/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Company/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Company/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Company/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Company/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Company/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
