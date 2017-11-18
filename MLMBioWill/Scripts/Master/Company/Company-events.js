$(document).ready(function () {

    $("#btnSaveCompany").click(function () {
        if ($("#frmCompany").valid()) {
            SaveCompany();
        }

    });

    $("#btnResetCompany").click(function () {

        document.getElementById("frmCompany").reset();

    });

});