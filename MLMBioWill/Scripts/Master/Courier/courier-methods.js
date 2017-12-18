function SaveCourier() {
    if ($("[name='CourierInfo.IsActive']").val() == 1 || $("[name='CourierInfo.IsActive']").val().toLowerCase() == "true") {
        activeFlg = true;
    }
    else {
        activeFlg = false;
    }

    $("#frmCourier").blur();
     
    var cViewModel = {

        CourierInfo: {

            Id: $("[name='CourierInfo.Id']").val(),

            CourierName: $("[name='CourierInfo.CourierName']").val(),

            CourierId: $("[name='CourierInfo.CourierId']").val(),

            ServedPincode: $("[name='CourierInfo.ServedPincode']").val(),                

            IsActive: activeFlg,

        }
    }

    var url = "";

    if ($("[name='CourierInfo.Id']").val() == 0) {

        url = "/Courier/Insert"
    }
    else {

        url = "/Courier/Update"
    }

    PostAjaxWithProcessJson(url, cViewModel, AfterSaveCourier, $("body"));
}

function AfterSaveCourier(data) {
    FriendlyMessage(data);

    $("[name='Address.ObjectId']").val(data.CourierInfo.Id);

    $("[name='Address.AddressFor']").val(data.AddressViewModelList.Address.AddressFor);

    $("[name='ContactDetails.ObjectId']").val(data.CourierInfo.Id);

    $("[name='ContactDetails.ContactFor']").val(data.AddressViewModelList.Address.AddressFor);

    $("#link1").show();

    $("#link2").show();

    GetAddress();

    GetContactDetails();

    // alert(data.Company.CompanyId);
}
