

function insertHyphen(txtId) {
    var v = $("#" + txtId).val();
    if (v.match(/^\d{2}$/) !== null) {
        $("#" + txtId).val(v + '-')
    } else if (v.length == 5) {
        $("#" + txtId).val(v + '-20')
    }
    //if (v.length == 8)
    //{
    //    var n = v.split('-');
    //    if (n[2].length == 2)
    //    {
    //        n[2] = "20" + n[2];
    //        $("#")
    //    }
    //}

}

function focus(ctrl) {
    $("#" + ctrl).addClass("focus");
    $("#" + ctrl).removeClass("blur");
}

function Blur(ctrl) {
    $("#" + ctrl).removeClass("focus");
    $("#" + ctrl).addClass("blur");
}


function TabIndexes() {
    if ($('input[type="text"]').attr("readonly") != false) {
        $('input[type="text"]').attr("TabIndex", 0);
        $('input[type="text"][readonly]').attr("TabIndex", -1);
        $('input[type="text"][disabled]').attr("TabIndex", -1);
        $('input[type="text"][class*="disabledClass"]').attr("TabIndex", -1);
    }
}


function Validate(Labelid, txtId) {
    var txt = $(txtId).val();
    if ($('#' + txtId).val().length != 10) {
        $('#' + Labelid).css("color", "Red").css("font-weight", "700");
        $('#' + Labelid).text("      Please enter 10 digit plate number!!");
    }
    if ($('#' + txtId).val().length == 10 || $('#' + txtId).val().length > 10) {
        $('#' + Labelid).text("");
    }

    if ($('#' + txtId).val() == "") {
        $('#' + Labelid).text("");
    }

}

function validateDateFormat(Labelid, txtId) {
    if ($("#" + txtId).val().length > 0) {
        var Filter = /^(\d{1,2})-([a-zA-Z]{2})\-(19|20)\d{2}$/;
        var str = trimAll($("#" + txtId).val());
        //if (!Filter.test(str) && str != "") {
        //    $('#' + Labelid).css("color", "Red").css("font-weight", "700");
        //    $('#' + Labelid).text("Invalid date format. date should be DD-MMM-YYYY format!!");
        //    return false;
        //}
        //else {
        //    $('#' + Labelid).text("");
        //}

        var month = new Array();
        month[0] = "01";
        month[1] = "02";
        month[2] = "03";
        month[3] = "04";
        month[4] = "05";
        month[5] = "06";
        month[6] = "07";
        month[7] = "08";
        month[8] = "09";
        month[9] = "10";
        month[10] = "11";
        month[11] = "12";

        var Day = new Array();
        Day[0] = 31;
        Day[1] = 28;
        Day[2] = 31;
        Day[3] = 30;
        Day[4] = 31;
        Day[5] = 30;
        Day[6] = 31;
        Day[7] = 31;
        Day[8] = 30;
        Day[9] = 31;
        Day[10] = 30;
        Day[11] = 31;
        Day[12] = 29
        $('#' + Labelid).text("");
        count = 0;
        var result = "NO";
        var n = str.split('-');
        if (n.length == 3) {
            for (i = 0; i <= month.length; i++) {
                if (month[i] == n[1].toLowerCase()) {
                    result = "MATCH";
                    count = i;
                }
            }
            if (!isNaN(n[2])) {
                if (parseInt(n[2]) % 4 == 0) {
                    count = 12;
                }
            }
            else {
                result = "NO";
            }
            if (result == "MATCH") {
                if (parseInt(n[0]) < 0 || parseInt(n[0]) > Day[count]) {
                    $('#' + Labelid).css("color", "Red").css("font-weight", "700");
                    $('#' + Labelid).text("Invalid date format. date should be DD-MM-YYYY format!!");
                    return false;
                }
            }
            else {
                $('#' + Labelid).css("color", "Red").css("font-weight", "700");
                $('#' + Labelid).text("Invalid date format. date should be DD-MM-YYYY format!!");
                return false;
            }
        }
        else {
            $('#' + Labelid).css("color", "Red").css("font-weight", "700");
            $('#' + Labelid).text("Invalid date format. date should be DD-MM-YYYY format!!");
            return false;
        }
    }
}


