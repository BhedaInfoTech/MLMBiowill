using MLMBioWill.Common;
using MLMBioWill.Models;
using MLMBioWill.Models.Master;
using MLMBiowillBusinessEntities.Common;
using MLMBiowillHelper.Authorization;
using MLMBiowillHelper.Logging;
using MLMBiowillRepo.Master;
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
    public class CategoryController : BaseController
    {
        public CategoryRepo _cRepo;

        public CategoryController()
        {
            _cRepo = new CategoryRepo();
        }

        //[AuthorizeUser(RoleModule.Category, Function.View)]
        public ActionResult Index(CategoryViewModel cViewModel)
        {
            return View("Index",cViewModel);
        }

        //[AuthorizeUser(RoleModule.Category, Function.Create)]
        public JsonResult Insert(CategoryViewModel cViewModel)
        {
            Set_Date_Session(cViewModel.CategoryInfo);
            using (TransactionScope tran = new TransactionScope())
            {
                try
                {

                    cViewModel.CategoryInfo.CategoryId = _cRepo.Insert(cViewModel.CategoryInfo);

                    cViewModel.FriendlyMessage.Add(MessageStore.Get("CATEGORY01"));

                    tran.Complete();

                    Logger.Debug("Category Controller Insert");

                }
                catch (Exception ex)
                {
                    tran.Dispose();

                    cViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                    Logger.Error("Category Controller - Insert " + ex.Message);
                }
            }

            return Json(cViewModel);
        }

        //[AuthorizeUser(RoleModule.Category, Function.View)]
        public JsonResult GetCategories(CategoryViewModel cViewModel)
        {
            PaginationInfo pager = new PaginationInfo();

            pager = cViewModel.Pager;

            PaginationViewModel pViewModel = new PaginationViewModel();

            try
            {
                pViewModel.dt = _cRepo.GetCategories(cViewModel.CategoryInfo.CategoryName, ref pager);

                pViewModel.Pager = pager;

                Logger.Debug("Category Controller GetCategories");
            }

            catch (Exception ex)
            {
                cViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Country Controller - GetCategories" + ex.ToString());
            }

            return Json(JsonConvert.SerializeObject(pViewModel), JsonRequestBehavior.AllowGet);

        }

        //[AuthorizeUser(RoleModule.Category, Function.Edit)]
        public JsonResult Update(CategoryViewModel cViewModel)
        {
            Set_Date_Session(cViewModel.CategoryInfo);

            using (TransactionScope tran = new TransactionScope())
            {
                try
                {   
                    _cRepo.Update(cViewModel.CategoryInfo);

                    cViewModel.FriendlyMessage.Add(MessageStore.Get("CATEGORY02"));

                    tran.Complete();

                    Logger.Debug("Category Controller Update");
                }
                catch (Exception ex)
                {
                    tran.Dispose();
                    
                    cViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                    Logger.Error("Category Controller - Update  " + ex.Message);
                }
            }
            return Json(cViewModel);
        }

        //[AuthorizeUser(RoleModule.Category, Function.View)]
        public JsonResult CheckCategoryNameExist(string categoryName)
        {
            bool check = false;

            CategoryViewModel cViewModel = new CategoryViewModel();

            try
            {
                check = _cRepo.CheckCategoryNameExist(categoryName);

                Logger.Debug("Category Controller CheckCategoryNameExist");
            }
            catch (Exception ex)
            {
                Logger.Error("Category Controller - CheckCategoryNameExist" + ex.Message);
            }

            return Json(check, JsonRequestBehavior.AllowGet);

        }
    }
}