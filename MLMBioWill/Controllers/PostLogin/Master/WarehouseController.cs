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

        public BranchManager _branchManager;

        public WarehouseController()
        {
            _warehouseManager = new WarehouseManager();
            _branchManager = new BranchManager();
        }

        //[AuthorizeUser(RoleModule.Warehouse, Function.View)]
        public ActionResult Index(WarehouseViewModel wViewModel)
        {
            wViewModel.BranchInfoList = _branchManager.GetBranchList();
            return View("Index", wViewModel);
        }

        //[AuthorizeUser(RoleModule.Warehouse, Function.View)]
        public ActionResult Search()
        {
            return View("Search");
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

                    wViewModel.AddressViewModelList.Address.AddressFor = AddressFor.Warehouse.ToString();

                    wViewModel.ContactViewModelList.ContactDetails.ContactFor = AddressFor.Warehouse.ToString();

                    wViewModel.FriendlyMessage.Add(MessageStore.Get("WAREHOUSE01"));

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
                pViewModel.dt = _warehouseManager.GetWarehouses(wViewModel.WarehouseFilter.WarehouseName, ref pager);

                pViewModel.Pager = pager;

                Logger.Debug("Warehouse Controller GetWarehouses");
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

                    wViewModel.FriendlyMessage.Add(MessageStore.Get("WAREHOUSE02"));

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

        public ActionResult GetWarehouseById(WarehouseViewModel wViewModel)
        {
            WarehouseViewModel wareViewModel = new WarehouseViewModel();
            try
            {
                wareViewModel.BranchInfoList = _branchManager.GetBranchList();

                wareViewModel.WarehouseInfo = _warehouseManager.GetWarehouseById(wViewModel.WarehouseFilter.Id);

                wareViewModel.AddressViewModelList.Address.ObjectId = wViewModel.WarehouseFilter.Id;

                wareViewModel.ContactViewModelList.ContactDetails.ObjectId = wViewModel.WarehouseFilter.Id;

            }
            catch (Exception ex)
            {
                

                wViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Warehouse Controller - Update  " + ex.Message);
            }
            return Index(wareViewModel);
        }
    }
}