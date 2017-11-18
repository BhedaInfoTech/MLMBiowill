using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MLMBiowillBusinessEntities.Common;

namespace MLMBioWill.Models.Lookup
{
    public class LookupViewModel
    {
        public LookupViewModel()
        {
            Pager = new PaginationInfo();

            PartialDt = new DataTable();

            HeaderNames = new string[0];

        }

        public PaginationInfo Pager { get; set; }

        public DataTable PartialDt { get; set; }

        public string[] HeaderNames { get; set; }

        public string Value { get; set; }

        public string EditLookupValue { get; set; }

    }
}