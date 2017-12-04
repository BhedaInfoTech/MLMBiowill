using MLMBiowillBusinessEntities.Common;
using MLMBiowillBusinessEntities.UserManagement;
using MLMBiowillRepo.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLMBiowillRepo.UserManagement
{
    public class RoleRepo
    {
        SqlHelperRepo _sqlHelper = null;

        public RoleRepo()
        {
            _sqlHelper = new SqlHelperRepo();
        }

        public int Insert(RoleInfo role)
        {
            int roleId = Convert.ToInt32(_sqlHelper.ExecuteScalerObj(SetValuesInRole(role), StoredProcedureEnum.sp_Insert_Role.ToString(), CommandType.StoredProcedure));

            foreach (var item in role.Modules)
            {
                _sqlHelper.ExecuteScalerObj(SetValuesInModule(item, roleId), StoredProcedureEnum.sp_Insert_Role_Module.ToString(), CommandType.StoredProcedure);
            }

            return roleId;
        }

        public List<SqlParameter> SetValuesInRole(RoleInfo role)
        {

            List<SqlParameter> sqlParam = new List<SqlParameter>();

            if (role.RoleId != 0)
            {
                sqlParam.Add(new SqlParameter("@RoleId", role.RoleId));
            }
            else
            {                                                                    
                sqlParam.Add(new SqlParameter("@CreatedBy", role.CreatedBy));
            }

            sqlParam.Add(new SqlParameter("@RoleName", role.RoleName));

            sqlParam.Add(new SqlParameter("@IsActive", role.IsActive));

            sqlParam.Add(new SqlParameter("@UpdatedBy", role.UpdatedBy));    

            return sqlParam;
        }

        public List<SqlParameter> SetValuesInModule(ModuleInfo module, int roleId)
        {

            List<SqlParameter> sqlParam = new List<SqlParameter>();

            if (module.ModuleId != 0)
            {
                sqlParam.Add(new SqlParameter("@ModuleId", module.ModuleId));
            }
            else
            {

            }
            sqlParam.Add(new SqlParameter("@HasAccess", module.HasAccess));

            sqlParam.Add(new SqlParameter("@IsCreate", module.IsCreate));

            sqlParam.Add(new SqlParameter("@IsEdit", module.IsEdit));

            sqlParam.Add(new SqlParameter("@IsView", module.IsView));

            sqlParam.Add(new SqlParameter("@IsDelete", module.IsDelete));

            sqlParam.Add(new SqlParameter("@RoleId", roleId));

            return sqlParam;
        }

        public DataTable GetRoles(string roleName, ref PaginationInfo pager)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            sqlParam.Add(new SqlParameter("@RoleName", roleName));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, StoredProcedureEnum.sp_Get_Roles.ToString(), CommandType.StoredProcedure);

            return CommonMethods.GetPaginatedTable(dt, ref pager);
        }

        private RoleInfo GetRoleValues(DataRow dr)
        {

            RoleInfo Role = new RoleInfo();

            Role.RoleId = Convert.ToInt32(dr["RoleId"]);

            if (!dr.IsNull("RoleName"))
                Role.RoleName = Convert.ToString(dr["RoleName"]);

            if (!dr.IsNull("IsActive"))
                Role.IsActive = Convert.ToBoolean(dr["IsActive"]);

            return Role;

        }

        private ModuleInfo GetModuleValues(DataRow dr)
        {

            ModuleInfo Module = new ModuleInfo();

            Module.ModuleId = Convert.ToInt32(dr["ModuleId"]);

            Module.ModuleName = Convert.ToString(dr["ModuleName"]);

            if (!dr.IsNull("HasAccess"))
                Module.HasAccess = Convert.ToBoolean(dr["HasAccess"]);

            if (!dr.IsNull("IsCreate"))
                Module.IsCreate = Convert.ToBoolean(dr["IsCreate"]);

            if (!dr.IsNull("IsEdit"))
                Module.IsEdit = Convert.ToBoolean(dr["IsEdit"]);

            if (!dr.IsNull("IsView"))
                Module.IsView = Convert.ToBoolean(dr["IsView"]);

            if (!dr.IsNull("IsDelete"))
                Module.IsDelete = Convert.ToBoolean(dr["IsDelete"]);

            return Module;

        }

        public RoleInfo GetRoleById(int roleid)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            RoleInfo Role = new RoleInfo();

            sqlParam.Add(new SqlParameter("@RoleId", roleid));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, StoredProcedureEnum.sp_Get_Role_By_Id.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Role = GetRoleValues(dr);
                }
            }
            return Role;
        }

        public List<ModuleInfo> GetModuleByRoleId(int role_id)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            List<ModuleInfo> Modules = new List<ModuleInfo>();

            sqlParam.Add(new SqlParameter("@RoleId", role_id));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, StoredProcedureEnum.sp_Get_Module_By_Role_Id.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Modules.Add(GetModuleValues(dr));

                }
            }
            return Modules;
        }

        public void Update(RoleInfo role)
        {
            _sqlHelper.ExecuteNonQuery(SetValuesInRole(role), StoredProcedureEnum.sp_Update_Role.ToString(), CommandType.StoredProcedure);

            foreach (var item in role.Modules)
            {
                _sqlHelper.ExecuteNonQuery(SetValuesInModule(item, role.RoleId), StoredProcedureEnum.sp_Update_Role_Module.ToString(), CommandType.StoredProcedure);
            }

        }

        public bool CheckRoleNameExist(string rolename)
        {

            string ProcedureName = string.Empty;

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@RoleName", rolename));

            return Convert.ToBoolean(_sqlHelper.ExecuteScalerObj(sqlParams, StoredProcedureEnum.sp_Check_Role_Name_Exist.ToString(), CommandType.StoredProcedure));

        }


    }
}
