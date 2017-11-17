using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data;            
using MLMBiowillRepo.Utilities;
using MLMBiowillBusinessEntities.City;
using MLMBiowillBusinessEntities.Common;
using MLMBiowillHelper.Logging;
using MLMBiowillBusinessEntities.Country;
using MLMBiowillBusinessEntities.State;

namespace MLMBiowillRepo.Master
{
    public class CityRepo
    {

        SqlHelperRepo _sqlHelper = null;

        public CityRepo()
        {
            _sqlHelper = new SqlHelperRepo();
        }

        public int Insert_CityMaster(CityInfo city)
        {
            return Convert.ToInt32(_sqlHelper.ExecuteScalerObj(SetValuesInCity(city), StoredProcedureEnum.sp_Insert_City.ToString(), CommandType.StoredProcedure));
        }

        public List<SqlParameter> SetValuesInCity(CityInfo city)
        {

            List<SqlParameter> sqlParam = new List<SqlParameter>();

            if (city.CityId != 0)
            {
                sqlParam.Add(new SqlParameter("CityId", city.CityId));
            }
            else
            {
                sqlParam.Add(new SqlParameter("CreatedBy", city.CreatedBy));
            }

            sqlParam.Add(new SqlParameter("CountryId", city.CountryId));

            Logger.Debug("City Controller setCountryId:" + city.CountryId);

            sqlParam.Add(new SqlParameter("StateId", city.StateId));

            Logger.Debug("City Controller SetStateId:" + city.StateId);

            sqlParam.Add(new SqlParameter("CityCode", city.CityCode));

            Logger.Debug("City Controller CityCode:" + city.CityCode);

            sqlParam.Add(new SqlParameter("CityName", city.CityName));

            Logger.Debug("City Controller CityName:" + city.CityName);

            sqlParam.Add(new SqlParameter("IsActive", city.IsActive));

            Logger.Debug("City Controller IsActive:" + city.IsActive);

            sqlParam.Add(new SqlParameter("UpdatedBy", city.UpdatedBy));

       
            return sqlParam;
        }

        public DataTable GetCities(int countryId, int stateId, string cityCode, string cityName, ref PaginationInfo pager)
      
        {

            List<SqlParameter> sqlParam = new List<SqlParameter>();

            sqlParam.Add(new SqlParameter("@CountryId", countryId));            

            sqlParam.Add(new SqlParameter("@StateId", stateId));

            sqlParam.Add(new SqlParameter("@CityCode", cityCode));

            sqlParam.Add(new SqlParameter("@CityName", cityName));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, StoredProcedureEnum.sp_Get_Cities.ToString(), CommandType.StoredProcedure);

            return CommonMethods.GetPaginatedTable(dt, ref pager);         

        }

        private CityInfo GetCitiesValues(DataRow dr)
        {

            CityInfo City = new CityInfo();

            City.CityId = Convert.ToInt32(dr["CityId"]);

            if (!dr.IsNull("CountryId"))
                City.CountryId = Convert.ToInt32(dr["CountryId"]);

            if (!dr.IsNull("CountryName"))
                City.CountryName = Convert.ToString(dr["CountryName"]);

            if (!dr.IsNull("StateId"))
                City.StateId = Convert.ToInt32(dr["StateId"]);

            if (!dr.IsNull("StateName"))
                City.StateName = Convert.ToString(dr["StateName"]);
            
            if (!dr.IsNull("CityCode"))
                City.CityCode = Convert.ToString(dr["CityCode"]);

            if (!dr.IsNull("CityName"))
                City.CityName = Convert.ToString(dr["CityName"]);
            
            if (!dr.IsNull("IsActive"))
                City.IsActive = Convert.ToBoolean(dr["IsActive"]);


            return City;

        }

        public void Update_CityMaster(CityInfo city)
        {
            _sqlHelper.ExecuteNonQuery(SetValuesInCity(city), StoredProcedureEnum.sp_Update_City.ToString(), CommandType.StoredProcedure);
        }

        public bool CheckCityCodeExist(string cityCode)
        {
            string ProcedureName = string.Empty;

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@CityCode", cityCode));

            Logger.Debug("City Controller Check CityCode:" + cityCode);

            return Convert.ToBoolean(_sqlHelper.ExecuteScalerObj(sqlParams, StoredProcedureEnum.sp_Check_CityCode_Exist.ToString(), CommandType.StoredProcedure));

        }

        public bool CheckCityNameExist(string cityName)
        {

            string ProcedureName = string.Empty;

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@CityName", cityName));

            Logger.Debug("City Controller Check CityName:" + cityName);

            return Convert.ToBoolean(_sqlHelper.ExecuteScalerObj(sqlParams, StoredProcedureEnum.sp_Check_CityName_Exist.ToString(), CommandType.StoredProcedure));

        }

        public List<CityInfo> GetCities()
        {
            List<CityInfo> cities = new List<CityInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParams, StoredProcedureEnum.sp_GetCountryStateCity.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    cities.Add(GetCityValues(dr));
                }
            }
            return cities;
        }

        public CityInfo GetCityValues(DataRow dr)
        {
            CityInfo retVal = new CityInfo();

            retVal.CityId = Convert.ToInt32(dr["CityId"]);

            retVal.CityName = Convert.ToString(dr["Name"]);

            return retVal;
        }

    }
}
