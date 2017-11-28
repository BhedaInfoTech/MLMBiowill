using MLMBiowillBusinessEntities.Common;
using MLMBiowillBusinessEntities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MLMBioWill.Models
{
    public class ContactViewModel
    {

        public ContactInfo ContactDetails { get; set; }
        public List<ContactInfo> Contactlist { get; set; }
        public ContactFilterInfo ContactFilter { get; set; }
        public PaginationInfo Pager { get; set; }
        public List<FriendlyMessage> FriendlyMessage { get; set; }



        public ContactViewModel()
        {

            ContactDetails = new ContactInfo();
            Contactlist = new List<ContactInfo>();
            ContactFilter = new ContactFilterInfo();
            Pager = new PaginationInfo();
            FriendlyMessage = new List<FriendlyMessage>();
        }

    }
}