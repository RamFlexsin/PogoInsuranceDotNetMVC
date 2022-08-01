$(document).ready(function () {
    debugger;
    $("#DIVHaveFEIN").hide();
    $("#DIVSSN").hide();

});

$(function () {

    $("input[name *= 'HaveFEIN']").change(function () {

        debugger;
        var haveFEIN = $("input[name='HaveFEIN']:checked").val();
        //$("input[name *= 'HaveFEIN']").val();
        if (haveFEIN == "Yes") {
            $("#DIVHaveFEIN").show();
            $("#DIVSSN").hide();
        }
        if (haveFEIN == "No") {
            $("#DIVHaveFEIN").hide();
            $("#DIVSSN").show();
        }
    });

});