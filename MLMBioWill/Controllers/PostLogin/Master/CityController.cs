using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using MLMBioWill.Common;
using MLMBiowillBusinesslogic.Master;
using MLMBiowillHelper.Authorization;
using MLMBiowillBusinessEntities.Common;
using MLMBioWill.Models.Master;
using MLMBioWill.Models;
using MLMBiowillHelper.Logging;
using MLMBiowillBusinessEntities.State;

namespace MLMBioWill.Controllers.Master
{

    //[SessionExpired]
    public class CityController : BaseController
    {
        public CityManager _cManager;

        public CityController()
        {
            _cManager = new CityManager();
        }

        //[AuthorizeUser(RoleModule.City, Function.View)]
        public ActionResult Index(CityViewModel cViewModel)
        {

            Set_Date_Session(cViewModel.City);

            cViewModel.Countries = _cManager.Drp_GetCountries();

            cViewModel.States = _cManager.Drp_Getstates();

            return View("Index", cViewModel);
        }

        //[AuthorizeUser(RoleModule.City, Function.View)]
        public ActionResult Search()
        {
            return View();
        }

        //[AuthorizeUser(RoleModule.City, Function.Create)]
        public JsonResult Insert(CityViewModel cViewModel)

        {
            try
            {
                Set_Date_Session(cViewModel.City);

                cViewModel.City.CityId = _cManager.Insert_CityMaster(cViewModel.City);

                cViewModel.FriendlyMessage.Add(MessageStore.Get("CITY01"));

                Logger.Debug("City Controller Insert");

            }
            catch (Exception ex)
            {

                cViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("City Controller - Insert " + ex.Message);
            }

            return Json(cViewModel);
        }

        //[AuthorizeUser(RoleModule.City, Function.View)]
        public JsonResult GetCities(CityViewModel cViewModel)
        {

            PaginationInfo pager = new PaginationInfo();

            pager = cViewModel.Pager;

            PaginationViewModel pViewModel = new PaginationViewModel();

            try
            {
                pViewModel.dt = _cManager.Get_CityMaster(cViewModel.City.CountryId, cViewModel.City.StateId, cViewModel.City.CityCode, cViewModel.City.CityName, ref pager);

                pViewModel.Pager = pager;

                Logger.Debug("City Controller GetCities");

            }

            catch (Exception ex)
            {
                cViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("City Controller - GetCities" + ex.ToString());
            }

            return Json(JsonConvert.SerializeObject(pViewModel), JsonRequestBehavior.AllowGet);

        }

        //[AuthorizeUser(RoleModule.City, Function.Edit)]
        public JsonResult Update(CityViewModel cViewModel)
        {
            try
            {
                Set_Date_Session(cViewModel.City);

                _cManager.Update_CityMaster(cViewModel.City);

                cViewModel.FriendlyMessage.Add(MessageStore.Get("CITY02"));

                Logger.Debug("City Controller Update");

            }
            catch (Exception ex)
            {
                cViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("City Controller - Update  " + ex.Message);
            }

            return Json(cViewModel);
        }

        //[AuthorizeUser(RoleModule.City, Function.View)]
        public JsonResult CheckCityCodeExist(string citycode)

        {
            bool check = false;

            CityViewModel cViewModel = new CityViewModel();

            try
            {
                check = _cManager.CheckCityCodeExist(citycode);

                Logger.Debug("City Controller CheckCityCodeExist");
            }
            catch (Exception ex)
            {
                Logger.Error("City Controller - CheckCityCodeExist" + ex.Message);
            }

            return Json(check, JsonRequestBehavior.AllowGet);
        }

        //[AuthorizeUser(RoleModule.City, Function.View)]
        public JsonResult CheckCityNameExist(string cityname)
        {
            bool check = false;

            CityViewModel cViewModel = new CityViewModel();

            try
            {
                check = _cManager.CheckCityNameExist(cityname);

                Logger.Debug("City Controller CheckCityNameExist");
            }
            catch (Exception ex)
            {
                Logger.Error("City Controller - CheckCityNameExist" + ex.Message);
            }

            return Json(check, JsonRequestBehavior.AllowGet);

        }

        //[AuthorizeUser(RoleModule.City, Function.View)]
        public JsonResult GetStatesByCountryId(int countryId)
        {
            List<StateInfo> states = new List<StateInfo>();
            try
            {
                states = _cManager.Get_States_By_Country_Id(countryId);

                Logger.Debug("City Controller GetStateByCountryId");
            }
            catch (Exception ex)
            {
                Logger.Error("City Controller-GetStateByCountryId " + ex.ToString());
            }

            return Json(states, JsonRequestBehavior.AllowGet);
        }

    }
}
