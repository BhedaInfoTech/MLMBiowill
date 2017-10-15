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
        public PaginationInfo Pager { get; set; }

        public CompanyViewModel()
        {
            Company = new CompanyInfo();
            Companylist = new List<CompanyInfo>();
            Pager = new PaginationInfo();
        }

    }
}