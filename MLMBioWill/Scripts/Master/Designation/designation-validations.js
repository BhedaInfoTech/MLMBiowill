$(document).ready(function () {

    $("#frmDesignation").validate({

        rules: {

             
            "DesignationInfo.DesignationName":
             {
                required: true,
                CheckDesignationExist:true
             }

        },
        messages: {
            
            "DesignationInfo.DesignationName":
                {
                    required: "Designation name is required."
                }
        }

    });

     
    jQuery.validator.addMethod("CheckDesignationExist", function (value, element) {

        return GetAjaxAlreadyExists('/Designation/CheckDesignationNameExist', { DesignationName: value }, $("#txtDesignationName"), $("#hdnDesignationName"));

    }, "Designation name already exist.")

});





