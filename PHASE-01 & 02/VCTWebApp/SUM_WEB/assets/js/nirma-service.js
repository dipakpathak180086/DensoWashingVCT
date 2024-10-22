GPageSize = 1;

function getPageData(PageNumber, Type) {
    if (Type == "Security") {
        $("#dvSecLoader").css("display", "block");
        var htmltbl = "";
        $("#dvSearchResult").html("");
        $("#dvPaging").html("");
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "secure-service/Default.aspx/GetSeuritySearchDataResult",
            data: "{GateEntryNumber:'" + GateNumber + "',Fromdate:'" + $("#txtIncomingFromDate").val() + "',todate:'" + $("#txtIncomingToDate").val() + "',VechilePlateNumber:'" + $("#txtVechilePlateNo").val() + "',InComing:'" + InComing + "',PageNumber:'" + PageNumber + "',PageSize:'" + PageSize + "'}",
            success: function (data) {
                if (data != null) {
                    //  alert(data.d.length);
                    if (data.d.length > 0) {
                        for (var i = 0; i < data.d.length; i++) {
                            if (i == 0) {
                                htmltbl += "<table title='Double click to select' id='data-table' class='table table-striped table-bordered ' style='white-space: nowrap'><thead>";
                                htmltbl += " <tr><th onclick=\"javascript:sortTable(0,'data-table');\">Security Gate Entry No</th>  <th onclick=\"javascript:sortTable(1,'data-table');\">Incoming Date</th> <th onclick=\"javascript:sortTable(2,'data-table');\">Vehicle Plate No</th> <th onclick=\"javascript:sortTable(3,'data-table');\">Security in Vehicle</th>  </tr> </thead> <tbody>";

                            }
                            if (i % 2 == 0)
                                htmltbl += "<tr class='odd gradeX' ondblclick=\" Call(); SetSecurityGateNumber('" + data.d[i].GateEntryNumber + "');\">";
                            else
                                htmltbl += "<tr class='even gradeC' ondblclick=\"Call();  SetSecurityGateNumber('" + data.d[i].GateEntryNumber + "');\">";
                            htmltbl += "<td>" + data.d[i].GateEntryNumber + "</td><td>" + data.d[i].IncomingTime + "</td><td>" + data.d[i].VechilePlateNumber + "</td><td>" + data.d[i].TransactionType + "</td></tr>";
                        }
                        htmltbl += "</tbody>";
                        // FrameResize();
                        $("#dvSearchResult").html(htmltbl);
                        getPaging("dvPaging", data.d[0].TotalRows, PageNumber, PageSize, Type);
                    }
                    else {
                        $("#dvSecLoader").css("display", "none");
                        alert("Details not avilable in database.");
                    }
                    $("#dvSecLoader").css("display", "none");
                }
                else {
                    $("#dvSecLoader").css("display", "none");
                    alert("Details not avilable in database.");
                }
            },
            error: function (result) {
                $("#dvSecLoader").css("display", "none");
                alert("Error");
            }
        });
    }

    //else if (Type == 'SaltGateentry') {

    //    $("#dvAdminLoader").css("display", "block");
    //    var htmltbl = '';
    //    $('#dvGateEntrySearchResult').html('');
    //    $('#dvGateEntryPaging').html('');
    //    $.ajax({
    //        type: "POST",
    //        contentType: "application/json; charset=utf-8",
    //        url: "GateEntryForSalt.aspx/DisplayGateEntrySearchResult",
    //        data: "{GateEntryNo:'" + $("#ddlFromGateEntry").val() + "',FrominComingDate:'" + $("#txtFromDate").val() + "',ToinComingDate:'" + $("#txtToDate").val() + "',VehiclePlateNo:'" + $("#txtVehiclePlateNosearch").val() + "',SecurityDocsNo:'" + $("#txtDocsNo").val() + "',PageNumber:'" + PageNumber + "',PageSize:'" + PageSize + "'}",
    //        success: function (data) {
    //            if (data != null) {
    //                if (data.d.length > 0) {
    //                    for (var i = 0; i < data.d.length; i++) {
    //                        if (i == 0) {
    //                            htmltbl += "<table title='Double click to select' id='data-table' class='table table-striped table-bordered '><thead>";
    //                            htmltbl += "<tr><th>Gate Entry No</th> <th>Vehicle Type</th> <th>Vehicle Short No</th><th>Vehicle Plate No</th><th>Incoming DateTime</th><th>Outgoing DateTime</th><th>Security Docs No</th><th>PO NO</th><th>Line No</th></tr> </thead> <tbody>";

    //                        }
    //                        if (i % 2 == 0)
    //                            htmltbl += "<tr class='odd gradeX' ondblclick=\'Call(); javascript:SetGateEntryURL(\"" + data.d[i].BCDATA + "\");\'>";
    //                        else
    //                            htmltbl += "<tr class='even gradeC' ondblclick=\' Call(); javascript:SetGateEntryURL(\"" + data.d[i].BCDATA + "\");\'>";
    //                        htmltbl += "<td>" + data.d[i].GateEntryNo + "</td><td>" + data.d[i].str_VehicleType + "</td><td>" + data.d[i].vehicleshortNo + "</td><td>" + data.d[i].VehiclePlateNo + "</td><td>" + data.d[i].incomingtime + "</td><td>" + data.d[i].OutgoingTime + "</td><td>" + data.d[i].SecurityDocsNo + "</td><td>" + data.d[i].Po_NO + "</td><td>" + data.d[i].Line_No + "</td></tr>";
    //                    }
    //                    htmltbl += "</tbody>";
    //                    $('#dvGateEntrySearchResult').html(htmltbl);
    //                    getPaging("dvGateEntryPaging", data.d[0].TotalRows, PageNumber, PageSize, Type);
    //                    $("#dvAdminLoader").css("display", "none");
    //                }
    //                else {
    //                    $("#dvAdminLoader").css("display", "none");
    //                    alert('Detailt not avilable in database.');
    //                }
    //            }

    //        },
    //        error: function (result) {
    //            $("#dvAdminLoader").css("display", "none");
    //            alert('Error');
    //        }
    //    });
    //}

    else if (Type == 'SaltGateentry') {

        $("#dvAdminLoader").css("display", "block");
        var htmltbl = '';
        $('#dvGateEntrySearchResult').html('');
        $('#dvGateEntryPaging').html('');
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "GateEntryForSalt.aspx/DisplayGateEntrySearchResult",
            data: "{GateEntryNo:'" + $("#ddlFromGateEntry").val() + "',FrominComingDate:'" + $("#txtFromDate").val() + "',ToinComingDate:'" + $("#txtToDate").val() + "',VehiclePlateNo:'" + $("#txtVehiclePlateNosearch").val() + "',SecurityDocsNo:'" + $("#txtDocsNo").val() + "',PageNumber:'" + PageNumber + "',PageSize:'" + PageSize + "'}",
            success: function (data) {
                if (data != null) {
                    if (data.d.length > 0) {
                        for (var i = 0; i < data.d.length; i++) {
                            //<th>Security Docs No</th>
                            if (i == 0) {  
                                htmltbl += "<table title='Double click to select' id='data-table' class='table table-striped table-bordered '><thead>";  
                                htmltbl += "<tr><th>Gate Entry No</th> <th>Vehicle Type</th> <th>Vehicle Short No</th><th>Vehicle Plate No</th><th>Incoming DateTime</th><th>Outgoing DateTime</th><th>PO NO</th><th>Line No</th></tr> </thead> <tbody>";

                            }
                            if (i % 2 == 0)
                                htmltbl += "<tr class='odd gradeX' ondblclick=\'Call(); javascript:SetGateEntryURL(\"" + data.d[i].BCDATA + "\");\'>";
                            else
                                htmltbl += "<tr class='even gradeC' ondblclick=\' Call(); javascript:SetGateEntryURL(\"" + data.d[i].BCDATA + "\");\'>";
                            var vehptyp = "";
                            var vehp = "";
                            var security = "";
                            var Outgoing = "";
                            if (data.d[i].str_VehicleType != "" && data.d[i].str_VehicleType != "null")
                                vehptyp = data.d[i].str_VehicleType;
                            if (data.d[i].VehiclePlateNo != "" && data.d[i].VehiclePlateNo != "null")
                                vehp = data.d[i].VehiclePlateNo;
                            if (data.d[i].OutgoingTime != "" && data.d[i].OutgoingTime != "null")
                                Outgoing = data.d[i].OutgoingTime;
                            //if (data.d[i].SecurityDocsNo != "" && data.d[i].SecurityDocsNo != "null")
                            //    security = data.d[i].SecurityDocsNo;
                            //<td>" + security + "</td>
                            htmltbl += "<td>" + data.d[i].GateEntryNo + "</td><td>" + vehptyp + "</td><td>" + data.d[i].vehicleshortNo + "</td><td>" + vehp + "</td><td>" + data.d[i].incomingtime + "</td><td>" + Outgoing + "</td><td>" + data.d[i].Po_NO + "</td><td>" + data.d[i].Line_No + "</td></tr>";
                        }
                        htmltbl += "</tbody>";
                        $('#dvGateEntrySearchResult').html(htmltbl);
                        getPaging("dvGateEntryPaging", data.d[0].TotalRows, PageNumber, PageSize, Type);
                        $("#dvAdminLoader").css("display", "none");
                    }
                    else {
                        $("#dvAdminLoader").css("display", "none");
                        alert('Detailt not avilable in database.');
                    }
                }

            },
            error: function (result) {
                $("#dvAdminLoader").css("display", "none");
                alert('Error');
            }
        });
    }



    else if (Type == "Indent") {
        $("#dvPo").css("display", "block");
        var htmltbl = "";
        $("#dvIndentResult").html("");
        $("#dvIndentPaging").html("");
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "secure-service/Default.aspx/GetIndentSearchResult",
            data: "{MinProjectCode:'" + fromProjectCode + "',MaxProjectCode:'" + ToProjectCode + "',MinCostCenterCode:'" + FromCostCenterCode + "',MaxCostCenterCode:'" + ToCostCenterCode + "',MinUnitCode:'" + FromUnitCode + "',MaxUnitCode:'" + ToUnitCode + "',ObjectType:'" + $("#txtObjectType").val() + "',IndentNumber:'" + $("#txtIndentNumber").val() + "',IndentFromDate:'" + $("#txtFromIndentDate").val() + "',IndentToDate:'" + $("#txtToIndentDate").val() + "',PageNumber:'" + PageNumber + "',PageSize:'" + PageSize + "'}",
            success: function (data) {
                if (data != null) {
                    if (data.d.length > 0) {
                        for (var i = 0; i < data.d.length; i++) {
                            if (i == 0) {
                                htmltbl += "<table title='Double click to select' ondblclick='EnableParentClose();' id='data-table' class='table table-striped table-bordered ' style='white-space: nowrap'><thead>";
                                htmltbl += " <tr><th>Indent No.</th><th>Project Code</th>  <th>Cost centre Code</th> <th>Unit Code</th> <th>Object Type</th> <th> LnNo</th><th>Indent Date</th></tr> </thead> <tbody>";

                            }
                            if (i % 2 == 0)
                                htmltbl += "<tr class='odd gradeX' ondblclick=\"LoadingGif(); javascript:Set8110Object('" + data.d[i].IndentNo + "');\">";
                            else
                                htmltbl += "<tr class='even gradeC' ondblclick=\"LoadingGif(); javascript:Set8110Object('" + data.d[i].IndentNo + "');\">";
                            htmltbl += "<td>" + data.d[i].IndentNo + "</td><td>" + data.d[i].ProjectCode + "</td><td>" + data.d[i].CostCentreCode + "</td><td>" + data.d[i].UnitCode + "</td><td>" + data.d[i].ObjectType + "</td><td>" + data.d[i].LnNo + "</td><td>" + data.d[i].IndentDate + "</td></tr>";
                        }
                        htmltbl += "</tbody>";
                        $("#dvIndentResult").html(htmltbl);
                        getPaging("dvIndentPaging", data.d[0].TotalRows, PageNumber, PageSize, Type);
                        $("#dvPo").css("display", "none");
                    }
                    else {
                        $("#dvPo").css("display", "none");
                        alert("No result found in database");
                    }
                }
                else {
                    $("#dvPo").css("display", "none");
                    alert("No result found in database");
                }

            },
            error: function (result) {
                $("#dvPo").css("display", "none");
                alert("Error");
            }
        });
    }
    else if (Type == "PO") {
        $("#dvPo").css("display", "block");
        var htmltbl = "";
        $("#dvPoPaging").html("");
        $("#dvPoData").html("");
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "secure-service/Default.aspx/GetPoSearchResult",
            data: "{PurchaseOrderMin:'" + $("#txtFromPoNumber").val() + "',PurchaseOrderMax:'" + $("#txtToPoNumber").val() + "',MinDate:'" + $("#txtFromPoDate").val() + "', MaxDate:'" + $("#txtToPoDate").val() + "',PartNo:'" + PartNumber + "',DocumentNo:'" + $("#txtReferenceDocumentNo").val() + "',PartyCode:'" + PartyCode + "',WarehouseCode:'" + WarehouseCode + "',ProjectCode:'" + ProjectCode + "',PageNumber:'" + PageNumber + "',PageSize:'" + PageSize + "'}",
            success: function (data) {
                if (data != null) {
                    if (data.d.length > 0) {
                        for (var i = 0; i < data.d.length; i++) {
                            if (i == 0) {
                                htmltbl += "<table title='Double click to select' ondblclick='EnableParentClose();' id='data-table' class='table table-striped table-bordered '><thead>";
                                htmltbl += " <tr><th>Po Number</th><th>WH No</th>  <th>Warehouse Name</th> <th>Party Code</th> <th>Party Mat Cd</th> <th> Party Code Description</th> <th>Part No</th><th>Part Match Code</th><th>Part Short Name</th><th>Part Name</th><th>UOM</th></tr> </thead> <tbody>";

                            }

                            if (i % 2 == 0)
                                htmltbl += "<tr class='odd gradeX' ondblclick=\"LoadingGif(); javascript:Set8110Object('" + data.d[i].PONumber + "');\">";
                            else
                                htmltbl += "<tr class='even gradeC' ondblclick=\"LoadingGif(); javascript:Set8110Object('" + data.d[i].PONumber + "');\">";
                            htmltbl += "<td>" + data.d[i].PONumber + "</td><td>" + data.d[i].WHNumber + "</td><td>" + data.d[i].WHName + "</td><td>" + data.d[i].PartyCode + "</td><td>" + data.d[i].PartyMatCd + "</td><td>" + data.d[i].PartyCodeDescription + "</td><td>" + data.d[i].PartNo + "</td><td>" + data.d[i].PartMatchCode + "</td><td>" + data.d[i].PartShortName + "</td><td>" + data.d[i].PartName + "</td><td>" + data.d[i].UOM + "</td></tr>";
                        }
                        htmltbl += "</tbody>";
                        $("#dvPoData").html(htmltbl);
                        getPaging("dvPoPaging", data.d[0].TotalRows, PageNumber, PageSize, Type);
                        $("#dvPo").css("display", "none");
                    }
                    else {
                        $("#dvPo").css("display", "none");
                        alert("No result found in database");
                    }
                }
                else {
                    $("#dvPo").css("display", "none");
                    alert("No result found in database");
                }

            },
            error: function (result) {
                $("#dvPo").css("display", "none");
                alert("Error");
            }
        });
    }
    else if (Type == "POINT") {
        $("#dvPo").css("display", "block");
        var htmltbl = "";
        $("#dvPoPaging").html("");
        $("#dvPoData").html("");
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "secure-service/Default.aspx/GetPoSearchResult",
            data: "{PurchaseOrderMin:'" + $("#txtFromPoNumber").val() + "',PurchaseOrderMax:'" + $("#txtToPoNumber").val() + "',MinDate:'" + $("#txtFromPoDate").val() + "', MaxDate:'" + $("#txtToPoDate").val() + "',PartNo:'" + PartNumber + "',DocumentNo:'" + $("#txtReferenceDocumentNo").val() + "',PartyCode:'" + PartyCode + "',WarehouseCode:'" + WarehouseCode + "',ProjectCode:'" + ProjectCode + "',PageNumber:'" + PageNumber + "',PageSize:'" + PageSize + "'}",
            success: function (data) {
                if (data != null) {
                    if (data.d.length > 0) {
                        for (var i = 0; i < data.d.length; i++) {
                            if (i == 0) {
                                htmltbl += "<table title='Double click to select'  id='data-table' class='table table-striped table-bordered '><thead>";
                                htmltbl += " <tr><th>Po Number</th><th>WH No</th>  <th>Warehouse Name</th> <th>Party Code</th> <th>Party Mat Cd</th> <th> Party Code Description</th> <th>Part No</th><th>Part Match Code</th><th>Part Short Name</th><th>Part Name</th><th>UOM</th></tr> </thead> <tbody>";

                            }

                            if (i % 2 == 0)
                                htmltbl += "<tr class='odd gradeX' ondblclick=\"Call(); javascript:SetPoNO('" + data.d[i].PONumber + "');\">";
                            else
                                htmltbl += "<tr class='even gradeC' ondblclick=\"Call(); javascript:SetPoNO('" + data.d[i].PONumber + "');\">";
                            htmltbl += "<td>" + data.d[i].PONumber + "</td><td>" + data.d[i].WHNumber + "</td><td>" + data.d[i].WHName + "</td><td>" + data.d[i].PartyCode + "</td><td>" + data.d[i].PartyMatCd + "</td><td>" + data.d[i].PartyCodeDescription + "</td><td>" + data.d[i].PartNo + "</td><td>" + data.d[i].PartMatchCode + "</td><td>" + data.d[i].PartShortName + "</td><td>" + data.d[i].PartName + "</td><td>" + data.d[i].UOM + "</td></tr>";
                        }
                        htmltbl += "</tbody>";
                        $("#dvPoData").html(htmltbl);
                        getPaging("dvPoPaging", data.d[0].TotalRows, PageNumber, PageSize, Type);
                        $("#dvPo").css("display", "none");
                    }
                    else {
                        $("#dvPo").css("display", "none");
                        alert("No result found in database");
                    }
                }
                else {
                    $("#dvPo").css("display", "none");
                    alert("No result found in database");
                }

            },
            error: function (result) {
                $("#dvPo").css("display", "none");
                alert("Error");
            }
        });
    }
    else if (Type == "Part") {
        $("#dvPo").css("display", "block");
        var htmltbl = "";
        $("#dvPartResult").html("");
        $("#dvPartPaging").html("");
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "secure-service/Default.aspx/GetPartSearchResult",
            data: "{PartType:'" + PartType + "',StructType:'" + StructType + "',PartNoMin:'" + $("#txtFromPartNo").val() + "', PartNoMax:'" + $("#txtToPartNo").val() + "',PartName:'" + $("#txtPartName").val() + "',PartShortName:'" + $("#txtPartShortName").val() + "',PartMatchCode:'" + $("#txtPartMatchCode").val() + "',BaseUOM:'" + BaseUOM + "',IsActivePartOnly:'" + IsActivePartOnly + "',PageNumber:'" + PageNumber + "',PageSize:'" + PageSize + "'}",
            success: function (data) {
                if (data != null) {
                    if (data.d.length > 0) {
                        for (var i = 0; i < data.d.length; i++) {
                            if (i == 0) {
                                htmltbl += "<table title='Double click to select' id='data-table' ondblclick='EnableParentClose();' class='table table-striped table-bordered ' style='white-space: nowrap'><thead>";
                                htmltbl += " <tr><th>Part No</th> <th>Part Match Code</th><th>Part Short Name</th><th>Part Name</th><th>UOM</th><th>Part Type</th><th>Structure Type</th>  </tr> </thead> <tbody>";

                            }
                            if (i % 2 == 0)
                                htmltbl += "<tr class='odd gradeX' ondblclick=\"LoadingGif(); javascript:Set8110PartDetails('" + data.d[i].PartNo + "','" + data.d[i].PartMatchCode + "','" + data.d[i].PartShortName + "','" + data.d[i].PartName + "','" + data.d[i].UOM + "');\">";
                            else
                                htmltbl += "<tr class='even gradeC' ondblclick=\"LoadingGif(); javascript:Set8110PartDetails('" + data.d[i].PartNo + "','" + data.d[i].PartMatchCode + "','" + data.d[i].PartShortName + "','" + data.d[i].PartName + "','" + data.d[i].UOM + "');\">";
                            htmltbl += "<td>" + data.d[i].PartNo + "</td><td>" + data.d[i].PartMatchCode + "</td><td>" + data.d[i].PartShortName + "</td><td>" + data.d[i].PartName + "</td><td>" + data.d[i].UOM + "</td><td>" + data.d[i].PartType + "</td><td>" + data.d[i].StructType + "</td></tr>";
                        }
                        htmltbl += "</tbody>";
                        $("#dvPartResult").html(htmltbl);
                        getPaging("dvPartPaging", data.d[0].TotalRows, PageNumber, PageSize, Type);
                        $("#dvPo").css("display", "none");
                    }
                    else {
                        $("#dvPo").css("display", "none");
                        alert("No result found in database");
                    }
                }
                else {
                    $("#dvPo").css("display", "none");
                    alert("No result found in database");
                }

            },
            error: function (result) {
                $("#dvPo").css("display", "none");
                alert("Error");
            }
        });
    }
    else if (Type == "Party") {
        $("#dvPartyPoLoader").css("display", "block");
        var htmltbl = "";
        $("#dvPartyData").html("");
        $("#dvPartyPaging").html("");
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "secure-service/Default.aspx/GetPartySearchResult",
            data: "{Customer:'" + Customer + "',Supplier:'" + Supplier + "', PartyMatchCode:'" + $("#txtPartyMatchCode").val() + "', PartyShortDescription:'" + $("#txtPartySDesc").val() + "',PartyCode:'" + PartyCode + "',LegalStatus:'" + LegalStatus + "',PageNumber:'" + PageNumber + "',PageSize:'" + PageSize + "'}",
            success: function (data) {
                if (data != null) {
                    if (data.d.length > 0) {
                        for (var i = 0; i < data.d.length; i++) {
                            if (i == 0) {
                                htmltbl += "<table title='Double click to select' ondblclick='EnableParentClose();' id='data-table' class='table table-striped table-bordered ' style='white-space: nowrap'><thead>";
                                htmltbl += " <tr><th>Customer</th><th>Supplier</th>  <th>Party Match Code</th> <th>Party Code</th><th>Party Name</th><th>Party Short Description</th><th>Legal Status</th></tr> </thead> <tbody>";

                            }
                            if (i % 2 == 0)
                                htmltbl += "<tr class='odd gradeX' ondblclick=\" javascript:Set8110PartyDetails('" + data.d[i].PartyCode + "','" + data.d[i].PartyMatchCode + "','" + data.d[i].PartyShortDescription + "');\">";
                            else
                                htmltbl += "<tr class='even gradeC' ondblclick=\" javascript:Set8110PartyDetails('" + data.d[i].PartyCode + "','" + data.d[i].PartyMatchCode + "','" + data.d[i].PartyShortDescription + "');\">";
                            htmltbl += "<td>" + data.d[i].Customer + "</td><td>" + data.d[i].Supplier + "</td><td>" + data.d[i].PartyMatchCode + "</td><td>" + data.d[i].PartyCode + "</td><td>" + data.d[i].PartyName + "</td><td>" + data.d[i].PartyShortDescription + "</td><td>" + data.d[i].PartyLegalStatus + "</td></tr>";
                        }
                        htmltbl += "</tbody>";
                        $("#dvPartyData").html(htmltbl);
                        getPaging("dvPartyPaging", data.d[0].TotalRows, PageNumber, PageSize, Type);
                        $("#dvPartyPoLoader").css("display", "none");
                    }
                    else {
                        $("#dvPartyPoLoader").css("display", "none");
                        alert("No result found in database");

                    }
                }
                else {
                    $("#dvPartyPoLoader").css("display", "none");
                    alert("No result found in database");
                }

            },
            error: function (result) {
                $("#dvPartyPoLoader").css("display", "none");
                alert("Error");
            }
        });
    }
    else if (Type == "TransporterCd") {
        $("#dvPartyLoader").css("display", "block");
        var htmltbl = "";
        $("#dvPartyData").html("");
        $("#transporterPaging").html("");
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "secure-service/Default.aspx/GetPartySearchResult",
            data: "{Customer:'" + Customer + "',Supplier:'" + Supplier + "', PartyMatchCode:'" + $("#txtPartyMatchCode").val() + "', PartyShortDescription:'" + $("#txtPartySDesc").val() + "',PartyCode:'" + PartyCode + "',LegalStatus:'" + LegalStatus + "',PageNumber:'" + PageNumber + "',PageSize:'" + PageSize + "'}",
            success: function (data) {
                if (data != null) {
                    if (data.d.length > 0) {
                        for (var i = 0; i < data.d.length; i++) {
                            if (i == 0) {
                                htmltbl += "<table title='Double click to select' ondblclick='EnableParentClose();' id='data-table' class='table table-striped table-bordered ' style='white-space: nowrap'><thead>";
                                htmltbl += " <tr><th>Customer</th><th>Supplier</th>  <th>Party Match Code</th> <th>Party Code</th><th>Party Name</th><th>Party Short Description</th><th>Legal Status</th></tr> </thead> <tbody>";

                            }
                            if (i % 2 == 0)
                                htmltbl += "<tr class='odd gradeX' ondblclick=\"Call(); javascript:Set8110PartyDetails('" + data.d[i].PartyCode + "-" + data.d[i].PartyName + "','" + data.d[i].PartyMatchCode + "','" + data.d[i].PartyShortDescription + "');\">";
                            else
                                htmltbl += "<tr class='even gradeC' ondblclick=\"Call(); javascript:Set8110PartyDetails('" + data.d[i].PartyCode + "-" + data.d[i].PartyName + "','" + data.d[i].PartyMatchCode + "','" + data.d[i].PartyShortDescription + "');\">";
                            htmltbl += "<td>" + data.d[i].Customer + "</td><td>" + data.d[i].Supplier + "</td><td>" + data.d[i].PartyMatchCode + "</td><td>" + data.d[i].PartyCode + "</td><td>" + data.d[i].PartyName + "</td><td>" + data.d[i].PartyShortDescription + "</td><td>" + data.d[i].PartyLegalStatus + "</td></tr>";
                        }
                        htmltbl += "</tbody>";
                        $("#dvPartyData").html(htmltbl);
                        getPaging("transporterPaging", data.d[0].TotalRows, PageNumber, PageSize, Type);
                        $("#dvPartyLoader").css("display", "none");
                    }
                    else {
                        $("#dvPartyLoader").css("display", "none");
                        alert("No result found in database");
                    }
                }
                else {
                    $("#dvPartyLoader").css("display", "none");
                    alert("No result found in database");
                }

            },
            error: function (result) {
                $("#dvPartyLoader").css("display", "none");
                alert("Error");
            }
        });
    }
    else if (Type == "TransportAvailability") {
        $("#dvTransporterLoader").css("display", "block");
        var TransporterCodeFrom = '';
        if ($("#txtTransportIDFrom").val() != "")
            TransporterCodeFrom = $("#txtTransportIDFrom").val().split('-')[0];
        var TransporterCodeTo = '';
        if ($("#txtTransporterCodeTo").val() != "")
            TransporterCodeTo = $("#txtTransporterCodeTo").val().split('-')[0];
        var htmltbl = '';
        $('#dvSearchResult').html('');
        $("#dvTransportIDPaging").html("");
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "secure-service/Default.aspx/GetTransportAvailabilitySearchDataResult",
            data: "{TransporterIDFrom:'" + $("#txtTransportIDFrom").val() + "',TransporterIDTo:'" + $("#txtTransportIDTo").val() + "',TransporterCodeFrom:'" + $('#txtTransporterCodeFrom').val() + "',TransporterCodeTo:'" + $('#txtTransporterCodeTo').val() + "',Fromdate:'" + $("#txtValidFrom").val() + "',Todate:'" + $("#txtValidTo").val() + "',FromLoc:'" + $("#txtFromLocation").val() + "',ToLoc:'" + $("#txtToLocation").val() + "',VechilePlateNumber:'" + $("#txtVehiclePlateNo").val() + "',Status:'" + $('#ddlStatus').val() + "',PageNumber:'" + PageNumber + "',PageSize:'" + PageSize + "'}",
            success: function (data) {
                if (data != null) {
                    if (data.d.length > 0) {
                        GRowNums = data.d.length;
                        for (var i = 0; i < data.d.length; i++) {
                            if (i == 0) {
                                htmltbl += "<table title='Double click to select' id='data-table' class='table table-striped table-bordered ' style='white-space: nowrap'><thead>";
                                htmltbl += "<tr><th>Transporter ID</th>  <th>Transporter Code</th> <th>From Date</th><th>To Date</th> <th>From Location</th><th>To Location</th><th>VechilePlateNumber</th><th>Status</th>  </tr> </thead> <tbody>";

                            }
                            if (i % 2 == 0)
                                htmltbl += "<tr class='odd gradeX' ondblclick=\'javascript:SetTransporter(" + data.d[i].TransporterIDFrom + ");\'>";
                            else
                                htmltbl += "<tr class='even gradeC' ondblclick=\'javascript:SetTransporter(" + data.d[i].TransporterIDFrom + ");\'>";
                            htmltbl += "<td>" + data.d[i].TransporterIDFrom + "</td><td>" + data.d[i].TransporterCodeFrom + "</td><td>" + data.d[i].Fromdate + "</td><td>" + data.d[i].Todate + "</td><td>" + data.d[i].FromLoc + "</td><td>" + data.d[i].ToLoc + "</td><td>" + data.d[i].VechilePlateNumber + "</td><td>" + data.d[i].Status + "</td></tr>";
                        }
                        htmltbl += "</tbody>";
                        $('#dvSearchResult').html(htmltbl);
                        getPaging("dvTransportIDPaging", data.d[0].TotalRows, PageNumber, PageSize, Type);
                        $("#dvTransporterLoader").css("display", "none");
                        GPageSize = data.d.length;
                        //alert(GPageSize);
                    }
                    else {
                        $("#dvTransporterLoader").css("display", "none");
                        alert('Detailt not avilable in database.');
                    }
                }

            },
            error: function (result) {
                $("#dvTransporterLoader").css("display", "none");
                alert('Error');
            }
        });
    }
    else if (Type == "SoNo") {
        $("#dvSOLoader").css("display", "block");
        var htmltbl = '';
        $('#dvSearchResult').html('');
        $("#dvSoNoPaging").html("");
        partyAddressId = 0;

        if ($("#ddlPartyAddress option:selected").val() != undefined) {
            partyAddressId =  $("#ddlPartyAddress option:selected").val();
        }
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "secure-service/Default.aspx/GetSOSearchDataResult",
            //data: "{PONO:'" + $("#txtPONO").val() + "',PartNO:'" + PartNo + "',PartyCode:'" + $("#txtPartyCode").val() + "',OrderDate:'" + OrderDate + "',DeliveryDate:'" + DeliveryDate + "',PageNumber:'" + PageNumber + "',PageSize:'" + PageSize + "',SO:'" + $('#txtPurchaseOrderNumber').val() + "'}",
            data: "{PONO:'" + $("#txtPONO").val() + "',PartNO:'" + PartNo + "',PartyCode:'" + $("#txtPartyCode").val() + "',OrderDate:'" + OrderDate + "',DeliveryDate:'" + DeliveryDate + "',PageNumber:'" + PageNumber + "',PageSize:'" + PageSize + "', SO:'" + $('#txtPurchaseOrderNumber').val() + "', PartyAddressID:'" + partyAddressId + "'}",
            success: function (data) {
                if (data != null) {
                    if (data.d.length > 0) {
                        for (var i = 0; i < data.d.length; i++) {
                            if (i == 0) {
                                htmltbl += "<table title='Double click to select' id='data-table' class='table table-striped table-bordered ' style='white-space: nowrap'><thead>";
                                htmltbl += "<tr><th>SONO</th><th>Line No</th><th>Product Code</th><th>Product Description</th><th>Transporter Mode</th><th style='display:none;'>NO_TRNMOD</th><th>PONO</th></tr> </thead> <tbody>";

                            }
                            if (i % 2 == 0)
                                htmltbl += "<tr class='odd gradeX'  ondblclick=\'Call(); javascript:SetSO(\"" + data.d[i].SO + "\"," + data.d[i].TransporterMode + ");\'>";
                            else
                                htmltbl += "<tr class='even gradeC' ondblclick=\'Call(); javascript:SetSO(\"" + data.d[i].SO + "\"," + data.d[i].TransporterMode + ");\'>";
                            htmltbl += "<td>" + data.d[i].SO + "</td><td>" + data.d[i].Line + "</td><td>" + data.d[i].ProductCode + "</td><td>" + data.d[i].ProductDescription + "</td><td>" + data.d[i].strTransporterMode + "</td><td style='display:none;'>" + data.d[i].TransporterMode + "</td><td>" + data.d[i].PONO + "</td></tr>";
                        }
                        htmltbl += "</tbody>";
                        $('#divSOSearchResult').html(htmltbl);
                        $("#dvSOLoader").css("display", "none");
                        getPaging("dvSoNoPaging", data.d[0].TotalRows, PageNumber, PageSize, Type);

                    }
                    else {
                        $("#dvSOLoader").css("display", "none");
                        alert('Detailt not avilable in database.');
                    }
                }

            },
            error: function (result) {
                $("#dvSOLoader").css("display", "none");
                alert('Error');
            }
        });
    }
    else if (Type == "TransporterIDOutgoing") {
        $("#dvTransporterLoader").css("display", "block");
        var TransporterCodeFrom = '';
        if ($("#txtTransportIDFrom").val() != "")
            TransporterCodeFrom = $("#txtTransportIDFrom").val().split('-')[0];
        var TransporterCodeTo = '';
        if ($("#txtTransporterCodeTo").val() != "")
            TransporterCodeTo = $("#txtTransporterCodeTo").val().split('-')[0];
        var htmltbl = '';
        $('#dvSearchResult').html('');
        $("#dvTransportIDPaging").html("");
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "secure-service/Default.aspx/GetTransportAvailabilitySearchDataResult",
            data: "{TransporterIDFrom:'" + $("#txtTransportIDFrom").val() + "',TransporterIDTo:'" + $("#txtTransportIDTo").val() + "',TransporterCodeFrom:'" + TransporterCodeFrom + "',TransporterCodeTo:'" + TransporterCodeTo + "',Fromdate:'" + $("#txtValidFrom").val() + "',Todate:'" + $("#txtValidTo").val() + "',FromLoc:'" + $("#txtFromLocation").val() + "',ToLoc:'" + $("#txtToLocation").val() + "',VechilePlateNumber:'" + $("#txtVehiclePlateNo").val() + "',Status:'" + $('#ddlStatus').val() + "',PageNumber:'" + PageNumber + "',PageSize:'" + PageSize + "'}",
            success: function (data) {
                if (data != null) {
                    if (data.d.length > 0) {
                        for (var i = 0; i < data.d.length; i++) {
                            if (i == 0) {
                                htmltbl += "<table title='Double click to select' id='data-table' class='table table-striped table-bordered ' style='white-space: nowrap'><thead>";
                                htmltbl += "<tr><th>Transporter ID</th>  <th>Transporter Code</th> <th>From Date</th><th>To Date</th> <th>From Location</th><th>To Location</th><th>VechilePlateNumber</th><th>Status</th>  </tr> </thead> <tbody>";

                            }
                            if (i % 2 == 0)
                                htmltbl += "<tr class='odd gradeX' ondblclick=\'javascript:SetTransporterID(" + data.d[i].TransporterIDFrom + ");\'>";
                            else
                                htmltbl += "<tr class='even gradeC' ondblclick=\'javascript:SetTransporterID(" + data.d[i].TransporterIDFrom + ");\'>";
                            htmltbl += "<td>" + data.d[i].TransporterIDFrom + "</td><td>" + data.d[i].TransporterCodeFrom + "</td><td>" + data.d[i].Fromdate + "</td><td>" + data.d[i].Todate + "</td><td>" + data.d[i].FromLoc + "</td><td>" + data.d[i].ToLoc + "</td><td>" + data.d[i].VechilePlateNumber + "</td><td>" + data.d[i].Status + "</td></tr>";
                        }
                        htmltbl += "</tbody>";
                        $('#dvSearchResult').html(htmltbl);
                        getPaging("dvTransportIDPaging", data.d[0].TotalRows, PageNumber, PageSize, Type);
                        $("#dvTransporterLoader").css("display", "none");
                    }
                    else {
                        $("#dvTransporterLoader").css("display", "none");
                        alert('Detailt not avilable in database.');
                    }
                }

            },
            error: function (result) {
                $("#dvTransporterLoader").css("display", "none");
                alert('Error');
            }
        });
    }
    else if (Type == 'Gateentry') {
        $("#dvAdminLoader").css("display", "block");
        var htmltbl = '';
        $('#dvGateEntrySearchResult').html('');
        $('#dvGateEntryPaging').html('');
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "Gatepass.aspx/DisplayGateEntrySearchResult",
            data: "{GateEntryNo:'" + $("#ddlFromGateEntry").val() + "',MaxGateEntryNo:'" + $("#ddlTodlGateEntry").val() + "',FrominComingDate:'" + $("#txtFromDate").val() + "',ToinComingDate:'" + $("#txtToDate").val() + "',Loaded_Unloaded:'" + $("#ddlFromLoadType").val() + "',VehicleType:'" + $("#ddlFromVehicleType").val() + "',VehiclePlateNo:'" + $("#txtVehiclePlateNosearch").val() + "',SecurityDocsNo:'" + $("#txtDocsNo").val() + "',InwardType:'" + $("#ddlFromInwardType").val() + "',TransporterCode:'" + TransporterCode + "',PageNumber:'" + PageNumber + "',PageSize:'" + PageSize + "'}",
            success: function (data) {
                if (data != null) {
                    if (data.d.length > 0) {
                        for (var i = 0; i < data.d.length; i++) {
                            if (i == 0) {
                                htmltbl += "<table title='Double click to select' id='data-table' class='table table-striped table-bordered ' style='white-space: nowrap'><thead>";
                                htmltbl += "<tr><th>Gate Entry No</th>  <th>Load Type</th><th>Vehicle Type</th><th>Vehicle Plate No</th><th>Security Docs No</th><th>Inward Type</th><th>Transporter Code</th></tr> </thead> <tbody>";

                            }
                            if (i % 2 == 0)
                                htmltbl += "<tr class='odd gradeX' ondblclick=\'Call(); javascript:SetGateEntryURL(\"" + data.d[i].BCDATA + "\");\'>";
                            else
                                htmltbl += "<tr class='even gradeC' ondblclick=\' Call(); javascript:SetGateEntryURL(\"" + data.d[i].BCDATA + "\");\'>";
                            htmltbl += "<td>" + data.d[i].GateEntryNo + "</td><td>" + data.d[i].str_Loaded_Unloaded + "</td><td>" + data.d[i].str_VehicleType + "</td><td>" + data.d[i].VehiclePlateNo + "</td><td>" + data.d[i].SecurityDocsNo + "</td><td>" + data.d[i].str_InwardType + "</td><td>" + data.d[i].TransporterCode + "</td></tr>";
                        }
                        htmltbl += "</tbody>";
                        $('#dvGateEntrySearchResult').html(htmltbl);
                        getPaging("dvGateEntryPaging", data.d[0].TotalRows, PageNumber, PageSize, Type);
                        $("#dvAdminLoader").css("display", "none");
                    }
                    else {
                        $("#dvAdminLoader").css("display", "none");
                        alert('Detailt not avilable in database.');
                    }
                }

            },
            error: function (result) {
                $("#dvAdminLoader").css("display", "none");
                alert('Error');
            }
        });
    }

    else if (Type == 'SecurityDetails') {
        var htmltbl = '';
        $('#dvTransactionDetails').html('');
        $('#dvtransPaging').html('');
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "secure-service/Default.aspx/GetDetailsData",
            data: "{Type:'" + Type + "',PageNumber:'" + PageNumber + "',PageSize:'" + PageSize + "'}",
            success: function (data) {
                if (data != null) {
                    if (data.d.length > 0) {
                        $("#ModelTitle").text("Security Gate Details (" + data.d.length + ")");
                        for (var i = 0; i < data.d.length; i++) {
                            if (i == 0) {
                                htmltbl += "<table title='Double click to select' id='data-table' class='table table-striped table-bordered ' style='white-space: nowrap'><thead>";
                                htmltbl += "<tr><th>Security Gate Entry No</th><th>Vehicle Plate No</th><th>Driver Name</th><th>INTM</th></tr> </thead> <tbody>";

                            }
                            if (i % 2 == 0)
                                htmltbl += "<tr class='odd gradeX'>";
                            else
                                htmltbl += "<tr class='even gradeC'>";
                            htmltbl += "<td>" + data.d[i].SecurityGateNo + "</td><td>" + data.d[i].VEHPLNO + "</td><td>" + data.d[i].DRIVERNM + "</td><td>" + data.d[i].SecurityINTM + "</td></tr>";
                        }
                        htmltbl += "</tbody>";
                        $('#dvTransactionDetails').html(htmltbl);
                        getPaging("dvtransPaging", data.d[0].TotalRows, PageNumber, PageSize, Type);
                    }
                    else {
                        alert('Detailt not avilable in database.');
                    }
                }

            },
            error: function (result) {
                alert('Error');
            }
        });
    }
    else if (Type == 'AdminDetails' || Type == 'GateEntryDetails' || Type == 'WB1' || Type == 'WB2' || Type == 'WB3' || Type == 'WB4' || Type == 'WB5' || Type == 'WB6') {

        var htmltbl = '';
        $('#dvTransactionDetails').html('');
        $('#dvtransPaging').html('');
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "secure-service/Default.aspx/GetDetailsData",
            data: "{Type:'" + Type + "',PageNumber:'" + PageNumber + "',PageSize:'" + PageSize + "'}",
            success: function (data) {
                if (Type == 'AdminDetails')
                    $("#ModelTitle").text("Admin Gate Details (0)");
                else if (Type == 'GateEntryDetails')
                    $("#ModelTitle").text("Gate Entry Details (0)");
                else
                    $("#ModelTitle").text("Weight Bridge " + Type.split('B')[1] + " Details (0)");
                if (data != null) {
                    if (data.d.length > 0) {
                        if (Type == 'AdminDetails')
                            $("#ModelTitle").text("Admin Gate Details (" + data.d.length + ")");
                        else if (Type == 'GateEntryDetails')
                            $("#ModelTitle").text("Gate Entry Details (" + data.d.length + ")");
                        else
                            $("#ModelTitle").text("Weight Bridge " + Type.split('B')[1] + " Details (" + data.d.length + ")");
                        for (var i = 0; i < data.d.length; i++) {
                            if (i == 0) {
                                htmltbl += "<table id='data-table' title='Double click to select' class='table table-striped table-bordered ' style='white-space: nowrap'><thead>";
                                htmltbl += "<tr><th>Vehicle Plate No</th><th>Driver Name</th><th>Admin Gate Entry No</th><th>Admin INTM</th><th>RFID</th><th>Barcode</th></tr> </thead> <tbody>";

                            }
                            if (i % 2 == 0)
                                htmltbl += "<tr class='odd gradeX'>";
                            else
                                htmltbl += "<tr class='even gradeC'>";
                            htmltbl += "<td>" + data.d[i].VEHPLNO + "</td><td>" + data.d[i].DRIVERNM + "</td><td>" + data.d[i].AdminGateEntryNo + "</td><td>" + data.d[i].AdminINTM + "</td><td>" + data.d[i].RFID + "</td><td>" + data.d[i].Barcode + "</td></tr>";
                        }
                        htmltbl += "</tbody>";
                        $('#dvTransactionDetails').html(htmltbl);
                        getPaging("dvtransPaging", data.d[0].TotalRows, PageNumber, PageSize, Type);
                    }
                    //else {
                    //    alert('Detailt not avilable in database.');
                    //}
                }

            },
            error: function (result) {
                //alert('Error');
                console.log(result);
            }
        });
    }
    else if (Type == 'WEIGHINGID') {
        $('#dvAdminLoader').css("display", "block");
        var htmltbl = '';
        $('#dvWeighingDetails').html('');
        $('#dvWeighingPaging').html('');
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "secure-service/Default.aspx/GetWeighingData",
            data: "{Type:'" + Type + "',PageNumber:'" + PageNumber + "',PageSize:'" + PageSize + "',VehiclePlateNumber:'" + $('#txtVehiclePlateNosearch').val() + "',  GateEntryNo:'" + $('#TxtGateEntry').val() + "',  Fromdate:'" + $('#txtFromDate').val() + "',  ToDate:'" + $('#txtToDate').val() + "',  WeghingId:'" + $('#txtWeighingID').val() + "'}",
            success: function (data) {
                if (data != null) {
                    if (data.d.length > 0) {
                       // $("#ModelTitle").text("Security ID Details (" + data.d[0].TotalRows + ")");
                        for (var i = 0; i < data.d.length; i++) {
                            if (i == 0) {
                                htmltbl += "<table title='Click to select' id='data-table' class='table table-striped table-bordered ' style='white-space: nowrap'><thead>";
                                htmltbl += "<tr><th>Weighing ID</th>  <th>Gate Entry No</th><th>Product Cd.</th><th>Party Cd.</th></tr> </thead> <tbody>";
                            }
                            if (i % 2 == 0)
                                htmltbl += "<tr class='odd gradeX'  onclick=\"Call(); SetWeighingIDURL('" + data.d[i].WeightmentID + "');\">";
                            else
                                htmltbl += "<tr class='even gradeC'  onclick=\"Call(); SetWeighingIDURL('" + data.d[i].WeightmentID + "');\">";
                            htmltbl += "<td>" + data.d[i].WeightmentID + "</td><td>" + data.d[i].GateEntryNo + "</td><td>" + data.d[i].PartNo + "</td><td>" + data.d[i].PartyName + "</td></tr>";
                        }
                        htmltbl += "</tbody>";
                        $('#dvWeighingDetails').html(htmltbl);
                        getPaging("dvWeighingPaging", data.d[0].TotalRows, PageNumber, PageSize, Type);
                        $('#dvAdminLoader').css("display", "none");
                    }
                    else {
                        $('#dvAdminLoader').css("display", "none");
                        alert('Detailt not avilable in database.');
                    }
                }
            },
            error: function (result) {
                $('#dvAdminLoader').css("display", "none");
                //alert('Error');
                console.log(result);
            }
        });
    }

    else if (Type == 'MISC') {
        $('#dvAdminLoader').css("display", "block");
        var htmltbl = '';
        $('#dvWeighingDetails').html('');
        $('#dvWeighingPaging').html('');
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "secure-service/Default.aspx/GetWeighingData",
            data: "{Type:'" + Type + "',PageNumber:'" + PageNumber + "',PageSize:'" + PageSize + "',VehiclePlateNumber:'" + $('#txtVehiclePlateNosearch').val() + "',  GateEntryNo:'" + $('#TxtGateEntry').val() + "',  Fromdate:'" + $('#txtFromDate').val() + "',  ToDate:'" + $('#txtToDate').val() + "',  WeghingId:'" + $('#txtWeighingID').val() + "'}",
            success: function (data) {
                if (data != null) {
                    if (data.d.length > 0) {
                        // $("#ModelTitle").text("Security ID Details (" + data.d[0].TotalRows + ")");
                        for (var i = 0; i < data.d.length; i++) {
                            if (i == 0) {
                                htmltbl += "<table title='Click to select' id='data-table' class='table table-striped table-bordered '><thead>";
                                htmltbl += "<tr><th>Weighing ID</th>  <th>Gate Entry No</th><th>Product Cd.</th><th>Party Cd.</th></tr> </thead> <tbody>";
                            }
                            if (i % 2 == 0)
                                htmltbl += "<tr class='odd gradeX'  onclick=\" Call(); SetWeighingIDURL('" + data.d[i].WeightmentID + "');\">";
                            else
                                htmltbl += "<tr class='even gradeC'  onclick=\" Call(); SetWeighingIDURL('" + data.d[i].WeightmentID + "');\">";
                            htmltbl += "<td>" + data.d[i].WeightmentID + "</td><td>" + data.d[i].GateEntryNo + "</td><td>" + data.d[i].PartNo + "</td><td>" + data.d[i].PartyName + "</td></tr>";
                        }
                        htmltbl += "</tbody>";
                        $('#dvWeighingDetails').html(htmltbl);
                        getPaging("dvWeighingPaging", data.d[0].TotalRows, PageNumber, PageSize, Type);
                        $('#dvAdminLoader').css("display", "none");
                    }
                    else {
                        $('#dvAdminLoader').css("display", "none");
                        alert('Detailt not avilable in database.');
                    }
                }
            },
            error: function (result) {
                $('#dvAdminLoader').css("display", "none");
                //alert('Error');
                console.log(result);
            }
        });
    }
}

