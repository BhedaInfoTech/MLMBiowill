$(document).ready(function () {
    
    $(document).on('change', " #tblContactPersonDetails [name='c1']", function (event) {

        if ($(this).prop('checked')) {

            var id = $(this).attr("data-ContactPersonDetailsId");

            $("#hdnSearchContactPersonDetailsId").val(id);

            //document.getElementById("btnEditContactDetails").disabled = false;

            //document.getElementById("btnDeleteContactDetails").disabled = false;

            GetContactPersonDetailsById();

            $("#btnDeleteContactPersonDetails").removeAttr("disabled");
        }

    });

    $("#btnAddContactPersonDetails").click(function () {
        if ($("#frmContactPersonDetails").valid()) {
            SaveContactPersonDetails();
        }
    });

    //$("#btnEditContactDetails").click(function () {
    //    GetContactDetailsById();
    //});

    $("#btnDeleteContactPersonDetails").click(function () {
        DeleteContactPersonDetails();
    });


});