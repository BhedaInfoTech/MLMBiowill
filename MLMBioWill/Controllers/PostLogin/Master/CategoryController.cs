using MLMBioWill.Common;
using MLMBioWill.Models;
using MLMBioWill.Models.Master;
using MLMBiowillBusinessEntities.Common;
using MLMBiowillHelper.Logging;
using MLMBiowillRepo.Master;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MLMBioWill.Controllers.PostLogin.Master
{
    public class CategoryController : BaseController
    {
        public CategoryRepo _cRepo;

        public CategoryController()
        {
            _cRepo = new CategoryRepo();
        }

        public ActionResult Index(CategoryViewModel cViewModel)
        {
            return View("Index",cViewModel);
        }

        public JsonResult Insert(CategoryViewModel cViewModel)
        {
            try
            {
                Set_Date_Session(cViewModel.CategoryInfo);

                cViewModel.CategoryInfo.CategoryId = _cRepo.Insert(cViewModel.CategoryInfo);

                cViewModel.FriendlyMessage.Add(MessageStore.Get("CATEGORY01"));

                Logger.Debug("Category Controller Insert");

            }
            catch (Exception ex)
            {
                cViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Category Controller - Insert " + ex.Message);
            }

            return Json(cViewModel);
        }

        public JsonResult GetCategories(CategoryViewModel cViewModel)
        {
            PaginationInfo pager = new PaginationInfo();

            pager = cViewModel.Pager;

            PaginationViewModel pViewModel = new PaginationViewModel();

            try
            {
                pViewModel.dt = _cRepo.GetCountries(cViewModel.CategoryInfo.CategoryName, ref pager);

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

        public JsonResult Update(CategoryViewModel cViewModel)
        {
            try
            {
                Set_Date_Session(cViewModel.CategoryInfo);

                _cRepo.Update(cViewModel.CategoryInfo);

                cViewModel.FriendlyMessage.Add(MessageStore.Get("CATEGORY02"));

                Logger.Debug("Category Controller Update");
            }
            catch (Exception ex)
            {
                cViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Category Controller - Update  " + ex.Message);
            }

            return Json(cViewModel);
        }

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