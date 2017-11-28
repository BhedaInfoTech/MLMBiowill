using MLMBiowillBusinessEntities.City;
using MLMBiowillBusinessEntities.Common;
using MLMBiowillBusinessEntities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MLMBioWill.Models
{
    public class AddressViewModel
    {
        public List<AddressInfo> Addresslist { get; set; }
        public AddressInfo Address { get; set; }
        public AddressFilterInfo AddressFilter { get; set; }
        public List<CityInfo> Cities { get; set; }
        public PaginationInfo Pager { get; set; }
        public List<FriendlyMessage> FriendlyMessage { get; set; }

        public AddressViewModel()
        {
            Addresslist = new List<AddressInfo>();
            Address = new AddressInfo();
            AddressFilter = new AddressFilterInfo();
            Cities = new List<CityInfo>();
            Pager = new PaginationInfo();
            FriendlyMessage = new List<FriendlyMessage>();
        }



    }
}