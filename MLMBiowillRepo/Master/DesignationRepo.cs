using MLMBiowillRepo.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MLMBiowillBusinessEntities.Master;
using MLMBiowillBusinessEntities.Common;
using System.Data.SqlClient;
using System.Data;

namespace MLMBiowillRepo.Master
{
    public class DesignationRepo
    {
        SqlHelperRepo _sqlHelper = null;

        public DesignationRepo()
        {
            _sqlHelper = new SqlHelperRepo();
        }

        public int Insert(DesignationInfo designationInfo)
        {
            return Convert.ToInt32(_sqlHelper.ExecuteScalerObj(SetValuesIndesignationInfo(designationInfo), StoredProcedureEnum.sp_Insert_Designation.ToString(), CommandType.StoredProcedure));
        }

        public List<SqlParameter> SetValuesIndesignationInfo(DesignationInfo designationInfo)
        {

            List<SqlParameter> sqlParam = new List<SqlParameter>();

            if (designationInfo.Id != 0)
            {
                sqlParam.Add(new SqlParameter("@DesignationId", designationInfo.Id));
            }
            else
            {
                sqlParam.Add(new SqlParameter("@CreatedBy", designationInfo.CreatedBy));
            }

            sqlParam.Add(new SqlParameter("@Designation", designationInfo.DesignationName));         

            sqlParam.Add(new SqlParameter("@IsActive", designationInfo.Active));            

            sqlParam.Add(new SqlParameter("@UpdatedBy", designationInfo.UpdatedBy));

            return sqlParam;
        }

        public DataTable GetDesignation(string designationName, ref PaginationInfo pager)
        {

            List<SqlParameter> sqlParam = new List<SqlParameter>();

            sqlParam.Add(new SqlParameter("@DesignationName", designationName));             

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, StoredProcedureEnum.sp_Get_Designations.ToString(), CommandType.StoredProcedure);

            return CommonMethods.GetPaginatedTable(dt, ref pager);
        }

        public void Update(DesignationInfo designationInfo)
        {
            _sqlHelper.ExecuteNonQuery(SetValuesIndesignationInfo(designationInfo), StoredProcedureEnum.sp_Update_Designation.ToString(), CommandType.StoredProcedure);
        }               

        public bool CheckDesignationExist(string bankName)
        {

            string ProcedureName = string.Empty;

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Designation", bankName));

            return Convert.ToBoolean(_sqlHelper.ExecuteScalerObj(sqlParams, StoredProcedureEnum.sp_Check_Designation_Exist.ToString(), CommandType.StoredProcedure));

        }
    }
}
