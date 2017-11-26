function SaveDepartment() {
     
	var activeFlg = true;

    if ($("[name='DepartmentInfo.Active']").val() == 1 || $("[name='DepartmentInfo.Active']").val() == "true")
    {
        activeFlg = true;
    }
    else
    {
        activeFlg = false;
    }   

    var cViewModel = {

        DepartmentInfo: {
            
            DepartmentName: $("[name='DepartmentInfo.DepartmentName']").val(),

            Id: $("[name='Filter.Id']").val(),

            Active: activeFlg
        }
    }

    var url = "";


    if ($("[name='Filter.Id']").val() == 0)
    {

        url = "/Department/Insert"
    }
    else
    {
        url = "/Department/Update"
    }


    PostAjaxWithProcessJson(url,cViewModel,AfterSave,$("body"));

}

function AfterSave(data)
{    
    FriendlyMessage(data);

    ResetDepartment();

    GetDepartments();
}

function GetDepartments() {

    var cViewModel =
		{
            DepartmentInfo: {

		        Id: "",
                		        
                DepartmentName: $("[name='DepartmentInfo.DepartmentName']").val(),

                Active: $("[name='DepartmentInfo.Active']").val()
		    },
		    Pager: {

		    	CurrentPage: $('#tblDepartment').attr("data-current-page"),
		    },
		}
     
    PostAjaxWithProcessJson("/Department/GetDepartments", cViewModel, BindDepartments, $("#frmSearchDepartment"));
}

function BindDepartments(data)
{              
	var list = JSON.parse(data);

	var kTable = {
        dataList: ["Department", "IsActiveStr"],
		primayKey:"Id",
        hiddenFields: ["Id", "Department", "Active"],
		headerNames:["Department Name", "Is Active"],
		data: list.dt,
	}

	buildHtmlTable(kTable, $('#tblDepartment'));

	BindPagination(list.Pager, $('#tblDepartment'));
}

function ResetDepartment() {
    
    $("[name='DepartmentInfo.DepartmentName']").val("");

    $("[name='DepartmentInfo.Id']").val("");

    $("[name='Filter.Id']").val("");

    if ($("[name='DepartmentInfo.Active']").val() == 0 || $("[name='DepartmentInfo.Active']").val() == "false")
    {
        $("[name='DepartmentInfo.Active']").trigger('click');
    }

}

function Pagination(CurrentPage)
{

	$('#tblDepartment').attr("data-current-page", CurrentPage);

    GetDepartments();

}

function GetSetDepartmentValues(obj)
{
    var id = $(obj).attr("data-id");     

    var departmentName = $(obj).attr("data-department");

    $("#hdnSearchDepartmentId").val(id);     

    $("[name='DepartmentInfo.DepartmentName']").val(departmentName);

}


