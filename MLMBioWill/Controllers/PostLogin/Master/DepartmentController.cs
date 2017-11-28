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
using System.Web;
using System.Web.Mvc;

namespace MLMBioWill.Controllers.PostLogin.Master
{
    public class DepartmentController : BaseController
    {
        public DeparmentManager _deptManager;

        public DepartmentController()
        {
            _deptManager = new DeparmentManager();
        }

        //[AuthorizeUser(RoleModule.Country, Function.View)]
        public ActionResult Index(DepartmentViewModel dViewModel)
        {
            return View("Index", dViewModel);
        }

        //[AuthorizeUser(RoleModule.Country, Function.View)]
        public ActionResult Search()
        {
            return View();
        }

        //[AuthorizeUser(RoleModule.Country, Function.Create)]
        public JsonResult Insert(DepartmentViewModel dViewModel)
        {
            try
            {
                Set_Date_Session(dViewModel.DepartmentInfo);

                dViewModel.DepartmentInfo.Id = _deptManager.Insert_Department(dViewModel.DepartmentInfo);

                dViewModel.FriendlyMessage.Add(MessageStore.Get("DEPARTMENT01"));

                Logger.Debug("Department Controller Insert");

            }
            catch (Exception ex)
            {
                dViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Department Controller - Insert " + ex.Message);
            }

            return Json(dViewModel);
        }

        //[AuthorizeUser(RoleModule.Country, Function.View)]
        public JsonResult GetDepartments(DepartmentViewModel dViewModel)
        {
            PaginationInfo pager = new PaginationInfo();

            pager = dViewModel.Pager;

            PaginationViewModel pViewModel = new PaginationViewModel();

            try
            {
                pViewModel.dt = _deptManager.GetDepartments(dViewModel.DepartmentInfo.DepartmentName, ref pager);

                pViewModel.Pager = pager;

                Logger.Debug("Department Controller GetDeparment");
            }

            catch (Exception ex)
            {
                dViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Department Controller - GetDeparment" + ex.ToString());
            }

            return Json(JsonConvert.SerializeObject(pViewModel), JsonRequestBehavior.AllowGet);

        }

        //[AuthorizeUser(RoleModule.Country, Function.Edit)]
        public JsonResult Update(DepartmentViewModel dViewModel)
        {
            try
            {
                Set_Date_Session(dViewModel.DepartmentInfo);

                _deptManager.Update_Deparment(dViewModel.DepartmentInfo);

                dViewModel.FriendlyMessage.Add(MessageStore.Get("DEPARTMENT02"));

                Logger.Debug("Department Controller Update");
            }
            catch (Exception ex)
            {
                dViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Department Controller - Update  " + ex.Message);
            }

            return Json(dViewModel);
        }

        //[AuthorizeUser(RoleModule.Country, Function.View)]
        public JsonResult CheckDepartmentExist(string department)
        {
            bool check = false;

            DepartmentViewModel dViewModel = new DepartmentViewModel();

            try
            {
                check = _deptManager.CheckDeparmentExist(department);

                Logger.Debug("Department Controller CheckDepartmentExist");
            }
            catch (Exception ex)
            {
                Logger.Error("Department Controller - CheckDepartmentExist" + ex.Message);
            }

            return Json(check, JsonRequestBehavior.AllowGet);
        }        
    }
}