using MLMBiowillBusinessEntities.Common;
using MLMBiowillBusinessEntities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MLMBioWill.Models.Master
{
    public class AgentViewModel
    {
        public AgentViewModel()
        {
            AgentInfo = new AgentInfo();

            FriendlyMessage = new List<FriendlyMessage>();

            AgentList = new List<AgentInfo>();

            Pager = new PaginationInfo();

            BranchInfoList = new List<BranchInfo>();

        }
        public AgentInfo AgentInfo { get; set; }

        public AgentFilter AgentFilter { get; set; }

        public List<AgentInfo> AgentList { get; set; }

        public PaginationInfo Pager { get; set; }         

        public List<FriendlyMessage> FriendlyMessage { get; set; }

        public List<BranchInfo> BranchInfoList { get; set; }
    }
    public class AgentFilter
    {
        public string AgentCode { get; set; }

        public int Id { get; set; }
    }
}
