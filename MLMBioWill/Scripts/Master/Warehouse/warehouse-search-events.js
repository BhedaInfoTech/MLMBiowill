$(document).ready(function () {

    GetWarehouse();

    document.getElementById("btnEditWarehouse").disabled = true;

    document.getElementById("btnViewContactDetails").disabled = true;

    $(document).on('change', "#tblWarehouse [name='c1']", function (event) {

        if ($(this).prop('checked')) {

            var id = $(this).attr("data-id");

            $("#hdnSearchWarehouseId").val(id);

            document.getElementById("btnEditWarehouse").disabled = false;

            document.getElementById("btnViewContactDetails").disabled = false;

        }

    });

    $("#btnSearchWarehouse").click(function () {

        $("#tblWarehouse").attr("data-current-page", "0");

        GetWarehouse();
    });

    $("#btnEditWarehouse").click(function () {

        var wViewModel =
            {
                WarehouseFilter: {                     

                    Id: $("[name='WarehouseFilter.Id']").val(),

                } 
            }
         

        $("#frmSearchWarehouse").attr("action", "/Warehouse/GetWarehouseById");

        $("#frmSearchWarehouse").submit();

    });

    $("#btnViewContactDetails").click(function (event) {

        //$(".parent-modal").find(".modal-body").load("/Hotel/GetContactPersonListing", null, call_back);
    });

    function call_back(data) {

        $(".parent-modal").find(".modal-title").html("Contact details");

        GetContactPerson();

        $(".parent-modal").modal("show");
    }

    $("#btnResetCompany").click(function () {

        document.getElementById("frmSearchCompany").reset();
    });

});