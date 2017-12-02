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
    public class BankController : BaseController
    {
        public BankManager _bankManager;

        public BankController()
        {
            _bankManager = new BankManager();
        }

        //[AuthorizeUser(RoleModule.Bank, Function.View)]
        public ActionResult Index(BankViewModel  bViewModel)
        {
            return View("Index", bViewModel);
        }

        //[AuthorizeUser(RoleModule.Bank, Function.View)]
        public ActionResult Search()
        {
            return View();
        }

        //[AuthorizeUser(RoleModule.Bank, Function.Create)]
        public JsonResult Insert(BankViewModel  bViewModel)
        {
            Set_Date_Session(bViewModel.BankInfo);
            
            using (TransactionScope tran = new TransactionScope())
            {
                try
                {
                    
                    bViewModel.BankInfo.Id = _bankManager.Insert_Bank(bViewModel.BankInfo);

                    bViewModel.FriendlyMessage.Add(MessageStore.Get("BANK01"));

                    tran.Complete();

                    Logger.Error("Bank Controller :- Insert Success. ");
                }
                catch (Exception ex)
                {
                    tran.Dispose();

                    bViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                    Logger.Error("Bank Controller - Insert Error " + ex.Message);
                }
            }
            return Json(bViewModel);
        }

        //[AuthorizeUser(RoleModule.Bank, Function.View)]
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

        //[AuthorizeUser(RoleModule.Bank, Function.Edit)]
        public JsonResult Update(BankViewModel  bViewModel)
        {
            Set_Date_Session(bViewModel.BankInfo);
            
            using (TransactionScope tran = new TransactionScope())
            {   
                try
                {
                    _bankManager.Update_Bank(bViewModel.BankInfo);

                    bViewModel.FriendlyMessage.Add(MessageStore.Get("BANK02"));

                    tran.Complete();

                    Logger.Error("Bank Controller :- Update Success ");
                }
                catch (Exception ex)
                {
                    tran.Dispose();

                    Logger.Error("Bank Controller :- Update Error :"+ ex.Message);

                    bViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));
                }
            }
            return Json(bViewModel);
        }
                
        //[AuthorizeUser(RoleModule.Bank, Function.View)]
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