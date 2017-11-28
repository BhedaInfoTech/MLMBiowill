function SaveBank() {
     
	var activeFlg = true;

    if ($("[name='BankInfo.Active']").val() == 1 || $("[name='BankInfo.Active']").val() == "true")
    {
        activeFlg = true;
    }
    else
    {
        activeFlg = false;
    }   

    var cViewModel = {

        BankInfo: {
            
            BankName: $("[name='BankInfo.BankName']").val(),

            BranchName: $("[name='BankInfo.BranchName']").val(),

            IFSCCode: $("[name='BankInfo.IFSCCode']").val(),

            Id: $("[name='Filter.Id']").val(),

            Active: activeFlg
        }
    }

    var url = "";


    if ($("[name='Filter.Id']").val() == 0)
    {

        url = "/Bank/Insert"
    }
    else
    {
        url = "/Bank/Update"
    }


    PostAjaxWithProcessJson(url,cViewModel,AfterSave,$("body"));

}

function AfterSave(data)
{
    
    FriendlyMessage(data);

    ResetBanks();

    GetBanks();
}

function GetBanks() {
    
    var cViewModel =
		{
            BankInfo: {

		        Id: "",
                		        
                BankName: $("[name='BankInfo.BankName']").val(),

                BranchName: $("[name='BankInfo.BranchName']").val(),

                IFSCCode: $("[name='BankInfo.IFSCCode']").val(),

                Active: $("[name='BankInfo.Active']").val()
		    },
		    Pager: {

		    	CurrentPage: $('#tblBank').attr("data-current-page"),
		    },
		}
     
    PostAjaxWithProcessJson("/Bank/GetBanks", cViewModel, BindBanks, $("#frmSearchBank"));
}

function BindBanks(data)
{    
     
	var list = JSON.parse(data);

	var kTable = {
        dataList: ["BankName", "BankBranch","IFSCCode", "IsActiveStr"],
		primayKey:"Id",
        hiddenFields: ["Id", "BankName", "BankBranch","IFSCCode", "Active"],
		headerNames:["Bank Name","Branch Name","IFSC Code", "Is Active"],
		data: list.dt,
	}

	buildHtmlTable(kTable, $('#tblBank'));

	BindPagination(list.Pager, $('#tblBank'));
}

function ResetBanks() {

    

    $("[name='BankInfo.BankName']").val("");

    $("[name='BankInfo.BranchName']").val("");

    $("[name='BankInfo.IFSCCode']").val("");

    $("[name='Filter.Id']").val("");

    if ($("[name='BankInfo.Active']").val() == 0 || $("[name='BankInfo.Active']").val() == "false")
    {
        $("[name='BankInfo.Active']").trigger('click');
    }

}

function Pagination(CurrentPage)
{

	$('#tblBank').attr("data-current-page", CurrentPage);

    GetBanks();

}

function GetSetBankValues(obj)
{
    var id = $(obj).attr("data-id");     

    var bankName = $(obj).attr("data-bankname");

    $("#hdnSearchBankId").val(id);     

    $("[name='BankInfo.BankName']").val(bankName);

    $("[name='BankInfo.BranchName']").val($(obj).attr("data-bankbranch"));

    $("[name='BankInfo.IFSCCode']").val($(obj).attr("data-ifsccode"));

}


