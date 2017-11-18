using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;          
using MLMBiowillRepo.Utilities;
using MLMBiowillBusinessEntities.Country;
using MLMBiowillBusinessEntities.Common;
using MLMBiowillHelper.Logging;
using System.Text;
using System.Threading.Tasks;

namespace MLMBiowillRepo.Master
{
    public class CountryRepo
    {

        SqlHelperRepo _sqlHelper = null;

        public CountryRepo()
        {
            _sqlHelper = new SqlHelperRepo();
        }

        public int Insert(CountryInfo country)
        {
            return Convert.ToInt32(_sqlHelper.ExecuteScalerObj(SetValuesInCountry(country), StoredProcedureEnum.sp_Insert_Country.ToString(), CommandType.StoredProcedure));
        }

        public List<SqlParameter> SetValuesInCountry(CountryInfo country)
        {

            List<SqlParameter> sqlParam = new List<SqlParameter>();

            if (country.CountryId != 0)
            {
                sqlParam.Add(new SqlParameter("CountryId", country.CountryId));
            }
            else
            {   
                sqlParam.Add(new SqlParameter("CreatedBy", country.CreatedBy));
            }

            sqlParam.Add(new SqlParameter("CountryCode", country.CountryCode));

            Logger.Debug("Country Controller CountryCode:" + country.CountryCode);

            sqlParam.Add(new SqlParameter("CountryName", country.CountryName));

            Logger.Debug("Country Controller CountryName:" + country.CountryName);

            sqlParam.Add(new SqlParameter("@IsActive", country.IsActive));

            Logger.Debug("Country Controller IsActive:" + country.IsActive);

            sqlParam.Add(new SqlParameter("UpdatedBy", country.UpdatedBy));
            
            return sqlParam;
        }

		public DataTable GetCountries(string countryCode, string countryName, ref PaginationInfo pager)
        {

            List<SqlParameter> sqlParam = new List<SqlParameter>();

            sqlParam.Add(new SqlParameter("@CountryCode", countryCode));

            sqlParam.Add(new SqlParameter("@CountryName", countryName));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, StoredProcedureEnum.sp_Get_Countries.ToString(), CommandType.StoredProcedure);

			return CommonMethods.GetPaginatedTable(dt, ref pager);
        }      

        public void Update(CountryInfo country)
        {
            _sqlHelper.ExecuteNonQuery(SetValuesInCountry(country), StoredProcedureEnum.sp_Update_Country.ToString(), CommandType.StoredProcedure);
        }

        public bool CheckCountryCodeExist(string countryCode)
        {
            bool Check = false;

            string ProcedureName = string.Empty;

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@CountryCode", countryCode));

            Logger.Debug("Country Controller CountryCode:" + countryCode);

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParams, StoredProcedureEnum.sp_Check_Country_Code_Exist.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                int count = dt.Rows.Count;

                List<DataRow> drList = new List<DataRow>();

                drList = dt.AsEnumerable().ToList();

                foreach (DataRow dr in drList)
                {
                    Check = Convert.ToBoolean(dr["CountryCodeCount"]);
                }
            }

            return Check;
        }

        public bool CheckCountryNameExist(string countryName)
        {

            string ProcedureName = string.Empty;

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@CountryName", countryName));

            Logger.Debug("Country Controller CountryName:" +countryName);

            return Convert.ToBoolean(_sqlHelper.ExecuteScalerObj(sqlParams, StoredProcedureEnum.sp_Check_Country_Name_Exist.ToString(), CommandType.StoredProcedure));

        }

        public List<CountryInfo> GetCountries()
        {
            List<CountryInfo> countries = new List<CountryInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParams, StoredProcedureEnum.sp_drp_Get_Countries.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    countries.Add(GetCountryValues(dr));
                }
            }
            return countries;
        }

        private CountryInfo GetCountryValues(DataRow dr)
        {
            CountryInfo retVal = new CountryInfo();

            retVal.CountryId = Convert.ToInt32(dr["CountryId"]);

            retVal.CountryName = Convert.ToString(dr["CountryName"]);

            return retVal;
        }
    }
}




















//public CountryInfo Get_Country_By_Id(int CountryId)
//{
//    CountryInfo Country = new CountryInfo();

//    DataTable dt = null;

//    List<SqlParameter> sqlParamList = new List<SqlParameter>();

//    sqlParamList.Add(new SqlParameter("@CountryId", CountryId));

//    dt = _sqlHelper.ExecuteDataTable(sqlParamList, StoredProcedureEnum.sp_Get_Country_By_Id.ToString(), CommandType.StoredProcedure);

//    foreach (DataRow dr in dt.Rows)
//    {

//        if (!dr.IsNull("CountryCode"))
//        {
//            Country.CountryCode = Convert.ToString(dr["CountryCode"]);
//        }

//        if (!dr.IsNull("CountryName"))
//        {
//            Country.CountryName = Convert.ToString(dr["CountryName"]);
//        }
//    }
//    return Country;
//}
