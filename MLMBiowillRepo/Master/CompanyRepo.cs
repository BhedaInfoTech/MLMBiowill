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
    public class CompanyRepo
    {
        SqlHelperRepo _sqlRepo;

        public CompanyRepo()
        {
            _sqlRepo = new SqlHelperRepo();
        }

        #region Push/Put Methods in Procedure
        public int Insert_CompanyMaster(CompanyInfo CompanyMaster)
        {
            int CompanyMasterId = Convert.ToInt32(_sqlRepo.ExecuteScalerObj(SetValuesCompanyMaster(CompanyMaster), StoredProcedureEnum.sp_Save_CompanyMaster.ToString(), CommandType.StoredProcedure));

            return CompanyMasterId;
        }

        public void Update_CompanyMaster(CompanyInfo CompanyMaster)
        {
            _sqlRepo.ExecuteNonQuery(SetValuesCompanyMaster(CompanyMaster), StoredProcedureEnum.sp_Save_CompanyMaster.ToString(), CommandType.StoredProcedure);
        }

        private List<SqlParameter> SetValuesCompanyMaster(CompanyInfo CompanyMaster)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("@CompanyId", CompanyMaster.CompanyId));
            sqlParams.Add(new SqlParameter("@Name", CompanyMaster.CompanyName));
            sqlParams.Add(new SqlParameter("@GSTNumber", CompanyMaster.GSTNumber));
            sqlParams.Add(new SqlParameter("@PAN", CompanyMaster.PAN));
            sqlParams.Add(new SqlParameter("@Active", CompanyMaster.IsActive));
            sqlParams.Add(new SqlParameter("@CreatedBy", CompanyMaster.CreatedBy));
            //sqlParams.Add(new SqlParameter("@CreatedOn", CompanyMaster.CreatedDate));
            sqlParams.Add(new SqlParameter("@UpdatedBy", CompanyMaster.UpdatedBy));
            //sqlParams.Add(new SqlParameter("@UpdatedOn", CompanyMaster.UpdatedDate));
            return sqlParams;
        }

        #endregion

        #region Get Methods from Procedure
        public DataTable Get_CompanyMaster(int CompanyMasterId, ref PaginationInfo pager)
        {

            List<SqlParameter> sqlParam = new List<SqlParameter>();
                                                 
            sqlParam.Add(new SqlParameter("@CompanyId", CompanyMasterId));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParam, StoredProcedureEnum.sp_Get_CompanyMaster.ToString(), CommandType.StoredProcedure);

            return CommonMethods.GetPaginatedTable(dt, ref pager);

        }

        public List<CompanyInfo> Get_CompanyMasters(ref PaginationInfo pager)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            List<CompanyInfo> CompanyMasters = new List<CompanyInfo>();
            int CompanyMasterId = 0;
            sqlParams.Add(new SqlParameter("@CompanyId", CompanyMasterId));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedureEnum.sp_Get_CompanyMaster.ToString(), CommandType.StoredProcedure);
            foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
            {
                CompanyMasters.Add(Get_CompanyMaster_Values(dr));
            }
            return CompanyMasters;
        }

        public CompanyInfo Get_CompanyMaster_By_Id(int CompanyMasterId)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            CompanyInfo CompanyMaster = new CompanyInfo();
            sqlParams.Add(new SqlParameter("@CompanyId", CompanyMasterId));
            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedureEnum.sp_Get_CompanyMaster.ToString(), CommandType.StoredProcedure);
            List<DataRow> drList = new List<DataRow>();
            drList = dt.AsEnumerable().ToList();
            foreach (DataRow dr in drList)
            {
                CompanyMaster = Get_CompanyMaster_Values(dr);
            }
            return CompanyMaster;
        }

        private CompanyInfo Get_CompanyMaster_Values(DataRow dr)
        {
            CompanyInfo CompanyMaster = new CompanyInfo();

            CompanyMaster.CompanyId = Convert.ToInt32(dr["CompanyId"]);
            CompanyMaster.CompanyName = Convert.ToString(dr["CompanyName"]);
            CompanyMaster.GSTNumber = Convert.ToString(dr["GSTNumber"]);
            CompanyMaster.PAN = Convert.ToString(dr["PAN"]);
            CompanyMaster.IsActive = Convert.ToBoolean(dr["Active"]);
            CompanyMaster.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
            CompanyMaster.CreatedDate = Convert.ToDateTime(dr["CreatedOn"]);
            CompanyMaster.UpdatedBy = Convert.ToInt32(dr["UpdatedBy"]);
            CompanyMaster.UpdatedDate = Convert.ToDateTime(dr["UpdatedOn"]);
            return CompanyMaster;
        }

        public Boolean Check_CompanyName(string CompanyName)
        {
            bool Is_Exist = false;
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            sqlParam.Add(new SqlParameter("@CompanyName", CompanyName));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParam, StoredProcedureEnum.sp_Check_CompanyName_Exist.ToString(), CommandType.StoredProcedure);
            if(dt.Rows.Count> 0)
            {
                Is_Exist = Convert.ToBoolean(dt.Rows[0][0]);
            }

            return Is_Exist;
        }

        #endregion


        public void Delete_CompanyMaster_By_Id(int CompanyMasterId)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("@CompanyId", CompanyMasterId));
            _sqlRepo.ExecuteNonQuery(sqlParams, StoredProcedureEnum.sp_Delete_CompanyMaster_By_Id.ToString(), CommandType.StoredProcedure);
        }
    
}
}
