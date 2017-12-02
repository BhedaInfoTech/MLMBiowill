/// <reference path="../../jquery.uploadify.js" />

$(document).ready(function () {

    GetDesignations();

    $(document).on('change',"[name='c1']", function (event) {

    	if ($(this).prop('checked'))
        {
             
    		GetSetDesignationValues($(this));

    		SetActive($("[name='DesignationInfo.Active']"), $(this).attr("data-active"));
        }
    });

    $("#btnSaveDesignation").click(function () {

        if ($("#frmDesignation").valid())
        {
            SaveDesignation();
        }

    });

    $("#btnSearchDesignation").click(function () {

        $("#tblDesignation").attr("data-current-page", "0");

        GetDesignations();     

    });

    $("#btnResetDesignation").click(function ()
    {
        ResetDesignations();

        GetDesignations();     
    });

});
