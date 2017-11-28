$(document).ready(function () {

    $("#frmBank").validate({

        rules: {

             
            "BankInfo.BankName":
             {
                required: true,
                CheckBankExist:true
             }

        },
        messages: {
            
            "BankInfo.BankName":
                {
                    required: "Bank name is required."
                }
        }

    });

     
    jQuery.validator.addMethod("CheckBankExist", function (value, element) {

        return GetAjaxAlreadyExists('/Bank/CheckBankNameExist', { BankName: value }, $("#txtBankName"), $("#hdnBankName"));

    }, "Bank already exist.")

});





