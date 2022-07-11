$(function() {
	$('[data-decrease]').click(decrease);
	$('[data-increase]').click(increase);
	$('[data-val]').change(valueChange);
});

function decrease() {
	var value = $(this).parent().find('[data-val]').val();
	if(value > 1) {
		value--;
		$(this).parent().find('[data-val]').val(value);
	}
}

function increase() {
	var value = $(this).parent().find('[data-val]').val();
	if(value < 100) {
		value++;
		$(this).parent().find('[data-val]').val(value);
	}
}

function valueChange() {
	var value = $(this).val();
	if(value == undefined || isNaN(value) == true || value <= 0) {
		$(this).val(1);
	} else if(value >= 101) {
		$(this).val(100);
	}
}
