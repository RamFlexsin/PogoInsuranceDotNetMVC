$(document).ready(function () {
    debugger;
  
    //$("#contactDetails_Phone").change(function (e) {
       
    //    addPhoneMask.call(this, [3, 7], $(this).val());

    //});
    //$("#contactDetails_Email").change(function (e) {
    //    debugger;
    //    var CCNValue = $.trim($(this).val());
    //    //var arr = CCNValue.split('@');
    //    var length = CCNValue.length;
    //    var len = parseInt(length / 3);
    //    length = length - len;
    //    addMask.call(this, [4, length], $(this).val());
    //    //$(this).val(CCNValue.substring(0, 7) + CCNValue.substring(7, 15).replace(/\d/g, "*") + CCNValue.substring(15));
    //});
    $("#DIVDBA").hide();

});

$(function () {

    $("#IsUseDBAName").change(function () {

        debugger;
        var IsUseDBAName = $("input[name='IsUseDBAName']:checked").val();
        if (IsUseDBAName == true || IsUseDBAName == "true") {
            $("#DIVDBA").show();
        }
        else {
            $("#DIVDBA").hide();
        }
    });

});