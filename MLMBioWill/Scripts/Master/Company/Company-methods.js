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

function AfterSaveCompany(data) {
    FriendlyMessage(data);

    $("[name='Address.ObjectId']").val(data.Company.CompanyId);

    $("[name='Address.AddressFor']").val(data.AddressViewModelList.Address.AddressFor);

    $("[name='ContactDetails.ObjectId']").val(data.Company.CompanyId);

    $("[name='ContactDetails.ContactFor']").val(data.AddressViewModelList.Address.AddressFor);
    
    $("#link1").show();

    $("#link2").show();

    GetAddress();

    GetContactDetails();

    // alert(data.Company.CompanyId);
}
