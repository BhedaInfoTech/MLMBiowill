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
    public class CourierRepo
    {
        SqlHelperRepo _sqlHelper = null;

        public CourierRepo()
        {
            _sqlHelper = new SqlHelperRepo();
        }

        public int Insert(CourierInfo CourierInfo)
        {
            return Convert.ToInt32(_sqlHelper.ExecuteScalerObj(SetValuesInCourierInfo(CourierInfo), StoredProcedureEnum.sp_Insert_Courier.ToString(), CommandType.StoredProcedure));
        }

        public List<SqlParameter> SetValuesInCourierInfo(CourierInfo CourierInfo)
        {

            List<SqlParameter> sqlParam = new List<SqlParameter>();

            if (CourierInfo.Id != 0)
            {
                sqlParam.Add(new SqlParameter("@Id", CourierInfo.Id));
            }
            else
            {
                sqlParam.Add(new SqlParameter("@CreatedBy", CourierInfo.CreatedBy));
            }

            sqlParam.Add(new SqlParameter("@CourierId", CourierInfo.CourierId));

            sqlParam.Add(new SqlParameter("@CourierName", CourierInfo.CourierName));

            sqlParam.Add(new SqlParameter("@ServedPincode", CourierInfo.ServedPincode));

            sqlParam.Add(new SqlParameter("@IsActive", CourierInfo.IsActive));

            sqlParam.Add(new SqlParameter("UpdatedBy", CourierInfo.UpdatedBy));

            return sqlParam;
        }

        public DataTable GetCouriers(string CourierName, ref PaginationInfo pager)
        {

            List<SqlParameter> sqlParam = new List<SqlParameter>();             

            sqlParam.Add(new SqlParameter("@CourierName", CourierName));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, StoredProcedureEnum.sp_Get_Couriers.ToString(), CommandType.StoredProcedure);

            return CommonMethods.GetPaginatedTable(dt, ref pager);
        }

        public void Update(CourierInfo CourierInfo)
        {
            _sqlHelper.ExecuteNonQuery(SetValuesInCourierInfo(CourierInfo), StoredProcedureEnum.sp_Update_Courier.ToString(), CommandType.StoredProcedure);
        }

        public bool CheckCourierNameExist(string courierName)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@CourierName", courierName));

            return Convert.ToBoolean(_sqlHelper.ExecuteScalerObj(sqlParams, StoredProcedureEnum.sp_Check_CourierName_Exist.ToString(), CommandType.StoredProcedure));

        }

        public CourierInfo Get_Courier_By_Id(int CourierId)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            CourierInfo courierInfo = new CourierInfo();
            sqlParams.Add(new SqlParameter("@CourierId", CourierId));
            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParams, StoredProcedureEnum.sp_GetCourierById.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in dt.Rows)
            {
                courierInfo = Get_Courier_Values(dr);
            }
            return courierInfo;
        }

        private CourierInfo Get_Courier_Values(DataRow dr)
        {
            CourierInfo courierInfo = new CourierInfo();

            courierInfo.Id = Convert.ToInt32(dr["Id"]);
            courierInfo.CourierId = Convert.ToString(dr["CourierId"]);
            courierInfo.CourierName = Convert.ToString(dr["CourierName"]);
            courierInfo.ServedPincode = Convert.ToString(dr["ServedPincode"]);
            courierInfo.IsActive = Convert.ToBoolean(dr["Active"]);
            courierInfo.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
            courierInfo.CreatedDate = Convert.ToDateTime(dr["CreatedOn"]);
            courierInfo.UpdatedBy = Convert.ToInt32(dr["UpdatedBy"]);
            courierInfo.UpdatedDate = Convert.ToDateTime(dr["UpdatedOn"]);
            return courierInfo;
        }
    }
}
