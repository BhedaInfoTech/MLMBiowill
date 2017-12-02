using MLMBiowillBusinessEntities.Common;
using MLMBiowillBusinessEntities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MLMBioWill.Models.Master
{
    public class WarehouseViewModel
    {
        public WarehouseViewModel()
        {
            WarehouseInfo = new WarehouseInfo();

            WarehouseInfoList = new List<WarehouseInfo>();

            BranchInfoList = new List<BranchInfo>();

            FriendlyMessage = new List<FriendlyMessage>();

            Pager = new PaginationInfo();

        }

        public WarehouseInfo WarehouseInfo { get; set; }

        public List<BranchInfo> BranchInfoList { get; set; }

        public List<WarehouseInfo> WarehouseInfoList { get; set; }

        public PaginationInfo Pager { get; set; }

        public List<FriendlyMessage> FriendlyMessage { get; set; }

    }

    public class WarehouseFilter
    {
        public string WarehouseName { get; set; }
        public int Id { get; set; }
    }
}