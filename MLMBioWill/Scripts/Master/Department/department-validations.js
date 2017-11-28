$(document).ready(function () {

    $("#frmDepartment").validate({

        rules: {

             
            "DepartmentInfo.DepartmentName":
             {
                required: true,
                CheckDepartmentExist:true
             }

        },
        messages: {
            
            "DepartmentInfo.DepartmentName":
                {
                    required: "Department name is required."
                }
        }

    });

     
    jQuery.validator.addMethod("CheckDepartmentExist", function (value, element) {

        return GetAjaxAlreadyExists('/Department/CheckDepartmentExist', { DepartmentName: value }, $("#txtDepartmentName"), $("#hdnDepartmentName"));

    }, "Department name already exist.")

});





