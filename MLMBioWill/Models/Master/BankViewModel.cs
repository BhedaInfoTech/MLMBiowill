using MLMBiowillBusinessEntities.Common;
using MLMBiowillBusinessEntities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MLMBioWill.Models.Master
{
    public class BankViewModel
    {
        public BankViewModel()
        {
            BankInfo = new BankInfo();

            FriendlyMessage = new List<FriendlyMessage>();

            BankList = new List<BankInfo>();

            Pager = new PaginationInfo();

        }
        public BankInfo BankInfo { get; set; }

        public BankFilter BankFilter { get; set; }

        public List<BankInfo> BankList { get; set; }

        public PaginationInfo Pager { get; set; }

        public List<FriendlyMessage> FriendlyMessage { get; set; }
    }
    public class BankFilter
    {
        public string BankName { get; set; }
        public int Id { get; set; }
    }
}