using MLMBiowillBusinessEntities.Common;
using MLMBiowillBusinessEntities.UserManagement;
using MLMBiowillRepo.UserManagement;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLMBiowillBusinesslogic.UserManagement
{
    public class RoleManager
    {
        RoleRepo _roleRepo;

        public RoleManager()
        {
            _roleRepo = new RoleRepo();
        }

        public int InsertRole(RoleInfo role)
        {
            return _roleRepo.Insert(role);
        }     

        public void UpdateRole(RoleInfo role)
        {
            _roleRepo.Update(role);
        }

        public DataTable GetRoles(string roleName, ref PaginationInfo pager)
        {
            return _roleRepo.GetRoles(roleName, ref pager);
        }

        public RoleInfo GetRoleById(int roleid)
        {
            return _roleRepo.GetRoleById(roleid);
        }

        public List<ModuleInfo> GetModuleByRoleId(int role_id)
        {
            return _roleRepo.GetModuleByRoleId(role_id);
        }

        public bool CheckRoleNameExist(string rolename)
        {
            return _roleRepo.CheckRoleNameExist(rolename);
        }

    }
}
