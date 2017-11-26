function SaveSubCategory() {
     
	var activeFlg = true;

    if ($("[name='SubcategoryInfo.Active']").val() == 1 || $("[name='SubcategoryInfo.Active']").val() == "true")
    {
        activeFlg = true;
    }
    else
    {
        activeFlg = false;
    }   

    var cViewModel = {

        SubcategoryInfo: {
            
            SubCategoryName: $("[name='SubcategoryInfo.SubCategoryName']").val(),

            CategoryId: $("#drpCategory").val(), 

            Id: $("[name='Filter.Id']").val(),

            Active: activeFlg
        }
    }

    var url = "";


    if ($("[name='Filter.Id']").val() == 0)
    {

        url = "/Subcategory/Insert"
    }
    else
    {
        url = "/Subcategory/Update"
    }

    PostAjaxWithProcessJson(url,cViewModel,AfterSave,$("body"));

}

function AfterSave(data)
{
    
    FriendlyMessage(data);

    ResetSubCategories();

    GetSubCategories();
}

function GetSubCategories() {

    var cViewModel =
		{
            SubcategoryInfo: {

		        Id: "",
                		        
                SubCategoryName: $("[name='SubcategoryInfo.SubCategoryName']").val(),                

                CategoryId: $("#drpCategory").val(),

                Active: $("[name='SubcategoryInfo.Active']").val()
		    },
		    Pager: {

		    	CurrentPage: $('#tblSubCategory').attr("data-current-page"),
		    },
		}
     
    PostAjaxWithProcessJson("/Subcategory/GetSubCategories", cViewModel, BindSubCategories, $("#frmSearchSubCategory"));
}

function BindSubCategories(data)
{    
    
	var list = JSON.parse(data);

	var kTable = {
        dataList: ["Name", "Category", "IsActiveStr"],
		primayKey:"Id",
        hiddenFields: ["Id", "Name", "Category", "CategoryId","Active"],
        headerNames: ["Name", "Category", "Is Active"],
		data: list.dt
	}

	buildHtmlTable(kTable, $('#tblSubCategory'));

    BindPagination(list.Pager, $('#tblSubCategory'));
}

function ResetSubCategories() {
    
    $("[name='SubcategoryInfo.SubCategoryName']").val("");

    $("[name='SubcategoryInfo.CategoryId']").val("");     

    $("[name='Filter.Id']").val("");

    if ($("[name='SubcategoryInfo.Active']").val() == 0 || $("[name='SubcategoryInfo.Active']").val() == "false")
    {
        $("[name='SubcategoryInfo.Active']").trigger('click');
    }

}

function Pagination(CurrentPage)
{

	$('#tblSubCategory').attr("data-current-page", CurrentPage);

    GetSubCategories();
}

function GetSetSubCategoryValues(obj)
{
    var id = $(obj).attr("data-id");     

    var subcategoryName = $(obj).attr("data-name");

    $("#hdnSearchBranchId").val(id);     

    $("[name='SubcategoryInfo.BranchName']").val(subcategoryName);     

    $("[name='SubcategoryInfo.CategoryId']").val($(obj).attr("data-categoryid"));

    $("[name='SubcategoryInfo.CategoryId']").attr("data-value", $(obj).attr("data-categoryid"));

    GetAutocompleteById("SubcategoryInfo.CategoryId");
}


