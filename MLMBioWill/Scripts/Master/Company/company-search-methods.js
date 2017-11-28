function GetCompany()
{
    var cCompanyViewModel =
        {
            Filter: {

                CompanyName: $("[name='Filter.CompanyName']").val(),

                CompanyId: $("[name='Filter.CompanyId']").val(),

            },
            Pager: {

                CurrentPage: $('#tblCompany').attr("data-current-page"),
            },
        }

    PostAjaxJson("/Company/GetCompanyMaster", cCompanyViewModel, BindCompany);
}

function BindCompany(data)
{
    var list = JSON.parse(data);
    var kTable = {
        dataList: ["CompanyName", "GSTNumber", "PAN","Active"],
        primayKey: "CompanyId",
        hiddenFields: ["CompanyId", "CompanyName"],
        headerNames: ["Company Name", "GST Number", "PAN","Active"],
        data: list.dt,
    }

    buildHtmlTable(kTable, $('#tblCompany'));

    BindPagination(list.Pager, $('#tblCompany'));

}

function Pagination(CurrentPage) {

    $('#tblCompany').attr("data-current-page", CurrentPage);

    GetCompany();

    document.getElementById("btnEditCompany").disabled = true;

    //document.getElementById("btnViewContactDetails").disabled = true;

}
