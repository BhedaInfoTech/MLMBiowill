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

namespace MLMBiowillRepo.Master
{
    public class SeriesRepo
    {
        //SqlHelperRepo _sqlHelper = null;

        //public SeriesRepo()
        //{
        //    _sqlHelper = new SqlHelperRepo();
        //}

        //public int Insert(SeriesInfo SeriesInfo)
        //{
        //    return Convert.ToInt32(_sqlHelper.ExecuteScalerObj(SetValuesInSeriesInfo(SeriesInfo), StoredProcedureEnum.sp_Insert_Branch.ToString(), CommandType.StoredProcedure));
        //}

        //public List<SqlParameter> SetValuesInSeriesInfo(SeriesInfo SeriesInfo)
        //{

        //    List<SqlParameter> sqlParam = new List<SqlParameter>();

        //    if (SeriesInfo.Id != 0)
        //    {
        //        sqlParam.Add(new SqlParameter("@BranchId", SeriesInfo.Id));
        //    }
        //    else
        //    {
        //        sqlParam.Add(new SqlParameter("@CreatedBy", SeriesInfo.CreatedBy));
        //    }

        //    sqlParam.Add(new SqlParameter("@Name", SeriesInfo.BranchName));

        //    sqlParam.Add(new SqlParameter("@GSTNumber", SeriesInfo.GSTNumber));

        //    sqlParam.Add(new SqlParameter("@Pan", SeriesInfo.PANNumber));

        //    sqlParam.Add(new SqlParameter("@CompanyId", SeriesInfo.CompanyId));

        //    sqlParam.Add(new SqlParameter("@IsActive", SeriesInfo.Active));

        //    sqlParam.Add(new SqlParameter("UpdatedBy", SeriesInfo.UpdatedBy));

        //    return sqlParam;
        //}

        //public DataTable GetSeries(int companyId, string BranchName, ref PaginationInfo pager)
        //{

        //    List<SqlParameter> sqlParam = new List<SqlParameter>();

        //    sqlParam.Add(new SqlParameter("@CompanyId", companyId));

        //    sqlParam.Add(new SqlParameter("@BranchName", BranchName));

        //    DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, StoredProcedureEnum.sp_Get_Branches.ToString(), CommandType.StoredProcedure);

        //    return CommonMethods.GetPaginatedTable(dt, ref pager);
        //}

        //public void Update(SeriesInfo SeriesInfo)
        //{
        //    _sqlHelper.ExecuteNonQuery(SetValuesInSeriesInfo(SeriesInfo), StoredProcedureEnum.sp_Update_Branch.ToString(), CommandType.StoredProcedure);
        //}

        //public bool CheckSeriesExist(string branchName)
        //{

        //    List<SqlParameter> sqlParams = new List<SqlParameter>();

        //    sqlParams.Add(new SqlParameter("@BranchName", branchName));

        //    return Convert.ToBoolean(_sqlHelper.ExecuteScalerObj(sqlParams, StoredProcedureEnum.sp_Check_Branch_Exist.ToString(), CommandType.StoredProcedure));

        //}

        //public List<CompanyInfo> GetCompanies()
        //{
        //    List<CompanyInfo> countries = new List<CompanyInfo>();

        //    List<SqlParameter> sqlParams = new List<SqlParameter>();

        //    DataTable dt = _sqlHelper.ExecuteDataTable(sqlParams, StoredProcedureEnum.sp_drp_Get_Companies.ToString(), CommandType.StoredProcedure);

        //    if (dt != null && dt.Rows.Count > 0)
        //    {
        //        foreach (DataRow dr in dt.Rows)
        //        {
        //            countries.Add(GetCompaniesValues(dr));
        //        }
        //    }
        //    return countries;
        //}

        //private CompanyInfo GetCompaniesValues(DataRow dr)
        //{
        //    CompanyInfo retVal = new CompanyInfo();

        //    retVal.CompanyId = Convert.ToInt32(dr["Id"]);

        //    retVal.CompanyName = Convert.ToString(dr["Name"]);

        //    return retVal;
        //}
    }
}