function validateDateFormatWithThis(Labelid, txtId) {
    if ($(txtId).val().length > 0) {
        var Filter = /^(\d{1,2})-([a-zA-Z]{3})\-(19|20)\d{2}$/;
        var str = trimAll($(txtId).val());
        //if (!Filter.test(str) && str != "") {
        //    $('#' + Labelid).css("color", "Red").css("font-weight", "700");
        //    $('#' + Labelid).text("Invalid date format. date should be DD-MM-YYYY format!!");
        //    return false;
        //}
        //else {
        //    $('#' + Labelid).text("");
        //}

        var month = new Array();
        month[0] = "01";
        month[1] = "02";
        month[2] = "03";
        month[3] = "04";
        month[4] = "05";
        month[5] = "06";
        month[6] = "07";
        month[7] = "08";
        month[8] = "09";
        month[9] = "10";
        month[10] = "11";
        month[11] = "12";

        var Day = new Array();
        Day[0] = 31;
        Day[1] = 28;
        Day[2] = 31;
        Day[3] = 30;
        Day[4] = 31;
        Day[5] = 30;
        Day[6] = 31;
        Day[7] = 31;
        Day[8] = 30;
        Day[9] = 31;
        Day[10] = 30;
        Day[11] = 31;
        Day[12] = 29

        count = 0;
        var result = "NO";
        var n = str.split('-');
        if (n.length == 3) {
            for (i = 0; i <= month.length; i++) {
                if (month[i] == n[1].toLowerCase()) {
                    result = "MATCH";
                    count = i;
                }
            }
            if (!isNaN(n[2])) {
                if (parseInt(n[2]) % 4 == 0) {
                    count = 12;
                }
            }
            else {
                result = "NO";
            }
            if (result == "MATCH") {
                if (parseInt(n[0]) < 0 || parseInt(n[0]) > Day[count]) {
                    $('#' + Labelid).css("color", "Red").css("font-weight", "700");
                    $('#' + Labelid).text("Invalid date format. date should be DD-MM-YYYY format!!");
                    return false;
                }
            }
            else {
                $('#' + Labelid).css("color", "Red").css("font-weight", "700");
                $('#' + Labelid).text("Invalid date format. date should be DD-MM-YYYY format!!");
                return false;
            }
        }
        else {
            $('#' + Labelid).css("color", "Red").css("font-weight", "700");
            $('#' + Labelid).text("Invalid date format. date should be DD-MM-YYYY format!!");
            return false;
        }
    }
}

function ValidateLicense(Labelid, txtId) {
    var str = $(txtId).val();
    if (/^[a-zA-Z0-9- ]*$/.test(str) == false) {
        $('#' + Labelid).css("color", "Red").css("font-weight", "700");
        $('#' + Labelid).text("[Invalid!!]");
    }
    else {
        $('#' + Labelid).text("");
    }
}

function ConvertDateFormat(dd_MM_yyyy) {
    var arr = dd_MM_yyyy.split('-');
    var d = new Date(arr[1] + " " + arr[0] + "," + arr[2]);
    return d;
}

function CompareToCurrentDate(ctrl, msgcontrol, Message) {
    $("#" + ctrl).val(trimAll($("#" + ctrl).val()));
    //var dt = new Date($("#" + ctrl).val());
    var dt = ConvertDateFormat($("#" + ctrl).val())
    var D1 = dt.getDate() + '/' + (dt.getMonth() + 1) + '/' + (dt.getFullYear());
    dt = new Date();
    var D2 = dt.getDate() + '/' + (dt.getMonth() + 1) + '/' + (dt.getFullYear());
    var dateFirst = D1.split('/');
    var dateSecond = D2.split('/');
    var value = new Date(dateFirst[1] + " " + dateFirst[0] + "," + dateFirst[2]); //Year, Month, Date
    var current = new Date(dateSecond[1] + " " + dateSecond[0] + "," + dateSecond[2]);
    if (value <= current) {
        $("#" + msgcontrol).css("color", "Red").css("font-weight", "700");
        $("#" + msgcontrol).text(Message);
        $("#" + ctrl).click(function (e) {
            $("#" + msgcontrol).text("");
        });
        $("#" + ctrl).change(function (e) {
            $("#" + msgcontrol).text("");
        });
        $("#" + ctrl).focus();
        return false;
    }

    else {
        return true;
    }
}


function CompareDate(ctrl, ctrl2, msgcontrol, Message) {
    $("#" + ctrl).val(trimAll($("#" + ctrl).val()))
    $("#" + ctrl2).val(trimAll($("#" + ctrl2).val()))
    var dt = new Date($("#" + ctrl).val());
    var D1 = dt.getDate() + '/' + (dt.getMonth()) + '/' + (dt.getFullYear());
    dt = new Date($("#" + ctrl2).val());
    var D2 = dt.getDate() + '/' + (dt.getMonth()) + '/' + (dt.getFullYear());
    var dateFirst = D1.split('/');
    var dateSecond = D2.split('/');
    var value = new Date(dateFirst[2], dateFirst[1], dateFirst[0]); //Year, Month, Date
    var current = new Date(dateSecond[2], dateSecond[1], dateSecond[0]);
    if (value > current) {
        $("#" + msgcontrol).css("color", "Red").css("font-weight", "700");
        $("#" + msgcontrol).text(Message);
        $("#" + ctrl).click(function (e) {
            $("#" + msgcontrol).text("");
        });
        $("#" + ctrl).change(function (e) {
            $("#" + msgcontrol).text("");
        });
        $("#" + ctrl).focus();
        return false;
    }

    else {
        return true;
    }
}

