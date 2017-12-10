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

        public DataTable GetWarehouses(string warhouseName, ref PaginationInfo pager)
        {

            List<SqlParameter> sqlParam = new List<SqlParameter>();            

            sqlParam.Add(new SqlParameter("@WarehouseName", warhouseName));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, StoredProcedureEnum.sp_Get_Warehouse.ToString(), CommandType.StoredProcedure);

            return CommonMethods.GetPaginatedTable(dt, ref pager);
        }

        public void Update(WarehouseInfo WarhouseInfo)
        {
            _sqlHelper.ExecuteNonQuery(SetValuesInWarehouseInfo(WarhouseInfo), StoredProcedureEnum.sp_Update_Warehouse.ToString(), CommandType.StoredProcedure);
        }

        public bool CheckWarehouseExist(string warehouseName)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@WarehouseName", warehouseName));

            return Convert.ToBoolean(_sqlHelper.ExecuteScalerObj(sqlParams, StoredProcedureEnum.sp_Check_Warehouse_Exist.ToString(), CommandType.StoredProcedure));

        }

        public WarehouseInfo Get_WarehouseMaster_By_Id(int WarehouseId)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            WarehouseInfo WarehouseInfo = new WarehouseInfo();
            sqlParams.Add(new SqlParameter("@WarehouseId", WarehouseId));
            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParams, StoredProcedureEnum.sp_GetWarehouseById.ToString(), CommandType.StoredProcedure);
             
            foreach (DataRow dr in dt.Rows)
            {
                WarehouseInfo = Get_Warehouse_Values(dr);
            }
            return WarehouseInfo;
        }

        private WarehouseInfo Get_Warehouse_Values(DataRow dr)
        {
            WarehouseInfo WarehouseInfo = new WarehouseInfo();

            WarehouseInfo.Id = Convert.ToInt32(dr["Id"]);
            WarehouseInfo.WarehouseName = Convert.ToString(dr["WarehouseName"]);             
            WarehouseInfo.BranchId = Convert.ToInt32(dr["BranchId"]);
            WarehouseInfo.IsActive = Convert.ToBoolean(dr["Active"]);
            WarehouseInfo.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
            WarehouseInfo.CreatedDate = Convert.ToDateTime(dr["CreatedOn"]);
            WarehouseInfo.UpdatedBy = Convert.ToInt32(dr["UpdatedBy"]);
            WarehouseInfo.UpdatedDate = Convert.ToDateTime(dr["UpdatedOn"]);
            return WarehouseInfo;
        }

    }
}