function FileUpload(Img, Type, output) {

    var fileUpload = $("#DriverPictureUpload").get(0);
    var files = fileUpload.files;
    var data = new FormData();
    data.append(files[0].name, files[0]);
    data.append("image", Img);
    var options = {};
    options.url = "image.ashx";
    options.type = "POST";
    options.data = data;
    options.contentType = false;
    options.processData = false;
    options.success = function (result) {
        if (Type == "UPDATE") {
            if (output == "SUCCESS") {
                $("#msgsuccess").text("Security gate data save successfully.");
                $("#msgsuccess").show();
                ResetSecurityGateControl();
                //  window.location.href = "SecurityGateEntry.aspx";
            }
            else {
                $("#msgerror").text("oops somthing went wrong please try again later." + output);
                $("#msgerror").show();
            }

        }
        else {
            if (output != null) {

                ResetSecurityGateControl();
                $("#msgsuccess").text("Security gate data save successfully.Security Gate Number:" + output);
                $("#msgsuccess").show();

            }
            else {
                $("#msgerror").text("oops somthing went wrong please try again later.");
                $("#msgerror").show();
            }



        }


    };
    options.error = function (err) {
        alert(err);
    };
    $.ajax(options);
    //  evt.preventDefault();
}



function SaveSecurityGateentryData(GateEnteryNumber, TransactionType, IncomingTime, VechileType, VechilePlateNumber, PermitTrip, State, DriverName, LicenseNumberLock, SealNo, Remarks, RTOPassWeight, RTOCapacityQty, InsurancePolicyNo, InsurancePolicyValidity, LicenseNumber, LicenseValidy, Type, DriverPicture, LoadingType, EwayNo, EwayDate) {

    try {
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "secure-service/Default.aspx/SaveSecurityGateData",
            data: "{GateEnteryNumber:'" + GateEnteryNumber + "',  TransactionType:'" + TransactionType + "',  IncomingTime:'" + IncomingTime + "',  VechileType:'" + VechileType + "',  VechilePlateNumber:'" + VechilePlateNumber + "',  PermitTrip:'" + PermitTrip + "',  State:'" + State + "',  DriverName:'" + DriverName + "',  LicenseNumberLock:'" + LicenseNumberLock + "',  SealNo:'" + SealNo + "',  Remarks:'" + Remarks + "',  RTOPassWeight:'" + RTOPassWeight + "',  RTOCapacityQty:'" + RTOCapacityQty + "',  InsurancePolicyNo:'" + InsurancePolicyNo + "',  InsurancePolicyValidity:'" + InsurancePolicyValidity + "',  LicenseNumber:'" + LicenseNumber + "',  LicenseValidy:'" + LicenseValidy + "',  Type :'" + Type + "', DriverPicture:'" + DriverPicture + "',LoadingType:'" + LoadingType + "',EwayNo:'" + EwayNo + "',EwayDate:'" + EwayDate + "'}",
            dataType: "json",
            success: function (data) {
                var div = data.d.split('~');
                if (div[0] == "error") {
                    $("#btnSave").attr("disabled", false);
                    $("#msg" + div[0]).html("<button type='button' class='close' onclick='closeDiv(\"msg" + div[0] + "\");'>x</button><h4><i class='icon fa fa-check'></i>Alert!</h4>" + div[1]);
                    $("#msg" + div[0]).show();
                }
                if (div[0] == "success") {
                    if (div[1].indexOf('completed') > 0 || div[1].indexOf('updated') > 0)
                    {
                        $('#lblVahiclePlateNoMsg').html("");
                    }
                    else {
                        $("#ddlSecurityGateEntry").append("<option value='" + div[1] + "--" + VechilePlateNumber + "-0'>" + div[1] + "-" + VechilePlateNumber.toUpperCase() + "</option>")
                        $("#ddlSecurityGateEntry").val(div[1] + "--" + VechilePlateNumber + "-0");
                        $("#ddlSecurityGateEntry").attr("disabled", true);
                        $(".search").trigger("chosen:updated");
                        _isDirty = false;
                        $('#lblVahiclePlateNoMsg').html("");
                    }
                }
                if (GateEnteryNumber != "") {
                    $("#msg" + div[0]).html("<button type='button' class='close' onclick='closeDiv(\"msg" + div[0] + "\");'>x</button><h4><i class='icon fa fa-check'></i>Alert!</h4>" + div[1]);
                    $("#msg" + div[0]).show();
                }
                $('#btnCapture').attr("disabled", "disable");
                $("#dvL").fadeOut(100);

            },
            error: function (result) {
                $("#msgerror").html("<button type='button' class='close' data-dismiss='alert' aria-hidden='true'>x</button><h4><i class='icon fa fa-check'></i>Alert!</h4>" + result);
                $("#msgerror").show();
                $("#dvL").fadeOut(100);
            }
        });
    }
    catch (err) {
        $("#msgerror").html("<button type='button' class='close' data-dismiss='alert' aria-hidden='true'>x</button><h4><i class='icon fa fa-check'></i>Alert!</h4>" + err);
        $("#msgerror").show();
        $("#dvL").fadeOut(100);
    }
}

