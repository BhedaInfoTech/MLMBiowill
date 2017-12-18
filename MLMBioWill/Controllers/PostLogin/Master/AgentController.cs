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
    public class AgentController : BaseController
    {
        public AgentManager _agentManager;

        public BranchManager _branchManager;

        public AgentController()
        {
            _agentManager = new AgentManager();
            _branchManager = new BranchManager();
        }

        //[AuthorizeUser(RoleModule.Agent, Function.View)]
        public ActionResult Index(AgentViewModel aViewModel)
        {
            aViewModel.BranchInfoList = _branchManager.GetBranchList();
            return View("Index", aViewModel);
        }

        //[AuthorizeUser(RoleModule.Agent, Function.View)]
        public ActionResult Search()
        {
            return View("Search");
        }

        //[AuthorizeUser(RoleModule.Agent, Function.Create)]
        public JsonResult Insert(AgentViewModel aViewModel)
        {
            Set_Date_Session(aViewModel.AgentInfo);

            using (TransactionScope tran = new TransactionScope())
            {
                try
                {

                    aViewModel.AgentInfo.Id = _agentManager.Insert_Agent(aViewModel.AgentInfo);

                    aViewModel.AddressViewModelList.Address.AddressFor = AddressFor.Agent.ToString();

                    aViewModel.ContactViewModelList.ContactDetails.ContactFor = AddressFor.Agent.ToString();

                    aViewModel.FriendlyMessage.Add(MessageStore.Get("AGENT01"));

                    Logger.Debug("Agent Controller Insert");

                    tran.Complete();
                }
                catch (Exception ex)
                {
                    tran.Dispose();

                    aViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                    Logger.Error("Agent Controller - Insert " + ex.Message);
                }

            }
            return Json(aViewModel);
        }


        //[AuthorizeUser(RoleModule.Agent, Function.View)]
        public JsonResult GetAgents(AgentViewModel aViewModel)
        {
            PaginationInfo pager = new PaginationInfo();

            pager = aViewModel.Pager;

            PaginationViewModel pViewModel = new PaginationViewModel();

            try
            {
                pViewModel.dt = _agentManager.GetAgents(aViewModel.AgentInfo.BranchId,aViewModel.AgentInfo.FirstName, ref pager);

                pViewModel.Pager = pager;

                Logger.Debug("Agent Controller GetAgents");
            }

            catch (Exception ex)
            {
                aViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Agent Controller - GetAgents" + ex.ToString());
            }

            return Json(JsonConvert.SerializeObject(pViewModel), JsonRequestBehavior.AllowGet);

        }

        //[AuthorizeUser(RoleModule.Agent, Function.Edit)]
        public JsonResult Update(AgentViewModel aViewModel)
        {
            Set_Date_Session(aViewModel.AgentInfo);

            using (TransactionScope tran = new TransactionScope())
            {
                try
                {
                    _agentManager.Update_Agent(aViewModel.AgentInfo);

                    aViewModel.FriendlyMessage.Add(MessageStore.Get("AGENT02"));

                    Logger.Debug("Agent Controller Update");

                    tran.Complete();

                }
                catch (Exception ex)
                {
                    tran.Dispose();

                    aViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                    Logger.Error("Agent Controller - Update  " + ex.Message);
                }
            }
            return Json(aViewModel);
        }
               

        public ActionResult GetAgentById(AgentViewModel aViewModel)
        {
            AgentViewModel wareViewModel = new AgentViewModel();
            try
            {
                wareViewModel.BranchInfoList = _branchManager.GetBranchList();

                wareViewModel.AgentInfo = _agentManager.GetAgentById(aViewModel.AgentFilter.Id);

                wareViewModel.AddressViewModelList.Address.ObjectId = aViewModel.AgentFilter.Id;

                wareViewModel.ContactViewModelList.ContactDetails.ObjectId = aViewModel.AgentFilter.Id;

            }
            catch (Exception ex)
            {


                aViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Agent Controller - Update  " + ex.Message);
            }
            return Index(wareViewModel);
        }
    }
}