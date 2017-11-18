using System;
using System.Web.Mvc;
using Newtonsoft.Json;
using MLMBioWill.Common;
using MLMBiowillBusinessEntities.Common;
using MLMBiowillBusinesslogic.Master;
using MLMBiowillHelper.Authorization;
using MLMBioWill.Models.Master;
using MLMBiowillHelper.Logging;
using MLMBioWill.Models;

namespace MLMBioWill.Controllers.Master
{
    //[SessionExpired]
    public class CountryController : BaseController
    {
        public CountryManager _CountryManager;

        public CountryController()
        {
            _CountryManager = new CountryManager();
        }

        //[AuthorizeUser(RoleModule.Country, Function.View)]
        public ActionResult Index(CountryViewModel cViewModel)
        {
            return View("Index", cViewModel);
        }

        //[AuthorizeUser(RoleModule.Country, Function.View)]
        public ActionResult Search()
        {
            return View();
        }

        //[AuthorizeUser(RoleModule.Country, Function.Create)]
        public JsonResult Insert(CountryViewModel cViewModel)
        {
            try
            {
                Set_Date_Session(cViewModel.Country);

                cViewModel.Country.CountryId = _CountryManager.Insert_Country(cViewModel.Country);

                cViewModel.FriendlyMessage.Add(MessageStore.Get("Country01"));

                Logger.Debug("Country Controller Insert");

            }
            catch (Exception ex)
            {
                cViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Country Controller - Insert " + ex.Message);
            }

            return Json(cViewModel);
        }

        //[AuthorizeUser(RoleModule.Country, Function.View)]
        public JsonResult GetCountries(CountryViewModel cViewModel)
        {
            PaginationInfo pager = new PaginationInfo();

            pager = cViewModel.Pager;

            PaginationViewModel pViewModel = new PaginationViewModel();

            try
            {
                pViewModel.dt = _CountryManager.GetCountries(cViewModel.Country.CountryCode, cViewModel.Country.CountryName, ref pager);

                pViewModel.Pager = pager;

                Logger.Debug("Country Controller GetCountries");
            }

            catch (Exception ex)
            {
                cViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Country Controller - GetCountries" + ex.ToString());
            }

            return Json(JsonConvert.SerializeObject(pViewModel), JsonRequestBehavior.AllowGet);

        }

        //[AuthorizeUser(RoleModule.Country, Function.Edit)]
        public JsonResult Update(CountryViewModel cViewModel)
        {
            try
            {
                Set_Date_Session(cViewModel.Country);

                _CountryManager.Update_Country(cViewModel.Country);

                cViewModel.FriendlyMessage.Add(MessageStore.Get("Country02"));

                Logger.Debug("Country Controller Update");
            }
            catch (Exception ex)
            {
                cViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Country Controller - Update  " + ex.Message);
            }

            return Json(cViewModel);
        }

        //[AuthorizeUser(RoleModule.Country, Function.View)]
        public JsonResult CheckCountryCodeExist(string countryCode)
        {
            bool check = false;

            CountryViewModel cViewModel = new CountryViewModel();

            try
            {
                check = _CountryManager.CheckCountryCodeExist(countryCode);

                Logger.Debug("Country Controller CheckCountryCodeExist");
            }
            catch (Exception ex)
            {
                Logger.Error("Country Controller - CheckCountryCodeExist" + ex.Message);
            }

            return Json(check, JsonRequestBehavior.AllowGet);
        }

        //[AuthorizeUser(RoleModule.Country, Function.View)]
        public JsonResult CheckCountryNameExist(string countryName)
        {
            bool check = false;

            CountryViewModel cViewModel = new CountryViewModel();

            try
            {
                check = _CountryManager.CheckCountryNameExist(countryName);

                Logger.Debug("Country Controller CheckCountryNameExist");
            }
            catch (Exception ex)
            {
                Logger.Error("Country Controller - CheckCountryNameExist" + ex.Message);
            }

            return Json(check, JsonRequestBehavior.AllowGet);

        }

    }
}





















