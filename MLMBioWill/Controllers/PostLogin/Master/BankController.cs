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
    public class BankController : BaseController
    {
        public BankManager _bankManager;

        public BankController()
        {
            _bankManager = new BankManager();
        }

        //[AuthorizeUser(RoleModule.Country, Function.View)]
        public ActionResult Index(BankViewModel  bViewModel)
        {
            return View("Index", bViewModel);
        }

        //[AuthorizeUser(RoleModule.Country, Function.View)]
        public ActionResult Search()
        {
            return View();
        }

        //[AuthorizeUser(RoleModule.Country, Function.Create)]
        public JsonResult Insert(BankViewModel  bViewModel)
        {
            try
            {
                Set_Date_Session(bViewModel.BankInfo);

                bViewModel.BankInfo.Id = _bankManager.Insert_Bank(bViewModel.BankInfo);

                bViewModel.FriendlyMessage.Add(MessageStore.Get("BANK01"));                

            }
            catch (Exception ex)
            {
                bViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));                
            }

            return Json(bViewModel);
        }

        //[AuthorizeUser(RoleModule.Country, Function.View)]
        public JsonResult GetBanks(BankViewModel  bViewModel)
        {
            PaginationInfo pager = new PaginationInfo();

            pager = bViewModel.Pager;

            PaginationViewModel pViewModel = new PaginationViewModel();

            try
            {
                pViewModel.dt = _bankManager.GetBanks(bViewModel.BankInfo.BankName, ref pager);

                pViewModel.Pager = pager;                
            }

            catch (Exception ex)
            {
                bViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));                 
            }

            return Json(JsonConvert.SerializeObject(pViewModel), JsonRequestBehavior.AllowGet);

        }

        //[AuthorizeUser(RoleModule.Country, Function.Edit)]
        public JsonResult Update(BankViewModel  bViewModel)
        {
            try
            {
                Set_Date_Session(bViewModel.BankInfo);

                _bankManager.Update_Bank(bViewModel.BankInfo);

                bViewModel.FriendlyMessage.Add(MessageStore.Get("BANK02"));                
            }
            catch (Exception ex)
            {
                bViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));                
            }
            return Json(bViewModel);
        }
                
        //[AuthorizeUser(RoleModule.Country, Function.View)]
        public JsonResult CheckBankNameExist(string bankName)
        {
            bool check = false;

            BankViewModel  bViewModel = new BankViewModel ();

            try
            {
                check = _bankManager.CheckBankExist(bankName);                 
            }
            catch (Exception ex)
            {
                Logger.Error("Bank Controller - CheckBankNameExist" + ex.Message);
            }

            return Json(check, JsonRequestBehavior.AllowGet);

        }
    }
}