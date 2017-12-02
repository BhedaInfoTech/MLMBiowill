using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using MLMBioWill.Controllers;
using MLMBiowillBusinesslogic.Master;
using MLMBiowillHelper.Authorization;
using MLMBioWill.Models.Master;
using MLMBiowillBusinessEntities.Common;
using MLMBioWill.Models;
using MLMBiowillHelper.Logging;
using MLMBioWill.Common;
using System.Transactions;

namespace Lohana.Controllers.PostLogin.Master
{
    //[SessionExpired]
    public class StateController : BaseController
    {
        public StateManager _stManager;

        public StateController()
        {
            _stManager = new StateManager();
        }

        //[AuthorizeUser(RoleModule.State, Function.View)]
        public ActionResult Index(StateViewModel sViewModel)
        {

            Set_Date_Session(sViewModel.State);

            sViewModel.Countries = _stManager.Drp_GetCountries();

            return View("Index", sViewModel);
        }

        //[AuthorizeUser(RoleModule.State, Function.View)]
        public ActionResult Search()
        {
            return View();
        }

        //[AuthorizeUser(RoleModule.State, Function.Create)]
        public JsonResult Insert(StateViewModel sViewModel)
        {
            Set_Date_Session(sViewModel.State);
            using (TransactionScope tran = new TransactionScope())
            {
                try
                {
                    sViewModel.State.StateId = _stManager.Insert_StateMaster(sViewModel.State);

                    sViewModel.FriendlyMessage.Add(MessageStore.Get("STATE01"));

                    tran.Complete();

                    Logger.Debug("State Controller Insert");

                }
                catch (Exception ex)
                {
                    tran.Dispose();

                    sViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                    Logger.Error("State Controller - Insert " + ex.Message);
                }
            }
            return Json(sViewModel);
        }

        //[AuthorizeUser(RoleModule.State, Function.View)]
        public JsonResult GetStates(StateViewModel sViewModel)
        {
            PaginationInfo pager = new PaginationInfo();

            pager = sViewModel.Pager;

            PaginationViewModel pViewModel = new PaginationViewModel();

            try
            {

                pViewModel.dt = _stManager.Get_StateMaster(sViewModel.State.CountryId, sViewModel.State.StateCode, sViewModel.State.StateName, ref pager);

                pViewModel.Pager = pager;

                Logger.Debug("State Controller GetStates");
            }

            catch (Exception ex)
            {

                sViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("State Controller - GetStates" + ex.ToString());
            }

            return Json(JsonConvert.SerializeObject(pViewModel), JsonRequestBehavior.AllowGet);

        }

        //[AuthorizeUser(RoleModule.State, Function.Edit)]
        public JsonResult Update(StateViewModel sViewModel)
        {
            Set_Date_Session(sViewModel.State);
            using (TransactionScope tran = new TransactionScope())
            {

                try
                {
                    _stManager.Update_StateMaster(sViewModel.State);

                    sViewModel.FriendlyMessage.Add(MessageStore.Get("STATE02"));

                    tran.Complete();

                    Logger.Debug("State Controller Update");

                }
                catch (Exception ex)
                {
                    tran.Dispose();

                    sViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                    Logger.Error("State Controller - Update  " + ex.Message);
                }
            }
            return Json(sViewModel);
        }

        //[AuthorizeUser(RoleModule.State, Function.View)]
        public JsonResult CheckStateCodeExist(string stateCode)

        {
            bool check = false;

            StateViewModel sViewModel = new StateViewModel();

            try
            {
                check = _stManager.CheckStateCodeExist(stateCode);

                Logger.Debug("State Controller CheckStateCodeExist");
            }
            catch (Exception ex)
            {
                Logger.Error("State Controller - CheckStateCodeExist" + ex.Message);
            }

            return Json(check, JsonRequestBehavior.AllowGet);
        }

        //[AuthorizeUser(RoleModule.State, Function.View)]
        public JsonResult CheckStateNameExist(string stateName)
        {
            bool check = false;

            StateViewModel sViewModel = new StateViewModel();

            try
            {
                check = _stManager.CheckStateNameExist(stateName);

                Logger.Debug("State Controller CheckStateNameExist");
            }
            catch (Exception ex)
            {
                Logger.Error("State Controller - CheckStateNameExist" + ex.Message);
            }

            return Json(check, JsonRequestBehavior.AllowGet);

        }


    }
}
