$(document).ready(function () {
    $("#frmCompany").validate({

        rules: {

            "Company.CompanyName":
            {
                required: true,
                CheckCompanyNameExist: true
            },
            "Company.GSTNumber":
            {
                required: true,
                maxlength:20
            },
            "Company.PAN":
            {
                required: true,
                maxlength: 10
            }
        },
        messages: {

            "Company.CompanyName":
            {
                required: "Company name is required."
            },
            "Company.GSTNumber":
            {
                requried: "Company GST Number is required."
            },
            "Company.PAN":
            {
                required: "PAN Number is required.",
            }
        }

    });





    jQuery.validator.addMethod("CheckCompanyNameExist", function (value, element) {

        return GetAjaxAlreadyExists('/Company/CheckCompanyNameExist', { CompanyName: value }, $("#txtCompanyName"), $("#hdnCompanyName"));

    }, "Company name is already exist.");


    jQuery.validator.addMethod("CheckPanFormat", function (value, element) {

         

    }, "Pan should be in XXXXX1111X format.");


    //jQuery.validator.addMethod("Url", function (value, element) {

    //    return /^http(s)?:\/\/(www\.)?[a-z0-9]+([\-\.]{1}[a-z0-9]+)*\.[a-z]{2,5}(:[0-9]{1,5})?(\/.*)?$/.test(value);
    //});














    jQuery.validator.addMethod("BusinessType", function (value, element) {
        var result = true;

        if ($("#drpBusinessType").val() == "0") {
            result = false;
        }

        return result;

    }, "Service type is required.");

    jQuery.validator.addMethod("City", function (value, element) {
        var result = true;

        if ($("#drpCity").val() == "0") {
            result = false;
        }

        return result;

    }, "City name is required.");

    jQuery.validator.addMethod("PaymentOption", function (value, element) {
        var result = true;

        if ($("#drpPaymentOption").val() == "0") {
            result = false;
        }

        return result;

    }, "Payment option is required.");


});