
function SaveContactPersonDetails() {

    if ($("[name='ContactPersonDetails.IsDefault']").val() == 1 || $("[name='ContactPersonDetails.IsDefault']").val().toLowerCase() == "true") {
        DefaultFlag = true;
    }
    else {
        DefaultFlag = false;
    }


    if ($("[name='ContactPersonDetails.IsActive']").val() == 1 || $("[name='ContactPersonDetails.IsActive']").val().toLowerCase() == "true") {
        activeFlg = true;
    }
    else {
        activeFlg = false;
    }

    $("#frmContactPersonDetails").blur();

    var vViewModel = {

        ContactPersonDetails: {

            ContactPersonId: $("[name='ContactPersonDetails.ContactId']").val(),

            ContactPersonFor: $("[name='ContactPersonDetails.ContactFor']").val(),
            
            ObjectId: $("[name='ContactPersonDetails.ObjectId']").val(),

            FirstName: $("[name='ContactPersonDetails.ContactFor']").val(),

            MiddleName: $("[name='ContactPersonDetails.ContactFor']").val(),

            LastName: $("[name='ContactPersonDetails.ContactFor']").val(),

            Designation: $("[name='ContactPersonDetails.Designation']").val(),

            EmailId: $("[name='ContactPersonDetails.ContactFor']").val(),

            IsDefault: DefaultFlag,

            IsActive: activeFlg
        }
    }
    var url = "";

    if ($("[name='ContactPersonDetails.ContactId']").val() == 0) {

        url = "/Contact/InsertContactPerson"
    }
    else {
        url = "/Contact/UpdateContactPerson"

    }
    PostAjaxJson(url, vViewModel, AfterContactPersonDetailsSave);
}

function AfterContactPersonDetailsSave(data) {

    FriendlyMessage(data);

    ResetContactPersonDetails();

    GetContactPersonDetails();

}

function ResetContactPersonDetails() {

    $("#hdnSearchContactId").val('');

    $("#drpContactPersonFor").val('0');

    SetActive($("[name='ContactPersonDetails.IsDefault']"), false);

    $("[name='ContactPersonDetails.CountryCode']").val('');

    $("[name='ContactPersonDetails.StdCode']").val('');

    $("[name='ContactPersonDetails.TelMobNumber']").val('');

    SetActive($("[name='ContactPersonDetails.IsActive']"), false);

}

function GetContactPersonDetails() {

    var vViewModel =
        {
            ContactPersonDetails: {

                ContactFor: $("#hdnAddFor").val(),

                ObjectId: $("#hdnObjectId").val(),

            },
            Pager: {

                CurrentPage: $('#tblContactPersonDetails').attr("data-current-page"),
            },
        }

    PostAjaxJson("/Contact/GetContactList", vViewModel, BindContactPersonDetails);
}

function BindContactPersonDetails(data) {

    var list = JSON.parse(data);

    var kTable = {
        dataList: ["ContactType", "StdCode", "TelMobNumber", "IsDefault", "Active"],
        primayKey: "ContactId",
        hiddenFields: ["ContactId", "CountryCode","ContactFor", "ObjectId"],
        headerNames: ["Contact Type", "State Code", "Tel. Number" , "Default", "Active"],
        data: list.dt,
    }

    buildHtmlTable(kTable, $('#tblContactPersonDetails'));

    BindPagination(list.Pager, $('#tblContactPersonDetails'));

}

function GetContactPersonDetailsById() {

    var vViewModel =
        {
            ContactPersonDetails: {

                ContactPersonId: $("#hdnSearchContactId").val(),
            },
            Pager: {

                CurrentPage: $('#tblContactPersonDetails').attr("data-current-page"),
            },
        }

    PostAjaxJson("/Contact/GetContactPersonById", vViewModel, BindContactPersonDetailsById);
}

function BindContactPersonDetailsById(data) {

    var obj = data;

    var City = obj.ContactPersonDetails.Designation;


    $("[name='ContactPersonDetails.ContactId']").val(obj.ContactPersonDetails.ContactId);

    $("[name='ContactPersonDetails.ContactFor']").val(obj.ContactPersonDetails.ContactFor);

    $("[name='ContactPersonDetails.ContactType']").val(obj.ContactPersonDetails.ContactType);

    $("[name='ContactPersonDetails.ObjectId']").val(obj.ContactPersonDetails.ObjectId);

    SetActive($("[name='ContactPersonDetails.IsDefault']"), obj.ContactPersonDetails.IsDefault);

    $("[name='ContactPersonDetails.CountryCode']").val(obj.ContactPersonDetails.CountryCode);

    $("[name='ContactPersonDetails.StdCode']").val(obj.ContactPersonDetails.StdCode);

    $("[name='ContactPersonDetails.TelMobNumber']").val(obj.ContactPersonDetails.TelMobNumber);
  
    SetActive($("[name='ContactPersonDetails.IsActive']"), obj.ContactPersonDetails.IsActive);
  
    $("#hdnContactAddFor").val(obj.ContactPersonDetails.ContactFor);

    $("#hdnContactObjectId").val(obj.ContactPersonDetails.ObjectId);

}

function DeleteContactPersonDetails() {

    var vViewModel =
        {

            ContactPersonDetails: {

                ContactId: $("[name='ContactPersonDetails.ContactId']").val(),

                ObjectId: $("#hdnObjectId").val(),


            },
            Pager: {

                CurrentPage: $('#hdnCurrentPage').val()
            },
        }

    PostAjaxJson("/Contact/DeleteContactPersonDetails", vViewModel, AfterDeleteContactPersonDetails);

    $("#hdnContactId").val('');


}

function AfterDeleteContactPersonDetails(data) {

    FriendlyMessage(data);

    ResetContactPersonDetails();

    GetContactPersonDetails();
}

function Pagination(CurrentPage) {

    $('#tblContactPersonDetails').attr("data-current-page", CurrentPage);

    GetContactPersonDetails();

}

