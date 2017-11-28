
function SaveContactDetails() {

    if ($("[name='ContactDetails.IsDefault']").val() == 1 || $("[name='ContactDetails.IsDefault']").val().toLowerCase() == "true") {
        DefaultFlag = true;
    }
    else {
        DefaultFlag = false;
    }


    if ($("[name='ContactDetails.IsActive']").val() == 1 || $("[name='ContactDetails.IsActive']").val().toLowerCase() == "true") {
        activeFlg = true;
    }
    else {
        activeFlg = false;
    }

    $("#frmContactDetails").blur();

    var vViewModel = {

        ContactDetails: {

            ContactId: $("[name='ContactDetails.ContactId']").val(),

            ContactFor: $("[name='ContactDetails.ContactFor']").val(),

            ContactType: $("[name='ContactDetails.ContactType']").val(),

            ObjectId: $("[name='ContactDetails.ObjectId']").val(),

            IsDefault: DefaultFlag,

            CountryCode: $("[name='ContactDetails.CountryCode']").val(),

            StdCode: $("[name='ContactDetails.StdCode']").val(),

            TelMobNumber: $("[name='ContactDetails.TelMobNumber']").val(),
            
            IsActive: activeFlg
        }
    }
    var url = "";

    if ($("[name='ContactDetails.ContactId']").val() == 0) {

        url = "/Contact/InsertContact"
    }
    else {
        url = "/Contact/UpdateContact"

    }
    PostAjaxJson(url, vViewModel, AfterContactDetailsSave);
}

function AfterContactDetailsSave(data) {

    FriendlyMessage(data);

    ResetContactDetails();

    GetContactDetails();

}

function ResetContactDetails() {

    $("#hdnSearchContactId").val('');

    $("#drpContactType").val('0');

    SetActive($("[name='ContactDetails.IsDefault']"), false);

    $("[name='ContactDetails.CountryCode']").val('');

    $("[name='ContactDetails.StdCode']").val('');

    $("[name='ContactDetails.TelMobNumber']").val('');

    SetActive($("[name='ContactDetails.IsActive']"), false);

}

function GetContactDetails() {

    var vViewModel =
        {
            ContactDetails: {

                ContactFor: $("#hdnAddFor").val(),

                ObjectId: $("#hdnObjectId").val(),

            },
            Pager: {

                CurrentPage: $('#tblContactDetails').attr("data-current-page"),
            },
        }

    PostAjaxJson("/Contact/GetContactList", vViewModel, BindContactDetails);
}

function BindContactDetails(data) {

    var list = JSON.parse(data);

    var kTable = {
        dataList: ["ContactType", "StdCode", "TelMobNumber", "IsDefault", "Active"],
        primayKey: "ContactId",
        hiddenFields: ["ContactId", "CountryCode","ContactFor", "ObjectId"],
        headerNames: ["Contact Type", "State Code", "Tel. Number" , "Default", "Active"],
        data: list.dt,
    }

    buildHtmlTable(kTable, $('#tblContactDetails'));

    BindPagination(list.Pager, $('#tblContactDetails'));

}

function GetContactDetailsById() {

    var vViewModel =
        {
            ContactDetails: {

                ContactId: $("#hdnSearchContactId").val(),


            },
            Pager: {

                CurrentPage: $('#tblContactDetails').attr("data-current-page"),
            },
        }

    PostAjaxJson("/Contact/GetContactById", vViewModel, BindContactDetailsById);
}

function BindContactDetailsById(data) {

    var obj = data;

    var City = obj.ContactDetails.City;


    $("[name='ContactDetails.ContactId']").val(obj.ContactDetails.ContactId);

    $("[name='ContactDetails.ContactFor']").val(obj.ContactDetails.ContactFor);

    $("[name='ContactDetails.ContactType']").val(obj.ContactDetails.ContactType);

    $("[name='ContactDetails.ObjectId']").val(obj.ContactDetails.ObjectId);

    SetActive($("[name='ContactDetails.IsDefault']"), obj.ContactDetails.IsDefault);

    $("[name='ContactDetails.CountryCode']").val(obj.ContactDetails.CountryCode);

    $("[name='ContactDetails.StdCode']").val(obj.ContactDetails.StdCode);

    $("[name='ContactDetails.TelMobNumber']").val(obj.ContactDetails.TelMobNumber);
  
    SetActive($("[name='ContactDetails.IsActive']"), obj.ContactDetails.IsActive);
  
    $("#hdnContactAddFor").val(obj.ContactDetails.ContactFor);

    $("#hdnContactObjectId").val(obj.ContactDetails.ObjectId);

}

function DeleteContactDetails() {

    var vViewModel =
        {

            ContactDetails: {

                ContactId: $("[name='ContactDetails.ContactId']").val(),

                ObjectId: $("#hdnObjectId").val(),


            },
            Pager: {

                CurrentPage: $('#hdnCurrentPage').val()
            },
        }

    PostAjaxJson("/Contact/DeleteContactDetails", vViewModel, AfterDeleteContactDetails);

    $("#hdnContactId").val('');


}

function AfterDeleteContactDetails(data) {

    FriendlyMessage(data);

    ResetContactDetails();

    GetContactDetails();
}

function Pagination(CurrentPage) {

    $('#tblContactDetails').attr("data-current-page", CurrentPage);

    GetContactDetails();

}

