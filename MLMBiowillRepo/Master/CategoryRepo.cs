using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MLMBiowillRepo;
using MLMBiowillRepo.Utilities;
using MLMBiowillBusinessEntities.Common;
using MLMBiowillBusinessEntities.Master;
using System.Data.SqlClient;
using System.Data;
using MLMBiowillHelper.Logging;

namespace MLMBiowillRepo.Master
{
    public class CategoryRepo
    {
        SqlHelperRepo _sqlHelper = null;

        public CategoryRepo()
        {
            _sqlHelper = new SqlHelperRepo();
        }

        public int Insert(Category category)
        {
            return Convert.ToInt32(_sqlHelper.ExecuteScalerObj(SetValuesInCountry(category), StoredProcedureEnum.sp_Insert_Category.ToString(), CommandType.StoredProcedure));
        }

        private List<SqlParameter> SetValuesInCountry(Category category)
        {

            List<SqlParameter> sqlParam = new List<SqlParameter>();

            if (category.CategoryId != 0)
            {
                sqlParam.Add(new SqlParameter("CategoryId", category.CategoryId));
            }
            else
            {
       
                sqlParam.Add(new SqlParameter("CreatedBy", category.CreatedBy));
            }             

            sqlParam.Add(new SqlParameter("CategoryName", category.CategoryName));

            Logger.Debug("Category Controller CategoryName:" + category.CategoryName);

            sqlParam.Add(new SqlParameter("@IsActive", category.Active));

            Logger.Debug("Category Controller IsActive:" + category.Active);

            sqlParam.Add(new SqlParameter("UpdatedBy", category.UpdatedBy));

       
            return sqlParam;
        }

        public DataTable GetCategories(string categoryName, ref PaginationInfo pager)
        { 
            List<SqlParameter> sqlParam = new List<SqlParameter>();             

            sqlParam.Add(new SqlParameter("@CategoryName", categoryName));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, StoredProcedureEnum.sp_Get_Categories.ToString(), CommandType.StoredProcedure);

            return CommonMethods.GetPaginatedTable(dt, ref pager);
        }

        public void Update(Category category)
        {
            _sqlHelper.ExecuteNonQuery(SetValuesInCountry(category), StoredProcedureEnum.sp_Update_Category.ToString(), CommandType.StoredProcedure);
        }
                 
        public bool CheckCategoryNameExist(string categoryName)
        {

            string ProcedureName = string.Empty;

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@CategoryName", categoryName));

            Logger.Debug("Category Controller categoryName:" + categoryName);

            return Convert.ToBoolean(_sqlHelper.ExecuteScalerObj(sqlParams, StoredProcedureEnum.sp_Check_CategoryName_Exist.ToString(), CommandType.StoredProcedure));

        }
    }
}
