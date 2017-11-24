$(document).ready(function () {
    
    $(document).on('change', " #tblContactDetails [name='c1']", function (event) {

        if ($(this).prop('checked')) {

            var id = $(this).attr("data-ContactDetailsId");

            $("#hdnSearchContactDetailsId").val(id);

            //document.getElementById("btnEditContactDetails").disabled = false;

            //document.getElementById("btnDeleteContactDetails").disabled = false;

            GetContactDetailsById();

            $("#btnDeleteContactDetails").removeAttr("disabled");
        }

    });

    $("#btnAddContactDetails").click(function () {
        if ($("#frmContactDetails").valid()) {
            SaveContactDetails();
        }
    });

    //$("#btnEditContactDetails").click(function () {
    //    GetContactDetailsById();
    //});

    $("#btnDeleteContactDetails").click(function () {
        DeleteContactDetails();
    });


});