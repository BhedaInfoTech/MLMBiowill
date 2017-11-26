/// <reference path="../../jquery.uploadify.js" />

$(document).ready(function () {

    GetBanks();

    $(document).on('change',"[name='c1']", function (event) {

    	if ($(this).prop('checked'))
        {
             
    		GetSetBankValues($(this));

    		SetActive($("[name='BankInfo.Active']"), $(this).attr("data-active"));
        }
    });

    $("#btnSaveBank").click(function () {
        
        if ($("#frmBank").valid())
        {
            SaveBank();
        }

    });

    $("#btnSearchBank").click(function () {

        $("#tblBank").attr("data-current-page", "0");

        GetBanks();     

    });

    $("#btnResetBank").click(function ()
    {
        ResetBanks();

        GetBanks(); 
    });

});
