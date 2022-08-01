
function addPhoneMask(range, value) {
    $(this).val(value.substring(0, range[0])
        + value.substring(range[0], range[1]).replace(/[0-9]/g, "*")
        + value.substring(range[1]));
}
function addMask(range, value) {
    $(this).val(value.substring(0, range[0])
        + value.substring(range[0], range[1]).replace(/[0-9 a-z A-Z]/g, "*")
        + value.substring(range[1]));
}
function addSpace(spacePoints, value) {
    for (var i = 0; i < spacePoints.length; i++) {
        var point = spacePoints[i];
        if (value.length > point && value.charAt(point) !== ' ')
            $(this).val((value.substr(0, point) + " "
                + value.substr(point, value.length)));
    }
}
function decrease(id) {
    debugger;
    var value = $(id).val();
    //$(this).parent().find('[data-val]').val();
    if (value > 1) {
        value--;
        $(id).val(value);
        //$(this).parent().find('[data-val]').val(value);
    }
}

function increase(id) {
    debugger;
    var value = $(id).val();
        //$(this).parent().find('[data-val]').val();
    if (value < 100) {
        value++;
        $(id).val(value);
        //$(this).parent().find('[data-val]').val(value);
    }
}
$(function () {
    //$("#cardnum").keyup(function (e) {
    //    var cardNo = $(this).val();
    //    //Add the indices where you need a space
    //    addSpace.call(this, [4, 9, 14], cardNo);
    //    //Enter any valid range to add mask character.
    //    addMask.call(this, [7, 15], $(this).val()); //Pick the changed value to add mask 
    //});
});

