$(document).ready(function () {

    GetCompany();

    document.getElementById("btnEditCompany").disabled = true;

    document.getElementById("btnViewContactDetails").disabled = true;

    $(document).on('change', "#tblCompany [name='c1']", function (event) {

        if ($(this).prop('checked')) {

            var id = $(this).attr("data-Companyid");

            $("#hdnSearchCompanyId").val(id);

            document.getElementById("btnEditCompany").disabled = false;

            document.getElementById("btnViewContactDetails").disabled = false;

        }

    });

    $("#btnSearchCompany").click(function () {

        $("#tblCompany").attr("data-current-page", "0");

        GetCompany();
    });

    $("#btnEditCompany").click(function () {

        $("#frmSearchCompany").attr("action", "/Company/GetCompanyById");

        $("#frmSearchCompany").submit();

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