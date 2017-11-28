using MLMBiowillBusinessEntities.Common;
using MLMBiowillBusinessEntities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MLMBioWill.Models.Master
{
    public class BranchViewModel
    {
        public BranchViewModel()
        {
            BranchInfo = new BranchInfo();

            FriendlyMessage = new List<FriendlyMessage>();

            BranchList = new List<BranchInfo>();

            Pager = new PaginationInfo();

            CompanyInfo = new List<CompanyInfo>();

        }
        public BranchInfo BranchInfo { get; set; }

        public BranchFilter BranchFilter { get; set; }

        public List<BranchInfo> BranchList { get; set; }

        public PaginationInfo Pager { get; set; }

        public List<CompanyInfo> CompanyInfo { get; set; }

        public List<FriendlyMessage> FriendlyMessage { get; set; }
    }
    public class BranchFilter
    {
        public string BranchName { get; set; }
        public int Id { get; set; }
    }
}