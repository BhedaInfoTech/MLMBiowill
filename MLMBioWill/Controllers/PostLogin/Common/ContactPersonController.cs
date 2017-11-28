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

namespace MLMBioWill.Controllers.PostLogin.Common
{
    //[SessionExpired]
    public class ContactPersonController : BaseController
    {
        ContactPersonManager _ContactPersonManager;

        public ContactPersonController()
        {
            _ContactPersonManager = new ContactPersonManager();
        }

        //[AuthorizeUser(RoleModule.ContactPerson, Function.View)]
        public JsonResult GetContactPersonList(ContactPersonViewModel vViewModel)
        {
            PaginationInfo pager = new PaginationInfo();

            pager = vViewModel.Pager;

            PaginationViewModel pViewModel = new PaginationViewModel();

            try
            {

                //vViewModel.Contact.ContactFor = ContactFor.Company.ToString();

                pViewModel.dt = _ContactPersonManager.Get_Contact_By_Type_For(vViewModel.ContactPersonDetails, ref pager);

                pViewModel.Pager = pager;

                Logger.Debug("Contact Person Controller GetContactList");

            }

            catch (Exception ex)
            {
                vViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Contact Person Controller - GetContactList" + ex.ToString());
            }

            return Json(JsonConvert.SerializeObject(pViewModel), JsonRequestBehavior.AllowGet);
        }

        //[AuthorizeUser(RoleModule.ContactPerson, Function.View)]
        public JsonResult GetContactPersonById(ContactPersonViewModel vViewModel)
        {                    
            try
            {
                vViewModel.ContactPersonDetails = _ContactPersonManager.Get_ContactPerson_By_Id(vViewModel.ContactPersonDetails.ContactPersonId);

                Logger.Debug("Contact Person Controller GetContactById");
            }
            catch (Exception ex)
            {
                vViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Contact Person Controller - GetContactById" + ex.ToString());
            }

            TempData["vViewModel"] = vViewModel;


            return Json(vViewModel, JsonRequestBehavior.AllowGet);
        }

        //[AuthorizeUser(RoleModule.ContactPerson, Function.Create)]
        public JsonResult InsertContactPerson(ContactPersonViewModel cViewModel)
        {

            Set_Date_Session(cViewModel.ContactPersonDetails);

            using (TransactionScope tran = new TransactionScope())
            {
                try
                {
                    cViewModel.ContactPersonDetails.ContactPersonId = _ContactPersonManager.Insert_ContactPerson(cViewModel.ContactPersonDetails);
                    //cViewModel.ContactPersonViewModelList.Contact.ContactFor = ContactFor.Contact.ToString();

                    cViewModel.FriendlyMessage.Add(MessageStore.Get("Cont01"));

                    Logger.Debug("Contact Person Controller Insert Contact");

                    tran.Complete();

                }
                catch (Exception ex)
                {
                    tran.Dispose();

                    cViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                    Logger.Error("Contact Person Controller - Insert Method : " + ex.Message);
                }
            }
            return Json(cViewModel);
        }

        //[AuthorizeUser(RoleModule.ContactPerson, Function.Edit)]
        public JsonResult UpdateContactPerson(ContactPersonViewModel cViewModel)
        {
            Set_Date_Session(cViewModel.ContactPersonDetails);

            int ContactId = cViewModel.ContactPersonDetails.ContactPersonId;

            using (TransactionScope tran = new TransactionScope())
            {
                try
                {
                    _ContactPersonManager.Update_ContactPerson(cViewModel.ContactPersonDetails);

                    cViewModel.ContactPersonDetails.ContactPersonId = ContactId;

                    //cViewModel.ContactPersonViewModelList.Contact.ContactFor = ContactFor.Contact.ToString();

                    cViewModel.FriendlyMessage.Add(MessageStore.Get("Cont02"));

                    Logger.Debug("Contact Person Controller Update Contact");

                    tran.Complete();

                }
                catch (Exception ex)
                {
                    tran.Dispose();

                    cViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                    Logger.Error("Contact Person Controller - UpdateContact  " + ex.Message);
                }
            }
            return Json(cViewModel);

        }

        //[AuthorizeUser(RoleModule.ContactPerson, Function.Delete)]
        public JsonResult DeleteContactPerson(ContactPersonViewModel cViewModel)
        {
            Set_Date_Session(cViewModel.ContactPersonDetails);

            using (TransactionScope tran = new TransactionScope())
            {

                try
                {
                    _ContactPersonManager.Delete_ContactPerson_By_Id(cViewModel.ContactPersonDetails.ContactPersonId);

                    //cViewModel.ContactPersonViewModelList.Contact.ContactFor = ContactFor.Contact.ToString();

                    cViewModel.FriendlyMessage.Add(MessageStore.Get("Cont03"));

                    Logger.Debug("Contact Person Controller Deleted Contact");

                    tran.Complete();
                }
                catch (Exception ex)
                {
                    tran.Dispose();

                    cViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                    Logger.Error("Contact Person Controller - DeleteContact  " + ex.Message);
                }
            }
            return Json(cViewModel);

        }

        [HttpGet]
        //[AuthorizeUser(RoleModule.ContactPerson, Function.View)]
        public JsonResult ContactPersonExist(string ContactType, string AddFor, string ObjectId)
        {
            Boolean IsExist = false;
            try
            {

               // IsExist = _ContactPersonManager.CheckContactType(ContactType, AddFor, ObjectId);

                Logger.Debug("Contact Person Controller ContactPersonExist");
            }
            catch (Exception ex)
            {
                Logger.Error("Contact Person Controller - ContactPersonExist  " + ex.Message);
            }

            return Json(IsExist, JsonRequestBehavior.AllowGet);

        }
    }
}