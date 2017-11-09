using MLMBiowillBusinessEntities.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MLMBioWill.Models
{
    public class PaginationViewModel
    {
        public PaginationViewModel()
        {
            dt = new DataTable();

            Pager = new PaginationInfo();
        }

        public PaginationInfo Pager
        {
            get;
            set;
        }

        public DataTable dt
        {
            get;
            set;
        }
    }
}