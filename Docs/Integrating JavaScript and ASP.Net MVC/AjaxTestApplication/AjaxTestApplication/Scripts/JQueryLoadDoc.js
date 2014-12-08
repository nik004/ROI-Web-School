/// <reference path="../Resources/jQueryGetDocumentation.html" />
/// <reference path="../Resources/jQueryLoadDocumentation.html" />
/// <reference path="../Resources/jQueryLoadDocumentation.html" />
function loadFullAsyncXMLDoc() {
    $.ajax({
        url: "../Resources/ajax_info.txt",
        data: null,
        success: function (response) {
            $("#myDiv").html(response);
        },
        dataType: "html"
    });
};

function loadFullAsyncXMLDocWithLoad() {
    $("#loadDiv").load("../Resources/jQueryLoadDocumentation.html");
};

function loadFullAsyncXMLDocWithGet() {
    $.get("../Resources/jQueryGetDocumentation.html",
        function(response) {
            $("#getDiv").html(response);
        });
};

function loadFullAsyncXMLDocWithPost() {
    $.post("/Home/GetPostDocumentation",
        function (response) {
            $("#postDiv").html(response);
        });
};


function loadWithLoadingImg() {
    $.ajax({
        url: "/Home/GetAjaxTipsWithDelay",
        cache: false,
        dataType:'json',
        beforeSend: function () {
            $('#loadingmessage').show();
        },
        complete: function () {
            $('#loadingmessage').hide();
        },
        success: function (response) {
            $("#myDiv").html(response.data);
        }
    });
}