function ResetSecuritySearchControl() {

    $("#txtIncomingFromDate").val("");
    $("#txtIncomingToDate").val("");
    $("#txtVechilePlateNo").val("");
    $("#txtSecurityGateNumber").val("");
    $("#dvSearchResult").html("");
    $("#dvPaging").html("");
}


var GNO;
var Veh;
var Stage;
var BCDATA;
function SetGateEntry(GateEntryNumber) {
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "secure-service/Default.aspx/SetGateEntry",
        data: "{GateEntryNumber:'" + GateEntryNumber + "'}",
        success: function (data) {
            if (data != null) {
                if (data.d.length > 0) {
                    SecurityGateEntryNo = GateEntryNumber;
                    GNO = GateEntryNumber;
                    Veh = data.d[0].VehiclePlateNo;
                    Stage = data.d[0].Stage;
                    BCDATA = data.d[0].BCDATA;
                    $("#panelTitle").html("Security Gate Entry - " + GateEntryNumber);
                    $("#title").html("Security Gate Entry - " + GateEntryNumber);
                    $("#txtVehiclePlateNo").val(data.d[0].VehiclePlateNo);
                    $("#txtPolicyNumber").val(data.d[0].InsPolicyNumber);
                    $("#txtPolicyValidity").val(data.d[0].InsPolicyValidity);
                    $("#txtWeight").val(data.d[0].RTOWeight);
                    $("#txtDriverName").val(data.d[0].DriverName);
                    $("#txtLicenseValidity").val(data.d[0].LicenseExpiryDate);
                    $("#txtEwayNo").val(data.d[0].EwayNo);
                    $("#txtEwayDate").val(data.d[0].EwayDate);
                    /////////
                    $("#imgDriver").attr('src', ImageFolder + data.d[0].DriverPicture)
                    //$('#imgDriver').src = ImageFolder+data.d[0].DriverPicture;

                    //////
                    $("#ddlVechileType option").each(function () {
                        this.selected = $(this).val() == data.d[0].VechileType;
                    });
                    //   CheckVechicleEntry(data.d[0].VehiclePlateNo, data.d[0].Incomin_Outgoing);
                    //CheckVehicleAvilability(data.d[0].VehiclePlateNo, 'txtVehiclePlateNo');
                    $("#ddlStateName").val(data.d[0].StateName);
                    $("#txtRemark").val(data.d[0].Remark);
                    $("#txtDriverLicense").val(data.d[0].LicenseNumber),

                      $("#ddlLoadingType option").each(function () {
                          this.selected = $(this).val() == data.d[0].Loaded_Unloaded;
                      });
                    //$("#dvIncoming").css('display', "block");
                    outdate = data.d[0].OutGoingDT;
                    intime = data.d[0].IncominDT;
                    $("input:radio[name=rdTrip][value=" + data.d[0].Trip + "]").attr('checked', 'checked')
                    $("input:radio[name=rdoLicenselock][value=" + data.d[0].Lock + "]").attr('checked', 'checked')
                    if (data.d[0].Incomin_Outgoing == "O") {
                        DisabledGn8000();
                        $("#lblTime").text("Outgoing Date & Time:");
                        $("#lblincoming").text(data.d[0].IncominDT);
                        $("#dvIncoming").css('display', "block");
                        $("input:radio[name=rdoReportType]").attr("disabled", true);
                        $("#txtIncomingDate").val(data.d[0].OutGoingDT);
                        $("input:radio[name=rdTrip]").attr("disabled", true);
                        $("input:radio[name=rdoLicenselock]").attr("disabled", true);
                        $("#ddlSecurityGateEntry").append("<option value='" + BCDATA + "'>" + SecurityGateEntryNo + "</option>")
                    }
                    else {
                        //$("input:radio[name=rdTrip][value=" + data.d[0].Trip + "]").attr('checked', 'checked')
                        //$("input:radio[name=rdoLicenselock][value=" + data.d[0].Lock + "]").attr('checked', 'checked')
                        $("input:radio[name=rdoReportType]").attr("disabled", false);
                        $("#ddlSecurityGateEntry").append("<option value='" + BCDATA + "'>" + SecurityGateEntryNo + "</option>") 
                        //
                        $("#txtIncomingDate").val(data.d[0].IncominDT);
                    }
                    $("#ddlSecurityGateEntry").val(BCDATA);
                    $("#ddlSecurityGateEntry").attr("disabled", true);
                    $(".search").trigger("chosen:updated");
                    $("#btnSGNSearch").attr("disabled", true);
                    $("input:radio[name=rdoReportType][value=" + data.d[0].Incomin_Outgoing + "]").attr('checked', 'checked'),
                    $("#txtSealNumber").val(data.d[0].SealNumber);

                    if (data.d[0].Stage == "0") {
                        $("input:radio[id=rdoutGoing]").attr("disabled", false);
                        //$("input:radio[id=rdincoming]").attr("disabled", false);
                        document.getElementById("btnSave").disabled = false;
                        $("input:radio[name=rdTrip]").attr("disabled", false);
                        $("input:radio[name=rdoLicenselock]").attr("disabled", false);
                    }
                   
                    else if (data.d[0].Stage == "7") {
                        $("#lblincoming").text(data.d[0].IncominDT);
                        //$("input:radio[id=rdoutGoing]").attr("checked", true);
                        $("input:radio[id=rdoutGoing]").attr("disabled", false);
                        $("input:radio[id=rdoincoming]").attr("disabled", true);
                        DisabledGn8000();
                        $("input:radio[name=rdTrip]").attr("disabled", false);
                        $("input:radio[name=rdoLicenselock]").attr("disabled", false);
                        document.getElementById("btnSave").disabled = false;
                        var dt = new Date();
                        //var month = new Array();
                        //month[0] = "Jan";
                        //month[1] = "Feb";
                        //month[2] = "Mar";
                        //month[3] = "Apr";
                        //month[4] = "May";
                        //month[5] = "Jun";
                        //month[6] = "Jul";
                        //month[7] = "Aug";
                        //month[8] = "Sep";
                        //month[9] = "Oct";
                        //month[10] = "Nov";
                        //month[11] = "Dec";
                       // var time = dt.getDate() + '-' + ("0" + (dt.getMonth() + 1)).slice(-2) + '-' + (dt.getFullYear()) + ' ' + dt.getHours() + ':' + dt.getMinutes() + ':' + dt.getSeconds();
                       // $("#txtIncomingDate").val(time);
                    }
                    else {
                        $("input:radio[id=rdoutGoing]").attr("disabled", true);
                        document.getElementById("btnSave").disabled = true;
                        if (data.d[0].Stage >= "2")
                        $("#btnScan").attr("disabled", true);
                    }
                }
            }
            else {

                alert("Driver details not avilable in database.");
            }

        },
        error: function (result) {
            alert("Error");
        }
    });
}

