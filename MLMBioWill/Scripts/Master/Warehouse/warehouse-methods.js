function SaveWarehouse() {
    if ($("[name='WarehouseInfo.IsActive']").val() == 1 || $("[name='WarehouseInfo.IsActive']").val().toLowerCase() == "true") {
        activeFlg = true;
    }
    else {
        activeFlg = false;
    }

    $("#frmWarehouse").blur();
     
    var wViewModel = {

        WarehouseInfo: {

            Id: $("[name='WarehouseInfo.Id']").val(),

            WarehouseName: $("[name='WarehouseInfo.WarehouseName']").val(),

            BranchId: $('#drpBranch').val(),            

            IsActive: activeFlg,

        }
    }

    var url = "";

    if ($("[name='WarehouseInfo.Id']").val() == 0) {

        url = "/Warehouse/Insert"
    }
    else {

        url = "/Warehouse/Update"
    }

    PostAjaxWithProcessJson(url, wViewModel, AfterSaveCompany, $("body"));
}

function AfterSaveCompany(data) {
    FriendlyMessage(data);

    $("[name='Address.ObjectId']").val(data.WarehouseInfo.Id);

    $("[name='Address.AddressFor']").val(data.AddressViewModelList.Address.AddressFor);

    $("[name='ContactDetails.ObjectId']").val(data.WarehouseInfo.Id);

    $("[name='ContactDetails.ContactFor']").val(data.AddressViewModelList.Address.AddressFor);

    $("#link1").show();

    $("#link2").show();

    GetAddress();

    GetContactDetails();

    // alert(data.Company.CompanyId);
}
