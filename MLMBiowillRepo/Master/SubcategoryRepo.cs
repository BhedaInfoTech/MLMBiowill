using MLMBiowillBusinessEntities.Common;
using MLMBiowillRepo.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MLMBiowillBusinessEntities.Master;
using System.Data.SqlClient;
using System.Data;

namespace MLMBiowillRepo.Master
{
    public class SubcategoryRepo
    {
        SqlHelperRepo _sqlHelper = null;

        public SubcategoryRepo()
        {
            _sqlHelper = new SqlHelperRepo();
        }

        public int Insert(SubcategoryInfo subcategory)
        {
            return Convert.ToInt32(_sqlHelper.ExecuteScalerObj(SetValuesInSubcategory(subcategory), StoredProcedureEnum.sp_Insert_Subcategory.ToString(), CommandType.StoredProcedure));
        }

        public List<SqlParameter> SetValuesInSubcategory(SubcategoryInfo subcategoryInfo)
        {

            List<SqlParameter> sqlParam = new List<SqlParameter>();

            if (subcategoryInfo.Id != 0)
            {
                sqlParam.Add(new SqlParameter("@SubcategoryId", subcategoryInfo.Id));
            }
            else
            {
                sqlParam.Add(new SqlParameter("@CreatedBy", subcategoryInfo.CreatedBy));
            }

            sqlParam.Add(new SqlParameter("@CategoryId", subcategoryInfo.CategoryId));             

            sqlParam.Add(new SqlParameter("@Name", subcategoryInfo.SubCategoryName));            

            sqlParam.Add(new SqlParameter("@IsActive", subcategoryInfo.Active));            

            sqlParam.Add(new SqlParameter("UpdatedBy", subcategoryInfo.UpdatedBy));

            return sqlParam;
        }

        public DataTable GetSubcategories(int CategoryId, string countryName, ref PaginationInfo pager)
        {

            List<SqlParameter> sqlParam = new List<SqlParameter>();

            sqlParam.Add(new SqlParameter("@CategoryId", CategoryId));

            sqlParam.Add(new SqlParameter("@SubcategoryName", countryName));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, StoredProcedureEnum.sp_Get_Subcategories.ToString(), CommandType.StoredProcedure);

            return CommonMethods.GetPaginatedTable(dt, ref pager);
        }

        public void Update_Subcategory(SubcategoryInfo subcategory)
        {
            _sqlHelper.ExecuteNonQuery(SetValuesInSubcategory(subcategory), StoredProcedureEnum.sp_Update_Subcategory.ToString(), CommandType.StoredProcedure);
        }         

        public bool CheckSubcategoryExist(string subcategory)
        {

            string ProcedureName = string.Empty;

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@SubcategoryName", subcategory));             

            return Convert.ToBoolean(_sqlHelper.ExecuteScalerObj(sqlParams, StoredProcedureEnum.sp_Check_Subcategory_Exist.ToString(), CommandType.StoredProcedure));

        }

        public List<Category> GetCategories()
        {
            List<Category> categories = new List<Category>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParams, StoredProcedureEnum.sp_GetCategories.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    categories.Add(GetCategoryValues(dr));
                }
            }
            return categories;
        }

        private Category GetCategoryValues(DataRow dr)
        {
            Category retVal = new Category();

            retVal.CategoryId = Convert.ToInt32(dr["Id"]);

            retVal.CategoryName = Convert.ToString(dr["Name"]);

            return retVal;
        }
    }
}
