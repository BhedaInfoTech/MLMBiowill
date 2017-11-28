using MLMBiowillBusinessEntities.Common;
using MLMBiowillBusinessEntities.Master;
using MLMBiowillRepo.Master;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLMBiowillBusinesslogic.Master
{
    public class DeparmentManager
    {
        DepartmentRepo _departmentRepo;

        public DeparmentManager()
        {
            _departmentRepo = new DepartmentRepo();
        }
        public int Insert_Department(DepartmentInfo _departmentInfo)
        {
            return _departmentRepo.Insert(_departmentInfo);
        }

        public DataTable GetDepartments(string department, ref PaginationInfo pager)
        {
            return _departmentRepo.GetDepartments(department, ref pager);
        }

        public void Update_Deparment(DepartmentInfo _departmentInfo)
        {
            _departmentRepo.Update(_departmentInfo);
        }
        
        public bool CheckDeparmentExist(string department)
        {
            return _departmentRepo.CheckdepartmentInfoNameExist(department);
        }
    }
}
