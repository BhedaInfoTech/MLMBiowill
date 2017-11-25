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
    public class ContactPersonRepo
    {

        SqlHelperRepo _sqlRepo;

        public ContactPersonRepo()
        {
            _sqlRepo = new SqlHelperRepo();
        }

        public Int32 Insert_ContactPersonMaster(ContactPersonInfo ContPerInfo)
        {
            return Convert.ToInt32(_sqlRepo.ExecuteScalerObj(Set_Values_In_ContactPersonMaster(ContPerInfo), StoredProcedureEnum.sp_Insert_ContactPersonMaster.ToString(), CommandType.StoredProcedure));
        }

        public void Update_ContactPersonMaster(ContactPersonInfo ContPerInfo)
        {
            _sqlRepo.ExecuteNonQuery(Set_Values_In_ContactPersonMaster(ContPerInfo), StoredProcedureEnum.sp_Update_ContactPersonMaster.ToString(), CommandType.StoredProcedure);
        }

        private List<SqlParameter> Set_Values_In_ContactPersonMaster(ContactPersonInfo ContPerInfo)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            if (ContPerInfo.ContactPersonId != 0)
            {
                sqlParams.Add(new SqlParameter("@ContactPersonId", ContPerInfo.ContactPersonId));
            }
            else
            {
                sqlParams.Add(new SqlParameter("@CreatedBy", ContPerInfo.CreatedBy));
            }
                                                                                    
            sqlParams.Add(new SqlParameter("@ContactFor", ContPerInfo.ContactFor));
            sqlParams.Add(new SqlParameter("@ObjectId", ContPerInfo.ObjectId));
                                                                                        

            sqlParams.Add(new SqlParameter("@IsDefault", ContPerInfo.IsDefault));
            sqlParams.Add(new SqlParameter("@Active", ContPerInfo.IsActive));
            sqlParams.Add(new SqlParameter("@UpdatedBy", ContPerInfo.UpdatedBy));

            return sqlParams;
        }

        public List<ContactPersonInfo> Get_ContactPersonMasters(ref PaginationInfo pager)
        {
            List<ContactPersonInfo> ContPerInfos = new List<ContactPersonInfo>();
            DataTable dt = _sqlRepo.ExecuteDataTable(null, StoredProcedureEnum.sp_Get_ContactPersonMaster.ToString(), CommandType.StoredProcedure);
            foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
            {
                ContPerInfos.Add(Get_ContactPersonMaster_Values(dr));
            }
            return ContPerInfos;
        }

        public ContactPersonInfo Get_ContactPersonMaster_By_Id(int ContactPersonMasterId)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            ContactPersonInfo ContPerInfo = new ContactPersonInfo();
            sqlParams.Add(new SqlParameter("@ContactPersonId", ContactPersonMasterId));
            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedureEnum.sp_Get_ContactPersonMaster_By_Id.ToString(), CommandType.StoredProcedure);
            List<DataRow> drList = new List<DataRow>();
            drList = dt.AsEnumerable().ToList();
            foreach (DataRow dr in drList)
            {
                ContPerInfo = Get_ContactPersonMaster_Values(dr);
            }
            return ContPerInfo;
        }

        public DataTable Get_ContactPersonMaster_By_Type_For_Id(ContactPersonInfo ContactPersonMasterInfo, ref PaginationInfo pager)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            ContactPersonInfo ContPerInfo = new ContactPersonInfo();
            //sqlParams.Add(new SqlParameter("@ContactType", ContactPersonMasterInfo.ContactType));
            sqlParams.Add(new SqlParameter("@ContactFor", ContactPersonMasterInfo.ContactFor));
            sqlParams.Add(new SqlParameter("@ObjectId", ContactPersonMasterInfo.ObjectId));
            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedureEnum.sp_Get_ContactPersMast_By_Type_For_ObjectId.ToString(), CommandType.StoredProcedure);
            //List<DataRow> drList = new List<DataRow>();
            //drList = dt.AsEnumerable().ToList();
            //foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
            //{
            //    ContPerInfo = Get_ContactPersonMaster_Values(dr);
            //}
            return dt;
        }

        private ContactPersonInfo Get_ContactPersonMaster_Values(DataRow dr)
        {
            ContactPersonInfo ContPerInfo = new ContactPersonInfo();

            ContPerInfo.ContactPersonId = Convert.ToInt32(dr["ContactPersonId"]);
            ContPerInfo.ContactType = Convert.ToString(dr["ContactType"]);
            ContPerInfo.ContactFor = Convert.ToString(dr["ContactFor"]);
            ContPerInfo.ObjectId = Convert.ToInt32(dr["ObjectId"]);
            ContPerInfo.CountryCode = Convert.ToString(dr["CountryCode"]);
            ContPerInfo.StdCode = Convert.ToString(dr["StdCode"]);
            ContPerInfo.TelMobNumber = Convert.ToString(dr["TelMobNumber"]);
            ContPerInfo.IsDefault = Convert.ToBoolean(dr["IsDefault"]);
            ContPerInfo.IsActive = Convert.ToBoolean(dr["Active"]);
            ContPerInfo.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
            ContPerInfo.CreatedDate = Convert.ToDateTime(dr["CreatedOn"]);
            ContPerInfo.UpdatedBy = Convert.ToInt32(dr["UpdatedBy"]);
            ContPerInfo.UpdatedDate = Convert.ToDateTime(dr["UpdatedOn"]);
            return ContPerInfo;
        }

        public void Delete_ContactPersonMaster_By_Id(int ContactPersonMasterId)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("@ContactPersonId", ContactPersonMasterId));
            _sqlRepo.ExecuteNonQuery(sqlParams, StoredProcedureEnum.sp_Delete_ContactPersonMaster_By_Id.ToString(), CommandType.StoredProcedure);
        }


        //public bool CheckContactType(string ContactType, string ContactFor, string ObjectId)
        //{
        //    Boolean IsExists = false;
        //    List<SqlParameter> sqlParams = new List<SqlParameter>();
        //    sqlParams.Add(new SqlParameter("@ContactType", ContactType));
        //    sqlParams.Add(new SqlParameter("@ContactFor", ContactFor));
        //    sqlParams.Add(new SqlParameter("@ObjectId", ObjectId));
        //    DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedureEnum.sp_Check_ContactType.ToString(), CommandType.StoredProcedure);
        //    if (dt.Rows.Count > 0)
        //    {
        //        IsExists = true;
        //    }

        //    return IsExists;
        //}
    }
}
