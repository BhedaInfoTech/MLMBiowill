using MLMBioWill.Common;
using MLMBioWill.Models;
using MLMBioWill.Models.UserManagement;
using MLMBiowillBusinessEntities.Common;
using MLMBiowillBusinesslogic.UserManagement;
using MLMBiowillHelper.Authorization;
using MLMBiowillHelper.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MLMBioWill.Controllers.PostLogin.UserManagement
{
    //[SessionExpired]
    public class RoleController : BaseController
    {
        // GET: Role
        public RoleManager _roleManager;

        public RoleController()
        {
            _roleManager = new RoleManager();
        }

        //[AuthorizeUser(RoleModule.Role, Function.View)]
        public ActionResult Index(RoleViewModel rViewModel)
        {
            if (TempData["rViewModel"] != null)
            {
                rViewModel = (RoleViewModel)TempData["rViewModel"];
            }

            if (rViewModel.Role.RoleId == 0)
            {
                rViewModel.Role.Modules = _roleManager.GetModuleByRoleId(rViewModel.Role.RoleId);
            }

            return View("Index", rViewModel);
        }

        public ActionResult Search(RoleViewModel rViewModel)
        {
            return View("Search", rViewModel);
        }

        public JsonResult Insert(RoleViewModel rViewModel)
        {
            try
            {
                Set_Date_Session(rViewModel.Role);

                foreach (var item in rViewModel.Role.Modules)
                {
                    Set_Date_Session(item);
                }
                rViewModel.Role.RoleId = _roleManager.InsertRole(rViewModel.Role);

                rViewModel.FriendlyMessage.Add(MessageStore.Get("Ro01"));

            }
            catch (Exception ex)
            {
                rViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Role Controller - Insert " + ex.Message);
            }

            return Json(rViewModel);
        }

        public JsonResult GetRoles(RoleViewModel rViewModel)
        {
            PaginationInfo pager = new PaginationInfo();

            pager = rViewModel.Pager;

            PaginationViewModel pViewModel = new PaginationViewModel();

            try
            {
                pViewModel.dt = _roleManager.GetRoles(rViewModel.Filter.RoleName, ref pager);

                pViewModel.Pager = pager;
            }

            catch (Exception ex)
            {
                rViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Test Controller - GetRoles" + ex.ToString());
            }

            return Json(JsonConvert.SerializeObject(pViewModel), JsonRequestBehavior.AllowGet);

        }

        public ActionResult GetRoleById(RoleViewModel rViewModel)
        { 
            try
            {
                rViewModel.Role = _roleManager.GetRoleById(rViewModel.Role.RoleId);

                rViewModel.Role.Modules = _roleManager.GetModuleByRoleId(rViewModel.Role.RoleId);
            }
            catch (Exception ex)
            {
                rViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Role Controller - GetRoleById" + ex.ToString());
            }

            TempData["rViewModel"] = rViewModel;

            return RedirectToAction("Index");
        }

        public JsonResult Update(RoleViewModel rViewModel)
        {
            try
            {
                Set_Date_Session(rViewModel.Role);

                foreach (var item in rViewModel.Role.Modules)
                {
                    Set_Date_Session(item);
                }

                _roleManager.UpdateRole(rViewModel.Role);

                rViewModel.FriendlyMessage.Add(MessageStore.Get("Ro02"));

            }
            catch (Exception ex)
            {

                rViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Role Controller - Update  " + ex.Message);
            }

            return Json(rViewModel);
        }

        public JsonResult CheckRoleNameExist(string rolename)
        {
            bool check = false;

            RoleViewModel rViewModel = new RoleViewModel();

            try
            {
                check = _roleManager.CheckRoleNameExist(rolename);
            }
            catch (Exception ex)
            {
                Logger.Error("Role Controller - CheckRoleNameExist" + ex.Message);
            }

            return Json(check, JsonRequestBehavior.AllowGet);

        }
    }
}