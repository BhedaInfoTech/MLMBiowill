using MLMBiowillBusinessEntities.Common;
using MLMBiowillBusinessEntities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MLMBioWill.Models.Master
{
    public class DesignationViewModel
    {
        public DesignationViewModel()
        {
            DesignationInfo = new DesignationInfo();

            FriendlyMessage = new List<FriendlyMessage>();

            DesignationList = new List<DesignationInfo>();

            Pager = new PaginationInfo();

        }
        public DesignationInfo DesignationInfo { get; set; }

        public DesignationFilter DesignationFilter { get; set; }

        public List<DesignationInfo> DesignationList { get; set; }

        public PaginationInfo Pager { get; set; }

        public List<FriendlyMessage> FriendlyMessage { get; set; }
    }
    public class DesignationFilter
    {
        public string DesignationName { get; set; }
        public int Id { get; set; }
    }
}