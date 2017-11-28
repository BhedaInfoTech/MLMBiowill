function SaveBranch() {
    
	var activeFlg = true;

    if ($("[name='BranchInfo.Active']").val() == 1 || $("[name='BranchInfo.Active']").val() == "true")
    {
        activeFlg = true;
    }
    else
    {
        activeFlg = false;
    }   

    var cViewModel = {

        BranchInfo: {
            
            BranchName: $("[name='BranchInfo.BranchName']").val(),

            CompanyId: $("#drpCompany").val(),

            GSTNumber: $("[name='BranchInfo.GSTNumber']").val(),

            PANNumber: $("[name='BranchInfo.PANNumber']").val(),

            Id: $("[name='Filter.Id']").val(),

            Active: activeFlg
        }
    }

    var url = "";


    if ($("[name='Filter.Id']").val() == 0)
    {

        url = "/Branch/Insert"
    }
    else
    {
        url = "/Branch/Update"
    }

    PostAjaxWithProcessJson(url,cViewModel,AfterSave,$("body"));

}

function AfterSave(data)
{
    
    FriendlyMessage(data);

    ResetBranches();

    GetBranches();
}

function GetBranches() {

    var cViewModel =
		{
            BranchInfo: {

		        Id: "",
                		        
                BranchName: $("[name='BranchInfo.BranchName']").val(),

                GSTNumber: $("[name='BranchInfo.GSTNumber']").val(),

                PANNumber: $("[name='BranchInfo.PANNumber']").val(),

                CompanyId: $("#drpCompany").val(),

                Active: $("[name='BranchInfo.Active']").val()
		    },
		    Pager: {

		    	CurrentPage: $('#tblBranch').attr("data-current-page"),
		    },
		}
     
    PostAjaxWithProcessJson("/Branch/GetBranches", cViewModel, BindBranches, $("#frmSearchBranch"));
}

function BindBranches(data)
{    
     
	var list = JSON.parse(data);

	var kTable = {
        dataList: ["Name", "GSTNumber", "PAN","CompanyName", "IsActiveStr"],
		primayKey:"Id",
        hiddenFields: ["Id", "Name", "GSTNumber", "PAN", "CompanyId","CompanyName", "Active"],
        headerNames: ["Branch Name", "GST No.", "PAN No.","Company Name", "Is Active"],
		data: list.dt
	}

	buildHtmlTable(kTable, $('#tblBranch'));

    BindPagination(list.Pager, $('#tblBranch'));
}

function ResetBranches() {
    
    $("[name='BranchInfo.BranchName']").val("");

    $("[name='BranchInfo.GSTNumber']").val("");

    $("[name='BranchInfo.PANNumber']").val("");

    $("[name='BranchInfo.CompanyId']").val("");

    $("[name='Filter.Id']").val("");

    if ($("[name='BranchInfo.Active']").val() == 0 || $("[name='BranchInfo.Active']").val() == "false")
    {
        $("[name='BranchInfo.Active']").trigger('click');
    }

}

function Pagination(CurrentPage)
{

	$('#tblBranch').attr("data-current-page", CurrentPage);

    GetBranches();

}

function GetSetBranchValues(obj)
{
    var id = $(obj).attr("data-id");     

    var BranchName = $(obj).attr("data-name");

    $("#hdnSearchBranchId").val(id);     

    $("[name='BranchInfo.BranchName']").val(BranchName);

    $("[name='BranchInfo.GSTNumber']").val($(obj).attr("data-gstnumber"));

    $("[name='BranchInfo.PANNumber']").val($(obj).attr("data-pan"));

    $("[name='BranchInfo.CompanyId']").val($(obj).attr("data-companyid"));

    $("[name='BranchInfo.CompanyId']").attr("data-value", $(obj).attr("data-companyid"));

    GetAutocompleteById("Branch.CompanyId");
}


