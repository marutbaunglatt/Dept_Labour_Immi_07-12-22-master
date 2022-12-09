
function getOperation1(doeId) {
    var agency = $('#AgencyID');
    agency.val('');
    agency.empty().append('');
    $("#AgencyID").val('');
    textPermission();

    var thaiCompany = $('#ThaiCompanyID');
    thaiCompany.val('');
    thaiCompany.empty().append('');
    $("#ThaiCompanyID").val('');

    if (doeId != "") {
        doeId = parseInt(doeId);

        $.ajax({
            method: 'GET',
            url: "/Operation_2/GetDemandData/?doeId=" + doeId,
            dataType: "json",
            contentType: "application/json",
            success: function (data, textStatus, jqXHR) {
                if (data.data !== null) {

                    let applyDate = convertDateFormat(data.data.Apply_Date);
                    $("#Apply_Date").val(applyDate);
                    let crdate = convertDateFormat(data.data.DOEDate);
                    $("#Contract_Request_Date").val(crdate);
                    if (data.data.agency !== null) {
                        agency.append($("<option></option>").attr("value", data.data.agency.Id).text(data.data.agency.AgencyName));
                    }
                    if (data.thaiCompany !== null) {
                        thaiCompany.append($("<option></option>").attr("value", data.data.thaiCompany.ID).text(data.data.thaiCompany.CompanyName));
                    }
                    $("#Permit_Male_Worker").val(data.data.MaleWorkers);
                    $("#Permit_Female_Worker").val(data.data.FemaleWorkers);
                    $("#Permit_Total_Worker").val(data.data.TotalWorkers);
                    $("#WorkType").val(data.data.WorkType);
                }

                if (data.EC === null) {
                    $("#Remain_Male_Worker").val(data.data.MaleWorkers);
                    $("#Remain_Female_Worker").val(data.data.FemaleWorkers);
                    $("#Remain_Total_Worker").val(data.data.TotalWorkers);
                }
                else if (data.EC !== null) {
                    $("#Remain_Male_Worker").val(data.EC.Remain_Male_Worker);
                    $("#Remain_Female_Worker").val(data.EC.Remain_Female_Worker);
                    $("#Remain_Total_Worker").val(data.EC.Remain_Total_Worker);

                    if (data.EC.Remain_Male_Worker == 0) {
                        $("#Actual_Contract_Male_Worker").attr('disabled', true);
                    }
                    if (data.EC.Remain_Female_Worker == 0) {
                        $("#Actual_Contract_Female_Worker").attr('disabled', true);
                    }
                    if (data.EC.Remain_Male_Worker == 0 && data.EC.Remain_Female_Worker == 0) {
                        $("#saveEC").attr('disabled', true);
                        $("#saveEC").attr('style', 'cursor: not-allowed');
                    }
                }
                console.log(data);
            },
            error: function (jqXHR, textStatus, errorThrown) { }
        });
    }
};

function convertDateFormat(dateStr) {
    var convertDateTime = "";
    if (dateStr != null) {
        const d = new Date(dateStr);
        var day = ("0" + d.getDate()).slice(-2);
        var month = ("0" + (d.getMonth() + 1)).slice(-2);
        convertDateTime = d.getFullYear() + '-' + month + '-' + day;
    }
    return convertDateTime;
}

function textPermission() {
    $("#Request_Male_Worker").attr('disabled', false);
    $("#Request_Female_Worker").attr('disabled', false);
    $("#Request_Total_Workers").attr('disabled', false);
    $("#Contract_Granted_Date").attr('disabled', false);
    $("#Actual_Contract_Male_Worker").attr('disabled', false);
    $("#Actual_Contract_Female_Worker").attr('disabled', false);
    $("#Remark").attr('disabled', false);
    $("#saveEC").attr('disabled', false);
    //$("#saveEC").attr('style', 'cursor: not-allowed');
    $("#saveEC").attr('style', 'cursor: allowed');
}

