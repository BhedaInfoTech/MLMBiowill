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
    public class AddressRepo
    {

        SqlHelperRepo _sqlRepo;

        public AddressRepo()
        {
            _sqlRepo = new SqlHelperRepo();
        }

        public Int32 Insert_AddressMaster(AddressInfo AddInfo)
        {
            return Convert.ToInt32(_sqlRepo.ExecuteScalerObj(Set_Values_In_AddressMaster(AddInfo), StoredProcedureEnum.sp_Insert_AddressMaster.ToString(), CommandType.StoredProcedure));
        }

        public void Update_AddressMaster(AddressInfo AddInfo)
        {
            _sqlRepo.ExecuteNonQuery(Set_Values_In_AddressMaster(AddInfo), StoredProcedureEnum.sp_Update_AddressMaster.ToString(), CommandType.StoredProcedure);
        }

        private List<SqlParameter> Set_Values_In_AddressMaster(AddressInfo AddInfo)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            if (AddInfo.AddressId != 0)
            {
                sqlParams.Add(new SqlParameter("@AddressId", AddInfo.AddressId));
            }
            else
            {
                sqlParams.Add(new SqlParameter("@CreatedBy", AddInfo.CreatedBy));
            }
            sqlParams.Add(new SqlParameter("@AddressType", AddInfo.AddressType));
            sqlParams.Add(new SqlParameter("@AddressFor", AddInfo.AddressFor));
            sqlParams.Add(new SqlParameter("@ObjectId", AddInfo.ObjectId));
            sqlParams.Add(new SqlParameter("@Address", AddInfo.Address));
            sqlParams.Add(new SqlParameter("@City", AddInfo.City));
            sqlParams.Add(new SqlParameter("@PinCode", AddInfo.Pincode));
            sqlParams.Add(new SqlParameter("@EmailID", AddInfo.EmailId));
            sqlParams.Add(new SqlParameter("@Website", AddInfo.Website));
            sqlParams.Add(new SqlParameter("@IsDefault", AddInfo.IsDefault));
            sqlParams.Add(new SqlParameter("@Active", AddInfo.IsActive));
            sqlParams.Add(new SqlParameter("@UpdatedBy", AddInfo.UpdatedBy));
            return sqlParams;
        }

        public List<AddressInfo> Get_AddressMasters(ref PaginationInfo pager)
        {
            List<AddressInfo> AddInfos = new List<AddressInfo>();
            DataTable dt = _sqlRepo.ExecuteDataTable(null, StoredProcedureEnum.sp_Get_AddressMaster.ToString(), CommandType.StoredProcedure);
            foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
            {
                AddInfos.Add(Get_AddressMaster_Values(dr));
            }
            return AddInfos;
        }

        public AddressInfo Get_AddressMaster_By_Id(int addressmasterId)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            AddressInfo AddInfo = new AddressInfo();
            sqlParams.Add(new SqlParameter("@AddressId", addressmasterId));
            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedureEnum.sp_Get_AddressMaster_By_Id.ToString(), CommandType.StoredProcedure);
            List<DataRow> drList = new List<DataRow>();
            drList = dt.AsEnumerable().ToList();
            foreach (DataRow dr in drList)
            {
                AddInfo = Get_AddressMaster_Values(dr);
            }
            return AddInfo;
        }

        public DataTable Get_AddressMaster_By_Type_For_Id(AddressInfo AddressMasterInfo, ref PaginationInfo pager)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            AddressInfo AddInfo = new AddressInfo();
            //sqlParams.Add(new SqlParameter("@AddressType", AddressMasterInfo.AddressType));
            sqlParams.Add(new SqlParameter("@AddressFor", AddressMasterInfo.AddressFor));
            sqlParams.Add(new SqlParameter("@ObjectId", AddressMasterInfo.ObjectId));
            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedureEnum.sp_Get_AddMast_By_Type_For_ObjectId.ToString(), CommandType.StoredProcedure);
            //List<DataRow> drList = new List<DataRow>();
            //drList = dt.AsEnumerable().ToList();
            //foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
            //{
            //    AddInfo = Get_AddressMaster_Values(dr);
            //}
            return dt;
        }

        private AddressInfo Get_AddressMaster_Values(DataRow dr)
        {
            AddressInfo AddInfo = new AddressInfo();

            AddInfo.AddressId = Convert.ToInt32(dr["AddressId"]);
            AddInfo.AddressType = Convert.ToString(dr["AddressType"]);
            AddInfo.AddressFor = Convert.ToString(dr["AddressFor"]);
            AddInfo.ObjectId = Convert.ToInt32(dr["ObjectId"]);
            AddInfo.Address = Convert.ToString(dr["Address"]);
            //AddInfo.Country = Convert.ToInt32(dr["Country"]);
            //AddInfo.State = Convert.ToInt32(dr["State"]);
            AddInfo.City = Convert.ToInt32(dr["City"]);
            AddInfo.Pincode = Convert.ToString(dr["PinCode"]);
            AddInfo.EmailId = Convert.ToString(dr["EmailID"]);
            AddInfo.Website = Convert.ToString(dr["Website"]);
            AddInfo.IsDefault = Convert.ToBoolean(dr["IsDefault"]);
            AddInfo.IsActive = Convert.ToBoolean(dr["Active"]);
            AddInfo.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
            AddInfo.CreatedDate = Convert.ToDateTime(dr["CreatedOn"]);
            AddInfo.UpdatedBy = Convert.ToInt32(dr["UpdatedBy"]);
            AddInfo.UpdatedDate = Convert.ToDateTime(dr["UpdatedOn"]);
            return AddInfo;
        }

        public void Delete_AddressMaster_By_Id(int addressmasterId)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("@AddressId", addressmasterId));
            _sqlRepo.ExecuteNonQuery(sqlParams, StoredProcedureEnum.sp_Delete_AddressMaster_By_Id.ToString(), CommandType.StoredProcedure);
        }


        public bool CheckAddressType(string AddressType, string AddressFor, string ObjectId)
        {
            Boolean IsExists = false;
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("@AddressType", AddressType));
            sqlParams.Add(new SqlParameter("@AddressFor", AddressFor));
            sqlParams.Add(new SqlParameter("@ObjectId", ObjectId));
            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedureEnum.sp_Check_AddressType.ToString(), CommandType.StoredProcedure);
            if (dt.Rows.Count > 0)
            {
                IsExists = true;
            }

            return IsExists;
        }
    }
}
