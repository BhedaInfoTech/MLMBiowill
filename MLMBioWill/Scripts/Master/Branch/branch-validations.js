$(document).ready(function () {

    $("#frmBranch").validate({

        rules: {

             
            "BranchInfo.BranchName":
             {
                required: true,
                CheckBranchExist:true
            },
            "BranchInfo.CompanyId":
            {
                required: true                 
            }

        },
        messages: {
            
            "BranchInfo.BranchName":
                {
                    required: "Branch name is required."
            },
            "BranchInfo.CompanyId":
            {
                required: "Company is required."
            }
        }

    });

     
    jQuery.validator.addMethod("CheckBranchExist", function (value, element) {

        return GetAjaxAlreadyExists('/Branch/CheckBranchExist', { branch: value }, $("#txtBranchName"), $("#hdnBranchName"));

    }, "Branch name already exist.")

});





