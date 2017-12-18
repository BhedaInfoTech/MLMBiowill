using MLMBiowillBusinessEntities.Common;
using MLMBiowillBusinessEntities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MLMBioWill.Models.Master
{
    public class CourierViewModel
    {
        public CourierViewModel()
        {
            CourierInfo = new CourierInfo();

            FriendlyMessage = new List<FriendlyMessage>();

            CourierList = new List<CourierInfo>();

            Pager = new PaginationInfo();

            AddressViewModelList = new AddressViewModel();

            ContactViewModelList = new ContactViewModel();

            AddressViewModelList.Address.AddressFor = AddressFor.Warehouse.ToString();

            ContactViewModelList.ContactDetails.ContactFor = AddressFor.Warehouse.ToString();
        }
        public CourierInfo CourierInfo { get; set; }

        public CourierFilter CourierFilter { get; set; }

        public List<CourierInfo> CourierList { get; set; }

        public PaginationInfo Pager { get; set; }        

        public List<FriendlyMessage> FriendlyMessage { get; set; }

        public ContactViewModel ContactViewModelList { get; set; }

        public AddressViewModel AddressViewModelList { get; set; }
    }
    public class CourierFilter
    {
        public string CourierName { get; set; }
        public int Id { get; set; }
    }

}
