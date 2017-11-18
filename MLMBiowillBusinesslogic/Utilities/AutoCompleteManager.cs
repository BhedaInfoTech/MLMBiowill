using MLMBiowillBusinessEntities.Common;
using MLMBiowillRepo.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLMBiowillBusinesslogic.Utilities
{
    public class AutoCompleteManager
    {
        AutoCompleteRepo _autoCompleteRepo;

        public AutoCompleteManager()
        {
            _autoCompleteRepo = new AutoCompleteRepo();

        }

        public List<AutocompleteInfo> GetAutocompletesByPageName(string ControllerName)
        {

            return _autoCompleteRepo.GetAutocompletesByPageName(ControllerName);
        }

        public DataTable GetTableData(string q, int page, string idFieldName, string textFieldName, string tableName, string dependentFieldName, string dependentFieldValue, string extraFields)
        {
            return _autoCompleteRepo.GetTableData(q, page, idFieldName, textFieldName, tableName, dependentFieldName, dependentFieldValue, extraFields);
        }
                                                          


        public DataTable GetTableDataById(string id, string idFieldName, string textFieldName, string tableName, string extraFields)
        {
            return _autoCompleteRepo.GetTableDataById(id, idFieldName, textFieldName, tableName, extraFields);
        }

    }
}
