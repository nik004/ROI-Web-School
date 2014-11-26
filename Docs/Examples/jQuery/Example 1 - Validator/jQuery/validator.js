$(function () {
    $("#validate").click(function () {
		$(".required").each(function(){
			$(this).toggleClass(function() {
				return $("input", this).val() == "" ? "invalid" : "";
			});
		});
    });
});