function ValidateDate(dt, lbl) {
    var n = new Date(), y = n.getFullYear(), m = n.getMonth();

    var Filter = /^(\d{1,2})-([a-zA-Z]{3})\-(19|20)\d{2}$/;
    var str = trimAll($(dt).val());
    if (!Filter.test(str) && str != "") {
        $('#' + lbl).css("color", "Red").css("font-weight", "700");
        $('#' + lbl).text("Invalid date format. date should be DD-MM-YYYY format!!");
    }
    else {
        $('#' + lbl).text("");
    }
    //if (FromDate > d) {
    //    $("#" + lbl).html("Valid from cannot be greater than todays date!!");
    //    $(dt).val("");
    //}
    //else {
    //    $("#" + lbl).html("");
    //}
    var lastDay = new Date(y, m + 1, 0);
    var str = "" + lastDay + "";
    var arr = str.substring(4, 15).split(" ");
    $("#txtValidTo").val(arr[1] + "-" + arr[0] + "-" + arr[2]);
}

function isFloatNumberKey(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode > 31 && (charCode < 46 || charCode > 57 || charCode == 47))
        return false;

    return true;
}

function isNumberKey(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode > 31 && (charCode < 48 || charCode > 57))
        evt.preventDefault();
        //return false;

    //return true;
}

function isNumberWKey(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode == 46)
        return true;
    if (charCode > 31 && (charCode < 48 || charCode > 57))
        return false;
    return true;
}

function isDatetimeKey(e) {
    var k;
    document.all ? k = e.keycode : k = e.which;
    return ((k > 44 && k < 58 && k != 46 && k != 47) || (k > 64 && k < 91) || (k > 96 && k < 123) || k == 8 || k == 0);
}

//function isDatetimeKey(evt) {
//    var charCode = (evt.which) ? evt.which : event.keyCode;
//    if (charCode > 31 && (charCode < 45 || charCode > 57) && charCode != 46)
//        return false;

//    return true;
//}

function isAlphaNumeric(e) {
    var k;
    document.all ? k = e.keycode : k = e.which;
    return ((k > 47 && k < 58) || (k > 64 && k < 91) || (k > 96 && k < 123) || k == 0 || k == 8);
}



function trimAll(sString) {
    while (sString.substring(0, 1) == ' ') {
        sString = sString.substring(1, sString.length);
    }
    while (sString.substring(sString.length - 1, sString.length) == ' ') {
        sString = sString.substring(0, sString.length - 1);
    } return sString;
}
function onlyAlphabets(e) {
    var inputValue;
    document.all ? inputValue = e.keycode : inputValue = e.which;
    if (!(inputValue >= 65 && inputValue <= 122) && (inputValue != 32 && inputValue != 0)) {
        e.preventDefault();
    }
}

function RequiredValidation(ctrl, msgcontrol, Message) {
    $("#" + ctrl).val(trimAll($("#" + ctrl).val()))
    if ($("#" + ctrl).val() == '') {
        $("#" + msgcontrol).css("color", "Red").css("font-weight", "700");
        $("#" + msgcontrol).text(Message);
        $("#" + ctrl).click(function (e) {
            $("#" + msgcontrol).text("");
        });
        $("#" + ctrl).change(function (e) {
            $("#" + msgcontrol).text("");
        });
        $("#" + ctrl).focus();
        return false;
    }
    else {
        return true;
    }
}

function AlphanumericValidation(ctrl, msgcontrol, Message) {
    $("#" + ctrl).val(trimAll($("#" + ctrl).val()))
    var str = $("#" + ctrl).val();
    var filter = /^[A-Za-z0-9]+$/;
    if (!filter.test(str) && str != "") {
        $("#" + msgcontrol).text(Message);
        $("#" + ctrl).keyup(function (e) {
            $("#" + msgcontrol).text("");

        });
        $("#" + ctrl).focus();
        return false;
    }
    else {
        $("#" + msgcontrol).text("");
        return true;
    }
}

function DropdownValidation(ctrl, msgcontrol, Message, text) {

    if ($("#" + ctrl + " :selected").text() == text) {
        $("#" + msgcontrol).css("color", "Red").css("font-weight", "700");
        $("#" + msgcontrol).text(Message);
        $("#" + ctrl).change(function (e) {
            $("#" + msgcontrol).text("");

        });
        $("#" + ctrl).focus();
        return false;
    }
    else {

        $("#" + msgcontrol).text("");
        return true;
    }
}


