USE [MLMBiowill]
GO
/****** Object:  StoredProcedure [dbo].[sp_Get_ContactMast_By_Type_For_ObjectId]    Script Date: 11/25/2017 06:23:20 ******/
DROP PROCEDURE [dbo].[sp_Get_ContactMast_By_Type_For_ObjectId]
GO
/****** Object:  StoredProcedure [dbo].[sp_Get_ContactMaster]    Script Date: 11/25/2017 06:23:20 ******/
DROP PROCEDURE [dbo].[sp_Get_ContactMaster]
GO
/****** Object:  StoredProcedure [dbo].[sp_Get_Countries]    Script Date: 11/25/2017 06:23:20 ******/
DROP PROCEDURE [dbo].[sp_Get_Countries]
GO
/****** Object:  StoredProcedure [dbo].[sp_Get_States]    Script Date: 11/25/2017 06:23:20 ******/
DROP PROCEDURE [dbo].[sp_Get_States]
GO
/****** Object:  StoredProcedure [dbo].[sp_Get_States_By_CountryId]    Script Date: 11/25/2017 06:23:20 ******/
DROP PROCEDURE [dbo].[sp_Get_States_By_CountryId]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetCountryStateCity]    Script Date: 11/25/2017 06:23:20 ******/
DROP PROCEDURE [dbo].[sp_GetCountryStateCity]
GO
/****** Object:  StoredProcedure [dbo].[sp_Insert_AddressMaster]    Script Date: 11/25/2017 06:23:20 ******/
DROP PROCEDURE [dbo].[sp_Insert_AddressMaster]
GO
/****** Object:  StoredProcedure [dbo].[sp_Insert_Category]    Script Date: 11/25/2017 06:23:20 ******/
DROP PROCEDURE [dbo].[sp_Insert_Category]
GO
/****** Object:  StoredProcedure [dbo].[sp_Insert_City]    Script Date: 11/25/2017 06:23:20 ******/
DROP PROCEDURE [dbo].[sp_Insert_City]
GO
/****** Object:  StoredProcedure [dbo].[sp_Insert_ContactMaster]    Script Date: 11/25/2017 06:23:20 ******/
DROP PROCEDURE [dbo].[sp_Insert_ContactMaster]
GO
/****** Object:  StoredProcedure [dbo].[sp_Insert_Country]    Script Date: 11/25/2017 06:23:20 ******/
DROP PROCEDURE [dbo].[sp_Insert_Country]
GO
/****** Object:  StoredProcedure [dbo].[sp_Insert_State]    Script Date: 11/25/2017 06:23:20 ******/
DROP PROCEDURE [dbo].[sp_Insert_State]
GO
/****** Object:  StoredProcedure [dbo].[sp_Save_CompanyMaster]    Script Date: 11/25/2017 06:23:20 ******/
DROP PROCEDURE [dbo].[sp_Save_CompanyMaster]
GO
/****** Object:  StoredProcedure [dbo].[sp_Update_AddressMaster]    Script Date: 11/25/2017 06:23:20 ******/
DROP PROCEDURE [dbo].[sp_Update_AddressMaster]
GO
/****** Object:  StoredProcedure [dbo].[sp_Update_Category]    Script Date: 11/25/2017 06:23:20 ******/
DROP PROCEDURE [dbo].[sp_Update_Category]
GO
/****** Object:  StoredProcedure [dbo].[sp_Update_City]    Script Date: 11/25/2017 06:23:20 ******/
DROP PROCEDURE [dbo].[sp_Update_City]
GO
/****** Object:  StoredProcedure [dbo].[sp_Update_ContactMaster]    Script Date: 11/25/2017 06:23:20 ******/
DROP PROCEDURE [dbo].[sp_Update_ContactMaster]
GO
/****** Object:  StoredProcedure [dbo].[sp_Update_Country]    Script Date: 11/25/2017 06:23:20 ******/
DROP PROCEDURE [dbo].[sp_Update_Country]
GO
/****** Object:  StoredProcedure [dbo].[sp_Update_State]    Script Date: 11/25/2017 06:23:20 ******/
DROP PROCEDURE [dbo].[sp_Update_State]
GO
/****** Object:  View [dbo].[CountryStateCity]    Script Date: 11/25/2017 06:23:14 ******/
DROP VIEW [dbo].[CountryStateCity]
GO
/****** Object:  StoredProcedure [dbo].[Get_ContactMaster_By_Id]    Script Date: 11/25/2017 06:23:19 ******/
DROP PROCEDURE [dbo].[Get_ContactMaster_By_Id]
GO
/****** Object:  StoredProcedure [dbo].[sp_Check_AddressType]    Script Date: 11/25/2017 06:23:19 ******/
DROP PROCEDURE [dbo].[sp_Check_AddressType]
GO
/****** Object:  StoredProcedure [dbo].[sp_Check_CategoryName_Exist]    Script Date: 11/25/2017 06:23:19 ******/
DROP PROCEDURE [dbo].[sp_Check_CategoryName_Exist]
GO
/****** Object:  StoredProcedure [dbo].[sp_Check_CityCode_Exist]    Script Date: 11/25/2017 06:23:19 ******/
DROP PROCEDURE [dbo].[sp_Check_CityCode_Exist]
GO
/****** Object:  StoredProcedure [dbo].[sp_Check_CityName_Exist]    Script Date: 11/25/2017 06:23:19 ******/
DROP PROCEDURE [dbo].[sp_Check_CityName_Exist]
GO
/****** Object:  StoredProcedure [dbo].[sp_Check_CompanyName_Exist]    Script Date: 11/25/2017 06:23:19 ******/
DROP PROCEDURE [dbo].[sp_Check_CompanyName_Exist]
GO
/****** Object:  StoredProcedure [dbo].[sp_Check_Country_Code_Exist]    Script Date: 11/25/2017 06:23:19 ******/
DROP PROCEDURE [dbo].[sp_Check_Country_Code_Exist]
GO
/****** Object:  StoredProcedure [dbo].[sp_Check_Country_Name_Exist]    Script Date: 11/25/2017 06:23:19 ******/
DROP PROCEDURE [dbo].[sp_Check_Country_Name_Exist]
GO
/****** Object:  StoredProcedure [dbo].[sp_Check_MobileNumber]    Script Date: 11/25/2017 06:23:19 ******/
DROP PROCEDURE [dbo].[sp_Check_MobileNumber]
GO
/****** Object:  StoredProcedure [dbo].[sp_Check_StateCode_Exist]    Script Date: 11/25/2017 06:23:19 ******/
DROP PROCEDURE [dbo].[sp_Check_StateCode_Exist]
GO
/****** Object:  StoredProcedure [dbo].[sp_Check_StateName_Exist]    Script Date: 11/25/2017 06:23:19 ******/
DROP PROCEDURE [dbo].[sp_Check_StateName_Exist]
GO
/****** Object:  StoredProcedure [dbo].[sp_Delete_AddressMaster_By_Id]    Script Date: 11/25/2017 06:23:19 ******/
DROP PROCEDURE [dbo].[sp_Delete_AddressMaster_By_Id]
GO
/****** Object:  StoredProcedure [dbo].[sp_Delete_CompanyMaster_By_Id]    Script Date: 11/25/2017 06:23:19 ******/
DROP PROCEDURE [dbo].[sp_Delete_CompanyMaster_By_Id]
GO
/****** Object:  StoredProcedure [dbo].[sp_Delete_ContactMaster_By_Id]    Script Date: 11/25/2017 06:23:19 ******/
DROP PROCEDURE [dbo].[sp_Delete_ContactMaster_By_Id]
GO
/****** Object:  StoredProcedure [dbo].[sp_drp_Get_Countries]    Script Date: 11/25/2017 06:23:19 ******/
DROP PROCEDURE [dbo].[sp_drp_Get_Countries]
GO
/****** Object:  StoredProcedure [dbo].[sp_drp_Get_States]    Script Date: 11/25/2017 06:23:19 ******/
DROP PROCEDURE [dbo].[sp_drp_Get_States]
GO
/****** Object:  StoredProcedure [dbo].[sp_Get_AddMast_By_Type_For_ObjectId]    Script Date: 11/25/2017 06:23:19 ******/
DROP PROCEDURE [dbo].[sp_Get_AddMast_By_Type_For_ObjectId]
GO
/****** Object:  StoredProcedure [dbo].[sp_Get_AddressMaster]    Script Date: 11/25/2017 06:23:19 ******/
DROP PROCEDURE [dbo].[sp_Get_AddressMaster]
GO
/****** Object:  StoredProcedure [dbo].[sp_Get_AddressMaster_By_Id]    Script Date: 11/25/2017 06:23:19 ******/
DROP PROCEDURE [dbo].[sp_Get_AddressMaster_By_Id]
GO
/****** Object:  StoredProcedure [dbo].[sp_Get_Autocomplete_By_PageName]    Script Date: 11/25/2017 06:23:19 ******/
DROP PROCEDURE [dbo].[sp_Get_Autocomplete_By_PageName]
GO
/****** Object:  StoredProcedure [dbo].[sp_Get_Categories]    Script Date: 11/25/2017 06:23:19 ******/
DROP PROCEDURE [dbo].[sp_Get_Categories]
GO
/****** Object:  StoredProcedure [dbo].[sp_Get_Cities]    Script Date: 11/25/2017 06:23:20 ******/
DROP PROCEDURE [dbo].[sp_Get_Cities]
GO
/****** Object:  StoredProcedure [dbo].[sp_Get_CompanyMaster]    Script Date: 11/25/2017 06:23:20 ******/
DROP PROCEDURE [dbo].[sp_Get_CompanyMaster]
GO
/****** Object:  Table [dbo].[tblAddressMaster]    Script Date: 11/25/2017 06:23:09 ******/
DROP TABLE [dbo].[tblAddressMaster]
GO
/****** Object:  Table [dbo].[tblAutocomplete]    Script Date: 11/25/2017 06:23:09 ******/
DROP TABLE [dbo].[tblAutocomplete]
GO
/****** Object:  Table [dbo].[tblCityMaster]    Script Date: 11/25/2017 06:23:10 ******/
DROP TABLE [dbo].[tblCityMaster]
GO
/****** Object:  Table [dbo].[tblCompanyMaster]    Script Date: 11/25/2017 06:23:10 ******/
DROP TABLE [dbo].[tblCompanyMaster]
GO
/****** Object:  Table [dbo].[tblCountryMaster]    Script Date: 11/25/2017 06:23:11 ******/
DROP TABLE [dbo].[tblCountryMaster]
GO
/****** Object:  Table [dbo].[tblStateMaster]    Script Date: 11/25/2017 06:23:11 ******/
DROP TABLE [dbo].[tblStateMaster]
GO
/****** Object:  Table [dbo].[tblStateMaster]    Script Date: 11/25/2017 06:23:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblStateMaster](
	[StateId] [int] IDENTITY(1,1) NOT NULL,
	[CountryId] [int] NOT NULL,
	[StateCode] [nvarchar](50) NOT NULL,
	[StateName] [nvarchar](50) NOT NULL,
	[Active] [bit] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedBy] [int] NOT NULL,
	[UpdatedOn] [datetime] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblCountryMaster]    Script Date: 11/25/2017 06:23:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCountryMaster](
	[CountryId] [int] IDENTITY(1,1) NOT NULL,
	[CountryCode] [nvarchar](5) NOT NULL,
	[CountryName] [nvarchar](50) NOT NULL,
	[Active] [bit] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedBy] [int] NOT NULL,
	[UpdatedOn] [datetime] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblCompanyMaster]    Script Date: 11/25/2017 06:23:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCompanyMaster](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[GSTNumber] [nvarchar](25) NULL,
	[PAN] [nvarchar](25) NULL,
	[Active] [bit] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedBy] [int] NOT NULL,
	[UpdatedOn] [datetime] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblCityMaster]    Script Date: 11/25/2017 06:23:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCityMaster](
	[CityId] [int] IDENTITY(1,1) NOT NULL,
	[CountryId] [int] NOT NULL,
	[StateId] [int] NOT NULL,
	[CityCode] [nvarchar](50) NOT NULL,
	[CityName] [nvarchar](50) NOT NULL,
	[Active] [bit] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedBy] [int] NOT NULL,
	[UpdatedOn] [datetime] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblAutocomplete]    Script Date: 11/25/2017 06:23:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblAutocomplete](
	[AutocompleteId] [int] IDENTITY(1,1) NOT NULL,
	[PageName] [nvarchar](255) NULL,
	[ControlName] [nvarchar](255) NULL,
	[TableName] [nvarchar](255) NULL,
	[TextFieldName] [nvarchar](255) NULL,
	[IdFieldName] [nvarchar](255) NULL,
	[DependentControlName] [nvarchar](255) NULL,
	[DependentFieldName] [nvarchar](255) NULL,
	[IsMultiselect] [bit] NULL,
	[ExtraFields] [nvarchar](255) NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK__Autocomp__5C85A831338A9CD5] PRIMARY KEY CLUSTERED 
(
	[AutocompleteId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblAddressMaster]    Script Date: 11/25/2017 06:23:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblAddressMaster](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AddressType] [nvarchar](15) NOT NULL,
	[AddressFor] [nvarchar](15) NOT NULL,
	[ObjectId] [int] NOT NULL,
	[Address] [nvarchar](275) NOT NULL,
	[City] [int] NOT NULL,
	[PinCode] [nvarchar](10) NOT NULL,
	[EmailID] [nvarchar](50) NULL,
	[Website] [nvarchar](75) NULL,
	[IsDefault] [bit] NOT NULL,
	[Active] [bit] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedBy] [int] NOT NULL,
	[UpdatedOn] [datetime] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[sp_Get_CompanyMaster]    Script Date: 11/25/2017 06:23:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================  
-- Author:  <Mayur Bheda>  
-- Create date: <15-10-2017>  
-- Description: <To Fetch the Company Data by Id>  
-- =============================================  
CREATE PROCEDURE [dbo].[sp_Get_CompanyMaster]  
@CompanyId nvarchar(3)  
AS  
BEGIN  
 -- SET NOCOUNT ON added to prevent extra result sets from  
 -- interfering with SELECT statements.  
 SET NOCOUNT ON;  
  
    -- Insert statements for procedure here  
    Declare @SqlQuery nvarchar(Max);  
    Declare @Query nvarchar(Max);  
    Set @SqlQuery = '';  
    Set @Query = '';  
    if(@CompanyId != '0')  
    BEGIN  
     Set @Query += ' Where  Id = '+@CompanyId ;  
     END   
      
 Set @SqlQuery += ' Select Id as CompanyId, Name as CompanyName, GSTNumber, PAN, Active, CreatedBy, CreatedOn, UpdatedBy, UpdatedOn ';  
 Set @SqlQuery += ' From tblCompanyMaster ';  
 Set @SqlQuery += @Query;  
   
 Exec(@SqlQuery);  
   
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Get_Cities]    Script Date: 11/25/2017 06:23:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================  
-- Author:  <Mayur Bheda>  
-- Create date: <24.11.2017>  
-- Description: <Description,,>  
-- =============================================  
CREATE PROCEDURE [dbo].[sp_Get_Cities]  
   
(  
@CountryId int,  
@StateId int,  
@CityCode nvarchar(10),  
@CityName nvarchar(25)  
)  
    
AS  
  
BEGIN  
   
SELECT  
CI.CityId,  
CI.CountryId,  
CI.StateId,   
CI.CityCode,   
CI.CityName,   
C.CountryName,  
S.StateName,  
(case when CI.Active = 0 then 'false' else 'true' end)as [IsActive],  
  
(case when CI.Active = 0 then 'No' else 'Yes' end) as IsActiveStr  
  
FROM dbo.[tblCityMaster] CI  
  
INNER JOIN tblCountryMaster C ON C.CountryId = CI.CountryId   
  
INNER JOIN dbo.[tblStateMaster] S ON S.StateId = CI.StateId  
  
WHERE (case when @CountryId !=0 and @CountryId != '' then  CI.CountryId else '' end) = IsNull(@CountryId,'')  
  
AND (case when @StateId !=0 and @StateId != '' then  CI.StateId else '' end) = IsNull(@StateId,'')  
  
AND (case when @CityCode is not null and @CityCode != '' then  CityCode else '' end) = IsNull(@CityCode,'')   
  
AND (case when @CityName is not null and @CityName != '' then  CityName else '' end) = IsNull(@CityName,'')  
  
  
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Get_Categories]    Script Date: 11/25/2017 06:23:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Get_Categories] (@CategoryName nvarchar(25) ) AS BEGIN
SELECT Id,
       Name,
       CreatedOn,
       CreatedBy,
       UpdatedOn,
       [UpdatedBy],
       (CASE
            WHEN [Active] = 0 THEN 'false'
            ELSE 'true'
        END) AS [Active],
       (CASE
            WHEN [Active] = 0 THEN 'No'
            ELSE 'Yes'
        END) AS IsActiveStr
FROM dbo.tblCategoryMaster
WHERE (CASE
           WHEN @CategoryName IS NOT NULL
                AND @CategoryName != '' THEN Name
           ELSE ''
       END) LIKE '%'+IsNull(@CategoryName,'')+'%' END
GO
/****** Object:  StoredProcedure [dbo].[sp_Get_Autocomplete_By_PageName]    Script Date: 11/25/2017 06:23:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_Get_Autocomplete_By_PageName]  
(  
@PageName Nvarchar(255)  
)  
as  
begin  
  
select * from tblAutocomplete where PageName = @PageName  
  
end
GO
/****** Object:  StoredProcedure [dbo].[sp_Get_AddressMaster_By_Id]    Script Date: 11/25/2017 06:23:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[sp_Get_AddressMaster_By_Id]  
(  
@AddressId int  
)  
as  
begin  
Select Id as AddressId, AddressType, AddressFor, ObjectId, Address, City, PinCode, EmailID, Website, IsDefault, Active, CreatedBy, CreatedOn, UpdatedBy, UpdatedOn   
 from tblAddressMaster  
 where  Id = @AddressId  
end
GO
/****** Object:  StoredProcedure [dbo].[sp_Get_AddressMaster]    Script Date: 11/25/2017 06:23:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[sp_Get_AddressMaster]

as
begin
Select Id as AddressId, AddressType, AddressFor, ObjectId, Address,  City, PinCode, EmailID, Website, IsDefault, Active, CreatedBy, CreatedOn, UpdatedBy, UpdatedOn 
 from tblAddressMaster
end
GO
/****** Object:  StoredProcedure [dbo].[sp_Get_AddMast_By_Type_For_ObjectId]    Script Date: 11/25/2017 06:23:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[sp_Get_AddMast_By_Type_For_ObjectId]  
(    
@AddressFor nvarchar(20),   
@ObjectId nvarchar(20)  
)    
as    
begin    
Select Id as AddressId, AddressType, AddressFor, ObjectId, Address, City, PinCode, EmailID, Website, IsDefault, Active, CreatedBy, CreatedOn, UpdatedBy, UpdatedOn     
 from tblAddressMaster    
 where  AddressFor = @AddressFor   
 and ObjectId = @ObjectId  
   
end
GO
/****** Object:  StoredProcedure [dbo].[sp_drp_Get_States]    Script Date: 11/25/2017 06:23:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================  
-- Author:  <Mayur Bheda>  
-- Create date: <24.11.2017>  
-- Description: <Description,,>  
-- =============================================  
CREATE PROCEDURE [dbo].[sp_drp_Get_States]  
   
AS  
  
BEGIN  
  
Select StateId, StateName from tblStateMaster   
   
END
GO
/****** Object:  StoredProcedure [dbo].[sp_drp_Get_Countries]    Script Date: 11/25/2017 06:23:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================  
-- Author:  <Mayur Bheda>  
-- Create date: <24.11.2017>  
-- Description: <Description,,>  
-- =============================================  
CREATE PROCEDURE [dbo].[sp_drp_Get_Countries]  
   
AS  
  
BEGIN  
  
Select CountryId, CountryName from tblCountryMaster   
   
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Delete_ContactMaster_By_Id]    Script Date: 11/25/2017 06:23:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[sp_Delete_ContactMaster_By_Id]
(
@ContactId int
)
as
begin
Delete from tblTelephonMobileMaster 
Where
 Id = @ContactId 
end
GO
/****** Object:  StoredProcedure [dbo].[sp_Delete_CompanyMaster_By_Id]    Script Date: 11/25/2017 06:23:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Mayur Bheda>
-- Create date: <15-10-2017>
-- Description:	<To Delete the Company Data>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Delete_CompanyMaster_By_Id]
@CompanyId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	 Delete from tblCompanyMaster
	 Where Id = @CompanyId
	
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Delete_AddressMaster_By_Id]    Script Date: 11/25/2017 06:23:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[sp_Delete_AddressMaster_By_Id]  
(  
@AddressId int  
)  
as  
begin  
 Delete from tblAddressMaster  
 Where Id = @AddressId  
end
GO
/****** Object:  StoredProcedure [dbo].[sp_Check_StateName_Exist]    Script Date: 11/25/2017 06:23:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================  
-- Author:  <Mayur Bheda>  
-- Create date: <24.11.2017>  
-- Description: <Description,,>  
-- =============================================  
CREATE PROCEDURE [dbo].[sp_Check_StateName_Exist]  
(  
@StateName varchar(25)  
)  
  
AS  
BEGIN  
  
SELECT 1 FROM tblStateMaster WHERE  
LOWER(StateName) = LOWER(@StateName)   
  
  
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Check_StateCode_Exist]    Script Date: 11/25/2017 06:23:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================  
-- Author:  <Mayur Bheda>  
-- Create date: <24.11.2017>  
-- Description: <Description,,>  
-- =============================================  
CREATE PROCEDURE [dbo].[sp_Check_StateCode_Exist]  
(  
 @StateCode Varchar(10)  
)  
  
AS   
BEGIN  
  
SELECT 1 FROM tblStateMaster WHERE  
LOWER(StateCode) = LOWER(@StateCode)   
  
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Check_MobileNumber]    Script Date: 11/25/2017 06:23:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[sp_Check_MobileNumber]
(
@PhoneNumber nvarchar(30),
@ContactFor nvarchar(30),
@ObjectId int
)
as
begin
Select 1 from tblTelephonMobileMaster 
Where
 TelMobNumber = @PhoneNumber 
and ContactType = @ContactFor 
and ObjectId = @ObjectId 
and  Active = 1

end
GO
/****** Object:  StoredProcedure [dbo].[sp_Check_Country_Name_Exist]    Script Date: 11/25/2017 06:23:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================  
-- Author:  <Mayur Bheda>  
-- Create date: <24.11.2017>  
-- Description: <Description,,>  
-- =============================================  
CREATE PROCEDURE [dbo].[sp_Check_Country_Name_Exist]  
(  
@CountryName varchar(25)  
)  
  
AS  
BEGIN  
  
SELECT 1 FROM tblCountryMaster WHERE  
LOWER(CountryName) = LOWER(@CountryName)   
  
  
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Check_Country_Code_Exist]    Script Date: 11/25/2017 06:23:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================  
-- Author:  <Mayur Bheda>  
-- Create date: <24.11.2017>  
-- Description: <Description,,>  
-- =============================================  
CREATE PROCEDURE [dbo].[sp_Check_Country_Code_Exist]  
(  
 @CountryCode Varchar(10)  
)  
  
AS   
BEGIN  
  
Select COUNT(*) As CountryCodeCount from tblCountryMaster   
WHERE CountryCode = @CountryCode  
  
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Check_CompanyName_Exist]    Script Date: 11/25/2017 06:23:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Check_CompanyName_Exist] 
( 
	@CompanyName varchar(125) 
) 
AS 

BEGIN
	SELECT 1 FROM tblCompanyMaster WHERE LOWER(name) = LOWER(@CompanyName) 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Check_CityName_Exist]    Script Date: 11/25/2017 06:23:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================  
-- Author:  <Mayur Bheda>  
-- Create date: <24.11.2017>  
-- Description: <Description,,>  
-- =============================================  
CREATE PROCEDURE [dbo].[sp_Check_CityName_Exist]  
(  
@CityName varchar(25)  
)  
  
AS  
BEGIN  
  
SELECT 1 FROM tblCityMaster WHERE  
LOWER(CityName) = LOWER(@CityName)   
  
  
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Check_CityCode_Exist]    Script Date: 11/25/2017 06:23:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================  
-- Author:  <Mayur Bheda>  
-- Create date: <24.11.2017>  
-- Description: <Description,,>  
-- =============================================  
CREATE PROCEDURE [dbo].[sp_Check_CityCode_Exist]  
(  
 @CityCode Varchar(10)  
)  
  
AS   
BEGIN  
  
SELECT 1 FROM tblCityMaster WHERE  
LOWER(CityCode) = LOWER(@CityCode)   
  
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Check_CategoryName_Exist]    Script Date: 11/25/2017 06:23:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Check_CategoryName_Exist] 
( 
	@CategoryName varchar(25) 
) 
	AS BEGIN
	
	SELECT 1 FROM tblCategoryMaster
	WHERE LOWER(name) = LOWER(@CategoryName) END
GO
/****** Object:  StoredProcedure [dbo].[sp_Check_AddressType]    Script Date: 11/25/2017 06:23:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[sp_Check_AddressType]
(
@AddressType nvarchar(30),
@AddressFor nvarchar(30),
@ObjectId int
)
as
begin
Select 1 from tblAddressMaster 
Where
 AddressType = @AddressType 
and AddressFor = @AddressFor 
and ObjectId = @ObjectId 
and  Active = 1

end
GO
/****** Object:  StoredProcedure [dbo].[Get_ContactMaster_By_Id]    Script Date: 11/25/2017 06:23:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[Get_ContactMaster_By_Id]  
(    
@ContactId nvarchar(20)
)    
as    
begin    
SELECT Id as ContactId,ContactType,ContactFor,ObjectId,CountryCode,StdCode,TelMobNumber,IsDefault,Active,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn
 from tblTelephonMobileMaster    
 where  Id = @ContactId   
   
end
GO
/****** Object:  View [dbo].[CountryStateCity]    Script Date: 11/25/2017 06:23:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[CountryStateCity]
	AS SELECT City.CityId, 
	(CASE WHEN City.CityName is not null then (Country.CountryName + ',' + State.StateName + ',' + City.CityName)else 'No Match Found' end) 
	AS CityName FROM  tblCityMaster City
INNER JOIN tblCountryMaster Country ON City.CountryId = Country.CountryId
INNER JOIN tblStateMaster State ON City.StateId = State.StateId
GO
/****** Object:  StoredProcedure [dbo].[sp_Update_State]    Script Date: 11/25/2017 06:23:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================  
-- Author:  <Mayur Bheda>  
-- Create date: <24.11.2017>  
-- Description: <Description,,>  
-- =============================================  
CREATE PROCEDURE [dbo].[sp_Update_State]  
(  
  
@StateId INT,  
@CountryId INT,  
@StateCode NVARCHAR(10),  
@StateName NVARCHAR(25),  
@IsActive BIT,  
@UpdatedBy INT  
  
)  
  
AS  
BEGIN  
  
UPDATE tblStateMaster SET   
  
CountryId = @CountryId,  
StateCode = @StateCode,  
StateName = @StateName,  
Active=@IsActive,  
UpdatedOn = GETDATE(),  
UpdatedBy = @UpdatedBy   
  
WHERE StateId = @StateId  
  
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Update_Country]    Script Date: 11/25/2017 06:23:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================    
-- Author:  <Mayur Bheda>    
-- Create date: <24.11.2017>    
-- Description: <Description,,>    
-- =============================================    
CREATE PROCEDURE [dbo].[sp_Update_Country]    
(    
    
@CountryId INT,    
@CountryCode NVARCHAR(10),    
@CountryName NVARCHAR(25),    
@IsActive BIT,    
@UpdatedBy INT    
    
)    
    
AS    
BEGIN    
    
UPDATE tblCountryMaster SET     
    
CountryCode = @CountryCode,    
CountryName = @CountryName,    
Active=@IsActive,    
UpdatedOn = GETDATE(),    
UpdatedBy = @UpdatedBy     
    
WHERE CountryId = @CountryId    
    
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Update_ContactMaster]    Script Date: 11/25/2017 06:23:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[sp_Update_ContactMaster]  
	@ContactId int,
	@ContactType nvarchar(20),
	@ContactFor nvarchar(20),  
	@ObjectId int,
	@CountryCode nvarchar(5) ,
	@StdCode nvarchar(10),
	@TelMobNumber int,
	@IsDefault bit,
	@Active bit,
	@UpdatedBy int
as    
begin    
UPDATE tblTelephonMobileMaster
   SET ContactType = @ContactType
      ,ContactFor = @ContactFor
      ,ObjectId = @ObjectId
      ,CountryCode = @CountryCode
      ,StdCode = @StdCode
      ,TelMobNumber = @TelMobNumber
      ,IsDefault = @IsDefault
      ,Active = @Active
      ,UpdatedBy = @UpdatedBy
      ,UpdatedOn = GETDATE()
 WHERE 
 Id=@ContactId
 
end
GO
/****** Object:  StoredProcedure [dbo].[sp_Update_City]    Script Date: 11/25/2017 06:23:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================  
-- Author:  <Mayur Bheda>  
-- Create date: <24.11.2017>  
-- Description: <Description,,>  
-- =============================================  
CREATE Procedure [dbo].[sp_Update_City]  
(  
@CityId int,  
@CountryId int,  
@StateId int,  
@CityCode nvarchar(50),  
@CityName nvarchar(50),  
@IsActive BIT,  
@UpdatedBy int  
)  
as  
begin  
  
Update tblCityMaster Set   
 CountryId = @CountryId ,  
 StateId = @StateId ,  
 CityCode = @CityCode ,  
 CityName = @CityName ,  
 Active=@IsActive,  
 UpdatedOn = GETDATE(),  
 UpdatedBy = @UpdatedBy  
Where CityId = @CityId  
  Select SCOPE_IDENTITY();
end
GO
/****** Object:  StoredProcedure [dbo].[sp_Update_Category]    Script Date: 11/25/2017 06:23:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Update_Category]
 ( 
	@CategoryId INT, 
	@CategoryName NVARCHAR(25), 
	@IsActive BIT, 
	@UpdatedBy INT 
  ) 
  AS BEGIN
	UPDATE tblCategoryMaster
	SET Name = @CategoryName,
		Active=@IsActive,
		UpdatedOn = GETDATE(),
		UpdatedBy = @UpdatedBy
	WHERE Id =@CategoryId END
GO
/****** Object:  StoredProcedure [dbo].[sp_Update_AddressMaster]    Script Date: 11/25/2017 06:23:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[sp_Update_AddressMaster]
(
@AddressId int,
@AddressType nvarchar(30),
@AddressFor nvarchar(30),
@ObjectId int,
@Address nvarchar(550),
@City int,
@PinCode nvarchar(20),
@EmailID nvarchar(100),
@Website nvarchar(150),
@IsDefault bit,
@Active bit,
@UpdatedBy int
)
as
begin
Update tblAddressMaster Set 
 AddressType = @AddressType ,
 AddressFor = @AddressFor ,
 ObjectId = @ObjectId ,
 Address = @Address ,
 City = @City ,
 PinCode = @PinCode ,
 EmailID = @EmailID ,
 Website = @Website ,
 IsDefault = @IsDefault ,
 Active = @Active ,
 UpdatedBy = @UpdatedBy ,
 UpdatedOn = GETDATE()
Where Id = @AddressId
end
GO
/****** Object:  StoredProcedure [dbo].[sp_Save_CompanyMaster]    Script Date: 11/25/2017 06:23:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Mayur Bheda>
-- Create date: <15-10-2017>
-- Description:	<To Insert/Update the Company Data>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Save_CompanyMaster]
@CompanyId int,
@Name nvarchar(100),
@GSTNumber nvarchar(50),
@PAN nvarchar(50),
@Active bit,
@CreatedBy int,
@UpdatedBy int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
    if(@CompanyId = 0)
		BEGIN 
			Insert into tblCompanyMaster
				(Name,GSTNumber,PAN,Active,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
			values
				(@Name,@GSTNumber,@PAN,@Active,@CreatedBy,GETDATE(),@UpdatedBy,GETDATE())
		END	
	else
		BEGIN
			Update tblCompanyMaster
			Set 
				Name=@Name,
				GSTNumber=@GSTNumber,
				PAN =@PAN,
				Active =@Active,
				UpdatedBy =@UpdatedBy ,
				UpdatedOn = GETDATE()
			Where Id = @CompanyId
		END
Select SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Insert_State]    Script Date: 11/25/2017 06:23:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================  
-- Author:  <Mayur Bheda>  
-- Create date: <24.11.2017>  
-- Description: <Description,,>  
-- =============================================  
CREATE PROCEDURE [dbo].[sp_Insert_State]  
(  
@CountryId INT,  
@StateCode NVARCHAR(10),  
@StateName NVARCHAR(25),  
@IsActive BIT,  
@CreatedBy INT,  
@UpdatedBy INT  
)  
  
AS  
BEGIN  
  
INSERT INTO tblStateMaster  
(  
 CountryId,  
 StateCode,  
 StateName,  
 Active,  
 CreatedOn,  
 CreatedBy,  
 UpdatedOn,  
 UpdatedBy  
 )  
   
 VALUES  
   
(  
@CountryId,  
@StateCode,  
@StateName,  
@IsActive,  
GETDATE(),  
@CreatedBy,  
GETDATE(),  
@UpdatedBy)  
             
SELECT SCOPE_IDENTITY();  
  
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Insert_Country]    Script Date: 11/25/2017 06:23:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================    
-- Author:  <Mayur Bheda>    
-- Create date: <24.11.2017>    
-- Description: <Description,,>    
-- =============================================    
CREATE PROCEDURE [dbo].[sp_Insert_Country]    
(    
@CountryCode NVARCHAR(10),    
@CountryName NVARCHAR(25),    
@IsActive BIT,    
@CreatedBy INT,    
@UpdatedBy INT    
)    
    
AS    
BEGIN    
    
INSERT INTO [tblCountryMaster]    
(    
 CountryCode,    
 CountryName,    
 Active,    
 CreatedOn,
 CreatedBy,
 UpdatedOn,    
 UpdatedBy    
 )    
     
 VALUES    
     
(    
@CountryCode,    
@CountryName,    
@IsActive,    
GETDATE(),    
@CreatedBy,    
GETDATE(),    
@UpdatedBy)    
               
SELECT SCOPE_IDENTITY();    
    
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Insert_ContactMaster]    Script Date: 11/25/2017 06:23:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[sp_Insert_ContactMaster]
	@ContactType nvarchar(20),
	@ContactFor nvarchar(20),  
	@ObjectId int,
	@CountryCode nvarchar(3) ,
	@StdCode nvarchar(5),
	@TelMobNumber nvarchar(10),
	@IsDefault bit,
	@Active bit,
	@CreatedBy int,
	@UpdatedBy int
as    
begin    
INSERT INTO tblTelephonMobileMaster
           (ContactType,ContactFor,ObjectId,CountryCode,StdCode,TelMobNumber,IsDefault,
            Active,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
     VALUES
           (@ContactType,@ContactFor,@ObjectId,@CountryCode,@StdCode,@TelMobNumber,@IsDefault,
            @Active,@CreatedBy,GETDATE(),@UpdatedBy,GETDATE()) 
end
GO
/****** Object:  StoredProcedure [dbo].[sp_Insert_City]    Script Date: 11/25/2017 06:23:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================  
-- Author:  <Mayur Bheda>  
-- Create date: <24.11.2017>  
-- Description: <Description,,>  
-- =============================================  
CREATE Procedure [dbo].[sp_Insert_City]  
(  
@CountryId int,  
@StateId int,  
@CityCode nvarchar(50),  
@CityName nvarchar(50),  
@IsActive BIT,  
@CreatedBy int,  
@UpdatedBy int  
)  
as  
begin  
Insert into tblCityMaster  
(  
CountryId,  
StateId,  
CityCode,  
CityName,  
Active,  
CreatedOn,  
CreatedBy,  
UpdatedOn,  
UpdatedBy  
)  
values  
(  
@CountryId,  
@StateId,  
@CityCode,  
@CityName,  
@IsActive,  
GETDATE(),  
@CreatedBy,  
GETDATE(),  
@UpdatedBy  
)  

Select SCOPE_IDENTITY();
end
GO
/****** Object:  StoredProcedure [dbo].[sp_Insert_Category]    Script Date: 11/25/2017 06:23:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Insert_Category] 
( @CategoryName NVARCHAR(25), 
@IsActive BIT, 
@CreatedBy INT, 
@UpdatedBy INT ) AS BEGIN
INSERT INTO [tblCategoryMaster] ( Name, Active, CreatedOn, CreatedBy, UpdatedOn, UpdatedBy )
VALUES ( @CategoryName,
         @IsActive,
         GETDATE(),
         @CreatedBy,
         GETDATE(),
         @UpdatedBy)
SELECT SCOPE_IDENTITY(); END
GO
/****** Object:  StoredProcedure [dbo].[sp_Insert_AddressMaster]    Script Date: 11/25/2017 06:23:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[sp_Insert_AddressMaster]  
(  
@AddressType nvarchar(30),  
@AddressFor nvarchar(30),  
@ObjectId int,  
@Address nvarchar(550),  
@City int,  
@PinCode nvarchar(20),  
@EmailID nvarchar(100),  
@Website nvarchar(150),  
@IsDefault bit,  
@Active bit,  
@CreatedBy int,  
@UpdatedBy int  
)  
as  
begin  
Insert into tblAddressMaster  
(  
AddressType,  
AddressFor,  
ObjectId,  
Address,  
City,  
PinCode,  
EmailID,  
Website,  
IsDefault,  
Active,  
CreatedBy,  
CreatedOn,  
UpdatedBy,  
UpdatedOn  
)  
values  
(  
@AddressType,  
@AddressFor,  
@ObjectId,  
@Address,  
@City,  
@PinCode,  
@EmailID,  
@Website,  
@IsDefault,  
@Active,  
@CreatedBy,  
GETDATE(),  
@UpdatedBy,  
GETDATE()  
)  
  
Select SCOPE_IDENTITY();  
  
end
GO
/****** Object:  StoredProcedure [dbo].[sp_GetCountryStateCity]    Script Date: 11/25/2017 06:23:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================  
-- Author:  <Mayur Bheda>  
-- Create date: <24.11.2017>  
-- Description: <Description,,>  
-- =============================================  
CREATE PROCEDURE [dbo].[sp_GetCountryStateCity]  
  
  
AS  
BEGIN  
  
SELECT City.CityId, 
(CASE WHEN City.CityName is not null then (Country.CountryName + ',' + State.StateName + ',' + City.CityName)else 'No Match Found' end) AS Name 
FROM  tblCityMaster City  
INNER JOIN tblCountryMaster Country ON City.CountryId = Country.CountryId  
INNER JOIN tblStateMaster State ON City.StateId = State.StateId  
  
   
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Get_States_By_CountryId]    Script Date: 11/25/2017 06:23:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================    
-- Author:  <Mayur Bheda>    
-- Create date: <24.11.2017>    
-- Description: <Description,,>    
-- =============================================    
CREATE PROCEDURE [dbo].[sp_Get_States_By_CountryId]    
     
(    
@CountryId int    
)    
      
AS    
    
BEGIN  
  
SELECT s.StateId, s.StateName FROM tblStateMaster s  
inner JOIN tblCountryMaster cn on cn.CountryId=s.CountryId  
where cn.CountryId=@CountryId  
  
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Get_States]    Script Date: 11/25/2017 06:23:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================  
-- Author:  <Mayur Bheda>  
-- Create date: <24.11.2017>  
-- Description: <Description,,>  
-- =============================================  
CREATE PROCEDURE [dbo].[sp_Get_States]  
   
(  
@CountryId nvarchar(25),  
@StateCode nvarchar(10),  
@StateName nvarchar(25)  
)  
    
AS  
  
BEGIN  
   
SELECT   
S.StateId,  
S.CountryId,   
S.StateCode,  
S.StateName,  
C.CountryName,  
  
(case when S.Active  = 0 then 'false' else 'true' end)as [IsActive],  
  
(case when S.Active  = 0 then 'No' else 'Yes' end) as IsActiveStr  
  
FROM dbo.[tblStateMaster]  S  
  
INNER JOIN tblCountryMaster  C ON C.CountryId = S.CountryId  
  
WHERE (case when @CountryId !=0 and @CountryId != '' then  S.CountryId else '' end) = IsNull(@CountryId,'')   
  
AND (case when @StateCode is not null and @StateCode != '' then  StateCode else '' end) = IsNull(@StateCode,'')   
  
AND (case when @StateName is not null and @StateName != '' then  StateName else '' end) = IsNull(@StateName,'')  
  
  
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Get_Countries]    Script Date: 11/25/2017 06:23:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================  
-- Author:  <Mayur Bheda>  
-- Create date: <24.11.2017>  
-- Description: <Description,,>  
-- =============================================  
CREATE PROCEDURE [dbo].[sp_Get_Countries]  
   
(  
@CountryCode nvarchar(10),  
@CountryName nvarchar(25)  
)  
    
AS  
  
BEGIN  
   
SELECT [CountryId]  
      ,[CountryCode]  
      ,[CountryName]  
      ,[CreatedOn]  
      ,[CreatedBy]  
      ,[UpdatedOn]   
      ,[UpdatedBy],  
      (case when [Active] = 0 then 'false' else 'true' end)as [IsActive],  
      (case when [Active] = 0 then 'No' else 'Yes' end) as IsActiveStr  
        
       FROM dbo.tblCountryMaster   
  
WHERE (case when @CountryCode is not null and @CountryCode != '' then  CountryCode else '' end) = IsNull(@CountryCode,'')   
  
AND (case when @CountryName is not null and @CountryName != '' then  CountryName else '' end) = IsNull(@CountryName,'')  
  
  
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Get_ContactMaster]    Script Date: 11/25/2017 06:23:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[sp_Get_ContactMaster]  
    
as    
begin    
SELECT Id as ContactId,ContactType,ContactFor,ObjectId,CountryCode,StdCode,TelMobNumber,IsDefault,Active,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn
 from tblTelephonMobileMaster    
 
end
GO
/****** Object:  StoredProcedure [dbo].[sp_Get_ContactMast_By_Type_For_ObjectId]    Script Date: 11/25/2017 06:23:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[sp_Get_ContactMast_By_Type_For_ObjectId]  
(    
@ContactFor nvarchar(20),   
@ObjectId nvarchar(20)  
)    
as    
begin    
SELECT Id as ContactId,ContactType,ContactFor,ObjectId,CountryCode,StdCode,TelMobNumber,IsDefault,Active,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn
 from tblTelephonMobileMaster    
 where  ContactFor = @ContactFor   
 and ObjectId = @ObjectId  
   
end
GO
