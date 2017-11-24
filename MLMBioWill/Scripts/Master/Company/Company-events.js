$(document).ready(function () {


    if ($("[name='Company.CompanyId']").val() == 0) {

        $("#link1").hide();
        $("#link2").hide();
    }
    else {

        $("#link1").show();
        $("#link2").show();
    }


    $("#btnSaveCompany").click(function () {
        if ($("#frmCompany").valid()) {
            SaveCompany();
        }

    });

    $("#btnResetCompany").click(function () {

        document.getElementById("frmCompany").reset();

    });



});