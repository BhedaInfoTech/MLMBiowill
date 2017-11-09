using MLMBiowillBusinessEntities;
using MLMBiowillBusinessEntities.Common;
using MLMBiowillRepo.Master;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLMBiowillBusinesslogic.Master
{
    public class CompanyManager
    {
        CompanyRepo _CompanyRepo;

        public CompanyManager()
        {
            _CompanyRepo = new CompanyRepo();
        }

        public void Insert_CompanyMaster(CompanyInfo CompanyMaster)
        {
            _CompanyRepo.Insert_CompanyMaster(CompanyMaster);
        }

        public void Update_CompanyMaster(CompanyInfo CompanyMaster)
        {
            _CompanyRepo.Update_CompanyMaster(CompanyMaster);
        }

        public DataTable GetCompanyMaster(int CompanyMasterId, ref PaginationInfo pager)
        {
            return _CompanyRepo.Get_CompanyMaster(CompanyMasterId, ref pager);
        }

        public List<CompanyInfo> Get_CompanyMasters(ref PaginationInfo pager)
        {
            return _CompanyRepo.Get_CompanyMasters(ref pager);
        }

        public CompanyInfo Get_CompanyMaster_By_Id(int CompanyMasterId)
        {
            return _CompanyRepo.Get_CompanyMaster_By_Id(CompanyMasterId);
        }

        public void Delete_CompanyMaster_By_Id(int CompanyMasterId)
        {
            //_enquiryRepo.Delete_CompanyMaster_By_Id(CompanyMasterId);
        }
    }
}
