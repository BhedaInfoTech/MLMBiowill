using MLMBioWill.Common;
using MLMBioWill.Models;
using MLMBioWill.Models.Master;
using MLMBiowillBusinessEntities.Common;
using MLMBiowillBusinesslogic.Master;
using MLMBiowillHelper.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;

namespace MLMBioWill.Controllers.PostLogin.Master
{
    //[SessionExpired]
    public class DesignationController : BaseController
    {
        public DesignationManager _designationManager;

        public DesignationController()
        {
            _designationManager = new DesignationManager();
        }

        //[AuthorizeUser(RoleModule.Designation, Function.View)]
        public ActionResult Index(DesignationViewModel dViewModel)
        {
            return View("Index", dViewModel);
        }

        //[AuthorizeUser(RoleModule.Designation, Function.View)]
        public ActionResult Search()
        {
            return View();
        }

        //[AuthorizeUser(RoleModule.Designation, Function.Create)]
        public JsonResult Insert(DesignationViewModel dViewModel)
        {
            Set_Date_Session(dViewModel.DesignationInfo);
            using (TransactionScope tran = new TransactionScope())
            {
                try
                {

                    dViewModel.DesignationInfo.Id = _designationManager.Insert_Designation(dViewModel.DesignationInfo);

                    dViewModel.FriendlyMessage.Add(MessageStore.Get("DESIGNATION01"));

                    tran.Complete(); ;

                    Logger.Debug("Designation Controller Insert");

                }
                catch (Exception ex)
                {
                    tran.Dispose();
                    dViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                    Logger.Error("Designation Controller - Insert " + ex.Message);
                }

            }
            return Json(dViewModel);
        }

        //[AuthorizeUser(RoleModule.Designation, Function.View)]
        public JsonResult GetDesignation(DesignationViewModel dViewModel)
        {
            PaginationInfo pager = new PaginationInfo();

            pager = dViewModel.Pager;

            PaginationViewModel pViewModel = new PaginationViewModel();

            try
            {
                pViewModel.dt = _designationManager.GetDesignation(dViewModel.DesignationInfo.DesignationName, ref pager);

                pViewModel.Pager = pager;

                Logger.Debug("Designation Controller GetDesignation");
            }

            catch (Exception ex)
            {
                dViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Designation Controller - GetDesignation" + ex.ToString());
            }

            return Json(JsonConvert.SerializeObject(pViewModel), JsonRequestBehavior.AllowGet);

        }

        //[AuthorizeUser(RoleModule.Designation, Function.Edit)]
        public JsonResult Update(DesignationViewModel dViewModel)
        {
            Set_Date_Session(dViewModel.DesignationInfo);

            using (TransactionScope tran = new TransactionScope())
            {
                try
                {

                    _designationManager.Update_Designation(dViewModel.DesignationInfo);

                    dViewModel.FriendlyMessage.Add(MessageStore.Get("DESIGNATION02"));

                    tran.Complete();

                    Logger.Debug("Designation Controller Update");
                }
                catch (Exception ex)
                {
                    tran.Dispose();

                    dViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                    Logger.Error("Designation Controller - Update  " + ex.Message);
                }

            }

            return Json(dViewModel);
        }

        //[AuthorizeUser(RoleModule.Designation, Function.View)]
        public JsonResult CheckDesignationNameExist(string DesignationName)
        {
            bool check = false;

            DesignationViewModel dViewModel = new DesignationViewModel();

            try
            {
                check = _designationManager.CheckDesignationExist(DesignationName);

                Logger.Debug("Designation Controller CheckDesignationNameExist");
            }
            catch (Exception ex)
            {
                Logger.Error("Designation Controller - CheckDesignationNameExist" + ex.Message);
            }

            return Json(check, JsonRequestBehavior.AllowGet);

        }
    }
}