function DisabledGn8000() {
    $("#dvIncoming").css('display', "block");
    $("#dvLicenseValidity").css("display", "none");
    $("#dvPolicyValidity").css("display", "none");
    $("#lblTime").text("Outgoing Date & Time:");
    $("#ddlVechileType").attr("disabled", true);
    $("#txtVehiclePlateNo").attr("disabled", true);
    //$("#ddlStateName").attr("disabled", true);
    $("#txtDriverName").attr("disabled", true);
    $("#txtSealNumber").attr("disabled", true);
    $("#txtRemark").attr("disabled", true);
    $("#txtWeight").attr("disabled", true);
    $("#txtCapacity").attr("disabled", true);
    $("#txtPolicyNumber").attr("disabled", true);
    $("#txtPolicyValidity").attr("disabled", true);
    $("#txtDriverLicense").attr("disabled", true);
    $("#txtLicenseValidity").attr("disabled", true);
    $("#ddlLoadingType").attr("disabled", true);

    //  $("input:radio[name=rdoReportType][value=I]").attr("disabled", true);
    //$("input:radio[name=rdTrip]").attr("disabled", true);
    //$("input:radio[name=rdoLicenselock]").attr("disabled", true);
    outdate = '';
    intime = $("#txtIncomingDate").val();
    $(".search").trigger("chosen:updated");
    $("#ddlSecurityGateEntry").val(BCDATA);
}

