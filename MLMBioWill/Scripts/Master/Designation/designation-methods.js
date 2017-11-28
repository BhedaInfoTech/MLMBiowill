function SaveDesignation() {
     
	var activeFlg = true;

    if ($("[name='DesignationInfo.Active']").val() == 1 || $("[name='DesignationInfo.Active']").val() == "true")
    {
        activeFlg = true;
    }
    else
    {
        activeFlg = false;
    }   

    var cViewModel = {

        DesignationInfo: {
            
            DesignationName: $("[name='DesignationInfo.DesignationName']").val(),

            Id: $("[name='Filter.Id']").val(),

            Active: activeFlg
        }
    }

    var url = "";


    if ($("[name='Filter.Id']").val() == 0)
    {

        url = "/Designation/Insert"
    }
    else
    {
        url = "/Designation/Update"
    }


    PostAjaxWithProcessJson(url,cViewModel,AfterSave,$("body"));

}

function AfterSave(data)
{
    
    FriendlyMessage(data);

    ResetDesignations();

    GetDesignations();
}

function GetDesignations() {

    var cViewModel =
		{
            DesignationInfo: {

		        Id: "",
                		        
                DesignationName: $("[name='DesignationInfo.DesignationName']").val(),

                Active: $("[name='DesignationInfo.Active']").val()
		    },
		    Pager: {

		    	CurrentPage: $('#tblDesignaton').attr("data-current-page"),
		    },
		}
     
    PostAjaxWithProcessJson("/Designation/GetDesignation", cViewModel, BindDesignations, $("#frmSearchDesignation"));
}

function BindDesignations(data)
{    
     
	var list = JSON.parse(data);

	var kTable = {
        dataList: ["Designation", "IsActiveStr"],
		primayKey:"Id",
        hiddenFields: ["Id", "Designation", "Active"],
		headerNames:["Designation Name", "Is Active"],
		data: list.dt,
	}

	buildHtmlTable(kTable, $('#tblDesignation'));

	BindPagination(list.Pager, $('#tblDesignation'));
}

function ResetDesignations() {    

    $("[name='DesignationInfo.DesignationName']").val("");

    $("[name='DesignationInfo.Id']").val("");

    $("[name='Filter.Id']").val("");

    if ($("[name='DesignationInfo.Active']").val() == 0 || $("[name='DesignationInfo.Active']").val() == "false")
    {
        $("[name='DesignationInfo.Active']").trigger('click');
    }

}

function Pagination(CurrentPage)
{

	$('#tblDesignation').attr("data-current-page", CurrentPage);

    GetDesignations();

}

function GetSetDesignationValues(obj)
{
    var id = $(obj).attr("data-id");     

    var designationName = $(obj).attr("data-designation");

    $("#hdnSearchDesignationId").val(id);     

    $("[name='DesignationInfo.DesignationName']").val(designationName);

}


