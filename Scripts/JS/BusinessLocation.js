////$(function () {

////    $("input[name *= 'PrimaryState']").change(function () {

////        debugger;
////        var StateValue = $('select[name="PrimaryState"] option:selected').val();
////        if (StateValue == null || StateValue == "undefined" || StateValue == "") {
////            alert('Please select State.');
////            return false;
////        }
       
////    });

////});

$(document).on("click", ".nextBtn", function () {
    debugger;
    var StateValue = $('select[name="PrimaryState"] option:selected').val();
    if (StateValue == null || StateValue == "undefined" || StateValue == "") {
        alert('Please select State.');
        return false;
    }
});