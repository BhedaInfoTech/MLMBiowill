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
    public class CourierController : BaseController
    {
        public CourierManager _courierManager;

        public BranchManager _branchManager;

        public CourierController()
        {
            _courierManager = new CourierManager();             
        }

        //[AuthorizeUser(RoleModule.Courier, Function.View)]
        public ActionResult Index(CourierViewModel cViewModel)
        {            
            return View("Index", cViewModel);
        }

        //[AuthorizeUser(RoleModule.Courier, Function.View)]
        public ActionResult Search()
        {
            return View("Search");
        }

        //[AuthorizeUser(RoleModule.Courier, Function.Create)]
        public JsonResult Insert(CourierViewModel cViewModel)
        {
            Set_Date_Session(cViewModel.CourierInfo);

            using (TransactionScope tran = new TransactionScope())
            {
                try
                {

                    cViewModel.CourierInfo.Id = _courierManager.Insert_Courier(cViewModel.CourierInfo);

                    cViewModel.AddressViewModelList.Address.AddressFor = AddressFor.Courier.ToString();

                    cViewModel.ContactViewModelList.ContactDetails.ContactFor = AddressFor.Courier.ToString();

                    cViewModel.FriendlyMessage.Add(MessageStore.Get("COURIER01"));

                    Logger.Debug("Courier Controller Insert");

                    tran.Complete();
                }
                catch (Exception ex)
                {
                    tran.Dispose();

                    cViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                    Logger.Error("Courier Controller - Insert " + ex.Message);
                }

            }
            return Json(cViewModel);
        }


        //[AuthorizeUser(RoleModule.Courier, Function.View)]
        public JsonResult GetCouriers(CourierViewModel cViewModel)
        {
            PaginationInfo pager = new PaginationInfo();

            pager = cViewModel.Pager;

            PaginationViewModel pViewModel = new PaginationViewModel();

            try
            {
                pViewModel.dt = _courierManager.GetCouriers(cViewModel.CourierFilter.CourierName, ref pager);

                pViewModel.Pager = pager;

                Logger.Debug("Courier Controller GetCouriers");
            }

            catch (Exception ex)
            {
                cViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Courier Controller - GetCouriers" + ex.ToString());
            }

            return Json(JsonConvert.SerializeObject(pViewModel), JsonRequestBehavior.AllowGet);

        }

        //[AuthorizeUser(RoleModule.Courier, Function.Edit)]
        public JsonResult Update(CourierViewModel cViewModel)
        {
            Set_Date_Session(cViewModel.CourierInfo);

            using (TransactionScope tran = new TransactionScope())
            {
                try
                {
                    _courierManager.Update_Courier(cViewModel.CourierInfo);

                    cViewModel.FriendlyMessage.Add(MessageStore.Get("COURIER02"));

                    Logger.Debug("Courier Controller Update");

                    tran.Complete();

                }
                catch (Exception ex)
                {
                    tran.Dispose();

                    cViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                    Logger.Error("Courier Controller - Update  " + ex.Message);
                }
            }
            return Json(cViewModel);
        }

        //[AuthorizeUser(RoleModule.Courier, Function.View)]
        public JsonResult CheckCourierExist(string Courier)
        {
            bool check = false;

            CourierViewModel cViewModel = new CourierViewModel();

            try
            {
                check = _courierManager.CheckCourierNameExist(Courier);

                Logger.Debug("Courier Controller CheckCourierExist");
            }
            catch (Exception ex)
            {
                Logger.Error("Courier Controller - CheckCourierExist" + ex.Message);
            }

            return Json(check, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetCourierById(CourierViewModel cViewModel)
        {
            CourierViewModel wareViewModel = new CourierViewModel();
            try
            {               

                wareViewModel.CourierInfo = _courierManager.GetCourierInfoById(cViewModel.CourierFilter.Id);

                wareViewModel.AddressViewModelList.Address.ObjectId = cViewModel.CourierFilter.Id;

                wareViewModel.ContactViewModelList.ContactDetails.ObjectId = cViewModel.CourierFilter.Id;

            }
            catch (Exception ex)
            {


                cViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Courier Controller - Update  " + ex.Message);
            }
            return Index(wareViewModel);
        }
    }
}