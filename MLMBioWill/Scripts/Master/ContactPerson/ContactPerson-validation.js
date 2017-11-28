$(document).ready(function () {
    $("#frmContactDetails").validate({
        rules: {
            "ContactDetails.ContactType":
            {
                required: true
                //CheckContactExist: true
            },
            "ContactDetails.ObjectId":
            {
                //required: true,
                number: true,
            },
            "ContactDetails.CountryCode":
            {
                required: true,
                number :true
            },
            "ContactDetails.StdCode":
            {
                number : true
                //required: true
            },
            "ContactDetails.TelMobNumber":
            {
                required: true,
                number: true,
            }
            
        },
        messages: {

            "ContactDetails.ContactType":
            {
                required: "Contact Type is required."
            },
            "ContactDetails.ObjectId":
            {
                //required: true
            },
            "ContactDetails.CountryCode":
            {
                required: "Country Code is required."
            },
            "ContactDetails.StdCode":
            {
                //required: true
            },
            "ContactDetails.TelMobNumber":
            {
                required: "Telephone/Mobile Number is required."
            } 
        }

    });

    jQuery.validator.addMethod("CheckContactExist", function (value, element) {
        var result = true;

        result =  GetAjaxAlreadyExists('/Contact/ContactTypeExist', { ContactType: value, AddFor: $("[name='ContactDetails.ContactFor']").val(), ObjectId: $("[name='ContactDetails.ObjectId']").val() }, $("#drpContactType"), "");
        if (result == true)
        {
            result = false;
        }

        return result;

    }, "Contact Type already Selected.");

});
