﻿using MLMBioWill.Common;
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
    public class BranchController : BaseController
    {
        public BranchManager _branchManager;
        public CompanyManager _companyManager;

        public BranchController()
        {
            _branchManager = new BranchManager();
            _companyManager = new CompanyManager();
        }

        //[AuthorizeUser(RoleModule.Branch, Function.View)]
        public ActionResult Index(BranchViewModel bViewModel)
        {
            bViewModel.CompanyInfo = _branchManager.GetCompanies();

            return View("Index", bViewModel);
        }

        //[AuthorizeUser(RoleModule.Branch, Function.View)]
        public ActionResult Search()
        {
            return View();
        }

        //[AuthorizeUser(RoleModule.Branch, Function.Create)]
        public JsonResult Insert(BranchViewModel bViewModel)
        {
            Set_Date_Session(bViewModel.BranchInfo);

            using (TransactionScope tran = new TransactionScope())
            {
                try
                {

                    bViewModel.BranchInfo.Id = _branchManager.Insert_Branch(bViewModel.BranchInfo);

                    bViewModel.FriendlyMessage.Add(MessageStore.Get("BRANCH01"));

                    tran.Complete();

                    Logger.Debug("Branch Controller Insert");

                }
                catch (Exception ex)
                {
                    tran.Dispose();

                    bViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                    Logger.Error("Branch Controller - Insert " + ex.Message);
                }
            }
            return Json(bViewModel);
        }

        //[AuthorizeUser(RoleModule.Branch, Function.View)]
        public JsonResult GetBranches(BranchViewModel bViewModel)
        {
            PaginationInfo pager = new PaginationInfo();

            pager = bViewModel.Pager;

            PaginationViewModel pViewModel = new PaginationViewModel();

            try
            {
                pViewModel.dt = _branchManager.GetBranches(bViewModel.BranchInfo.CompanyId, bViewModel.BranchInfo.BranchName, ref pager);

                pViewModel.Pager = pager;

                Logger.Debug("Branch Controller GetBranches");
            }

            catch (Exception ex)
            {
                bViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Branch Controller - GetBranches" + ex.ToString());
            }

            return Json(JsonConvert.SerializeObject(pViewModel), JsonRequestBehavior.AllowGet);

        }

        //[AuthorizeUser(RoleModule.Branch, Function.Edit)]
        public JsonResult Update(BranchViewModel bViewModel)
        {
            Set_Date_Session(bViewModel.BranchInfo);

            using (TransactionScope tran = new TransactionScope())
            {
                try
                {  
                    _branchManager.Update_Branch(bViewModel.BranchInfo);

                    bViewModel.FriendlyMessage.Add(MessageStore.Get("BRANCH02"));

                    tran.Complete();

                    Logger.Debug("Branch Controller Update");
                }
                catch (Exception ex)
                {
                    tran.Dispose();

                    bViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                    Logger.Error("Branch Controller - Update  " + ex.Message);
                }
            }

            return Json(bViewModel);
        }

        //[AuthorizeUser(RoleModule.Branch, Function.View)]
        public JsonResult CheckBranchExist(string branch)
        {
            bool check = false;

            BranchViewModel bViewModel = new BranchViewModel();

            try
            {
                check = _branchManager.CheckBranchNameExist(branch);

                Logger.Debug("Branch Controller CheckBranchExist");
            }
            catch (Exception ex)
            {
                Logger.Error("Branch Controller - CheckBranchExist" + ex.Message);
            }

            return Json(check, JsonRequestBehavior.AllowGet);

        }
    }
}