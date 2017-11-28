$(document).ready(function () {

    $("#frmSubCategory").validate({

        rules: {

             
            "SubcategoryInfo.SubCategoryName":
             {
                required: true,
                CheckSubcategoryExist:true
            },
            "SubcategoryInfo.CategoryId":
            {
                required: true                 
            }

        },
        messages: {
            
            "SubcategoryInfo.SubCategoryName":
                {
                    required: "Subcategory name is required."
            },
            "SubcategoryInfo.CategoryId":
            {
                required: "Category is required."
            }
        }

    });

     
    jQuery.validator.addMethod("CheckSubcategoryExist", function (value, element) {

        return GetAjaxAlreadyExists('/Subcategory/CheckSubcategoryExist', { subcategoryName: value }, $("#txtSubCategoryName"), $("#hdnSubCategoryName"));

    }, "Branch name already exist.")

});





