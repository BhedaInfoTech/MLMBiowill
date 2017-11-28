
function SaveAddress() {

    if ($("[name='Address.IsDefault']").val() == 1 || $("[name='Address.IsDefault']").val().toLowerCase() == "true") {
        DefaultFlag = true;
    }
    else {
        DefaultFlag = false;
    }


    if ($("[name='Address.IsActive']").val() == 1 || $("[name='Address.IsActive']").val().toLowerCase() == "true") {
        activeFlg = true;
    }
    else {
        activeFlg = false;
    }

    $("#frmAddress").blur();

    var vViewModel = {

        Address: {

            AddressId: $("[name='Address.AddressId']").val(),

            AddressFor: $("[name='Address.AddressFor']").val(),

            AddressType: $("[name='Address.AddressType']").val(),

            ObjectId: $("[name='Address.ObjectId']").val(),

            IsDefault: DefaultFlag,

            EmailId: $("[name='Address.EmailId']").val(),

            Website: $("[name='Address.Website']").val(),

            Pincode: $("[name='Address.Pincode']").val(),

            Address: $("#txtAddress").val(),

            City: $("[name='Address.City']").val(),


            IsActive: activeFlg
        }
    }
    var url = "";

    if ($("[name='Address.AddressId']").val() == 0) {

        url = "/Address/InsertAddress"
    }
    else {
        url = "/Address/UpdateAddress"

    }
    PostAjaxJson(url, vViewModel, AfterAddressSave);
}

function AfterAddressSave(data) {

    FriendlyMessage(data);

    ResetAddress();

    GetAddress();

}

function ResetAddress() {

    $("#hdnSearchAddressId").val('');

    $("#drpAddressType").val('0');

    SetActive($("[name='Address.IsDefault']"), false);

    $("[name='Address.EmailId']").val('');

    $("[name='Address.Website']").val('');

    $("[name='Address.Pincode']").val('');

    $("[name='Address.Address']").val('');

    $("#txtAddress").text();

    var citydefault = -1;

    $("[name='Address.City']").attr("data-value", citydefault);

    SetActive($("[name='Address.IsActive']"), false);

}

function GetAddress() {

    var vViewModel =
        {
            Address: {

                AddressFor: $("#hdnAddFor").val(),

                ObjectId: $("#hdnObjectId").val(),

            },
            Pager: {

                CurrentPage: $('#tblAddress').attr("data-current-page"),
            },
        }

    PostAjaxJson("/Address/GetAddressList", vViewModel, BindAddress);
}

function BindAddress(data) {

    var list = JSON.parse(data);

    var kTable = {
        dataList: ["AddressType",  "PinCode", "EmailID", "IsDefault", "Active"],
        primayKey: "AddressId",
        hiddenFields: ["AddressId", "City", "AddressFor", "ObjectId"],
        headerNames: ["Address Type", "Pincode", "Email Id", "IsDefault", "Active"],
        data: list.dt,
    }

    buildHtmlTable(kTable, $('#tblAddress'));

    BindPagination(list.Pager, $('#tblAddress'));

}

function GetAddressById() {

    var vViewModel =
        {
            Address: {

                AddressId: $("#hdnSearchAddressId").val(),


            },
            Pager: {

                CurrentPage: $('#tblAddress').attr("data-current-page"),
            },
        }

    PostAjaxJson("/Address/GetAddressById", vViewModel, BindAddressById);
}

function BindAddressById(data) {

    var obj = data;

    var City = obj.Address.City;


    $("[name='Address.AddressId']").val(obj.Address.AddressId);

    $("[name='Address.AddressFor']").val(obj.Address.AddressFor);

    $("[name='Address.AddressType']").val(obj.Address.AddressType);

    $("[name='Address.ObjectId']").val(obj.Address.ObjectId);

    SetActive($("[name='Address.IsDefault']"), obj.Address.IsDefault);

    $("[name='Address.EmailId']").val(obj.Address.EmailId);

    $("[name='Address.Website']").val(obj.Address.Website);

    $("[name='Address.Pincode']").val(obj.Address.Pincode);

    $("[name='Address.Address']").val(obj.Address.Address);

    SetActive($("[name='Address.IsActive']"), obj.Address.IsActive);

    $("[name='Address.City']").attr("data-value", City);

    GetAutocompleteById("Address.City");

    $("#hdnAddFor").val(obj.Address.AddressFor);

    $("#hdnObjectId").val(obj.Address.ObjectId);

}

function DeleteAddress() {

    var vViewModel =
        {

            Address: {

                AddressId: $("[name='Address.AddressId']").val(),

                ObjectId: $("#hdnObjectId").val(),


            },
            Pager: {

                CurrentPage: $('#hdnCurrentPage').val()
            },
        }

    PostAjaxJson("/Address/DeleteAddress", vViewModel, AfterDeleteAddress);

    $("#hdnAddressId").val('');


}

function AfterDeleteAddress(data) {

    FriendlyMessage(data);

    ResetAddress();

    GetAddress();
}

function Pagination(CurrentPage) {

    $('#tblAddress').attr("data-current-page", CurrentPage);

    GetAddress();

}

