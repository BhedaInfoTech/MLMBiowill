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
            return Convert.ToInt32(_sqlHelper.ExecuteScalerObj(SetValuesInCountry(category), StoredProcedureEnum.spInsertCategory.ToString(), CommandType.StoredProcedure));
        }

        public List<SqlParameter> SetValuesInCountry(Category category)
        {

            List<SqlParameter> sqlParam = new List<SqlParameter>();

            if (category.CategoryId != 0)
            {
                sqlParam.Add(new SqlParameter("CategoryId", category.CategoryId));
            }
            else
            {
                sqlParam.Add(new SqlParameter("CreatedDate", category.CreatedDate));

                sqlParam.Add(new SqlParameter("CreatedBy", category.CreatedBy));
            }             

            sqlParam.Add(new SqlParameter("CategoryName", category.CategoryName));

            Logger.Debug("Category Controller CategoryName:" + category.CategoryName);

            sqlParam.Add(new SqlParameter("@IsActive", category.Active));

            Logger.Debug("Category Controller IsActive:" + category.Active);

            sqlParam.Add(new SqlParameter("UpdatedBy", category.UpdatedBy));

            sqlParam.Add(new SqlParameter("UpdatedDate", category.UpdatedDate));

            return sqlParam;
        }

        public DataTable GetCountries(string categoryName, ref PaginationInfo pager)
        {

            List<SqlParameter> sqlParam = new List<SqlParameter>();             

            sqlParam.Add(new SqlParameter("@CategoryName", categoryName));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, StoredProcedureEnum.spGetCategories.ToString(), CommandType.StoredProcedure);

            return CommonMethods.GetPaginatedTable(dt, ref pager);
        }

        public void Update(Category category)
        {
            _sqlHelper.ExecuteNonQuery(SetValuesInCountry(category), StoredProcedureEnum.spUpdateCategory.ToString(), CommandType.StoredProcedure);
        }
                 
        public bool CheckCategoryNameExist(string categoryName)
        {

            string ProcedureName = string.Empty;

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@CategoryName", categoryName));

            Logger.Debug("Category Controller categoryName:" + categoryName);

            return Convert.ToBoolean(_sqlHelper.ExecuteScalerObj(sqlParams, StoredProcedureEnum.spCheckCategoryNameExist.ToString(), CommandType.StoredProcedure));

        }
    }
}