function EnabledGN8000() {
    $("#lblTime").text("Incoming Date & Time:");
    $("#dvLicenseValidity").css("display", "block");
    $("#dvPolicyValidity").css("display", "block");
    $("#txtIncomingDate").val(intime);
    $("#ddlVechileType").attr("disabled", false);
    $("#txtVehiclePlateNo").attr("disabled", false);
    $("#ddlStateName").attr("disabled", false);
    $("#txtDriverName").attr("disabled", false);
    $("#txtSealNumber").attr("disabled", false);
    $("#txtRemark").attr("disabled", false);
    $("#txtWeight").attr("disabled", false);
    $("#txtCapacity").attr("disabled", false);
    $("#txtPolicyNumber").attr("disabled", false);
    $("#txtPolicyValidity").attr("disabled", false);
    $("#txtDriverLicense").attr("disabled", false);
    $("#txtLicenseValidity").attr("disabled", false);
    $("#ddlLoadingType").attr("disabled", false);
    if ($("#ddlSecurityGateEntry :selected").text() != "--select--") {
        $("#ddlSecurityGateEntry").attr("disabled", true);
        $("#btnSGNSearch").attr("disabled", true);
    }
    else {
        $("#ddlSecurityGateEntry").attr("disabled", false);
        $("#btnSGNSearch").attr("disabled", false);
    }
    //   $("input:radio[name=rdoReportType][value=I]").attr("disabled", false);
    $("input:radio[name=rdTrip]").attr("disabled", false);
    $("input:radio[name=rdoLicenselock]").attr("disabled", false);
    $(".search").trigger("chosen:updated");
}

