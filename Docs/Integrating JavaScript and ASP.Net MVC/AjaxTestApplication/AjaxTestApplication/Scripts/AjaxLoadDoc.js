function fullAsyncXMLDocLoad() {
    var xmlhttp;
    if (window.XMLHttpRequest) {
        // code for IE7+, Firefox, Chrome, Opera, Safari
        xmlhttp = new XMLHttpRequest();
    }
    else {
        // code for IE6, IE5
        xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
    }

    xmlhttp.onreadystatechange = function () {
        //state is complete
        if (xmlhttp.readyState == 4) {
            //http status is OK 
            if (xmlhttp.status == 200) {
                document.getElementById("myDiv").innerHTML = xmlhttp.responseText;
            }
        }
    }
    xmlhttp.open("GET", "../Resources/ajax_info.txt", true);
    xmlhttp.send();
};

function asyncXMLDocLoad() {
    //create XMLHttpRequest
    var xmlhttp = new XMLHttpRequest();

    xmlhttp.onreadystatechange = function () {
        //state is complete
        if (xmlhttp.readyState == 4) {
            //http status is OK 
            if (xmlhttp.status == 200) {
                //alert response text
                alert(xmlhttp.responseText);
            }
        }
    }

    //open async connection
    xmlhttp.open("GET", "../Resources/ajax_info.txt", true);
    //send request
    xmlhttp.send();
};

function syncXMLDocLoad() {
    var xmlhttp = new XMLHttpRequest();
    //open sync connection
    xmlhttp.open("GET", "../Resources/ajax_info.txt", false);
    //send request
    xmlhttp.send();

    $.ajax({
        beforeSend: function () {
            // Handle the beforeSend event
        },
        complete: function () {
            // Handle the complete event
        }
        // ......
    });



    //state is complete
    if (xmlhttp.readyState == 4) {
        //http status is OK 
        if (xmlhttp.status == 200) {
            //alert response text
            alert(xmlhttp.responseText);
        }
    }

};