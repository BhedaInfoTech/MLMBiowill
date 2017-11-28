$(document).ready(function () {
    $("#frmAddress").validate({
        rules: {
            "Address.AddressType":
            {
                required: true,
                CheckAddressExist: true
            },
            "Address.ObjectId":
            {
                //required: true,
                number: true,
            },
            "Address.EmailId":
            {
                required: true
            },
            "Address.Website":
            {
                //required: true
            },
            "Address.Pincode":
            {
                required: true,
                number: true,
            },
            "Address.Address":
            {
                required: true
            },
            "Address.City":
            {
                City: true
            }
            
        },
        messages: {

            "Address.AddressType":
            {
                required: "Address Type is required."
            },
            "Address.ObjectId":
            {
                //required: true
            },
            "Address.EmailId":
            {
                required: "Email Id is required."
            },
            "Address.Website":
            {
                //required: true
            },
            "Address.Pincode":
            {
                required: "Pincode is required."
            },
            "Address.Address":
            {
                required: "Address is required."
            },
            "Address.City":
            {
                dropdownrequired: "City is required."
            }
        }

    });

    jQuery.validator.addMethod("City", function (value, element) {
        var result = true;

        if ($("#drpCity").val() == "0") {
            result = false;
        }

        return result;

    }, "City name is required.");

    jQuery.validator.addMethod("CheckAddressExist", function (value, element) {
        var result = true;

        result =  GetAjaxAlreadyExists('/Address/AddressTypeExist', { AddressType: value, AddFor: $("[name='Address.AddressFor']").val(), ObjectId: $("[name='Address.ObjectId']").val() }, $("#drpAddressType"), "");
        if (result == true)
        {
            result = false;
        }

        return result;

    }, "Address Type already Selected.");

});
