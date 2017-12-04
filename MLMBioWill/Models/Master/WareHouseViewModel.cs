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

            AddressViewModelList = new AddressViewModel();

            ContactViewModelList = new ContactViewModel();

            AddressViewModelList.Address.AddressFor = AddressFor.Warehouse.ToString();

            ContactViewModelList.ContactDetails.ContactFor = AddressFor.Warehouse.ToString();

        }

        public ContactViewModel ContactViewModelList { get; set; }

        public AddressViewModel AddressViewModelList { get; set; }

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