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

            sqlParam.Add(new SqlParameter("@FirstName", agentInfo.FirstName));

            sqlParam.Add(new SqlParameter("@MiddleName", agentInfo.MiddleName));

            sqlParam.Add(new SqlParameter("@LastName", agentInfo.LastName));

            sqlParam.Add(new SqlParameter("@BranchId", agentInfo.BranchId));

            sqlParam.Add(new SqlParameter("@Sex", agentInfo.Sex));

            sqlParam.Add(new SqlParameter("@PANNumber", agentInfo.PanNumber));

            sqlParam.Add(new SqlParameter("@AadharNumber", agentInfo.AadharNumber));

            sqlParam.Add(new SqlParameter("@PhotoPath", agentInfo.ImagePath));

            sqlParam.Add(new SqlParameter("@IsActive", agentInfo.IsActive));

            sqlParam.Add(new SqlParameter("UpdatedBy", agentInfo.UpdatedBy));

            return sqlParam;
        }

        public DataTable GetAgents(int companyId, string BranchName, ref PaginationInfo pager)
        {

            List<SqlParameter> sqlParam = new List<SqlParameter>();

            sqlParam.Add(new SqlParameter("@BranchId", companyId));

            sqlParam.Add(new SqlParameter("@FirstName", BranchName));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, StoredProcedureEnum.sp_Get_Agents.ToString(), CommandType.StoredProcedure);

            return CommonMethods.GetPaginatedTable(dt, ref pager);
        }

        public void Update(AgentInfo agentInfo)
        {
            _sqlHelper.ExecuteNonQuery(SetValuesInAgentInfo(agentInfo), StoredProcedureEnum.sp_Update_Agent.ToString(), CommandType.StoredProcedure);
        }

        //public bool CheckAgentExist(string branchName)
        //{

        //    List<SqlParameter> sqlParams = new List<SqlParameter>();

        //    sqlParams.Add(new SqlParameter("@BranchName", branchName));

        //    return Convert.ToBoolean(_sqlHelper.ExecuteScalerObj(sqlParams, StoredProcedureEnum.sp_Check_Branch_Exist.ToString(), CommandType.StoredProcedure));

        //}

        public AgentInfo Get_Agent_By_Id(int agentId)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            AgentInfo agentInfo = new AgentInfo();
            sqlParams.Add(new SqlParameter("@AgentId", agentId));
            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParams, StoredProcedureEnum.sp_GetAgentById.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in dt.Rows)
            {
                agentInfo = Get_Agent_Values(dr);
            }
            return agentInfo;
        }

        private AgentInfo Get_Agent_Values(DataRow dr)
        {
            AgentInfo agentInfo = new AgentInfo();

            agentInfo.Id = Convert.ToInt32(dr["Id"]);
            agentInfo.AgentCode = Convert.ToString(dr["AgentCode"]);
            agentInfo.FirstName = Convert.ToString(dr["FirstName"]);
            agentInfo.MiddleName = Convert.ToString(dr["MiddleName"]);
            agentInfo.LastName = Convert.ToString(dr["LastName"]);
            agentInfo.BranchId = Convert.ToInt32(dr["BranchId"]);
            agentInfo.Sex = Convert.ToInt32(dr["Sex"]);
            agentInfo.PanNumber = Convert.ToString(dr["PANNumber"]);
            agentInfo.AadharNumber = Convert.ToString(dr["AadharNumber"]);
            agentInfo.IsActive = Convert.ToBoolean(dr["Active"]);
            agentInfo.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
            agentInfo.CreatedDate = Convert.ToDateTime(dr["CreatedOn"]);
            agentInfo.UpdatedBy = Convert.ToInt32(dr["UpdatedBy"]);
            agentInfo.UpdatedDate = Convert.ToDateTime(dr["UpdatedOn"]);
            return agentInfo;
        }

    }
}
