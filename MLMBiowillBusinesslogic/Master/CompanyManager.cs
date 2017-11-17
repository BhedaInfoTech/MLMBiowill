using MLMBiowillBusinessEntities.City;
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
    public class CompanyManager
    {
        CompanyRepo _CompanyRepo;
        CityRepo _CityRepo;

        public CompanyManager()
        {
            _CompanyRepo = new CompanyRepo();
            _CityRepo = new CityRepo();
        }

        public int Insert_CompanyMaster(CompanyInfo CompanyMaster)
        {
            return _CompanyRepo.Insert_CompanyMaster(CompanyMaster);
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
            
        public Boolean CheckCompanyNameExist(string CompanyName)
        {
            Boolean CompanyNameExsit;

            CompanyNameExsit = _CompanyRepo.Check_CompanyName(CompanyName);

            return CompanyNameExsit;
        }

        public void Delete_CompanyMaster_By_Id(int CompanyMasterId)
        {
            //_enquiryRepo.Delete_CompanyMaster_By_Id(CompanyMasterId);
        }

        public List<CityInfo> GetCities()
        {
            return _CityRepo.GetCities();
        }

    }
}
