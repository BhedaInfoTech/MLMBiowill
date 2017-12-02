/// <reference path="../../jquery.uploadify.js" />

$(document).ready(function () {

    GetAutocompleteScript("Subcategory");

    GetSubCategories();

    $(document).on('change',"[name='c1']", function (event) {

    	if ($(this).prop('checked'))
        {
             
    		GetSetSubCategoryValues($(this));

            SetActive($("[name='SubcategoryInfo.Active']"), $(this).attr("data-active"));
        }
    });

    $("#btnSaveSubCategory").click(function () {

        if ($("#frmSubCategory").valid())
        {
            SaveSubCategory();
        }

    });

    $("#btnSearchSubCategory").click(function () {

        $("#tblSubCategory").attr("data-current-page", "0");

        GetSubCategories();     

    });

    $("#btnResetSubCategory").click(function ()
    {
        ResetSubCategories();

        GetSubCategories();
    });

});
