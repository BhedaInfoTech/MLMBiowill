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
    public class ContactController : BaseController
    {
        ContactManager _ContactManager;

        public ContactController()
        {
            _ContactManager = new ContactManager();
        }

        //[AuthorizeUser(RoleModule.Contact, Function.View)]
        public JsonResult GetContactList(ContactViewModel vViewModel)
        {
            PaginationInfo pager = new PaginationInfo();

            pager = vViewModel.Pager;

            PaginationViewModel pViewModel = new PaginationViewModel();

            try
            {

                //vViewModel.Contact.ContactFor = ContactFor.Company.ToString();

                pViewModel.dt = _ContactManager.Get_Contact_By_Type_For(vViewModel.ContactDetails, ref pager);

                pViewModel.Pager = pager;

                Logger.Debug("Contact Controller GetContactList");

            }

            catch (Exception ex)
            {
                vViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Contact Controller - GetContactList" + ex.ToString());
            }

            return Json(JsonConvert.SerializeObject(pViewModel), JsonRequestBehavior.AllowGet);
        }

        //[AuthorizeUser(RoleModule.Contact, Function.View)]
        public JsonResult GetContactById(ContactViewModel vViewModel)
        {                    
            try
            {
                vViewModel.ContactDetails = _ContactManager.Get_Contact_By_Id(vViewModel.ContactDetails.ContactId);

                Logger.Debug("Contact Controller GetContactById");
            }
            catch (Exception ex)
            {
                vViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Contact Controller - GetContactById" + ex.ToString());
            }

            TempData["vViewModel"] = vViewModel;


            return Json(vViewModel, JsonRequestBehavior.AllowGet);
        }

        //[AuthorizeUser(RoleModule.Contact, Function.Create)]
        public JsonResult InsertContact(ContactViewModel cViewModel)
        {

            Set_Date_Session(cViewModel.ContactDetails);

            using (TransactionScope tran = new TransactionScope())
            {
                try
                {
                    cViewModel.ContactDetails.ContactId = _ContactManager.Insert_Contact(cViewModel.ContactDetails);
                    //cViewModel.ContactViewModelList.Contact.ContactFor = ContactFor.Contact.ToString();

                    cViewModel.FriendlyMessage.Add(MessageStore.Get("Cont01"));

                    Logger.Debug("Contact Controller Insert Contact");

                    tran.Complete();

                }
                catch (Exception ex)
                {
                    tran.Dispose();

                    cViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                    Logger.Error("Contact Controller - Insert Method : " + ex.Message);
                }
            }
            return Json(cViewModel);
        }

        //[AuthorizeUser(RoleModule.Contact, Function.Edit)]
        public JsonResult UpdateContact(ContactViewModel cViewModel)
        {
            Set_Date_Session(cViewModel.ContactDetails);

            int ContactId = cViewModel.ContactDetails.ContactId;

            using (TransactionScope tran = new TransactionScope())
            {
                try
                {
                    _ContactManager.Update_Contact(cViewModel.ContactDetails);

                    cViewModel.ContactDetails.ContactId = ContactId;

                    //cViewModel.ContactViewModelList.Contact.ContactFor = ContactFor.Contact.ToString();

                    cViewModel.FriendlyMessage.Add(MessageStore.Get("Cont02"));

                    Logger.Debug("Contact Controller Update Contact");

                    tran.Complete();

                }
                catch (Exception ex)
                {
                    tran.Dispose();

                    cViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                    Logger.Error("Contact Controller - UpdateContact  " + ex.Message);
                }
            }
            return Json(cViewModel);

        }

        //[AuthorizeUser(RoleModule.Contact, Function.Delete)]
        public JsonResult DeleteContact(ContactViewModel cViewModel)
        {
            Set_Date_Session(cViewModel.ContactDetails);

            using (TransactionScope tran = new TransactionScope())
            {

                try
                {
                    _ContactManager.Delete_Contact_By_Id(cViewModel.ContactDetails.ContactId);

                    //cViewModel.ContactViewModelList.Contact.ContactFor = ContactFor.Contact.ToString();

                    cViewModel.FriendlyMessage.Add(MessageStore.Get("Cont03"));

                    Logger.Debug("Contact Controller Deleted Contact");

                    tran.Complete();
                }
                catch (Exception ex)
                {
                    tran.Dispose();

                    cViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                    Logger.Error("Contact Controller - DeleteContact  " + ex.Message);
                }
            }
            return Json(cViewModel);

        }

        [HttpGet]
        //[AuthorizeUser(RoleModule.Contact, Function.View)]
        public JsonResult ContactTypeExist(string ContactType, string AddFor, string ObjectId)
        {
            Boolean IsExist = false;
            try
            {

               // IsExist = _ContactManager.CheckContactType(ContactType, AddFor, ObjectId);

                Logger.Debug("Contact Controller Deleted Contact");
            }
            catch (Exception ex)
            {
                Logger.Error("Contact Controller - DeleteContact  " + ex.Message);
            }

            return Json(IsExist, JsonRequestBehavior.AllowGet);

        }
    }
}