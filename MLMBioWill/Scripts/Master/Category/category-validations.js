$(document).ready(function () {

    $("#frmCategory").validate({

        rules: {

             
            "CategoryInfo.CategoryName":
             {
                required: true,
                CheckCategoryNameExist:true
             }

        },
        messages: {
            
            "CategoryInfo.CategoryName":
                {
                    required: "Category name is required."
                }
        }

    });

     
    jQuery.validator.addMethod("CheckCategoryNameExist", function (value, element) {

        return GetAjaxAlreadyExists('/Category/CheckCategoryNameExist', { CategoryName: value }, $("#txtCategoryName"), $("#hdnCategoryName"));

    }, "Category name already exist.")

});





