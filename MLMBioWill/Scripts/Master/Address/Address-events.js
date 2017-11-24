$(document).ready(function () {

    GetAutocompleteScript("Address");

    GetAutocompleteById("Address.City");

    GetAddress();

    $(document).on('change', " #tblAddress [name='c1']", function (event) {

        if ($(this).prop('checked')) {

            var id = $(this).attr("data-AddressId");

            $("#hdnSearchAddressId").val(id);

            //document.getElementById("btnEditAddress").disabled = false;

            //document.getElementById("btnDeleteAddress").disabled = false;

            GetAddressById();

            $("#btnDeleteAddress").removeAttr("disabled");
        }

    });

    $("#btnAddAddress").click(function () {
        if ($("#frmAddress").valid()) {
            SaveAddress();
        }
    });

    //$("#btnEditAddress").click(function () {
    //    GetAddressById();
    //});

    $("#btnDeleteAddress").click(function () {

        DeleteAddress();
    });


});