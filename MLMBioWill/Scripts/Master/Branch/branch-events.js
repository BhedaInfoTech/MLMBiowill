/// <reference path="../../jquery.uploadify.js" />

$(document).ready(function () {

    GetBranches();

    $(document).on('change',"[name='c1']", function (event) {

    	if ($(this).prop('checked'))
        {
             
    		GetSetBranchValues($(this));

    		SetActive($("[name='BranchInfo.Active']"), $(this).attr("data-active"));
        }
    });

    $("#btnSaveBranch").click(function () {

        if ($("#frmBranch").valid())
        {
            SaveBranch();
        }

    });

    $("#btnSearchBranch").click(function () {

        $("#tblBranch").attr("data-current-page", "0");

        GetBranches();     

    });

    $("#btnResetBranch").click(function ()
    {
        ResetBranches();
    });

});
