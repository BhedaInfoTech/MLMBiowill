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
    public class StateManager
    {
        StateRepo _stateRepo;
        CountryRepo _countryRepo;

        public StateManager()
        {
            _stateRepo = new StateRepo();
            _countryRepo = new CountryRepo();
        }

        public List<CountryInfo> Drp_GetCountries()
        {
            return _countryRepo.GetCountries();
        }

        public int Insert_StateMaster(StateInfo StateMaster)
        {
            return _stateRepo.Insert_StateMaster(StateMaster);
        }

        public void Update_StateMaster(StateInfo StateMaster)
        {
            _stateRepo.Update_StateMaster(StateMaster);
        }

        public DataTable Get_StateMaster(int CountryId, string StateCode, string StateName, ref PaginationInfo pager)
        {
            return _stateRepo.GetStates(CountryId,StateCode,StateName, ref pager);
        }
     
        public Boolean CheckStateCodeExist(string StateCode)
        {
            Boolean StateCodeExsit;

            StateCodeExsit = _stateRepo.CheckStateCodeExist(StateCode);

            return StateCodeExsit;
        }


        public Boolean CheckStateNameExist(string StateName)
        {
            Boolean StateNameExsit;

            StateNameExsit = _stateRepo.CheckStateNameExist(StateName);

            return StateNameExsit;
        }

        public void Delete_StateMaster_By_Id(int StateMasterId)
        {
            //_enquiryRepo.Delete_StateMaster_By_Id(StateMasterId);
        }
    }
}
