$(document).ready(function () {
    $("#frmCourier").validate({

        rules: {

            "CourierInfo.CourierName":
            {
                required: true,
                CheckCourierNameExist: true
            }
            ,
            "CourierInfo.CourierId":
            {
                required: true 
            } 
        },
        messages: {

            "CourierInfo.CourierName":
            {
                required: "Courier name is required."
            },
            "CourierInfo.CourierId":
            {
                requried: "Courier Code is required."
            } 
        }

    });

    jQuery.validator.addMethod("CheckCourierNameExist", function (value, element) {

        return GetAjaxAlreadyExists('/Courier/CheckCourierExist', { Courier: value }, $("#txtCourierName"), $("#hdnCourierName"));

    }, "Courier name is already exist.");
     

});