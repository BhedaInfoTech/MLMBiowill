/// <reference path="../../jquery.uploadify.js" />

$(document).ready(function () {

    GetDepartments();

    $(document).on('change',"[name='c1']", function (event) {

    	if ($(this).prop('checked'))
        {
            
    		GetSetDepartmentValues($(this));

    		SetActive($("[name='DepartmentInfo.Active']"), $(this).attr("data-active"));
        }
    });

    $("#btnSaveDepartment").click(function () {

        if ($("#frmDepartment").valid())
        {
            SaveDepartment();
        }

    });

    $("#btnSearchDepartment").click(function () {

        $("#tblDepartment").attr("data-current-page", "0");

        GetDepartments();     

    });

    $("#btnResetDepartment").click(function ()
    {
        ResetDepartment();

        GetDepartments();
    });

});
