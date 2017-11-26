using MLMBiowillRepo.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MLMBiowillBusinessEntities.Master;
using MLMBiowillBusinessEntities.Common;
using System.Data;
using System.Data.SqlClient;

namespace MLMBiowillRepo.Master
{
    public class DepartmentRepo
    {
        SqlHelperRepo _sqlHelper = null;

        public DepartmentRepo()
        {
            _sqlHelper = new SqlHelperRepo();
        }

        public int Insert(DepartmentInfo departmentInfo)
        {
            return Convert.ToInt32(_sqlHelper.ExecuteScalerObj(SetValuesIndepartmentInfo(departmentInfo), StoredProcedureEnum.sp_Insert_Department.ToString(), CommandType.StoredProcedure));
        }

        public List<SqlParameter> SetValuesIndepartmentInfo(DepartmentInfo departmentInfo)
        {

            List<SqlParameter> sqlParam = new List<SqlParameter>();

            if (departmentInfo.Id != 0)
            {
                sqlParam.Add(new SqlParameter("@DepartmentId", departmentInfo.Id));
            }
            else
            {
                sqlParam.Add(new SqlParameter("@CreatedBy", departmentInfo.CreatedBy));
            }

            sqlParam.Add(new SqlParameter("@Department", departmentInfo.DepartmentName));     

            sqlParam.Add(new SqlParameter("@IsActive", departmentInfo.Active));
             
            sqlParam.Add(new SqlParameter("@UpdatedBy", departmentInfo.UpdatedBy));

            return sqlParam;
        }

        public DataTable GetDepartments(string departmentInfoName, ref PaginationInfo pager)
        {

            List<SqlParameter> sqlParam = new List<SqlParameter>();             

            sqlParam.Add(new SqlParameter("@DepartmentName", departmentInfoName));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, StoredProcedureEnum.sp_Get_Deparments.ToString(), CommandType.StoredProcedure);

            return CommonMethods.GetPaginatedTable(dt, ref pager);
        }

        public void Update(DepartmentInfo departmentInfo)
        {
            _sqlHelper.ExecuteNonQuery(SetValuesIndepartmentInfo(departmentInfo), StoredProcedureEnum.sp_Update_Department.ToString(), CommandType.StoredProcedure);
        }        

        public bool CheckdepartmentInfoNameExist(string departmentName)
        {             

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@DepartmentName", departmentName));             

            return Convert.ToBoolean(_sqlHelper.ExecuteScalerObj(sqlParams, StoredProcedureEnum.sp_Check_Department_Exist.ToString(), CommandType.StoredProcedure));

        } 
    }
}