function ResetSecurityGateControl() {
    EnabledGN8000();
    $("#ddlVechileType").val(0);
    $("#txtVehiclePlateNo").val("");
    $("#ddlStateName").val(0);
    $("#txtDriverName").val("");
    $("#txtSealNumber").val("NA");
    $("#txtRemark").val("");
    $("#txtWeight").val(""),
    $("#txtCapacity").val(""),
    $("#txtPolicyNumber").val(""),
    $("#txtPolicyValidity").val(""),
    $("#txtDriverLicense").val(""),
    $("#txtLicenseValidity").val(""),
    $("#ddlLoadingType").val(0),
    $("input:radio[name=rdoReportType][value=I]").attr('checked', 'checked'),
    $("input:radio[name=rdTrip][value=Y]").attr('checked', 'checked'),
    $("input:radio[name=rdoLicenselock][value=N]").attr('checked', 'checked');
    $("#ddlSecurityGateEntry").val(0);
    $(".search").trigger("chosen:updated");
    $("#imgDriver").attr('src', '../images/usericon.jpg');
    $("#DriverPictureUpload").val("");
    $("#btnSave").attr("disabled", false);
    $("#ddlSecurityGateEntry").attr("disabled", false);
    $("#btnSGNSearch").attr("disabled", false);
    $("#dvIncoming").css('display', "none");
    $("#lblincoming").html("");
    $(".search").trigger("chosen:updated");
    var dt = new Date();
    //var month = new Array();
    //month[0] = "Jan";
    //month[1] = "Feb";
    //month[2] = "Mar";
    //month[3] = "Apr";
    //month[4] = "May";
    //month[5] = "Jun";
    //month[6] = "Jul";
    //month[7] = "Aug";
    //month[8] = "Sep";
    //month[9] = "Oct";
    //month[10] = "Nov";
    //month[11] = "Dec";
    var time = dt.getDate() + '-' + ("0" + (dt.getMonth() + 1)).slice(-2) + '-' + (dt.getFullYear()) + ' ' + dt.getHours() + ':' + dt.getMinutes() + ':' + dt.getSeconds();
    $("#txtIncomingDate").val(time);
    $("#lblVahiclePlateNoMsg").html("");
    $("#lblLoadingTypeMsg").html("");
    $("#lblDriverNameMsg").html("");
    $("#lblLicenseNumberMsg").html("");
    $("#lblPolicyNumberMsg").html("");
    $("#lblPolicyValidityMsg").html("");
    $("#lblSealNoMsg").html("");
    $("#lblRTOWeightMsg").html("");
    $("#txtEwayNo").val("");
    $("#txtEwayDate").val("");
    $("#btnScan").attr("disabled", false);
    
}


function CheckVehicleAvilability(VehiclePlateNumber) {
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "secure-service/Default.aspx/GetVechicleData",
        data: "{VechilePlateNumber:'" + VehiclePlateNumber + "'}",
        success: function (data) {
            if (data != null) {
                if (data.d.length > 0) {
                    $("#ddlVechileType option").each(function () {
                        this.selected = $(this).val() == data.d[0].VechileType;
                    });
                    $("#ddlVehicleType option").each(function () {
                        this.selected = $(this).val() == data.d[0].VechileType;
                    });
                    $("input:radio[name=rdTrip][value=" + data.d[0].Permit + "]").attr('checked', 'checked');
                    $("#txtPolicyNumber").val(data.d[0].InsPolicyNumber);
                    $("#txtPolicyValidity").val(data.d[0].InsPolicyValidity);
                    $("#txtWeight").val(data.d[0].RTOWeight);
                    $(".search").trigger("chosen:updated");
                    $("#Vechicleloader").css('display', 'none');
                    if (data.d[0].Permit == "N") {
                        $("#txtVehiclePlateNo").attr("disabled", true)
                        //$("#btnSave").attr("disabled", true);
                        alert("Vehicle is not permited to enter premisis");
                        document.getElementById("btnSave").disabled = true;
                    }
                    else {
                        $("#txtVehiclePlateNo").attr("disabled", false)
                        //$("#btnSave").attr("disabled", false);
                    }
                    $('#txtrfid').val(data.d[0].RFIDTag);
                }
                else {
                    //$("#ddlVechileType option").each(function () {
                    //    this.selected = $(this).val() == "--select--";
                    //});
                    $("input:radio[name=rdTrip][value=Y]").attr('checked', 'checked');
                    //$(".search").trigger("chosen:updated");
                    $("#Vechicleloader").css('display', 'none');
                }
            }
        },
        error: function (result) {
            $("#Vechicleloader").css('display', 'none');
        }
    });
}

function CheckVechicleEntry(VehiclePlateNumber, Type) {

    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "secure-service/Default.aspx/CheckVechicleEntry",
        data: "{VechilePlateNumber:'" + VehiclePlateNumber + "',Type:'" + Type + "'}",
        success: function (data) {
            if (data != null) {
                if (data.d > 0) {
                    //if(Type=='I')//<button type='button' onclick='closeDiv("msgerror")'>x</button>
                    //if ($("#ddlSecurityGateEntry :selected").val() == "--select--") {
                    if ($("#ddlSecurityGateEntry").attr("disabled") != "disabled") {
                        $("#msgerror").html("<button type='button' class='close' onclick='closeDiv(\"msgerror\");'>x</button><h4><i class='icon fa fa-check'></i>Alert!</h4>Vehicle transaction already open.");
                        //else
                        //    $("#msgerror").html("<button type='button' class='close' data-dismiss='alert' aria-hidden='true'>x</button><h4><i class='icon fa fa-check'></i>Alert!</h4> Vehicle has already entered the premises.");
                        $("#msgerror").show();
                        //$("#btnSave").attr("disabled", true);
                        VechicleEntry = true;
                    }
                    if ($("#ddlSecGateEntryNo :selected").text() == "--select--") {
                        $("#lblVahiclePlateNoMsg").html("Vehicle transaction already open.")
                        document.getElementById("btnSave").disabled = true;
                        //$("#msgerror").html("<button type='button' class='close' onclick='closeDiv(\"msgerror\");'>x</button><h4><i class='icon fa fa-check'></i>Alert!</h4>Vehicle transaction already open.");
                        //else
                        //    $("#msgerror").html("<button type='button' class='close' data-dismiss='alert' aria-hidden='true'>x</button><h4><i class='icon fa fa-check'></i>Alert!</h4> Vehicle has already entered the premises.");
                        //$("#msgerror").show();
                        //$("#btnSave").attr("disabled", true);
                        //      VechicleEntry = true;
                    }
                    else {
                        //document.getElementById("btnSave").disabled = false;
                    }
                }
                else {
                    $("#msgerror").hide();
                    //document.getElementById("btnSave").disabled = false;
                    //$("#btnSave").attr("disabled", false);
                    //    VechicleEntry = false;

                }
            }
        },
        error: function (result) {
            $("#msgerror").text(result);
            $("#msgerror").show();

        }
    });



    //return VechicleEntry;
}

function CheckLicenseEntry(LicenseNumber, GateEntry) {
    $("#msgerror").html("");
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "secure-service/Default.aspx/CheckLicenseEntry",
        data: "{LicenseNumber:'" + LicenseNumber + "', entry:" +GateEntry+ "}",
        success: function (data) {
            if (data != null) {
                if (data.d.length > 0) {
                    $("#msgerror").html("<button type='button' class='close' onclick='closeDiv(\"msgerror\");'>x</button><h4><i class='icon fa fa-check'></i>Alert!</h4> Driver license already in!!" + data.d);
                    $("#msgerror").show();

                    $("#lblLicense").html("Driver license already in!!" + data.d);
                    //  alert('Driver license already in!!'+data.d);
                }
                else {

                }
            }
            else {

            }

        },
        error: function (result) {
            $('#Driverloader').css('display', 'none');
            //  alert("Error");
        }
    });
}




function CheckDriverAvilability(LicenseNumber) {
    //   $("#" + ctrl).addClass('loader');
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "secure-service/Default.aspx/GetDriverData",
        data: "{LicenseNumber:'" + LicenseNumber + "'}",
        success: function (data) {
            if (data != null) {
                if (data.d.length > 0) {
                    $("#txtDriverName").val(data.d[0].DriverName);
                    $("#txtLicenseValidity").val(data.d[0].LicenseExpiryDate);
                    $("input:radio[name=rdoLicenselock][value=" + data.d[0].Lock + "]").attr('checked', 'checked');
                    // alert('../images/DriverPicture/' + data.d[0].DriverPicture);
                    $("#imgDriver").attr('src', '../images/DriverPicture/' + data.d[0].DriverPicture);
                    //    $("#" + ctrl).removeClass('loader');
                    $("#DriverPictureUpload").val(data.d[0].DriverPicture);
                    $('#Driverloader').css('display', 'none');
                    if (data.d[0].Lock == "Y") {
                        $("#txtDriverLicense").attr("disabled", true);
                        alert('Driver not allowed for the trip');
                        $("#btnSave").attr("disabled", true);
                    }
                    else {
                        $("#txtDriverLicense").attr("disabled", false);
                        $("#btnSave").attr("disabled", false);
                    }
                }
                else {
                    //$("#" + ctrl).removeClass("loader");
                    //$("#txtDriverName").val("");
                    //$("#txtLicenseValidity").val("");
                    $("input:radio[name=rdoLicenselock][value=N]").attr("checked", "checked");
                    // alert("../images/DriverPicture/" + data.d[0].DriverPicture);
                    $("#imgDriver").attr("src", "../images/usericon.jpg");
                    //    $("#" + ctrl).removeClass("loader");
                    $("#DriverPictureUpload").val("");
                    // alert("Driver details not avilable in database.");
                    $("#Driverloader").css("display", "none");
                }

            }
            else {
                $('#Driverloader').css('display', 'none');
                // alert("Driver details not avilable in database.");

            }

        },
        error: function (result) {
            $('#Driverloader').css('display', 'none');
            //  alert("Error");
        }
    });
}


function SetSecurityGateNumber(number) {
    $('#dvL').fadeIn(100);
    window.top.location.href = "SecurityGateEntry.aspx?sgn=" + number;

}

//function ResetSecurityResetControl() {
//    $("#ddlSecurityGateEntry").val("")

//    $("#txtIncomingFromDate").val("");
//    $("#txtIncomingToDate").val(""),
//    $("#txtVechilePlateNo").val("")
//    $("#ddlSecurityGateEntry").val('0');
//}

//function SearchSecurityGateEntry(GateEntryNumber, Fromdate, Todate, VechilePlateNumber, InComing) {
//    // alert("{GateEntryNumber:'" + GateEntryNumber + "',Fromdate:'" + Fromdate + "',Todate='" + Todate + "',VechilePlateNumber:'" + VechilePlateNumber + "',InComing:'" + InComing + "'}");
//    var htmltbl = "";
//    $("#dvSearchResult").html("");
//    $.ajax({
//        type: "POST",
//        contentType: "application/json; charset=utf-8",
//        url: "secure-service/Default.aspx/GetSeuritySearchDataResult",
//        data: "{GateEntryNumber:'" + GateEntryNumber + "',Fromdate:'" + Fromdate + "',todate:'" + Todate + "',VechilePlateNumber:'" + VechilePlateNumber + "',InComing:'" + InComing + "'}",
//        success: function (data) {
//            if (data != null) {
//                //  alert(data.d.length);
//                for (var i = 0; i < data.d.length; i++) {
//                    if (i == 0) {
//                        htmltbl += "<table id='data-table' class='table table-striped table-bordered ' style='white-space: nowrap'><thead>";
//                        htmltbl += " <tr><th>Security Gate Entry No</th>  <th>Incoming Date</th> <th>Vehicle Plate No</th> <th>Security in Vehicle</th>  </tr> </thead> <tbody>";

//                    }
//                    if (i % 2 == 0)
//                        htmltbl += "<tr class='odd gradeX' onclick=\"javascript:SetSecurityGateNumber('" + data.d[i].GateEntryNumber + "');\">";
//                    else
//                        htmltbl += "<tr class='even gradeC' onclick=\"javascript:SetSecurityGateNumber('" + data.d[i].GateEntryNumber + "');\">";
//                    htmltbl += "<td>" + data.d[i].GateEntryNumber + "</td><td>" + data.d[i].IncomingTime + "</td><td>" + data.d[i].VechilePlateNumber + "</td><td>" + data.d[i].TransactionType + "</td></tr>";
//                }
//                htmltbl += "</tbody>";
//                $("#dvSearchResult").html(htmltbl);
//            }
//            else {

//                alert("Driver details not avilable in database.");
//            }

//        },
//        error: function (result) {
//            alert("Error");
//        }
//    });
//}



//function SearchIndent(MinProjectCode, MaxProjectCode, MinCostCenterCode, MaxCostCenterCode, MinUnitCode, MaxUnitCode, ObjectType, IndentNumber, IndentFromDate, IndentToDate) {

