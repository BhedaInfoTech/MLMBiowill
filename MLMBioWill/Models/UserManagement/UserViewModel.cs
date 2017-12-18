using MLMBiowillBusinessEntities.Common;
using MLMBiowillBusinessEntities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MLMBioWill.Models.UserManagement
{
    public class UserViewModel
    {
        public UserViewModel()
        {
            Friendly_Message = new List<FriendlyMessage>();
            Pager = new PaginationInfo();
            User = new UserInfo();
            UserList = new List<UserInfo>();
        }
        public List<FriendlyMessage> Friendly_Message { get; set; }
        public PaginationInfo Pager { get; set; }
        public UserInfo User { get; set; }
        public List<UserInfo> UserList { get; set; }

    }
}