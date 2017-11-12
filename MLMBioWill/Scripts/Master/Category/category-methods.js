function SaveCategory() {
     
	var activeFlg = true;

    if ($("[name='CategoryInfo.Active']").val() == 1 || $("[name='CategoryInfo.Active']").val() == "true")
    {
        activeFlg = true;
    }
    else
    {
        activeFlg = false;
    }   

    var cViewModel = {

        CategoryInfo: {
            
            CategoryName: $("[name='CategoryInfo.CategoryName']").val(),

            CategoryId: $("[name='Filter.CategoryId']").val(),

            Active: activeFlg
        }
    }

    var url = "";


    if ($("[name='Filter.CategoryId']").val() == 0)
    {

        url = "/Category/Insert"
    }
    else
    {
        url = "/Category/Update"
    }


    PostAjaxWithProcessJson(url,cViewModel,AfterSave,$("body"));

}

function AfterSave(data)
{
    
    FriendlyMessage(data);

    ResetCategories();

    GetCategories();
}

function GetCategories() {

    var cViewModel =
		{
            CategoryInfo: {

		        CategoryId: "",
                		        
		        CategoryName: $("[name='CategoryInfo.CategoryName']").val(),

                Active: $("[name='CategoryInfo.Active']").val()
		    },
		    Pager: {

		    	CurrentPage: $('#tblCategory').attr("data-current-page"),
		    },
		}
     
    PostAjaxWithProcessJson("/Category/GetCategories", cViewModel, BindCategories, $("#frmSearchCategory"));
}

function BindCategories(data)
{    
     
	var list = JSON.parse(data);

	var kTable = {
		dataList: ["Name", "IsActiveStr"],
		primayKey:"Id",
		hiddenFields: ["Id", "Name", "Active"],
		headerNames:["Category Name", "Is Active"],
		data: list.dt,
	}

	buildHtmlTable(kTable, $('#tblCategory'));

	BindPagination(list.Pager, $('#tblCategory'));
}

function ResetCategories() {

    

    $("[name='CategoryInfo.CategoryName']").val("");

    $("[name='CategoryInfo.CategoryId']").val("");

    $("[name='Filter.CategoryId']").val("");

    if ($("[name='CategoryInfo.Active']").val() == 0 || $("[name='CategoryInfo.Active']").val() == "false")
    {
        $("[name='CategoryInfo.Active']").trigger('click');
    }

}

function Pagination(CurrentPage)
{

	$('#tblCategory').attr("data-current-page", CurrentPage);

    GetCategories();

}

function GetSetCategoryValues(obj)
{
    var id = $(obj).attr("data-id");     

    var categoryName = $(obj).attr("data-name");

    $("#hdnSearchCategoryId").val(id);     

    $("[name='CategoryInfo.CategoryName']").val(categoryName);

}