function changeRMaleWorker(male) {
    $("#Actual_Contract_Total_Worker").val(0);

    if (male != "") {
        male = parseInt(male);
    }
    else {
        male = 0;
    }
    let female = $("#Actual_Contract_Female_Worker").val();
    if (female == "") {
        female = 0;
    }
    $("#Actual_Contract_Total_Worker").val(male + parseInt(female));

    var doe = $("#DOEID").val();

    if (doe == undefined || doe == "") {
        $("#acmWorker").text('User need to choose DOE No.');
    }
    else {
        $("#acmWorker").text('');
        let rMaleWorker = $("#Remain_Male_Worker").val();

        if (male > rMaleWorker) {
            $("#acmWorker").text('Actual Contract Male Worker must be equal or less than Remain Male Worker.');
        }
    }
};

function changeRFemaleWorker(female) {

    $("#Actual_Contract_Total_Worker").val(0);

    if (female != "") {
        female = parseInt(female);
    }
    else {
        female = 0;
    }
    let male = $("#Actual_Contract_Male_Worker").val();
    if (male == "") {
        male = 0;
    }
    $("#Actual_Contract_Total_Worker").val(female + parseInt(male));
    var doe = $("#DOEID").val();

    if (doe == undefined || doe == "") {
        $("#acfWorker").text('User need to choose DOE No.');
    }
    else {
        $("#acfWorker").text('');
        let rFemaleWorker = $("#Remain_Female_Worker").val();
        rFemaleWorker = parseInt(rFemaleWorker);

        if (female > rFemaleWorker) {
            $("#acfWorker").text('Actual Contract Female Worker must be equal or less than Remain Female Worker.');
        }
    }
};

$("#saveEC").click(function () {

    if ($('#ECForm').valid() != false) {

        var isSave = false;
        let female = $("#Actual_Contract_Female_Worker").val();
        let male = $("#Actual_Contract_Male_Worker").val();
        var totalWorker = $("#Actual_Contract_Total_Worker").val();
        let rmale = $("#Remain_Male_Worker").val();
        let rfemale = $("#Remain_Female_Worker").val();
        var remainTotal = $("#Remain_Total_Worker").val();
        $("#acmWorker").text('');
        $("#acfWorker").text('');


        if (rmale != 0 && (parseInt(male) > parseInt(rmale))) {
            $("#acmWorker").text('Actual Contract Male Worker must be equal or less than Remain Male Worker.');
            isSave = true;
        }
        if (rfemale != 0 && (parseInt(female) > parseInt(rfemale))) {
            $("#acfWorker").text('Actual Contract Female Worker must be equal or less than Remain Female Worker.');
            isSave = true;
        }
        var remainMWorker = rmale - male;
        var remainFWorker = rfemale - female;
        var remainTotalWorker = remainTotal - totalWorker;

        if (isSave) {
            return isSave;
        }
        else {
            var ecData = {
                DOEID: $("#DOEID").val(),
                Apply_Date: $("#Apply_Date").val(),
                Contract_Request_Date: $("#Contract_Request_Date").val(),
                AgencyID: $("#AgencyID").val(),
                ThaiCompanyID: $("#ThaiCompanyID").val(),
                WorkType: $("#WorkType").val(),
                Request_Male_Worker: $("#Request_Male_Worker").val(),
                Request_Female_Worker: $("#Request_Female_Worker").val(),
                Request_Total_Workers: $("#Request_Total_Workers").val(),
                Contract_Granted_Date: $("#Contract_Granted_Date").val(),
                Permit_Male_Worker: $("#Permit_Male_Worker").val(),
                Permit_Female_Worker: $("#Permit_Female_Worker").val(),
                Permit_Total_Worker: $("#Permit_Total_Worker").val(),
                Actual_Contract_Male_Worker: $("#Actual_Contract_Male_Worker").val(),
                Actual_Contract_Female_Worker: $("#Actual_Contract_Female_Worker").val(),
                Actual_Contract_Total_Worker: $("#Actual_Contract_Total_Worker").val(),
                Remain_Male_Worker: remainMWorker,
                Remain_Female_Worker: remainFWorker,
                Remain_Total_Worker: remainTotalWorker,
                Remark: $("#Remark").val()
            }

            var inputData = JSON.stringify(ecData);

            $.ajax({
                type: "POST",
                data: inputData,
                url: "/Operation_2/SaveEC",
                dataType: "json",
                data: inputData,
                contentType: "application/json",
                success: function (data, textStatus, jqXHR) {
                    if (data.status === "success") {
                        window.location.href = data.url;
                    }
                    console.log({ data });
                },
                error: function (jqXHR, textStatus, errorThrown) { }
            });
        }
    }
});

