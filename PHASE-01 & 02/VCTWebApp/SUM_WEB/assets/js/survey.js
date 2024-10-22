


var counter = 3;
var textboxCounter = 6;

$(document).ready(function () {
   
    $("#dvAnswarPanel").hide();
    $("#txtTitle").focus();
    BindcategoryDropdown();
    if (Stitle != "") {
        GetSurveyDetails(Stitle);
        $("#txtTitle").val(Stitle);
        $("#txtTitle").attr("disabled", true);
        $("#txtQuestion").focus();
    }
    $("#ddlquestionType").change(function () {
        if ($("#ddlquestionType").val() != "0") {
            if ($("#ddlquestionType").val() != "User Input") {
                $("#dvAnswarPanel").show();
            }
            else {
                $("#dvAnswarPanel").hide();
            }
        }
    });

    $("#btnSave").click(function () {
        if ($.trim($("#txtTitle").val()) == "") {
            alert("Please enter Questionnaire title");
            $("#txtTitle").focus();
            return;

        }
        if ($("#ddlCategory").val() == "0") {
            alert("Please select questionnaire category");
            $("#ddlCategory").focus();
            return;

        }
        if ($.trim($("#txtQuestion").val()) == "") {
            alert("Please enter survey Question");
            $("#txtTitle").focus();
            return;

        }
        if ($.trim($("#txtQuestion").val()) == "") {
            alert("Please enter survey Question");
            $("#txtQuestion").focus();
            return;

        }
        if ($("#ddlquestionType").val() == "0") {
            alert("Please select answer type");
            $("#ddlquestionType").focus();
            return;
        }

        var Answar = [];
        Answar.length = 0;
        var ChkAnswar = [];
        ChkAnswar.length = 0;
        var msg = '';
        for (i = 1; i < counter; i++) {
            if ($('#txtAnswar' + i).val() != "") {
                if (!contains(Answar, $.trim($('#txtAnswar' + i).val()))) {
                    Answar.push($.trim($('#txtAnswar' + i).val()));
                    var j = document.getElementById("chkAnswar" + i);
                    if (j.checked == true) {
                        ChkAnswar.push(1);
                    }
                    else {
                        ChkAnswar.push(0);
                    }
                    //alert($('#txtAnswar' + i).val());
                }
                else {
                    alert("Duplicate answar find please correct it");
                    $('#txtAnswar' + i).focus();
                    return;
                }
            }

        }
        if (Answar.length < 2 && $("#ddlquestionType").val() != "User Input") {
            alert("Please enter at least 2 answer");
            $('#txtAnswar2').focus();
            return;
        }
        var answar = '';
        for (i = 0; i < Answar.length; i++) {
            answar += Answar[i] + "@" + ChkAnswar[i]+ "$";
        }
        SaveSurvey($("#txtTitle").val().replace("'", "&#39;"),$("#ddlCategory").val(), $("#txtQuestion").val().replace("'", "&#39;"), $("#ddlquestionType").val(), answar.replace("'", "&#39;"));
    });
    $("#btnReset").click(function () {
        Reset();
        $("#txtTitle").val("");
        $("#txtTitle").attr("disabled", false);
        $("#txtTitle").focus();
        $("#DVSurvey").html("");
    });


});


function Reset() {
   
    $("#txtQuestion").val("");
    $("#ddlquestionType option").each(function () {
        this.selected = $(this).val() == "0";
    });
    $("#dvAnswarPanel").hide();
    $("#txtQuestion").focus();
    $("#ddlCategory option").each(function () {
        this.selected = $(this).val() == "0";
    });
    for (i = 1; i < counter; i++) {
      $('#txtAnswar' + i).val("")  

    }
}
function SaveSurvey(SurveyTitle, SurveyCategory, SurveyQuestion, AnswarType,SurveyAnswar) {

    try {
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "SecureService/Default.aspx/SaveSurvey",
            data: "{SurveyTitle:'" + SurveyTitle + "', SurveyCategory:'" + SurveyCategory + "', SurveyQuestion:'" + SurveyQuestion + "', AnswarType:'" + AnswarType + "', SurveyAnswar:'" + SurveyAnswar + "'}",
            dataType: "json",
            success: function (data) {
                var div = data.d;
               
                if (div == "success") {
                    $("#txtTitle").attr("disabled", true);
                    Reset();
                    GetSurveyDetails($("#txtTitle").val());
                    alert("Survey Question Saved successfully");
                }
                else {
                    alert(div);
                }
            },
            error: function (result) {
                alert(result.responseText);
            }
        });
    }
    catch (err) {

        alert(err.responseText);
    }
}

function DeleteQuestion(SurveyID, QID) {
    try {
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "SecureService/Default.aspx/DeleteQuestion",
            data: "{SurveyID:'" + SurveyID + "',QuesID:'" + QID + "'}",
            dataType: "json",
            success: function (data) {
                if (data.d == "success")
                    GetSurveyDetails(SurveyID);
            },
            error: function (result) {
                alert(result.responseText);
            }
        });
    }
    catch (err) {

        alert(err.responseText);
    }
}

function BindcategoryDropdown() {
    $.ajax({
        type: "POST",
        url: "SecureService/Default.aspx/GetCategories",
        data: '{}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (r) {
            var ddlcategory = $("[id*=ddlCategory]");
            ddlcategory.empty().append('<option selected="selected" value="0"> Select</option>');
            $.each(r.d, function () {
                ddlcategory.append($("<option></option>").val(this['CategoryID']).html(this['CategoryName']));
            });
        },
        error: function (result) {
        alert(result.responseText);
    }
    });
}
function RemoveTextbox(i) {
    if (counter == 3) {
        alert("No more textbox to remove");
        return false;
    }
    $("#dvAnswar" + i).remove();
    counter--;


}
function contains(a, obj) {
    var i = a.length;
    while (i--) {
        if (a[i] === obj) {
            return true;
        }
    }
    return false;
}
function addAnswarTextBox(i) {
    if (counter > 10) {
        alert("Only 10 textboxes allow");
        return false;
    }

    //if (counter-1 ==i) {
    var newTextBoxDiv = $(document.createElement('div')).addClass("row")
         .attr("id", 'dvAnswar' + counter);


    newTextBoxDiv.after().html(' <div class="col-md-2 col-lg-2 "><label class="control-label">Answer:</label></div>' +
          ' <div class="col-md-4 col-lg-4 ">  <input type="text" id="txtAnswar' + counter + '"  maxlength="150" tabindex="' + textboxCounter + '"   class="form-control input-sm" />  </div> ' +
          '<div class="col-md-1 col-lg-1 "><input type="Checkbox" id="chkAnswar' + counter + '"></div><div class="col-md-1 col-lg-1 "><a href="javascript:addAnswarTextBox(' + counter + ');"><span class="glyphicon glyphicon-plus-sign" ></span></a><a href="javascript:RemoveTextbox(' + counter + ');"> <span class="glyphicon glyphicon-minus-sign" ></span> </a> </div>');

    newTextBoxDiv.appendTo("#dvAnswar");

    textboxCounter++;
    counter++;
    // }
    //else {
    //    i = i + 1;
    //    $("#txtAnswar" + i).focus();
    //}
}

function GetSurveyDetails(SurveyTitle) {
    $("#DVSurvey").html("");
    try {
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "SecureService/Default.aspx/GetSurvey",
            data: "{SurveyTitle:'" + SurveyTitle + "'}",
            dataType: "json",
            success: function (data) {
                $("#DVSurvey").html(data.d);
            },
            error: function (result) {
                alert(result.responseText);
            }
        });
    }
    catch (err) {

        alert(err.responseText);
    }
}