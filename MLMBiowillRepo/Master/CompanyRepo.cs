﻿using MLMBiowillBusinessEntities;
using MLMBiowillBusinessEntities.Common;
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
        public void Insert_CompanyMaster(CompanyInfo CompanyMaster)
        {
            _sqlRepo.ExecuteNonQuery(SetValuesCompanyMaster(CompanyMaster), StoredProcedureEnum.Save_CompanyMaster.ToString(), CommandType.StoredProcedure);
        }

        public void Update_CompanyMaster(CompanyInfo CompanyMaster)
        {
            _sqlRepo.ExecuteNonQuery(SetValuesCompanyMaster(CompanyMaster), StoredProcedureEnum.Save_CompanyMaster.ToString(), CommandType.StoredProcedure);
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
            //sqlParams.Add(new SqlParameter("@CreatedOn", CompanyMaster.CreatedOn));
            sqlParams.Add(new SqlParameter("@UpdatedBy", CompanyMaster.UpdatedBy));
            //sqlParams.Add(new SqlParameter("@UpdatedOn", CompanyMaster.UpdatedOn));
            return sqlParams;
        }

        #endregion

        #region Get Methods from Procedure
        public DataTable Get_CompanyMaster(int CompanyMasterId, ref PaginationInfo pager)
        {

            List<SqlParameter> sqlParam = new List<SqlParameter>();

            sqlParam.Add(new SqlParameter("@CompanyId", CompanyMasterId));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParam, StoredProcedureEnum.Get_CompanyMaster.ToString(), CommandType.StoredProcedure);

            return CommonMethods.GetPaginatedTable(dt, ref pager);

        }

        public List<CompanyInfo> Get_CompanyMasters(ref PaginationInfo pager)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            List<CompanyInfo> CompanyMasters = new List<CompanyInfo>();
            int CompanyMasterId = 0;
            sqlParams.Add(new SqlParameter("@CompanyId", CompanyMasterId));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedureEnum.Get_CompanyMaster.ToString(), CommandType.StoredProcedure);
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
            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedureEnum.Get_CompanyMaster.ToString(), CommandType.StoredProcedure);
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

            CompanyMaster.CompanyId = Convert.ToInt32(dr["Id"]);
            CompanyMaster.CompanyName = Convert.ToString(dr["Name"]);
            CompanyMaster.GSTNumber = Convert.ToString(dr["GSTNumber"]);
            CompanyMaster.PAN = Convert.ToString(dr["PAN"]);
            CompanyMaster.IsActive = Convert.ToBoolean(dr["Active"]);
            CompanyMaster.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
            CompanyMaster.CreatedOn = Convert.ToDateTime(dr["CreatedOn"]);
            CompanyMaster.UpdatedBy = Convert.ToInt32(dr["UpdatedBy"]);
            CompanyMaster.UpdatedOn = Convert.ToDateTime(dr["UpdatedOn"]);
            return CompanyMaster;
        }

        #endregion


        public void Delete_CompanyMaster_By_Id(int CompanyMasterId)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("@CompanyId", CompanyMasterId));
            _sqlRepo.ExecuteNonQuery(sqlParams, StoredProcedureEnum.Delete_CompanyMaster_By_Id.ToString(), CommandType.StoredProcedure);
        }
    
}
}