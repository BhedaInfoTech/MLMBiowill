using MLMBioWill.Common;
using MLMBioWill.Models;
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

namespace MLMBioWill.Controllers.PostLogin.Common
{
    public class AddressController : BaseController
    {
        AddressManager _AddressManager;

         public AddressController()
        {
            _AddressManager = new AddressManager();
        }

        //[AuthorizeUser(RoleModule.Address, Function.View)]
        public JsonResult GetAddressList(AddressViewModel vViewModel)
        {
            PaginationInfo pager = new PaginationInfo();

            pager = vViewModel.Pager;

            PaginationViewModel pViewModel = new PaginationViewModel();

            try
            {

                //vViewModel.Address.AddressFor = AddressFor.Company.ToString();

                pViewModel.dt = _AddressManager.Get_Address_By_Type_For(vViewModel.Address, ref pager);

                pViewModel.Pager = pager;

                Logger.Debug("Address Controller GetAddressList");

            }

            catch (Exception ex)
            {
                vViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Address Controller - GetAddressList" + ex.ToString());
            }

            return Json(JsonConvert.SerializeObject(pViewModel), JsonRequestBehavior.AllowGet);
        }

       //[AuthorizeUser(RoleModule.Address, Function.View)]
        public JsonResult GetAddressById(AddressViewModel  vViewModel)
        {

            try
            {
               vViewModel.Address = _AddressManager.Get_Address_By_Id(vViewModel.Address.AddressId);

                Logger.Debug("Address Controller GetAddressById");
            }
            catch (Exception ex)
            {
                vViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Address Controller - GetAddressById" + ex.ToString());
            }

            TempData["vViewModel"] = vViewModel;


            return Json(vViewModel, JsonRequestBehavior.AllowGet);
        }

        //[AuthorizeUser(RoleModule.Address, Function.Create)]
        public JsonResult InsertAddress(AddressViewModel cViewModel)
        {
            Set_Date_Session(cViewModel.Address);

            using (TransactionScope tran = new TransactionScope())
            {
                try
                {
                    cViewModel.Address.AddressId = _AddressManager.Insert_Address(cViewModel.Address);
                    //cViewModel.AddressViewModelList.Address.AddressFor = AddressFor.Address.ToString();

                    cViewModel.FriendlyMessage.Add(MessageStore.Get("Add01"));

                    Logger.Debug("Address Controller Insert Address");

                    tran.Complete();

                }
                catch (Exception ex)
                {
                    tran.Dispose();

                    cViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                    Logger.Error("Address Controller - Insert Method : " + ex.Message);
                }
            }
            return Json(cViewModel);
        }
                                                  
        //[AuthorizeUser(RoleModule.Address, Function.Edit)]
        public JsonResult UpdateAddress(AddressViewModel cViewModel)
        {
            Set_Date_Session(cViewModel.Address);

            int AddressId = cViewModel.Address.AddressId;

            using (TransactionScope tran = new TransactionScope())
            {

                try
                {
                    _AddressManager.Update_Address(cViewModel.Address);

                    cViewModel.Address.AddressId = AddressId;

                    //cViewModel.AddressViewModelList.Address.AddressFor = AddressFor.Address.ToString();

                    cViewModel.FriendlyMessage.Add(MessageStore.Get("Add02"));

                    Logger.Debug("Address Controller Update Address");

                    tran.Complete();
                }
                catch (Exception ex)
                {
                    tran.Dispose();

                    cViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                    Logger.Error("Address Controller - UpdateAddress  " + ex.Message);
                }
            }
            return Json(cViewModel);

        }

        //[AuthorizeUser(RoleModule.Address, Function.Delete)]
        public JsonResult DeleteAddress(AddressViewModel cViewModel)
        {
            Set_Date_Session(cViewModel.Address);

            using (TransactionScope tran = new TransactionScope())
            {

                try
                {
                    _AddressManager.Delete_Address_By_Id(cViewModel.Address.AddressId);

                    //cViewModel.AddressViewModelList.Address.AddressFor = AddressFor.Address.ToString();

                    cViewModel.FriendlyMessage.Add(MessageStore.Get("Add03"));

                    Logger.Debug("Address Controller Deleted Address");

                    tran.Complete();
                }
                catch (Exception ex)
                {
                    tran.Dispose();

                    cViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                    Logger.Error("Address Controller - DeleteAddress  " + ex.Message);
                }
            }
            return Json(cViewModel);

        }

        [HttpGet]
        //[AuthorizeUser(RoleModule.Address, Function.View)]
        public JsonResult AddressTypeExist(string AddressType,string AddFor, string ObjectId)
        {
            Boolean IsExist = false;
            try
            {

                IsExist =  _AddressManager.CheckAddressType(AddressType, AddFor, ObjectId);
             
                Logger.Debug("Address Controller Deleted Address");
            }
            catch (Exception ex)
            {
                Logger.Error("Address Controller - DeleteAddress  " + ex.Message);
            }

            return Json(IsExist,JsonRequestBehavior.AllowGet);

        }
    }
}