//    var htmltbl = "";
//    $("#dvIndentResult").html("");
//    $.ajax({
//        type: "POST",
//        contentType: "application/json; charset=utf-8",
//        url: "secure-service/Default.aspx/GetIndentSearchResult",
//        data: "{MinProjectCode:'" + MinProjectCode + "',MaxProjectCode:'" + MaxProjectCode + "',MinCostCenterCode:'" + MinCostCenterCode + "',MaxCostCenterCode:'" + MaxCostCenterCode + "',MinUnitCode:'" + MinUnitCode + "',MaxUnitCode:'" + MaxUnitCode + "',ObjectType:'" + ObjectType + "',IndentNumber:'" + IndentNumber + "',IndentFromDate:'" + IndentFromDate + "',IndentToDate:'" +IndentToDate + "'}",
//        success: function (data) {
//            if (data != null) {
//                if (data.d.length > 0) {
//                    for (var i = 0; i < data.d.length; i++) {
//                        if (i == 0) {
//                            htmltbl += "<table id='data-table' class='table table-striped table-bordered ' style='white-space: nowrap'><thead>";
//                            htmltbl += " <tr><th>Project Code</th>  <th>Cost centre Code</th> <th>Unit Code</th> <th>Object Type</th> <th> LnNo</th> <th>Indent No.</th><th>Indent Date</th></tr> </thead> <tbody>";

//                        }
//                        if (i % 2 == 0)
//                            htmltbl += "<tr class='odd gradeX' onclick=\"javascript:Set8110Object('" + data.d[i].IndentNo + "');\">";
//                        else
//                            htmltbl += "<tr class='even gradeC' onclick=\"javascript:Set8110Object('" + data.d[i].IndentNo + "');\">";
//                        htmltbl += "<td>" + data.d[i].ProjectCode + "</td><td>" + data.d[i].CostCentreCode + "</td><td>" + data.d[i].UnitCode + "</td><td>" + data.d[i].ObjectType + "</td><td>" + data.d[i].LnNo + "</td><td>" + data.d[i].IndentNo + "</td><td>" + data.d[i].IndentDate + "</td></tr>";
//                    }
//                    htmltbl += "</tbody>";
//                    $("#dvIndentResult").html(htmltbl);
//                }
//                else {
//                    alert("No result found in database");
//                }
//            }
//            else {

//                alert("No result found in database");
//            }

//        },
//        error: function (result) {
//            alert("Error");
//        }
//    });
//}

//function SearchPo(PurchaseOrderMin, PurchaseOrderMax, MinDate, MaxDate, PartNo, DocumentNo, PartyCode, WarehouseCode, ProjectCode) {
//   // alert("{PurchaseOrderMin:'" + PurchaseOrderMin + "',PurchaseOrderMax:'" + PurchaseOrderMax + "',MinDate:'" + MinDate + "',MaxDate:'" + MaxDate + "',PartNo:'" + PartNo + "',DocumentNo:'" + DocumentNo + "',PartyCode:'" + PartyCode + "',WarehouseCode:'" + WarehouseCode + "',ProjectCode:'" + ProjectCode + "'}");
//    var htmltbl = "";
//    $("#dvPoData").html("");
//    $.ajax({
//        type: "POST",
//        contentType: "application/json; charset=utf-8",
//        url: "secure-service/Default.aspx/GetPoSearchResult",
//        data: "{PurchaseOrderMin:'" + PurchaseOrderMin + "',PurchaseOrderMax:'" + PurchaseOrderMax + "',MinDate:'" + MinDate + "', MaxDate:'" + MaxDate + "',PartNo:'" + PartNo + "',DocumentNo:'" + DocumentNo + "',PartyCode:'" + PartyCode + "',WarehouseCode:'" + WarehouseCode + "',ProjectCode:'" + ProjectCode + "'}",
//        success: function (data) {
//            if (data != null) {
//                if (data.d.length > 0) {
//                    for (var i = 0; i < data.d.length; i++) {
//                        if (i == 0) {
//                            htmltbl += "<table id='data-table' class='table table-striped table-bordered ' style='white-space: nowrap'><thead>";
//                            htmltbl += " <tr><th>Po Number</th><th>WH No</th>  <th>Warehouse Name</th> <th>Party Code</th> <th>Party Mat Cd</th> <th> Party Code Description</th> <th>Part No</th><th>Part Match Code</th><th>Part Short Name</th><th>Part Name</th><th>UOM</th></tr> </thead> <tbody>";

//                        }

//                        if (i % 2 == 0)
//                            htmltbl += "<tr class='odd gradeX' onclick=\"javascript:Set8110Object('" + data.d[i].PONumber + "');\">";
//                        else
//                            htmltbl += "<tr class='even gradeC' onclick=\"javascript:Set8110Object('" + data.d[i].PONumber + "');\">";
//                        htmltbl += "<td>" + data.d[i].PONumber + "</td><td>" + data.d[i].WHNumber + "</td><td>" + data.d[i].WHName + "</td><td>" + data.d[i].PartyCode + "</td><td>" + data.d[i].PartyMatCd + "</td><td>" + data.d[i].PartyCodeDescription + "</td><td>" + data.d[i].PartNo + "</td><td>" + data.d[i].PartMatchCode + "</td><td>" + data.d[i].PartShortName + "</td><td>" + data.d[i].PartName + "</td><td>" + data.d[i].UOM + "</td></tr>";
//                    }
//                    htmltbl += "</tbody>";
//                    $("#dvPoData").html(htmltbl);
//                }
//                else {
//                    alert("No result found in database");
//                }
//            }
//            else {

//                alert("No result found in database");
//            }

//        },
//        error: function (result) {
//            alert("Error");
//        }
//    });
//}

//function SearchPart(PartType, StructType, PartNoMin, PartNoMax, PartName, PartShortName, PartMatchCode, BaseUOM, IsActivePartOnly) {
//    // alert("{PurchaseOrderMin:'" + PurchaseOrderMin + "',PurchaseOrderMax:'" + PurchaseOrderMax + "',MinDate:'" + MinDate + "',MaxDate:'" + MaxDate + "',PartNo:'" + PartNo + "',DocumentNo:'" + DocumentNo + "',PartyCode:'" + PartyCode + "',WarehouseCode:'" + WarehouseCode + "',ProjectCode:'" + ProjectCode + "'}");
//    var htmltbl = "";
//    $("#dvPartResult").html("");
//    $.ajax({
//        type: "POST",
//        contentType: "application/json; charset=utf-8",
//        url: "secure-service/Default.aspx/GetPartSearchResult",
//        data: "{PartType:'" + PartType + "',StructType:'" + StructType + "',PartNoMin:'" + PartNoMin + "', PartNoMax:'" + PartNoMax + "',PartName:'" + PartName + "',PartShortName:'" + PartShortName + "',PartMatchCode:'" + PartMatchCode + "',BaseUOM:'" + BaseUOM + "',IsActivePartOnly:'" + IsActivePartOnly + "'}",
//        success: function (data) {
//            if (data != null) {
//                if (data.d.length > 0) {
//                    for (var i = 0; i < data.d.length; i++) {
//                        if (i == 0) {
//                            htmltbl += "<table id='data-table' class='table table-striped table-bordered ' style='white-space: nowrap'><thead>";
//                            htmltbl += " <tr><th>Part Type</th><th>Structure Type</th>  <th>Part No</th> <th>Part Match Code</th><th>Part Short Name</th><th>Part Name</th><th>UOM</th></tr> </thead> <tbody>";

//                        }
//                        if (i % 2 == 0)
//                            htmltbl += "<tr class='odd gradeX' onclick=\"javascript:Set8110PartDetails('" + data.d[i].PartNo + "','" + data.d[i].PartMatchCode + "','" + data.d[i].PartShortName + "','" + data.d[i].PartName + "');\">";
//                        else
//                            htmltbl += "<tr class='even gradeC' onclick=\"javascript:Set8110PartDetails('" + data.d[i].PartNo + "','" + data.d[i].PartMatchCode + "','" + data.d[i].PartShortName + "','" + data.d[i].PartName + "');\">";
//                        htmltbl += "<td>" + data.d[i].PartType + "</td><td>" + data.d[i].StructType + "</td><td>" + data.d[i].PartNo + "</td><td>" + data.d[i].PartMatchCode + "</td><td>" + data.d[i].PartShortName + "</td><td>" + data.d[i].PartName + "</td><td>" + data.d[i].UOM + "</td></tr>";
//                    }
//                    htmltbl += "</tbody>";
//                    $("#dvPartResult").html(htmltbl);
//                }
//                else {
//                    alert("No result found in database");
//                }
//            }
//            else {

//                alert("No result found in database");
//            }

//        },
//        error: function (result) {
//            alert("Error");
//        }
//    });
//}
function ResetPoSearchControl() {

    $("#dvIndentResult").html("");
    $("#txtObjectType").val("");
    $("#txtIndentNumber").val("");
    $("#txtFromIndentDate").val("");
    $("#txtToIndentDate").val("");
    $("#dvPoPaging").html("");
    $("#dvIndentPaging").html("");
    $("#dvPartPaging").html("");
    $("#ddlFromProjectCode option").each(function () {
        this.selected = $(this).text() == "--Select--";
    });
    $("#ddlToProjectCode option").each(function () {
        this.selected = $(this).text() == "--Select--";
    });
    $("#ddlFromCostCenterCode option").each(function () {
        this.selected = $(this).text() == "--Select--";
    });
    $("#ddlFromUnitCode option").each(function () {
        this.selected = $(this).text() == "--Select--";
    });
    $("#ddlToUnitCode option").each(function () {
        this.selected = $(this).text() == "--Select--";
    });
    $("#dvPoData").html("");
    $("#msgPoerror").hide();
    $("#msgIndenterror").hide();
    $("#txtFromPoNumber").val("");
    $("#txtToPoNumber").val("");
    $("#txtFromPoDate").val("");
    $("#txtToPoDate").val("");
    $("#txtReferenceDocumentNo").val("");
    $("#ddlPartNo option").each(function () {
        this.selected = $(this).text() == "--Select--";
    });
    $("#ddlPartyCode option").each(function () {
        this.selected = $(this).text() == "--Select--";
    });
    $("#ddlWarehouse option").each(function () {
        this.selected = $(this).text() == "--Select--";
    });
    $("#ddlProjectCode option").each(function () {
        this.selected = $(this).text() == "--Select--";
    });
    $("#dvPartResult").html("");
    $("#msgParterror").hide();
    $("#ddlPartType option").each(function () {
        this.selected = $(this).text() == "--Select--";
    });
    $("#ddlStructureType option").each(function () {
        this.selected = $(this).text() == "--Select--";
    });
    $("#ddlBaseUom option").each(function () {
        this.selected = $(this).text() == "--Select--";
    });
    $("#txtFromPartNo").val("");
    $("#txtToPartNo").val("");
    $("#txtPartName").val("");
    $("#txtPartShortName").val("");
    $("#txtPartMatchCode").val("");

    $(".search").trigger("chosen:updated");
}

//function SearchParty(Customer, Supplier, PartyMatchCode, PartyShortDescription, PartyCode, LegalStatus) {
//    // alert("{PurchaseOrderMin:'" + PurchaseOrderMin + "',PurchaseOrderMax:'" + PurchaseOrderMax + "',MinDate:'" + MinDate + "',MaxDate:'" + MaxDate + "',PartNo:'" + PartNo + "',DocumentNo:'" + DocumentNo + "',PartyCode:'" + PartyCode + "',WarehouseCode:'" + WarehouseCode + "',ProjectCode:'" + ProjectCode + "'}");
//    var htmltbl = "";
//    $("#dvPartyData").html("");
//    $.ajax({
//        type: "POST",
//        contentType: "application/json; charset=utf-8",
//        url: "secure-service/Default.aspx/GetPartySearchResult",
//        data: "{Customer:'" + Customer + "',Supplier:'" + Supplier + "', PartyMatchCode:'" + PartyMatchCode + "', PartyShortDescription:'" + PartyShortDescription + "',PartyCode:'" + PartyCode + "',LegalStatus:'" + LegalStatus + "'}",
//        success: function (data) {
//            if (data != null) {
//                if (data.d.length > 0) {
//                    for (var i = 0; i < data.d.length; i++) {
//                        if (i == 0) {
//                            htmltbl += "<table id='data-table' class='table table-striped table-bordered ' style='white-space: nowrap'><thead>";
//                            htmltbl += " <tr><th>Customer</th><th>Supplier</th>  <th>Party Match Code</th> <th>Party Code</th><th>Party Name</th><th>Party Short Description</th><th>Legal Status</th></tr> </thead> <tbody>";

//                        }
//                        if (i % 2 == 0)
//                            htmltbl += "<tr class='odd gradeX' onclick=\"javascript:Set8110PartyDetails('" + data.d[i].PartyCode + "','" + data.d[i].PartyMatchCode + "','" + data.d[i].PartyShortDescription + "');\">";
//                        else
//                            htmltbl += "<tr class='even gradeC' onclick=\"javascript:Set8110PartyDetails('" + data.d[i].PartyCode + "','" + data.d[i].PartyMatchCode + "','" + data.d[i].PartyShortDescription + "');\">";
//                        htmltbl += "<td>" + data.d[i].Customer + "</td><td>" + data.d[i].Supplier + "</td><td>" + data.d[i].PartyMatchCode + "</td><td>" + data.d[i].PartyCode + "</td><td>" + data.d[i].PartyName + "</td><td>" + data.d[i].PartyShortDescription + "</td><td>" + data.d[i].PartyLegalStatus + "</td></tr>";
//                    }
//                    htmltbl += "</tbody>";
//                    $("#dvPartyData").html(htmltbl);
//                }
//                else {
//                    alert("No result found in database");
//                }
//            }
//            else {

