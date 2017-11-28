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
    public class SubcategoryController : BaseController
    {
        public SubcategoryManager _subcatManager;

        public SubcategoryController()
        {
            _subcatManager = new SubcategoryManager();
        }

        //[AuthorizeUser(RoleModule.Country, Function.View)]
        public ActionResult Index(SubcategoryViewModel dViewModel)
        {
            dViewModel.CategoryList = _subcatManager.GetCategories();
            return View("Index", dViewModel);
        }

        //[AuthorizeUser(RoleModule.Country, Function.View)]
        public ActionResult Search()
        {
            return View();
        }

        //[AuthorizeUser(RoleModule.Country, Function.Create)]
        public JsonResult Insert(SubcategoryViewModel dViewModel)
        {
            try
            {
                Set_Date_Session(dViewModel.SubcategoryInfo);

                dViewModel.SubcategoryInfo.Id = _subcatManager.Insert_Subcategory(dViewModel.SubcategoryInfo);

                dViewModel.FriendlyMessage.Add(MessageStore.Get("SUBCATEGORY01"));                

            }
            catch (Exception ex)
            {
                dViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));                  
            }

            return Json(dViewModel);
        }

        //[AuthorizeUser(RoleModule.Country, Function.View)]
        public JsonResult GetSubCategories(SubcategoryViewModel dViewModel)
        {
            PaginationInfo pager = new PaginationInfo();

            pager = dViewModel.Pager;

            PaginationViewModel pViewModel = new PaginationViewModel();

            try
            {
                pViewModel.dt = _subcatManager.GetSubcategories(dViewModel.SubcategoryInfo.CategoryId, dViewModel.SubcategoryInfo.SubCategoryName, ref pager);

                pViewModel.Pager = pager;

                Logger.Debug("Subcategory Controller GetSubCategories");
            }

            catch (Exception ex)
            {
                dViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Subcategory Controller - GetSubCategories" + ex.ToString());
            }

            return Json(JsonConvert.SerializeObject(pViewModel), JsonRequestBehavior.AllowGet);

        }

        //[AuthorizeUser(RoleModule.Country, Function.Edit)]
        public JsonResult Update(SubcategoryViewModel dViewModel)
        {
            try
            {
                Set_Date_Session(dViewModel.SubcategoryInfo);

                _subcatManager.Update_Subcategory(dViewModel.SubcategoryInfo);

                dViewModel.FriendlyMessage.Add(MessageStore.Get("SUBCATEGORY02"));

                Logger.Debug("Subcategory Controller Update");
            }
            catch (Exception ex)
            {
                dViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Subcategory Controller - Update  " + ex.Message);
            }

            return Json(dViewModel);
        }

        //[AuthorizeUser(RoleModule.Country, Function.View)]
        public JsonResult CheckSubcategoryExist(string subcategoryName)
        {
            bool check = false;

            SubcategoryViewModel dViewModel = new SubcategoryViewModel();

            try
            {
                check = _subcatManager.CheckSubcategoryNameExist(subcategoryName);

                Logger.Debug("Subcategory Controller CheckSubcategoryExist");
            }
            catch (Exception ex)
            {
                Logger.Error("Subcategory Controller - CheckSubcategoryExist" + ex.Message);
            }

            return Json(check, JsonRequestBehavior.AllowGet);

        }
    }
}