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

            sqlParams.Add(new SqlParameter("@ObjectFor", ContPerInfo.ContactPersonFor));
            sqlParams.Add(new SqlParameter("@FirstName", ContPerInfo.FirstName));
            sqlParams.Add(new SqlParameter("@LastName", ContPerInfo.LastName));
            sqlParams.Add(new SqlParameter("@MiddleName", ContPerInfo.MiddleName));
            sqlParams.Add(new SqlParameter("@EmailId", ContPerInfo.EmailId));


            sqlParams.Add(new SqlParameter("@IsDefault", ContPerInfo.IsDefault));
            sqlParams.Add(new SqlParameter("@Active", ContPerInfo.Active));
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
            sqlParams.Add(new SqlParameter("@ObjectFor", ContactPersonMasterInfo.ContactPersonFor));
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
            ContPerInfo.ContactPersonFor = Convert.ToString(dr["ObjectFor"]);
            ContPerInfo.ObjectId = Convert.ToInt32(dr["ObjectId"]);
            ContPerInfo.FirstName = Convert.ToString(dr["FirstName"]);
            ContPerInfo.MiddleName = Convert.ToString(dr["MiddleName"]);
            ContPerInfo.LastName = Convert.ToString(dr["LastName"]);
            ContPerInfo.EmailId = Convert.ToString(dr["EmailId"]);
            ContPerInfo.IsDefault = Convert.ToBoolean(dr["IsDefault"]);
            ContPerInfo.Active = Convert.ToBoolean(dr["Active"]);
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

        public bool CheckFirstMiddleLastNameExists(string FirstName, string MiddleName, string LastName, string ObjectFor, string ObjectId)
        {
            Boolean IsExists = false;
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("@FirstName", FirstName));
            sqlParams.Add(new SqlParameter("@MiddleName", MiddleName));
            sqlParams.Add(new SqlParameter("@LastName", LastName));
            sqlParams.Add(new SqlParameter("@ObjectFor", ObjectFor));
            sqlParams.Add(new SqlParameter("@ObjectId", ObjectId));
            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedureEnum.sp_Check_ContactPerson_Exsit_By_FirstMiddleLastName.ToString(), CommandType.StoredProcedure);
            if (dt.Rows.Count > 0)
            {
                IsExists = true;
            }

            return IsExists;
        }

        public bool CheckEmailIdExistsforCP(string EmailId, string ObjectFor, string ObjectId)
        {
            Boolean IsExists = false;
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("@EmailId", EmailId));
            sqlParams.Add(new SqlParameter("@ObjectFor", ObjectFor));
            sqlParams.Add(new SqlParameter("@ObjectId", ObjectId));
            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedureEnum.sp_Check_ContactPerson_EmailId_Exsit.ToString(), CommandType.StoredProcedure);
            if (dt.Rows.Count > 0)
            {
                IsExists = true;
            }

            return IsExists;
        }
    }
}
