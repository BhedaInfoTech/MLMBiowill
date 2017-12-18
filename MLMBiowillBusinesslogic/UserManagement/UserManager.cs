using MLMBiowillBusinessEntities.Common;
using MLMBiowillBusinessEntities.Master;
using MLMBiowillRepo.UserManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLMBiowillBusinesslogic.UserManagement
{
    public class UserManager
    {
        UserRepo _userRepo;

        public UserManager()
        {
            _userRepo = new UserRepo();

        }

        public int Insert_userInfo(UserInfo userInfo)
        {
            return _userRepo.Insert_UserMaster(userInfo);
        }

        public void Update_userInfo(UserInfo userInfo)
        {
            _userRepo.Update_UserMaster(userInfo);
        }


        public void Update_Token_UserMaster(UserInfo userInfo)
        {
            _userRepo.Update_Token_UserMaster(userInfo);
        }

        public List<UserInfo> Get_UserMasters(ref PaginationInfo pager)
        {
            return _userRepo.Get_UserMasters(ref pager);
        }

        public UserInfo Get_UserMaster_By_Id(int userInfoId)
        {
            return _userRepo.Get_UserMaster_By_Id(userInfoId);
        }

        public void Delete_userInfo_By_Id(int userInfoId)
        {
            _userRepo.Delete_UserMaster_By_Id(userInfoId);
        }

        public List<MappedUserDetail> Get_UserDetails_by_Object(string CalledFor)
        {
            return _userRepo.Get_User_By_Object(CalledFor);
        }
    }
}
