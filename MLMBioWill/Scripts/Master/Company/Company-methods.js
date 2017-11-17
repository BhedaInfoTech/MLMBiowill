function SaveCompany() {
    if ($("[name='Company.IsActive']").val() == 1 || $("[name='Company.IsActive']").val().toLowerCase() == "true") {
        activeFlg = true;
    }
    else {
        activeFlg = false;
    }

    $("#frmCompany").blur();

    var vViewModel = {

        Company: {

            CompanyId: $("[name='Company.CompanyId']").val(),
            
            CompanyName: $("[name='Company.CompanyName']").val(),

            GSTNumber: $("[name='Company.GSTNumber']").val(),

            PAN: $("[name='Company.PAN']").val(),

            //MobileNo: $("[name='Company.MobileNo']").val(),

            //PhoneNo: $("[name='Company.PhoneNo']").val(),

            //FaxNo: $("[name='Company.FaxNo']").val(),

            //Address: $("[name='Company.Address']").val(),

            //CityId: $("#drpCity").val(),

            //BusinessId: $("#hdnBusinessType").val(),

            //PINCode: $("[name='Company.PINCode']").val(),

            //EmailId: $("[name='Company.EmailId']").val(),

            //WebsiteURL: $("[name='Company.WebsiteURL']").val(),
            
            IsActive: activeFlg,

        }
    }
    
    var url = "";

    if ($("[name='Company.CompanyId']").val() == 0) {

        url = "/Company/Insert"
    }
    else {

        url = "/Company/UpdateCompany"
    }

    PostAjaxWithProcessJson(url, vViewModel, AfterSaveCompany, $("body"));
}

function AfterSaveCompany(data)
{
    alert(data.Company.CompanyId);
}
