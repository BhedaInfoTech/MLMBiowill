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
    public class ContactRepo
    {

        SqlHelperRepo _sqlRepo;

        public ContactRepo()
        {
            _sqlRepo = new SqlHelperRepo();
        }

        public Int32 Insert_ContactMaster(ContactInfo ContInfo)
        {
            return Convert.ToInt32(_sqlRepo.ExecuteScalerObj(Set_Values_In_ContactMaster(ContInfo), StoredProcedureEnum.sp_Insert_ContactMaster.ToString(), CommandType.StoredProcedure));
        }

        public void Update_ContactMaster(ContactInfo ContInfo)
        {
            _sqlRepo.ExecuteNonQuery(Set_Values_In_ContactMaster(ContInfo), StoredProcedureEnum.sp_Update_ContactMaster.ToString(), CommandType.StoredProcedure);
        }

        private List<SqlParameter> Set_Values_In_ContactMaster(ContactInfo ContInfo)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            if (ContInfo.ContactId != 0)
            {
                sqlParams.Add(new SqlParameter("@ContactId", ContInfo.ContactId));
            }
            else
            {
                sqlParams.Add(new SqlParameter("@CreatedBy", ContInfo.CreatedBy));
            }

            sqlParams.Add(new SqlParameter("@ContactType", ContInfo.ContactType));
            sqlParams.Add(new SqlParameter("@ContactFor", ContInfo.ContactFor));
            sqlParams.Add(new SqlParameter("@ObjectId", ContInfo.ObjectId));

            sqlParams.Add(new SqlParameter("@CountryCode", ContInfo.CountryCode));  
            sqlParams.Add(new SqlParameter("@StdCode", ContInfo.StdCode));
            sqlParams.Add(new SqlParameter("@TelMobNumber", ContInfo.TelMobNumber));

            sqlParams.Add(new SqlParameter("@IsDefault", ContInfo.IsDefault));
            sqlParams.Add(new SqlParameter("@Active", ContInfo.IsActive));
            sqlParams.Add(new SqlParameter("@UpdatedBy", ContInfo.UpdatedBy));

            return sqlParams;
        }

        public List<ContactInfo> Get_ContactMasters(ref PaginationInfo pager)
        {
            List<ContactInfo> ContInfos = new List<ContactInfo>();
            DataTable dt = _sqlRepo.ExecuteDataTable(null, StoredProcedureEnum.sp_Get_ContactMaster.ToString(), CommandType.StoredProcedure);
            foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
            {
                ContInfos.Add(Get_ContactMaster_Values(dr));
            }
            return ContInfos;
        }

        public ContactInfo Get_ContactMaster_By_Id(int ContactMasterId)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            ContactInfo ContInfo = new ContactInfo();
            sqlParams.Add(new SqlParameter("@ContactId", ContactMasterId));
            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedureEnum.sp_Get_ContactMaster_By_Id.ToString(), CommandType.StoredProcedure);
            List<DataRow> drList = new List<DataRow>();
            drList = dt.AsEnumerable().ToList();
            foreach (DataRow dr in drList)
            {
                ContInfo = Get_ContactMaster_Values(dr);
            }
            return ContInfo;
        }

        public DataTable Get_ContactMaster_By_Type_For_Id(ContactInfo ContactMasterInfo, ref PaginationInfo pager)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            ContactInfo ContInfo = new ContactInfo();
            //sqlParams.Add(new SqlParameter("@ContactType", ContactMasterInfo.ContactType));
            sqlParams.Add(new SqlParameter("@ContactFor", ContactMasterInfo.ContactFor));
            sqlParams.Add(new SqlParameter("@ObjectId", ContactMasterInfo.ObjectId));
            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedureEnum.sp_Get_ContactMast_By_Type_For_ObjectId.ToString(), CommandType.StoredProcedure);
            //List<DataRow> drList = new List<DataRow>();
            //drList = dt.AsEnumerable().ToList();
            //foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
            //{
            //    ContInfo = Get_ContactMaster_Values(dr);
            //}
            return dt;
        }

        private ContactInfo Get_ContactMaster_Values(DataRow dr)
        {
            ContactInfo ContInfo = new ContactInfo();

            ContInfo.ContactId = Convert.ToInt32(dr["ContactId"]);
            ContInfo.ContactType = Convert.ToString(dr["ContactType"]);
            ContInfo.ContactFor = Convert.ToString(dr["ContactFor"]);
            ContInfo.ObjectId = Convert.ToInt32(dr["ObjectId"]);
            ContInfo.CountryCode = Convert.ToString(dr["CountryCode"]);
            ContInfo.StdCode = Convert.ToString(dr["StdCode"]);
            ContInfo.TelMobNumber = Convert.ToString(dr["TelMobNumber"]);
            ContInfo.IsDefault = Convert.ToBoolean(dr["IsDefault"]);
            ContInfo.IsActive = Convert.ToBoolean(dr["Active"]);
            ContInfo.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
            ContInfo.CreatedOn = Convert.ToDateTime(dr["CreatedOn"]);
            ContInfo.UpdatedBy = Convert.ToInt32(dr["UpdatedBy"]);
            ContInfo.UpdatedOn = Convert.ToDateTime(dr["UpdatedOn"]);
            return ContInfo;
        }

        public void Delete_ContactMaster_By_Id(int ContactMasterId)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("@ContactId", ContactMasterId));
            _sqlRepo.ExecuteNonQuery(sqlParams, StoredProcedureEnum.sp_Delete_ContactMaster_By_Id.ToString(), CommandType.StoredProcedure);
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
