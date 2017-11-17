using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data;
using MLMBiowillRepo.Utilities;
using MLMBiowillBusinessEntities.State;
using MLMBiowillBusinessEntities.Common;   
using MLMBiowillHelper.Logging;

namespace MLMBiowillRepo.Master
{
    public class StateRepo
    {

        SqlHelperRepo _sqlHelper = null;

        public StateRepo()
        {
            _sqlHelper = new SqlHelperRepo();
        }

        public int Insert_StateMaster(StateInfo state)
        {
            return Convert.ToInt32(_sqlHelper.ExecuteScalerObj(SetValuesInState(state), StoredProcedureEnum.sp_Insert_State.ToString(), CommandType.StoredProcedure));
        }

        public List<SqlParameter> SetValuesInState(StateInfo state)
        {

            List<SqlParameter> sqlParam = new List<SqlParameter>();

            if (state.StateId != 0)
            {
                sqlParam.Add(new SqlParameter("StateId", state.StateId));
            }
            else
            {
                sqlParam.Add(new SqlParameter("CreatedBy", state.CreatedBy));
            }

            sqlParam.Add(new SqlParameter("CountryId", state.CountryId));

            Logger.Debug("State Controller CountryId:" +state.CountryId);

            sqlParam.Add(new SqlParameter("StateCode", state.StateCode));

            Logger.Debug("State Controller StateCode:" + state.StateCode);

            sqlParam.Add(new SqlParameter("StateName", state.StateName));

            Logger.Debug("State Controller StateName:" + state.StateName);

            sqlParam.Add(new SqlParameter("IsActive", state.IsActive));

            Logger.Debug("State Controller IsActive:" + state.IsActive);

            sqlParam.Add(new SqlParameter("UpdatedBy", state.UpdatedBy));

           
            return sqlParam;
        }

        public DataTable GetStates(int countryId, string stateCode,string stateName, ref PaginationInfo pager)
        {

            List<SqlParameter> sqlParam = new List<SqlParameter>();

            sqlParam.Add(new SqlParameter("@CountryId", countryId));

            sqlParam.Add(new SqlParameter("@StateCode", stateCode));

            sqlParam.Add(new SqlParameter("@StateName", stateName));                    

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, StoredProcedureEnum.sp_Get_States.ToString(), CommandType.StoredProcedure);

            return CommonMethods.GetPaginatedTable(dt, ref pager);
        }

        public void Update_StateMaster(StateInfo state)
        {
            _sqlHelper.ExecuteNonQuery(SetValuesInState(state), StoredProcedureEnum.sp_Update_State.ToString(), CommandType.StoredProcedure);
        }

        public bool CheckStateCodeExist(string stateCode)
        {
            string ProcedureName = string.Empty;

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@StateCode", stateCode));

            Logger.Debug("State Controller StateCode:" + stateCode);

            return Convert.ToBoolean(_sqlHelper.ExecuteScalerObj(sqlParams, StoredProcedureEnum.sp_Check_StateCode_Exist.ToString(), CommandType.StoredProcedure));

        }

        public bool CheckStateNameExist(string stateName)
        {

            string ProcedureName = string.Empty;

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@StateName", stateName));

            Logger.Debug("State Controller StateName:" + stateName);

            return Convert.ToBoolean(_sqlHelper.ExecuteScalerObj(sqlParams, StoredProcedureEnum.sp_Check_StateName_Exist.ToString(), CommandType.StoredProcedure));

        }

        public List<StateInfo> Getstates()
        {
            List<StateInfo> states = new List<StateInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParams, StoredProcedureEnum.sp_drp_Get_States.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    states.Add(GetStateValues(dr));
                }
            }
            return states;
        }

        public StateInfo GetStateValues(DataRow dr)
        {
            StateInfo retVal = new StateInfo();

            retVal.StateId = Convert.ToInt32(dr["StateId"]);

            retVal.StateName = Convert.ToString(dr["StateName"]);

            return retVal;
        }

        public List<StateInfo> GetStatesByCountryId(int countryId)
        {
            List<StateInfo> states = new List<StateInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@CountryId", countryId));
        
            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParams, StoredProcedureEnum.sp_Get_States_By_CountryId.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    states.Add(GetStateValues(dr));
                }
            }
            return states;
        }



    }
}
