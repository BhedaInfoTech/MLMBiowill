using MLMBiowillRepo.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MLMBiowillBusinessEntities.Master;
using MLMBiowillBusinessEntities.Common;
using System.Data.SqlClient;
using MLMBiowillHelper.Logging;
using System.Data;

namespace MLMBiowillRepo.Master
{
   public class AgentRepo
    {
        SqlHelperRepo _sqlHelper = null;

        public AgentRepo()
        {
            _sqlHelper = new SqlHelperRepo();
        }

        public int Insert(AgentInfo agentInfo)
        {
            return Convert.ToInt32(_sqlHelper.ExecuteScalerObj(SetValuesInAgentInfo(agentInfo), StoredProcedureEnum.sp_Insert_Agent.ToString(), CommandType.StoredProcedure));
        }

        public List<SqlParameter> SetValuesInAgentInfo(AgentInfo agentInfo)
        {

            List<SqlParameter> sqlParam = new List<SqlParameter>();

            if (agentInfo.Id != 0)
            {
                sqlParam.Add(new SqlParameter("@Id", agentInfo.Id));
            }
            else
            {
                sqlParam.Add(new SqlParameter("@CreatedBy", agentInfo.CreatedBy));
            }

            sqlParam.Add(new SqlParameter("@AgentCode", agentInfo.AgentCode));

            sqlParam.Add(new SqlParameter("@AgentCode", agentInfo.FirstName));

            sqlParam.Add(new SqlParameter("@AgentCode", agentInfo.MiddleName));

            sqlParam.Add(new SqlParameter("@AgentCode", agentInfo.LastName));

            sqlParam.Add(new SqlParameter("@AgentCode", agentInfo.BranchId));

            sqlParam.Add(new SqlParameter("@AgentCode", agentInfo.Sex));

            sqlParam.Add(new SqlParameter("@PANNumber", agentInfo.PanNumber));

            sqlParam.Add(new SqlParameter("@AadharNumber", agentInfo.AdharNumber));

            sqlParam.Add(new SqlParameter("@PhotoPath", agentInfo.ImagePath));

            sqlParam.Add(new SqlParameter("@IsActive", agentInfo.Active));

            sqlParam.Add(new SqlParameter("UpdatedBy", agentInfo.UpdatedBy));

            return sqlParam;
        }

        public DataTable GetBranches(int companyId, string BranchName, ref PaginationInfo pager)
        {

            List<SqlParameter> sqlParam = new List<SqlParameter>();

            sqlParam.Add(new SqlParameter("@CompanyId", companyId));

            sqlParam.Add(new SqlParameter("@BranchName", BranchName));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, StoredProcedureEnum.sp_Get_Branches.ToString(), CommandType.StoredProcedure);

            return CommonMethods.GetPaginatedTable(dt, ref pager);
        }

        public void Update(AgentInfo agentInfo)
        {
            _sqlHelper.ExecuteNonQuery(SetValuesInAgentInfo(agentInfo), StoredProcedureEnum.sp_Update_Branch.ToString(), CommandType.StoredProcedure);
        }

        public bool CheckbranchNameExist(string branchName)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@BranchName", branchName));

            return Convert.ToBoolean(_sqlHelper.ExecuteScalerObj(sqlParams, StoredProcedureEnum.sp_Check_Branch_Exist.ToString(), CommandType.StoredProcedure));

        }

        public List<BranchInfo> GetBranchList()
        {
            List<BranchInfo> branchInfoList = new List<BranchInfo>();

            BranchInfo branchInfo = new BranchInfo();

            List<SqlParameter> sqlParam = new List<SqlParameter>();

            sqlParam.Add(new SqlParameter("@CompanyId", DBNull.Value));

            sqlParam.Add(new SqlParameter("@BranchName", DBNull.Value));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, StoredProcedureEnum.sp_Get_Branches.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in dt.Rows)
            {
                branchInfo = new BranchInfo();

                branchInfo.Id = Convert.ToInt32(dr["Id"]);

                branchInfo.BranchName = Convert.ToString(dr["Name"]);

                branchInfoList.Add(branchInfo);
            }

            return branchInfoList;
        }
    }
}
