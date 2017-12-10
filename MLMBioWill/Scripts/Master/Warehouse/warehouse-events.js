$(document).ready(function ()
{
     
    //GetAutocompleteScript("Warehouse Branch");

    //GetAutocompleteById("WarehouseInfo.BranchId");

    if ($("[name='WarehouseInfo.Id']").val() == 0) {

        $("#tabAddress").hide();
        $("#tabContact").hide();
    }
    else {

        $("#tabAddress").show();
        $("#tabContact").show();
    }


    $("#btnSaveWarehouse").click(function () {
         
        if ($("#frmWarehouse").valid()) {
             
            SaveWarehouse();
        }

    });

    $("#btnResetWarehouse").click(function () {

        document.getElementById("frmWarehouse").reset();

    });


});