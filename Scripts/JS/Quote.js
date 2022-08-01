$(function () {

    $("input[name *= 'SelectedCompensation']").change(function () {

        debugger;
        var haveFEIN = $("input[name='SelectedCompensation']:checked").val();
        var titleId = "#spn_" + haveFEIN;
        var AmtId = "#Div_" + haveFEIN;
        var title = $(titleId).text();
        var Amt = $(AmtId).html();

        $("#spnProduct").text(title);
        $("#spnProductAmt").html(Amt);
    });

});