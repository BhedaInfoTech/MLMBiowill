$(document).ready(function ()
{
     
    //GetAutocompleteScript("Warehouse Branch");

    //GetAutocompleteById("CourierInfo.BranchId");

    if ($("[name='CourierInfo.Id']").val() == 0) {

        $("#tabAddress").hide();
        $("#tabContact").hide();
    }
    else {

        $("#tabAddress").show();
        $("#tabContact").show();
    }


    $("#btnSaveCourier").click(function () {
         
        if ($("#frmCourier").valid()) {
             
            SaveCourier();
        }

    });

    $("#btnResetCourier").click(function () {

        document.getElementById("frmCourier").reset();

    });


});