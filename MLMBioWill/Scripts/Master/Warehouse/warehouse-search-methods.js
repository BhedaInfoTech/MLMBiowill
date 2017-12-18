function GetWarehouse() {
    var wViewModel =
        {
            WarehouseFilter: {

                WarehouseName: $("[name='WarehouseFilter.WarehouseName']").val(),

                Id: $("[name='WarehouseFilter.Id']").val(),

            },
            Pager: {

                CurrentPage: $('#tblWarehouse').attr("data-current-page"),
            },
        }

    PostAjaxJson("/Warehouse/GetWarehouses", wViewModel, BindWarehouse);
}

function BindWarehouse(data) {
    var list = JSON.parse(data);
    var kTable = {
        dataList: ["WarehouseName", "BranchName",  "Active"],
        primayKey: "Id",
        hiddenFields: ["Id", "WarehouseName"],
        headerNames: ["Warehouse Name", "Branch Name", "Active"],
        data: list.dt,
    }

    buildHtmlTable(kTable, $('#tblWarehouse'));

    BindPagination(list.Pager, $('#tblWarehouse'));

}

function Pagination(CurrentPage) {

    $('#tblWarehouse').attr("data-current-page", CurrentPage);

    GetWarehouse();

    document.getElementById("btnEditWarehouse").disabled = true;

    //document.getElementById("btnViewContactDetails").disabled = true;

}