//                alert("No result found in database");
//            }

//        },
//        error: function (result) {
//            alert("Error");
//        }
//    });
//}

//function SearchTransporter(Customer, Supplier, PartyMatchCode, PartyShortDescription, PartyCode, LegalStatus) {
//    // alert("{PurchaseOrderMin:'" + PurchaseOrderMin + "',PurchaseOrderMax:'" + PurchaseOrderMax + "',MinDate:'" + MinDate + "',MaxDate:'" + MaxDate + "',PartNo:'" + PartNo + "',DocumentNo:'" + DocumentNo + "',PartyCode:'" + PartyCode + "',WarehouseCode:'" + WarehouseCode + "',ProjectCode:'" + ProjectCode + "'}");
//    var htmltbl = "";
//    $("#dvPartyData").html("");
//    $.ajax({
//        type: "POST",
//        contentType: "application/json; charset=utf-8",
//        url: "secure-service/Default.aspx/GetPartySearchResult",
//        data: "{Customer:'" + Customer + "',Supplier:'" + Supplier + "', PartyMatchCode:'" + PartyMatchCode + "', PartyShortDescription:'" + PartyShortDescription + "',PartyCode:'" + PartyCode + "',LegalStatus:'" + LegalStatus + "'}",
//        success: function (data) {
//            if (data != null) {
//                if (data.d.length > 0) {
//                    for (var i = 0; i < data.d.length; i++) {
//                        if (i == 0) {
//                            htmltbl += "<table id='data-table' class='table table-striped table-bordered ' style='white-space: nowrap'><thead>";
//                            htmltbl += " <tr><th>Customer</th><th>Supplier</th>  <th>Party Match Code</th> <th>Party Code</th><th>Party Name</th><th>Party Short Description</th><th>Legal Status</th></tr> </thead> <tbody>";

//                        }
//                        if (i % 2 == 0)
//                            htmltbl += "<tr class='odd gradeX' onclick=\"javascript:Set8110PartyDetails('" + data.d[i].PartyCode + "','" + data.d[i].PartyMatchCode + "','" + data.d[i].PartyShortDescription + "');\">";
//                        else
//                            htmltbl += "<tr class='even gradeC' onclick=\"javascript:Set8110PartyDetails('" + data.d[i].PartyCode + "','" + data.d[i].PartyMatchCode + "','" + data.d[i].PartyShortDescription + "');\">";
//                        htmltbl += "<td>" + data.d[i].Customer + "</td><td>" + data.d[i].Supplier + "</td><td>" + data.d[i].PartyMatchCode + "</td><td>" + data.d[i].PartyCode + "</td><td>" + data.d[i].PartyName + "</td><td>" + data.d[i].PartyShortDescription + "</td><td>" + data.d[i].PartyLegalStatus + "</td></tr>";
//                    }
//                    htmltbl += "</tbody>";
//                    $("#dvPartyData").html(htmltbl);
//                }
//                else {
//                    alert("No result found in database");
//                }
//            }
//            else {

//                alert("No result found in database");
//            }

//        },
//        error: function (result) {
//            alert("Error");
//        }
//    });
//}

function ResetPartSelectionControl() {
    $("#dvPartyData").html("");
    $("#txtPartyMatchCode").val("");
    $("#txtPartySDesc").val("");
    $("#ddlPartyName option").each(function () {
        this.selected = $(this).text() == "--Select--";
    });
    $("#ddlLegalStatus option").each(function () {
        this.selected = $(this).text() == "--Select--";
    });
    $("#chkCustomer").attr("checked", false);
    $("#chkSupplier").attr("checked", false);
}

function ResetTransportSelectionControl() {
    $("#txtTransportIDFrom").val("");
    $("#txtTransportIDFrom").val("");

    $("#dvSearchResult").html("");
    $("#txtValidFrom").val("");
    $("#txtValidTo").val(""),
    $("#txtVehiclePlateNo").val("")
    $("#ddlTransporterCodeFrom").val("0");
    $("#ddlTransporterCodeTo").val("0");
    $("#txtFromLocation").val("0");
    $("#txtToLocation").val("0");
    $("#ddlStatus").val("0");
}

function SetTransporter(number) {
    window.top.location.href = "TransporterAvailability.aspx?sgn=" + number;

}

//function SearchTransportAvailability(TransporterIDFrom,TransporterIDTo,TransporterCodeTo,TransporterCodeFrom, Fromdate, Todate,FromLoc,ToLoc, VechilePlateNumber, Status) {
//    var htmltbl = '';
//    $('#dvSearchResult').html('');
//    $.ajax({
//        type: "POST",
//        contentType: "application/json; charset=utf-8",
//        url: "secure-service/Default.aspx/GetTransportAvailabilitySearchDataResult",
//        data: "{TransporterIDFrom:'" + TransporterIDFrom + "',TransporterIDTo:'" + TransporterIDTo + "',TransporterCodeFrom:'" + TransporterCodeFrom + "',TransporterCodeTo:'" + TransporterCodeTo + "',Fromdate:'" + Fromdate + "',Todate:'" + Todate + "',FromLoc:'" + FromLoc + "',ToLoc:'" + ToLoc + "',VechilePlateNumber:'" + VechilePlateNumber + "',Status:'" + Status + "'}",
//        success: function (data) {
//            if (data != null) {
//                if (data.d.length > 0) {
//                    for (var i = 0; i < data.d.length; i++) {
//                        if (i == 0) {
//                            htmltbl += "<table id='data-table' class='table table-striped table-bordered ' style='white-space: nowrap'><thead>";
//                            htmltbl += "<tr><th>Transporter ID</th>  <th>Transporter Code</th> <th>From Date</th><th>To Date</th> <th>From Location</th><th>To Location</th><th>VechilePlateNumber</th><th>Status</th>  </tr> </thead> <tbody>";

//                        }
//                        if (i % 2 == 0)
//                            htmltbl += "<tr class='odd gradeX' onclick=\'javascript:SetTransporter(" + data.d[i].TransporterIDFrom + ");\'>";
//                        else
//                            htmltbl += "<tr class='even gradeC' onclick=\'javascript:SetTransporter(" + data.d[i].TransporterIDFrom + ");\'>";
//                        htmltbl += "<td>" + data.d[i].TransporterIDFrom + "</td><td>" + data.d[i].TransporterCodeFrom + "</td><td>" + data.d[i].Fromdate + "</td><td>" + data.d[i].Todate + "</td><td>" + data.d[i].FromLoc + "</td><td>" + data.d[i].ToLoc + "</td><td>" + data.d[i].VechilePlateNumber + "</td><td>" + data.d[i].Status + "</td></tr>";
//                    }
//                    htmltbl += "</tbody>";
//                    $('#dvSearchResult').html(htmltbl);
//                }
//                else {

//                    alert('Detailt not avilable in database.');
//                }
//            }

//        },
//        error: function (result) {
//            alert('Error');
//        }
//    });
//}



//function SetSO(number) {
//    window.top.location.href = "TransporterAvailability.aspx?sogn=" + number;
//}


// Search SO by ishoo
function SearchSONO(PONO, PartNO, PartyCode, OrderDate, DeliveryDate) {
    var htmltbl = '';
    $('#dvSearchResult').html('');
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "secure-service/Default.aspx/GetSOSearchDataResult",
        data: "{PONO:'" + PONO + "',PartNO:'" + PartNO + "',PartyCode:'" + PartyCode + "',OrderDate:'" + OrderDate + "',DeliveryDate:'" + DeliveryDate + "'}",
        success: function (data) {
            if (data != null) {
                if (data.d.length > 0) {
                    for (var i = 0; i < data.d.length; i++) {
                        if (i == 0) {
                            htmltbl += "<table id='data-table' class='table table-striped table-bordered ' style='white-space: nowrap'><thead>";
                            htmltbl += "<tr><th>SONO</th>  <th>PONO</th></tr> </thead> <tbody>";

                        }
                        if (i % 2 == 0)
                            htmltbl += "<tr class='odd gradeX' onclick=\'javascript:SetSO(\"" + data.d[i].SO + "\");\'>";
                        else
                            htmltbl += "<tr class='even gradeC' onclick=\'javascript:SetSO(" + data.d[i].SO + ");\'>";
                        htmltbl += "<td>" + data.d[i].SO + "</td><td>" + data.d[i].PONO + "</td></tr>";
                    }
                    htmltbl += "</tbody>";
                    $('#divSOSearchResult').html(htmltbl);
                }
                else {
                    alert('Detailt not avilable in database.');
                }
            }

        },
        error: function (result) {
            alert('Error');
        }
    });
}

function GetLineItem(SONO, LineNo, RowIndex, row) {
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "secure-service/Default.aspx/GetSOLineData",
        data: "{SONO:'" + SONO + "',LineNo:'" + LineNo + "'}",
        success: function (data) {
            if (data != null) {
                if (data.d.length > 0) {
                    for (var i = 0; i < data.d.length; i++) {
                        row.cells[3].getElementsByTagName("span")[0].innerText = data.d[i].SOQty;
                        row.cells[4].getElementsByTagName("span")[0].innerText = data.d[i].PendingQty;
                        row.cells[6].getElementsByTagName("span")[0].innerText = data.d[i].ProductCode;
                        row.cells[7].getElementsByTagName("span")[0].innerText = data.d[i].ProductDescription;
                        row.cells[8].getElementsByTagName("span")[0].innerText = data.d[i].SOUom;
                        row.cells[9].getElementsByTagName("span")[0].innerText = data.d[i].BsUOM;
                        row.cells[10].getElementsByTagName("span")[0].innerText = data.d[i].PartyCode;
                        row.cells[11].getElementsByTagName("span")[0].innerText = data.d[i].PartyName;
                    }
                }
            }
        },
        error: function (result) {
            alert('Error');
        }
    });
}



function SaveModuleAccessData(ModuleName,e) {
    //if (_isDirty == true) {
    //    var r = window.confirm("Are you sure! You want to exit the page ");
    //    if (r == true) {
            //$("#dvPanelRemove").click();
            $('#dvL').fadeIn(100);
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "secure-service/Default.aspx/SaveModuleAccessData",
                data: "{ModuleName:'" + ModuleName + "',IP:'" + IP + "'}",
                dataType: "json",
                success: function (data) {
                    //$('#dvL').fadeOut(100);
                },
                error: function (result) {
                    //$('#dvL').fadeOut(100);
                }
            });
        //}
        //else {
        //    e.preventDefault();
        //}
}


function ShowLoader() {
    $("#dvLoader").css("display", "block");
}

function HideLoader() {
    $("#dvLoader").css("display", "none");
}


function sortTable(n, id) {
    var table, rows, switching, i, x, y, shouldSwitch, dir, switchcount = 0;
    table = document.getElementById(id);
    switching = true;
    //Set the sorting direction to ascending:
    dir = "asc";
    /*Make a loop that will continue until
    no switching has been done:*/
    while (switching) {
        //start by saying: no switching is done:
        switching = false;
        rows = table.getElementsByTagName("TR");
        /*Loop through all table rows (except the
        first, which contains table headers):*/
        for (i = 1; i < (rows.length - 1) ; i++) {
            //start by saying there should be no switching:
            shouldSwitch = false;
            /*Get the two elements you want to compare,
            one from current row and one from the next:*/
            x = rows[i].getElementsByTagName("TD")[n];
            y = rows[i + 1].getElementsByTagName("TD")[n];
            /*check if the two rows should switch place,
            based on the direction, asc or desc:*/
            if (dir == "asc") {
                if (x.innerHTML.toLowerCase() > y.innerHTML.toLowerCase()) {
                    //if so, mark as a switch and break the loop:
                    shouldSwitch = true;
                    break;
                }
            } else if (dir == "desc") {
                if (x.innerHTML.toLowerCase() < y.innerHTML.toLowerCase()) {
                    //if so, mark as a switch and break the loop:
                    shouldSwitch = true;
                    break;
                }
            }
        }
        if (shouldSwitch) {
            /*If a switch has been marked, make the switch
            and mark that a switch has been done:*/
            rows[i].parentNode.insertBefore(rows[i + 1], rows[i]);
            switching = true;
            //Each time a switch is done, increase this count by 1:
            switchcount++;
        } else {
            /*If no switching has been done AND the direction is "asc",
            set the direction to "desc" and run the while loop again.*/
            if (switchcount == 0 && dir == "asc") {
                dir = "desc";
                switching = true;
            }
        }
    }

    function OnModalCloseClick() {
        //$("#poiFrame")[0].src = "";
        //$("#poiFrame")[0].src = $("#poiFrame")[0].src;
    }
}
