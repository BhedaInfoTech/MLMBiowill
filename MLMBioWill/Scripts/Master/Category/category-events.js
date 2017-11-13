/// <reference path="../../jquery.uploadify.js" />

$(document).ready(function () {

    GetCategories();

    $(document).on('change',"[name='c1']", function (event) {

    	if ($(this).prop('checked'))
        {
             
    		GetSetCategoryValues($(this));

    		SetActive($("[name='CategoryInfo.Active']"), $(this).attr("data-active"));
        }
    });

    $("#btnSaveCategory").click(function () {

        if ($("#frmCategory").valid())
        {
            SaveCategory();
        }

    });

    $("#btnSearchCategory").click(function () {

        $("#tblCategory").attr("data-current-page", "0");

        GetCategories();     

    });

    $("#btnResetCategory").click(function ()
    {
        ResetCategories();
    });

});
