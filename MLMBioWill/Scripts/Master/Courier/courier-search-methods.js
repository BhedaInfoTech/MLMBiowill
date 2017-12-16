function GetCourier() {
    var aViewModel =
        {
            CourierFilter: {

                CourierName: $("[name='CourierFilter.CourierName']").val(),

                Id: $("[name='CourierFilter.Id']").val(),

            },
            Pager: {

                CurrentPage: $('#tblCourier').attr("data-current-page"),
            },
        }

    PostAjaxJson("/Courier/GetCouriers", aViewModel, BindCourier);
}

function BindCourier(data) {
    var list = JSON.parse(data);
    var kTable = {
        dataList: ["CourierName","CourierId", "ServedPincode",  "Active"],
        primayKey: "Id",
        hiddenFields: ["Id", "CourierName"],
        headerNames: ["Courier Name", "Courier Code", "Served Pincode", "Active"],
        data: list.dt,
    }

    buildHtmlTable(kTable, $('#tblCourier'));

    BindPagination(list.Pager, $('#tblCourier'));

}

function Pagination(CurrentPage) {

    $('#tblCourier').attr("data-current-page", CurrentPage);

    GetCourier();

    document.getElementById("btnEditCourier").disabled = true;

    //document.getElementById("btnViewContactDetails").disabled = true;

}
