using MLMBiowillBusinessEntities.City;
using MLMBiowillBusinessEntities.Common;
using MLMBiowillBusinessEntities.Country;
using MLMBiowillBusinessEntities.State;
using MLMBiowillRepo.Master;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLMBiowillBusinesslogic.Master
{
    public class CityManager
    {
        CityRepo _cityRepo;
        StateRepo _stateRepo;
        CountryRepo _countryRepo;

        public CityManager()
        {
            _cityRepo = new CityRepo();
            _stateRepo = new StateRepo();
            _countryRepo = new CountryRepo();
        }

        public List<CountryInfo> Drp_GetCountries()
        {
            return _countryRepo.GetCountries();
        }

        public List<StateInfo> Drp_Getstates()
        {
            return _stateRepo.Getstates();
        }


        public List<StateInfo> Get_States_By_Country_Id(int CountryId)
        {
            return _stateRepo.GetStatesByCountryId(CountryId);
        }

        public int Insert_CityMaster(CityInfo CityMaster)
        {
            return _cityRepo.Insert_CityMaster(CityMaster);
        }

        public void Update_CityMaster(CityInfo CityMaster)
        {
            _cityRepo.Update_CityMaster(CityMaster);
        }

        public DataTable Get_CityMaster(int CountryId, int StateId,string CityCode, string CityName, ref PaginationInfo pager)
        {
            return _cityRepo.GetCities(CountryId, StateId, CityCode, CityName, ref pager);
        }

        public Boolean CheckCityCodeExist(string CityCode)
        {
            Boolean CityCodeExsit;

            CityCodeExsit = _cityRepo.CheckCityCodeExist(CityCode);

            return CityCodeExsit;
        }


        public Boolean CheckCityNameExist(string CityName)
        {
            Boolean CityNameExsit;

            CityNameExsit = _cityRepo.CheckCityNameExist(CityName);

            return CityNameExsit;
        }

        public void Delete_StateMaster_By_Id(int StateMasterId)
        {
            //_enquiryRepo.Delete_StateMaster_By_Id(StateMasterId);
        }

    }
}
