$(document).ready(function () {
    $("#frmWarehouse").validate({

        rules: {

            "WarehouseInfo.WarehouseName":
            {
                required: true,
                CheckWarehouseExist: true
            }
            ,
            "WarehouseInfo.BranchId":
            {
                required: true 
            } 
        },
        messages: {

            "WarehouseInfo.WarehouseName":
            {
                required: "Warehouse name is required."
            },
            "WarehouseInfo.BranchId":
            {
                requried: "Branch is required."
            } 
        }

    });

    jQuery.validator.addMethod("CheckWarehouseExist", function (value, element) {

        return GetAjaxAlreadyExists('/Warehouse/CheckWarehouseExist', { warehouse: value }, $("#txtWarehouseName"), $("#hdnWarehouseName"));

    }, "Warehouse name is already exist.");
     

});