$("#updateEC").click(function () {

    if ($('#ECForm').valid() != false) {

        var isSave = false;
        let female = $("#Actual_Contract_Female_Worker").val();
        let male = $("#Actual_Contract_Male_Worker").val();
        var totalWorker = $("#Actual_Contract_Total_Worker").val();
        let rmale = $("#Remain_Male_Worker").val();
        let rfemale = $("#Remain_Female_Worker").val();
        var remainTotal = $("#Remain_Total_Worker").val();
        $("#acmWorker").text('');
        $("#acfWorker").text('');

        if (rmale != 0 && male > rmale) {
            $("#acmWorker").text('Actual Contract Male Worker must be equal or less than Remain Male Worker.');
            isSave = true;
        }
        if (rfemale != 0 && female > rfemale) {
            $("#acfWorker").text('Actual Contract Female Worker must be equal or less than Remain Female Worker.');
            isSave = true;
        }
        var remainMWorker = rmale - male;
        var remainFWorker = rfemale - female;
        var remainTotalWorker = remainTotal - totalWorker;
        if (isSave) {
            return isSave;
        }
        else {
            var ecData = {
                ID: $("#ID").val(),
                DOEID: $("#DOEID").val(),
                Apply_Date: $("#Apply_Date").val(),
                Contract_Request_Date: $("#Contract_Request_Date").val(),
                AgencyID: $("#AgencyID").val(),
                ThaiCompanyID: $("#ThaiCompanyID").val(),
                WorkType: $("#WorkType").val(),
                Request_Male_Worker: $("#Request_Male_Worker").val(),
                Request_Female_Worker: $("#Request_Female_Worker").val(),
                Request_Total_Workers: $("#Request_Total_Workers").val(),
                Contract_Granted_Date: $("#Contract_Granted_Date").val(),
                Permit_Male_Worker: $("#Permit_Male_Worker").val(),
                Permit_Female_Worker: $("#Permit_Female_Worker").val(),
                Permit_Total_Worker: $("#Permit_Total_Worker").val(),
                Actual_Contract_Male_Worker: $("#Actual_Contract_Male_Worker").val(),
                Actual_Contract_Female_Worker: $("#Actual_Contract_Female_Worker").val(),
                Actual_Contract_Total_Worker: $("#Actual_Contract_Total_Worker").val(),
                Remain_Male_Worker: remainMWorker,
                Remain_Female_Worker: remainFWorker,
                Remain_Total_Worker: remainTotalWorker,
                Remark: $("#Remark").val()
            }

            var inputData = JSON.stringify(ecData);

            $.ajax({
                type: "POST",
                data: inputData,
                url: "/Operation_2/UpdateEC",
                dataType: "json",
                data: inputData,
                contentType: "application/json",
                success: function (data, textStatus, jqXHR) {
                    if (data.status === "success") {
                        window.location.href = data.url;
                    }
                    console.log({ data });
                },
                error: function (jqXHR, textStatus, errorThrown) { }
            });
        }
    }
});






















































































































