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
    public class WarehouseRepo
    {
        SqlHelperRepo _sqlHelper = null;

        public WarehouseRepo()
        {
            _sqlHelper = new SqlHelperRepo();
        }

        public int Insert(WarehouseInfo WarhouseInfo)
        {
            return Convert.ToInt32(_sqlHelper.ExecuteScalerObj(SetValuesInWarehouseInfo(WarhouseInfo), StoredProcedureEnum.sp_Insert_Warehouse.ToString(), CommandType.StoredProcedure));
        }

        public List<SqlParameter> SetValuesInWarehouseInfo(WarehouseInfo WarhouseInfo)
        {

            List<SqlParameter> sqlParam = new List<SqlParameter>();

            if (WarhouseInfo.Id != 0)
            {
                sqlParam.Add(new SqlParameter("@WarehouseId", WarhouseInfo.Id));
            }
            else
            {
                sqlParam.Add(new SqlParameter("@CreatedBy", WarhouseInfo.CreatedBy));
            }

            sqlParam.Add(new SqlParameter("@Warehouse", WarhouseInfo.WarehouseName));            

            sqlParam.Add(new SqlParameter("@BranchId", WarhouseInfo.BranchId));

            sqlParam.Add(new SqlParameter("@IsActive", WarhouseInfo.IsActive));

            sqlParam.Add(new SqlParameter("UpdatedBy", WarhouseInfo.UpdatedBy));

            return sqlParam;
        }

        public DataTable GetWarehouses(int branchId, string warhouseName, ref PaginationInfo pager)
        {

            List<SqlParameter> sqlParam = new List<SqlParameter>();

            sqlParam.Add(new SqlParameter("@BranchId", branchId));

            sqlParam.Add(new SqlParameter("@WarehouseName", warhouseName));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, StoredProcedureEnum.sp_Get_Warehouse.ToString(), CommandType.StoredProcedure);

            return CommonMethods.GetPaginatedTable(dt, ref pager);
        }

        public void Update(WarehouseInfo WarhouseInfo)
        {
            _sqlHelper.ExecuteNonQuery(SetValuesInWarehouseInfo(WarhouseInfo), StoredProcedureEnum.sp_Update_Branch.ToString(), CommandType.StoredProcedure);
        }

        public bool CheckWarehouseExist(string warehouseName)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@WarehouseName", warehouseName));

            return Convert.ToBoolean(_sqlHelper.ExecuteScalerObj(sqlParams, StoredProcedureEnum.sp_Check_Warehouse_Exist.ToString(), CommandType.StoredProcedure));

        }
         
    }
}
