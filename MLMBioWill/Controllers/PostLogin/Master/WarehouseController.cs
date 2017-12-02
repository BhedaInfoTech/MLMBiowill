using MLMBioWill.Common;
using MLMBioWill.Models;
using MLMBioWill.Models.Master;
using MLMBiowillBusinessEntities.Common;
using MLMBiowillBusinesslogic.Master;
using MLMBiowillHelper.Authorization;
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
    public class WarehouseController : BaseController
    {
        public WarehouseManager _warehouseManager;

        public WarehouseController()
        {
            _warehouseManager = new WarehouseManager();
        }

        //[AuthorizeUser(RoleModule.Warehouse, Function.View)]
        public ActionResult Index(WarehouseViewModel wViewModel)
        {
            return View("Index", wViewModel);
        }

        //[AuthorizeUser(RoleModule.Warehouse, Function.View)]
        public ActionResult Search()
        {
            return View();
        }

        //[AuthorizeUser(RoleModule.Warehouse, Function.Create)]
        public JsonResult Insert(WarehouseViewModel wViewModel)
        {
            Set_Date_Session(wViewModel.WarehouseInfo);

            using (TransactionScope tran = new TransactionScope())
            {
                try
                {

                    wViewModel.WarehouseInfo.Id = _warehouseManager.Insert_Warehouse(wViewModel.WarehouseInfo);

                    wViewModel.FriendlyMessage.Add(MessageStore.Get("DEPARTMENT01"));

                    Logger.Debug("Warehouse Controller Insert");

                    tran.Complete();
                }
                catch (Exception ex)
                {
                    tran.Dispose();

                    wViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                    Logger.Error("Warehouse Controller - Insert " + ex.Message);
                }

            }
            return Json(wViewModel);
        }


        //[AuthorizeUser(RoleModule.Warehouse, Function.View)]
        public JsonResult GetWarehouses(WarehouseViewModel wViewModel)
        {
            PaginationInfo pager = new PaginationInfo();

            pager = wViewModel.Pager;

            PaginationViewModel pViewModel = new PaginationViewModel();

            try
            {
                pViewModel.dt = _warehouseManager.GetWarehouses(wViewModel.WarehouseInfo.BranchId, wViewModel.WarehouseInfo.WarehouseName, ref pager);

                pViewModel.Pager = pager;

                Logger.Debug("Warehouse Controller GetDeparment");
            }

            catch (Exception ex)
            {
                wViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Warehouse Controller - GetWarehouses" + ex.ToString());
            }

            return Json(JsonConvert.SerializeObject(pViewModel), JsonRequestBehavior.AllowGet);

        }

        //[AuthorizeUser(RoleModule.Warehouse, Function.Edit)]
        public JsonResult Update(WarehouseViewModel wViewModel)
        {
            Set_Date_Session(wViewModel.WarehouseInfo);

            using (TransactionScope tran = new TransactionScope())
            {
                try
                {
                    _warehouseManager.Update_Warhouse(wViewModel.WarehouseInfo);

                    wViewModel.FriendlyMessage.Add(MessageStore.Get("DEPARTMENT02"));

                    Logger.Debug("Warehouse Controller Update");

                    tran.Complete();

                }
                catch (Exception ex)
                {
                    tran.Dispose();

                    wViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                    Logger.Error("Warehouse Controller - Update  " + ex.Message);
                }
            }
            return Json(wViewModel);
        }

        //[AuthorizeUser(RoleModule.Warehouse, Function.View)]
        public JsonResult CheckWarehouseExist(string warehouse)
        {
            bool check = false;

            WarehouseViewModel wViewModel = new WarehouseViewModel();

            try
            {
                check = _warehouseManager.CheckWarehouseExist(warehouse);

                Logger.Debug("Warhouse Controller CheckWarehouseExist");
            }
            catch (Exception ex)
            {
                Logger.Error("Warhouse Controller - CheckWarehouseExist" + ex.Message);
            }

            return Json(check, JsonRequestBehavior.AllowGet);
        }
    }
}