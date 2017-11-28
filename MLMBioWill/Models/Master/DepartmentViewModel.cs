using MLMBiowillBusinessEntities.Common;
using MLMBiowillBusinessEntities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MLMBioWill.Models.Master
{
    public class DepartmentViewModel
    {
        public DepartmentViewModel()
        {
            DepartmentInfo = new DepartmentInfo();

            FriendlyMessage = new List<FriendlyMessage>();

            DepartmentList = new List<DepartmentInfo>();

            Pager = new PaginationInfo();

        }
        public DepartmentInfo DepartmentInfo { get; set; }

        public DepartmentFilter DepartmentFilter { get; set; }

        public List<DepartmentInfo> DepartmentList { get; set; }

        public PaginationInfo Pager { get; set; }

        public List<FriendlyMessage> FriendlyMessage { get; set; }
    }
    public class DepartmentFilter
    {
        public string DepartmentName { get; set; }
        public int Id { get; set; }
    }
}