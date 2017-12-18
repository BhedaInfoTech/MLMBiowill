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
    public class UserController : BaseController
    {

        // GET: Role
        public UserManager _userManager;

        public UserController()
        {
            _userManager = new UserManager();
        }


        // GET: User
        [AuthorizeUser(RoleModule.User, Function.View)]
        public ActionResult Index(UserViewModel uViewModel)
        {
            if (TempData["uViewModel"] != null)
            {
                uViewModel = (UserViewModel)TempData["uViewModel"];
            }

            if (uViewModel.User.UserId == 0)
            {
                //uViewModel.User.Modules = _userManager.GetModuleByRoleId(uViewModel.Role.RoleId);
            }

            return View("Index", uViewModel);
        }

        [AuthorizeUser(RoleModule.User, Function.View)]
        public ActionResult Search()
        {
            return View("Search");
        }



        public JsonResult Insert(UserViewModel uViewModel)
        {
            try
            {
                Set_Date_Session(uViewModel.User);
                
                uViewModel.User.UserId = _userManager.Insert_userInfo(uViewModel.User);
                

                uViewModel.Friendly_Message.Add(MessageStore.Get("Ro01"));

            }
            catch (Exception ex)
            {
                uViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Role Controller - Insert " + ex.Message);
            }

            return Json(uViewModel);
        }

        public JsonResult GetRoles(UserViewModel uViewModel)
        {
            PaginationInfo pager = new PaginationInfo();

            pager = uViewModel.Pager;

            PaginationViewModel pViewModel = new PaginationViewModel();

            try
            {
                //pViewModel.dt = _userManager.GetRoles(uViewModel.Filter.RoleName, ref pager);

                pViewModel.Pager = pager;
            }

            catch (Exception ex)
            {
                uViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Test Controller - GetRoles" + ex.ToString());
            }

            return Json(JsonConvert.SerializeObject(pViewModel), JsonRequestBehavior.AllowGet);

        }

        public ActionResult GetRoleById(UserViewModel uViewModel)
        {
            try
            {
                //uViewModel.Role = _userManager.GetRoleById(uViewModel.Role.RoleId);

                //uViewModel.Role.Modules = _userManager.GetModuleByRoleId(uViewModel.Role.RoleId);
            }
            catch (Exception ex)
            {
                uViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Role Controller - GetRoleById" + ex.ToString());
            }

            TempData["uViewModel"] = uViewModel;

            return RedirectToAction("Index");
        }

        public JsonResult Update(UserViewModel uViewModel)
        {
            try
            {
                //Set_Date_Session(uViewModel.Role);

                //foreach (var item in uViewModel.Role.Modules)
                {
                    //Set_Date_Session(item);
                }

                //_userManager.UpdateRole(uViewModel.Role);

                uViewModel.Friendly_Message.Add(MessageStore.Get("Ro02"));

            }
            catch (Exception ex)
            {

                uViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Role Controller - Update  " + ex.Message);
            }

            return Json(uViewModel);
        }

        public JsonResult CheckRoleNameExist(string rolename)
        {
            bool check = false;

            UserViewModel uViewModel = new UserViewModel();

            try
            {
                //check = _userManager.CheckRoleNameExist(rolename);
            }
            catch (Exception ex)
            {
                Logger.Error("Role Controller - CheckRoleNameExist" + ex.Message);
            }

            return Json(check, JsonRequestBehavior.AllowGet);

        }

    }
}