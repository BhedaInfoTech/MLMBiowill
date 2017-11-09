using MLMBiowillBusinessEntities;
using MLMBiowillBusinessEntities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MLMBioWill.Models
{
    public class CompanyViewModel
    {
        public CompanyInfo Company { get; set; }
        public List<CompanyInfo> Companylist { get; set; }
        public CompanyFilter Filter { get; set; }
        public PaginationInfo Pager { get; set; }
        public List<FriendlyMessage> FriendlyMessage { get; set; }

        public CompanyViewModel()
        {
            Company = new CompanyInfo();
            Companylist = new List<CompanyInfo>();
            Filter = new CompanyFilter();
            Pager = new PaginationInfo();
            FriendlyMessage = new List<FriendlyMessage>();
        }



    }
}