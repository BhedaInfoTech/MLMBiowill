using MLMBiowillBusinessEntities.Common;
using MLMBiowillBusinessEntities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MLMBioWill.Models.Master
{
    public class ContactPersonViewModel
    {
        public ContactPersonInfo ContactPersonDetails { get; set; }
        public List<ContactPersonInfo> ContactPersonDetailslist { get; set; }
        public ContactPersonFilterInfo ContactPersonFilter { get; set; }
        public PaginationInfo Pager { get; set; }
        public List<FriendlyMessage> FriendlyMessage { get; set; }


        public ContactPersonViewModel()
        {
            ContactPersonDetails = new ContactPersonInfo();
            ContactPersonDetailslist = new List<ContactPersonInfo>();

        }
    }
}