

$(document).ready(function () {
    
    BindCustomerDropdown();
    BindQuestionierDropdown();
    GetdashboardData('','');
    $("#btnSearch").click(function () {
        var customer = '';
        var Qtype = '';
        if ($("#ddlCustomer").val() != "0") {
            customer = $("#ddlCustomer").val();

        }
        if ($("#ddlTitle").val() != "0") {
            Qtype = $("#ddlTitle").val();

        }
        GetdashboardData(customer, Qtype);

    });
    $("#btnReset").click(function () {
        ResetControl();
    });
   

});

function ResetControl() {
    $("#ddlCustomer option").each(function () {
        this.selected = $(this).val() == "0";
    });
    $("#ddlTitle option").each(function () {
        this.selected = $(this).val() == "0";
    });
    $('#ddlCustomer').trigger("chosen:updated");
    $('#ddlTitle').trigger("chosen:updated");
    GetdashboardData('', '');
}

function BindCustomerDropdown() {
    $.ajax({
        type: "POST",
        url: "SecureService/Default.aspx/GetCustomers",
        data: '{}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (r) {
            var ddlcategory = $("[id*=ddlCustomer]");
            ddlcategory.empty().append('<option selected="selected" value="0"> Select</option>');
            $.each(r.d, function () {
                ddlcategory.append($("<option></option>").val(this['CustomerCode']).html(this['CustomerName']));
            });
            $("#ddlCustomer").chosen({
                disable_search_threshold: 2,
                no_results_text: "Oops, nothing found!",
                width: "100%"
            });
        },
        error: function (result) {
            alert(result.responseText);
        }
    });
}

function BindQuestionierDropdown() {
    $.ajax({
        type: "POST",
        url: "SecureService/Default.aspx/GetSurveyList",
        data: '{}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (r) {
            var ddlcategory = $("[id*=ddlTitle]");
            ddlcategory.empty().append('<option selected="selected" value="0"> Select</option>');
            $.each(r.d, function () {
                ddlcategory.append($("<option></option>").val(this['SurveyID']).html(this['SurveyName']));
            });
            $("#ddlTitle").chosen({
                disable_search_threshold: 2,
                no_results_text: "Oops, nothing found!",
                width: "100%"
            });
        },
        error: function (result) {
            alert(result.responseText);
        }
    });
}


function OpenQuestionnaire(sid, stitle, CustomerCode, CustomerName) {
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "SecureService/Default.aspx/SetSession",
        data: "{CustomerCode:'" + CustomerCode + "',CustomerName:'" + CustomerName + "'}",
        success: function (data) {
            if (data.d == "success") {
               
                window.location.href = "../survey.aspx?sid=" + sid + "&stitle=" + stitle;

            }
          
        },
        error: function (result) {

            alert(result.responseText);
        }
    });
}



function GetdashboardData( Customer, Qtype) {
    var htmltbl = "";
    $("#CustomerDetails").html("");
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "SecureService/Default.aspx/GetSurveyResponse",
        data: "{Customer:'" + Customer + "',Qtype:'" + Qtype + "'}",
        success: function (data) {
            if (data != null) {
                if (data.d.length > 0) {
                    for (var i = 0; i < data.d.length; i++) {
                        if (i == 0) {
                            htmltbl += "<table  id='data-table' class='table table-striped table-bordered ' ><thead>";
                            htmltbl += " <tr><th >Date</th>  <th >Customer</th> <th>Contact Person</th> <th>Location</th><th>Questionnaire</th><th>#</th></tr> </thead> <tbody>";

                        }
                        if (i % 2 == 0)
                            htmltbl += "<tr class='odd gradeX'>";
                        else
                            htmltbl += "<tr class='even gradeC'>";
                        htmltbl += "<td>" + data.d[i].SurveyDate + "</td><td>" + data.d[i].CustomerName + "</td><td>" + data.d[i].ContactPersonName + "</td> <td>" + data.d[i].Location + "</td><td>" + data.d[i].SurveyName + "</td><td> <a href=\"javascript:OpenQuestionnaire('" + data.d[i].SurveyID + "','" + data.d[i].SurveyName + "','" + data.d[i].CustomerCode + "','" + data.d[i].CustomerName + "')\"><span class='glyphicon glyphicon-eye-open'> View</span></a></td></tr>";
                      

                    }
                    htmltbl += "</tbody>";
                    $("#CustomerDetails").html(htmltbl);

                }
                else {

                    alert("Details not avilable in database.");
                }

            }
            else {

                alert("Details not avilable in database.");
            }
        },
        error: function (result) {

            alert(result.responseText);
        }
    });
}