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
    public class BankRepo
    {
        SqlHelperRepo _sqlHelper = null;

        public BankRepo()
        {
            _sqlHelper = new SqlHelperRepo();
        }

        public int Insert(BankInfo bankInfo)
        {
            return Convert.ToInt32(_sqlHelper.ExecuteScalerObj(SetValuesInbankInfo(bankInfo), StoredProcedureEnum.sp_Insert_Bank.ToString(), CommandType.StoredProcedure));
        }

        public List<SqlParameter> SetValuesInbankInfo(BankInfo bankInfo)
        {

            List<SqlParameter> sqlParam = new List<SqlParameter>();

            if (bankInfo.Id != 0)
            {
                sqlParam.Add(new SqlParameter("@BankId", bankInfo.Id));
            }
            else
            {
                sqlParam.Add(new SqlParameter("@CreatedBy", bankInfo.CreatedBy));
            }

            sqlParam.Add(new SqlParameter("@BankBranch", bankInfo.BranchName));

            sqlParam.Add(new SqlParameter("@BankName", bankInfo.BankName));

            sqlParam.Add(new SqlParameter("@IFSCCode", bankInfo.IFSCCode));             

            sqlParam.Add(new SqlParameter("@IsActive", bankInfo.Active));            

            sqlParam.Add(new SqlParameter("@UpdatedBy", bankInfo.UpdatedBy));

            return sqlParam;
        }

        public DataTable GetBanks(string bankName, ref PaginationInfo pager)
        {

            List<SqlParameter> sqlParam = new List<SqlParameter>();             

            sqlParam.Add(new SqlParameter("@BankName", bankName));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, StoredProcedureEnum.sp_Get_Banks.ToString(), CommandType.StoredProcedure);

            return CommonMethods.GetPaginatedTable(dt, ref pager);
        }

        public void Update(BankInfo bankInfo)
        {
            _sqlHelper.ExecuteNonQuery(SetValuesInbankInfo(bankInfo), StoredProcedureEnum.sp_Update_Bank.ToString(), CommandType.StoredProcedure);
        }         

        public bool CheckbankNameExist(string bankName)
        {

            string ProcedureName = string.Empty;

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@BankName", bankName));            

            return Convert.ToBoolean(_sqlHelper.ExecuteScalerObj(sqlParams, StoredProcedureEnum.sp_Check_Bank_Exist.ToString(), CommandType.StoredProcedure));

        }        
        
    }
}
