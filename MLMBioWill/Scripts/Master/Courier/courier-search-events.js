$(document).ready(function () {

    GetCourier();

    document.getElementById("btnEditCourier").disabled = true;

    document.getElementById("btnViewContactDetails").disabled = true;

    $(document).on('change', "#tblCourier [name='c1']", function (event) {

        if ($(this).prop('checked')) {

            var id = $(this).attr("data-id");

            $("#hdnSearchCourierId").val(id);

            document.getElementById("btnEditCourier").disabled = false;

            document.getElementById("btnViewContactDetails").disabled = false;

        }

    });

    $("#btnSearchCourier").click(function () {

        $("#tblCourier").attr("data-current-page", "0");

        GetCourier();
    });

    $("#btnEditCourier").click(function () {

        var cViewModel =
            {
                CourierFilter: {                     

                    Id: $("[name='CourierFilter.Id']").val(),

                } 
            }
         

        $("#frmSearchCourier").attr("action", "/Courier/GetCourierById");

        $("#frmSearchCourier").submit();

    });

    $("#btnViewContactDetails").click(function (event) {

        //$(".parent-modal").find(".modal-body").load("/Hotel/GetContactPersonListing", null, call_back);
    });

    function call_back(data) {

        $(".parent-modal").find(".modal-title").html("Contact details");

        GetContactPerson();

        $(".parent-modal").modal("show");
    }

    $("#btnResetCourier").click(function () {

        document.getElementById("frmSearchCourier").reset();
    });

});