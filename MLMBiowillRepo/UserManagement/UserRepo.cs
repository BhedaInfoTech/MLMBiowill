using MLMBiowillBusinessEntities.Common;
using MLMBiowillBusinessEntities.Master;
using MLMBiowillRepo.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MLMBiowillRepo.UserManagement
{
    public class UserRepo
    {

        SqlHelperRepo _sqlRepo;

        public UserRepo()
        {
            _sqlRepo = new SqlHelperRepo();
        }

        #region Insert/Update User Master
        public int Insert_UserMaster(UserInfo _userInfo)
        {
            return Convert.ToInt32(_sqlRepo.ExecuteScalerObj(Set_Values_In_UserMaster(_userInfo), StoredProcedureEnum.sp_Insert_UserMaster.ToString(), CommandType.StoredProcedure));
        }

        public void Update_UserMaster(UserInfo _userInfo)
        {
            _sqlRepo.ExecuteNonQuery(Set_Values_In_UserMaster(_userInfo), StoredProcedureEnum.sp_Update_UserMaster.ToString(), CommandType.StoredProcedure);
        }

        private List<SqlParameter> Set_Values_In_UserMaster(UserInfo _userInfo)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Id", _userInfo.UserId));
            if (_userInfo.UserId == 0)
            {
                sqlParams.Add(new SqlParameter("@UserName", _userInfo.UserName));
                sqlParams.Add(new SqlParameter("@CreatedBy", _userInfo.CreatedBy));
            }
            else
            {
                sqlParams.Add(new SqlParameter("@UpdatedBy", _userInfo.UpdatedBy));

            }
            sqlParams.Add(new SqlParameter("@Password", _userInfo.Password));
            sqlParams.Add(new SqlParameter("@LinkedFor", _userInfo.LinkedFor));
            sqlParams.Add(new SqlParameter("@Linkedwith", _userInfo.LinkedWith));
            sqlParams.Add(new SqlParameter("@Active", _userInfo.Active));
            return sqlParams;
        }

        public void Update_Token_UserMaster(UserInfo _userInfo)
        {
            _sqlRepo.ExecuteNonQuery(Set_Values_For_Token(_userInfo), StoredProcedureEnum.sp_Update_Token_UserMaster.ToString(), CommandType.StoredProcedure);
        }

        private List<SqlParameter> Set_Values_For_Token(UserInfo _userInfo)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Id", _userInfo.UserId));
            sqlParams.Add(new SqlParameter("@UserName", _userInfo.UserName));
            sqlParams.Add(new SqlParameter("@Token", _userInfo.Token));
            return sqlParams;
        }

        #endregion

        #region Fetch User Details
        public List<UserInfo> Get_UserMasters(ref PaginationInfo pager)
        {
            List<UserInfo> _userInfos = new List<UserInfo>();
            DataTable dt = _sqlRepo.ExecuteDataTable(null, StoredProcedureEnum.sp_Get_UserMaster.ToString(), CommandType.StoredProcedure);
            foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
            {
                _userInfos.Add(Get_UserMaster_Values(dr));
            }
            return _userInfos;
        }

        public UserInfo Get_UserMaster_By_Id(int usermasterId)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            UserInfo _userInfo = new UserInfo();
            sqlParams.Add(new SqlParameter("@UserId", usermasterId));
            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedureEnum.sp_Get_UserMaster_By_Id.ToString(), CommandType.StoredProcedure);
            List<DataRow> drList = new List<DataRow>();
            drList = dt.AsEnumerable().ToList();
            foreach (DataRow dr in drList)
            {
                _userInfo = Get_UserMaster_Values(dr);
            }
            return _userInfo;
        }

        private UserInfo Get_UserMaster_Values(DataRow dr)
        {
            UserInfo _userInfo = new UserInfo();

            _userInfo.UserId = Convert.ToInt32(dr["UserId"]);
            _userInfo.UserName = Convert.ToString(dr["UserName"]);
            _userInfo.Password = Convert.ToString(dr["Password"]);
            _userInfo.LinkedFor = Convert.ToString(dr["LinkedFor"]);
            _userInfo.LinkedWith = Convert.ToString(dr["Linkedwith"]);
            _userInfo.Token = Convert.ToString(dr["Token"]);
            _userInfo.Active = Convert.ToBoolean(dr["Active"]);
            _userInfo.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
            _userInfo.UpdatedBy = Convert.ToInt32(dr["UpdatedBy"]);
            return _userInfo;
        }

        public List<MappedUserDetail> Get_User_By_Object(string CalledFor)
        {
            List<MappedUserDetail> _mappedUserDetails = new List<MappedUserDetail>();
            DataTable dt = _sqlRepo.ExecuteDataTable(null, StoredProcedureEnum.sp_Fetch_UserInfo_By_Object.ToString(), CommandType.StoredProcedure);
            foreach (DataRow dr in CommonMethods.GetRows(dt))
            {
                _mappedUserDetails.Add(Get_MappedUser_Values(dr));
            }
            return _mappedUserDetails;
        }

        private MappedUserDetail Get_MappedUser_Values(DataRow dr)
        {
            MappedUserDetail _mappedUserDetail = new MappedUserDetail();
            _mappedUserDetail.MappedId = Convert.ToInt32(dr["Id"]);
            _mappedUserDetail.MappedName = Convert.ToString(dr["Name"]);

            return _mappedUserDetail;
        }

        #endregion

        #region Delete
        public void Delete_UserMaster_By_Id(int usermasterId)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("@UserId", usermasterId));
            _sqlRepo.ExecuteNonQuery(sqlParams, StoredProcedureEnum.sp_Delete_UserMaster_By_Id.ToString(), CommandType.StoredProcedure);
        }

        #endregion


        public int Insert_UserRoleMapping(UserRoleMapping _userInfo)
        {
            return Convert.ToInt32(_sqlRepo.ExecuteScalerObj(Set_Values_In_UserRoleMapping(_userInfo), StoredProcedureEnum.sp_Insert_UserMaster.ToString(), CommandType.StoredProcedure));
        }

        public void Update_UserRoleMapping(UserRoleMapping _userInfo)
        {
            _sqlRepo.ExecuteNonQuery(Set_Values_In_UserRoleMapping(_userInfo), StoredProcedureEnum.sp_Update_UserMaster.ToString(), CommandType.StoredProcedure);
        }

        private List<SqlParameter> Set_Values_In_UserRoleMapping(UserRoleMapping _userInfo)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Id", _userInfo.UserRoleMappingId));
            sqlParams.Add(new SqlParameter("@UserId", _userInfo.UserId));
            sqlParams.Add(new SqlParameter("@RoleId", _userInfo.RoleId));
            if (_userInfo.UserRoleMappingId == 0)
            {
                sqlParams.Add(new SqlParameter("@CreatedBy", _userInfo.CreatedBy));
            }
            sqlParams.Add(new SqlParameter("@UpdatedBy", _userInfo.UpdatedBy));
            sqlParams.Add(new SqlParameter("@Active", _userInfo.Active));
            return sqlParams;
        }


    }
}