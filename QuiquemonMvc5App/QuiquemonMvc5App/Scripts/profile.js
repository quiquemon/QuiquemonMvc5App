$(".date").datetimepicker({
	locale: "es",
	format: "YYYY-MM-DD",
	maxDate: new Date(),
	allowInputToggle: true,
	ignoreReadonly: true
});

$("#Birthday").val(birthday);

$("#Logo").change(function() {
	document.getElementById("logoPreview").className = $(this).val();
});

$("#btnChangeLogo").click(function() {
	$("#logoBody .alert").remove();
	var token = document.getElementsByName("__RequestVerificationToken")[0].value;

	$.post("/Account/EditLogo", {
		name: $("#Logo").val(),
		__RequestVerificationToken: token
	}, function(response) {
		if (response.Success) {
			document.getElementById("profileLogo").className = response.Value;
			var html = App.Util.renderAlert(response.Message, "alert-info", true);
		} else {
			var html = App.Util.renderAlert("<b>Error</b> - " + response.Message, "alert-danger", true);
		}

		$("#logoBody").prepend(html);
	});
});

$("#btnEditPersonalInfo").click(function() {
	$("#personalInfoBody").remove();
	var token = document.getElementsByName("__RequestVerificationToken")[0].value;
		
	BootstrapDialog.show({
		title: "Mensaje de prueba",
		message: "<b>Token:</b> " + token,
		size: BootstrapDialog.SIZE_WIDE
	});
});