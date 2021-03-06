﻿using System;
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

        #region Subcategory
        sp_Insert_Subcategory,
        sp_Update_Subcategory,
        sp_Get_Subcategories,
        sp_Check_Subcategory_Exist,
        sp_GetCategories,
        #endregion

        #region Branch

        sp_Insert_Branch,
        sp_Update_Branch,
        sp_Get_Branches,
        sp_Check_Branch_Exist,
        #endregion

        #region BankMaster
        sp_Insert_Bank,
        sp_Update_Bank,
        sp_Get_Banks,
        sp_Check_Bank_Exist,
        #endregion

        #region Designation
        sp_Insert_Designation,
        sp_Update_Designation,
        sp_Get_Designations,
        sp_Check_Designation_Exist,
        #endregion

        #region Department
        sp_Insert_Department,
        sp_Update_Department,
        sp_Get_Deparments,
        sp_Check_Department_Exist,
        #endregion

        #region ContactMaster

        sp_Insert_ContactMaster,
        sp_Update_ContactMaster,
        sp_Get_ContactMaster,
        sp_Get_ContactMaster_By_Id,
        sp_Get_ContactMast_By_Type_For_ObjectId,
        sp_Delete_ContactMaster_By_Id,
        sp_Check_MobileNumber,
        #endregion

        #region ContactPersonMaster
        sp_Insert_ContactPersonMaster,
        sp_Update_ContactPersonMaster,
        sp_Get_ContactPersonMaster,
        sp_Get_ContactPersonMaster_By_Id,
        sp_Get_ContactPersMast_By_Type_For_ObjectId,
        sp_Delete_ContactPersonMaster_By_Id,
        sp_Check_ContactPerson_Exsit_By_FirstMiddleLastName,
        sp_Check_ContactPerson_EmailId_Exsit,
        #endregion

        #region Warehouse

        sp_Check_Warehouse_Exist,
        sp_Insert_Warehouse,
        sp_Update_Warehouse,
        sp_Get_Warehouse,
        sp_GetWarehouseById,
        #endregion

        #region Role Management
        sp_Insert_Role, 
        sp_Insert_Role_Module, 
        sp_Get_Roles, 
        sp_Get_Role_By_Id,
        sp_Get_Module_By_Role_Id,
        sp_Update_Role, 
        sp_Update_Role_Module, 
        sp_Check_Role_Name_Exist,
        #endregion

        #region Courier Master
        sp_Insert_Courier,
        sp_Get_Couriers,
        sp_Update_Courier,
        sp_Check_CourierName_Exist,
        sp_GetCourierById,
        #endregion

        #region Agent Master
        sp_Insert_Agent,
        sp_Get_Agents,
        sp_Update_Agent,
        sp_GetAgentById,
        #endregion


        #region UserMaster
        sp_Insert_UserMaster,
        sp_Update_UserMaster,
        sp_Update_Token_UserMaster,
        sp_Get_UserMaster,
        sp_Get_UserMaster_By_Id,
        sp_Delete_UserMaster_By_Id,
        sp_Fetch_UserInfo_By_Object,
        #endregion


        sp_Get_UserRole_Mapping_By_UserId,
        sp_Update_UserRole_Mapping,
        sp_Insert_UserRole_Mapping,

    }
}