function threeDecimalPlaces(txt, e) {
    var Filter = /^\d*\.\d{3}$/;///^\d*\.\d{3}$/;
    var prec = '000';
    var data = $(txt).val();
    var k;
    document.all ? k = e.keycode : k = e.which;
    //var Filter = "^[0-9]{1,8}(\\.\\d{1,3})?$"
    //if (Filter.test($(txt).val()) && $(txt).val() != "") {
    //    e.preventDefault();
    //}
    //else
    var d = $(txt).val().split('.');
    if (!(k >= 48 && k <= 57) && k != 46 && k != 8 && e.keyCode != 9)
        e.preventDefault();
    else if (k == 46 && d.length > 1)
        e.preventDefault();
    else if (d.length == 2) {
        if (d[1].length >= 3 && k != 8 && e.keyCode != 9) e.preventDefault();
    }
}



function addDecimal(txt) {
    var prec = '000';
    var data = $(txt).val();
    var d = $(txt).val().split('.');
    if (d.length == 2) {
        prec = (d[1] + '000').substring(0, 3);
    }
    $(txt).val(d[0] + '.' + prec);
}


function floatValidation(ctrl, msgcontrol, Message) {
    $("#" + ctrl).val(trimAll($("#" + ctrl).val()))
    var str = $("#" + ctrl).val();
    var filter = /^\d*\.?\d*$/;
    if (!filter.test(str) && str != "") {
        $("#" + msgcontrol).text(Message);
        $("#" + ctrl).keyup(function (e) {
            $("#" + msgcontrol).text("");

        });
        $("#" + ctrl).focus();
        return false;
    }
    else {
        $("#" + msgcontrol).text("");
        return true;
    }
}






//================================================End validation function written by Anupam ==============================================================





function SpaceAndSpecialChars(e) {
    var k;
    document.all ? k = e.keyCode : k = e.which;
    if (k == 32) {
        return false;
    }
    else {
        return ((k > 64 && k < 91) || (k > 96 && k < 123) || k == 8 || e.keyCode == 9 || k == 32 || (k >= 48 && k <= 57));
    }
}


function SpecialChars(e) {

    var k;
    document.all ? k = e.keyCode : k = e.which;
    return ((k > 64 && k < 91) || (k > 96 && k < 123) || k == 8 || k == 32 || e.keyCode == 9 || (k >= 48 && k <= 57));
}


//================================================End validation function written by Anupam ==============================================================


function getPaging(ctrl, rows, PageNumber, PageSize, Type) {
    var paging = "";
    var TotalPages = "";
    TotalPages = Math.ceil(rows / PageSize);
    if (TotalPages > 1) {
        var first, previous, next, last, nextpage, previouspage;
        if (PageNumber == 1) {
            nextpage = PageNumber;
            nextpage++;
            first = "";
            previous = "";
            next = "javascript:getPageData('" + nextpage + "','" + Type + "')";
            last = "javascript:getPageData('" + TotalPages + "','" + Type + "')";
        }
        else if (PageNumber > 1 && PageNumber != TotalPages) {
            nextpage = PageNumber;
            nextpage++;
            previouspage = PageNumber;
            previouspage--;
            first = "javascript:getPageData('" + 1 + "','" + Type + "')";
            previous = "javascript:getPageData('" + previouspage + "','" + Type + "')";
            next = "javascript:getPageData('" + nextpage + "','" + Type + "')";
            last = "javascript:getPageData('" + TotalPages + "','" + Type + "')";
        }
        else if (PageNumber == TotalPages) {
            previouspage = PageNumber;
            previouspage--;
            first = "javascript:getPageData('" + 1 + "','" + Type + "')";
            previous = "javascript:getPageData('" + previouspage + "','" + Type + "')";
            next = "";
            last = "";
        }

        if (first != "")
            paging += "<div class=\"tablefooter\"><div class=\"dataTables_paginate\"><a class=\"first paginate_button\" href = " + first + " >First</a><a tabindex=\"0\" class=\"previous paginate_button\" href =" + previous + ">Previous</a>";
        else
            paging += "<div class=\"tablefooter\"><div class=\"dataTables_paginate\">";

        paging += "<span class='spn'>Page " + PageNumber + " of " + TotalPages + "</span>&nbsp;&nbsp;";
        if (next != "")
            paging += "<a tabindex=\"0\" class=\"next paginate_button\" id=\"dyntable_next\" href =" + next + ">Next</a><a tabindex=\"0\" class=\"last paginate_button\" id=\"dyntable_last\" href =" + last + ">Last</a></div></div>";
        else
            paging += "</div></div>";
        $("#" + ctrl).html(paging);
    }
    else {
        $("#" + ctrl).html("");
    }
}
