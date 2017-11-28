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
    public class BranchRepo
    {
        SqlHelperRepo _sqlHelper = null;

        public BranchRepo()
        {
            _sqlHelper = new SqlHelperRepo();
        }

        public int Insert(BranchInfo branchInfo)
        {
            return Convert.ToInt32(_sqlHelper.ExecuteScalerObj(SetValuesInbranchInfo(branchInfo), StoredProcedureEnum.sp_Insert_Branch.ToString(), CommandType.StoredProcedure));
        }

        public List<SqlParameter> SetValuesInbranchInfo(BranchInfo branchInfo)
        {

            List<SqlParameter> sqlParam = new List<SqlParameter>();

            if (branchInfo.Id != 0)
            {
                sqlParam.Add(new SqlParameter("@BranchId", branchInfo.Id));
            }
            else
            {
                sqlParam.Add(new SqlParameter("@CreatedBy", branchInfo.CreatedBy));
            }

            sqlParam.Add(new SqlParameter("@Name", branchInfo.BranchName));

            sqlParam.Add(new SqlParameter("@GSTNumber", branchInfo.GSTNumber));

            sqlParam.Add(new SqlParameter("@Pan", branchInfo.PANNumber));

            sqlParam.Add(new SqlParameter("@CompanyId", branchInfo.CompanyId));             

            sqlParam.Add(new SqlParameter("@IsActive", branchInfo.Active));            

            sqlParam.Add(new SqlParameter("UpdatedBy", branchInfo.UpdatedBy));

            return sqlParam;
        }

        public DataTable GetBranches(int companyId,string BranchName, ref PaginationInfo pager)
        {

            List<SqlParameter> sqlParam = new List<SqlParameter>();

            sqlParam.Add(new SqlParameter("@CompanyId", companyId));

            sqlParam.Add(new SqlParameter("@BranchName", BranchName));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, StoredProcedureEnum.sp_Get_Branches.ToString(), CommandType.StoredProcedure);

            return CommonMethods.GetPaginatedTable(dt, ref pager);
        }

        public void Update(BranchInfo branchInfo)
        {
            _sqlHelper.ExecuteNonQuery(SetValuesInbranchInfo(branchInfo), StoredProcedureEnum.sp_Update_Branch.ToString(), CommandType.StoredProcedure);
        }
                
        public bool CheckbranchNameExist(string branchName)
        {          

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@BranchName", branchName));            

            return Convert.ToBoolean(_sqlHelper.ExecuteScalerObj(sqlParams, StoredProcedureEnum.sp_Check_Branch_Exist.ToString(), CommandType.StoredProcedure));

        }

        public List<CompanyInfo> GetCompanies()
        {
            List<CompanyInfo> countries = new List<CompanyInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParams, StoredProcedureEnum.sp_drp_Get_Companies.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    countries.Add(GetCompaniesValues(dr));
                }
            }
            return countries;
        }

        private CompanyInfo GetCompaniesValues(DataRow dr)
        {
            CompanyInfo retVal = new CompanyInfo();

            retVal.CompanyId = Convert.ToInt32(dr["Id"]);

            retVal.CompanyName = Convert.ToString(dr["Name"]);

            return retVal;
        }
    }
}
