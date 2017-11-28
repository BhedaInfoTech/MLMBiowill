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
    public class DesignationManager
    {
        DesignationRepo _designationRepo;
        public DesignationManager()
        {
            _designationRepo = new DesignationRepo();
        }
        public int Insert_Designation(DesignationInfo _designationInfo)
        {
            return _designationRepo.Insert(_designationInfo);
        }

        public DataTable GetDesignation(string designation, ref PaginationInfo pager)
        {
            return _designationRepo.GetDesignation(designation, ref pager);
        }

        public void Update_Designation(DesignationInfo _designationInfo)
        {
            _designationRepo.Update(_designationInfo);
        }         

        public bool CheckDesignationExist(string designation)
        {
            return _designationRepo.CheckDesignationExist(designation);
        }

    }
}
