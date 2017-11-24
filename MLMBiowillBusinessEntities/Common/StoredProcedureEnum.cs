using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLMBiowillBusinessEntities.Common
{
    public enum StoredProcedureEnum
    {

        #region Country  

        sp_Insert_Country,
        sp_Get_Countries,
        sp_Update_Country,
        sp_Check_Country_Code_Exist,
        sp_Check_Country_Name_Exist,

        #endregion

        #region State

        sp_Insert_State,
        sp_Get_States,
        sp_Update_State,
        sp_Check_StateCode_Exist,
        sp_Check_StateName_Exist,
        sp_drp_Get_Countries,

        #endregion

        #region City

        sp_Insert_City,
        sp_Get_Cities,
        sp_Update_City,
        sp_Check_CityCode_Exist,
        sp_Check_CityName_Exist,
        sp_drp_Get_States,
        sp_Get_States_By_CountryId,
        sp_GetCountryStateCity,
        #endregion

        #region AutoComplete
        sp_Get_Autocomplete_By_PageName,
        #endregion

        #region CompanyMaster

        sp_Save_CompanyMaster,
        sp_Get_CompanyMaster,
        sp_Delete_CompanyMaster_By_Id,
        sp_Check_CompanyName_Exist,

        #endregion

        #region Category

        sp_Insert_Category,
        sp_Update_Category,
        sp_Get_Categories,
        sp_Check_CategoryName_Exist,
        #endregion

        #region AddressMaster

        sp_Insert_AddressMaster,
        sp_Update_AddressMaster,
        sp_Get_AddressMaster,
        sp_Get_AddressMaster_By_Id,
        sp_Get_AddMast_By_Type_For_ObjectId,
        sp_Delete_AddressMaster_By_Id,
        sp_Check_AddressType,
        #endregion

        #region AddressMaster

        sp_Insert_ContactMaster,
        sp_Update_ContactMaster,
        sp_Get_ContactMaster,
        sp_Get_ContactMaster_By_Id,
        sp_Get_ContactMast_By_Type_For_ObjectId,
        sp_Delete_ContactMaster_By_Id,
        sp_Check_MobileNumber,
        #endregion


    }
}
