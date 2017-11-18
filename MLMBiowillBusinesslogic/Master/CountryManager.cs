using MLMBiowillBusinessEntities.Common;
using MLMBiowillBusinessEntities.Country;
using MLMBiowillRepo.Master;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLMBiowillBusinesslogic.Master
{
    public class CountryManager
    {
        CountryRepo _countryRepo;
        public CountryManager()
        {
            _countryRepo = new CountryRepo();
        }
        public int Insert_Country(CountryInfo _countryInfo)
        {
            return _countryRepo.Insert(_countryInfo);
        }
                              
        public DataTable GetCountries(string CountryCode, string CountryName, ref PaginationInfo pager)
        {
            return _countryRepo.GetCountries(CountryCode, CountryName, ref pager);
        }

        public void Update_Country(CountryInfo _countryInfo)
        {
             _countryRepo.Insert(_countryInfo);
        }

        public  bool CheckCountryCodeExist(string countryCode)
        {
            return _countryRepo.CheckCountryCodeExist(countryCode);
        }
                              
        public bool CheckCountryNameExist(string countryName)
        {
            return _countryRepo.CheckCountryNameExist(countryName);
        }

    }
}
