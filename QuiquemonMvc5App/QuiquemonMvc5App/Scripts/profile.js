function renderErrors(errors) {
	for (var e in errors) {
		if (errors[e].length > 0) {
			var html = "<p class='text-danger'>" + errors[e][0] + "</p>";

			if (e !== "Newsletter")
				$("#" + e).parent().parent().addClass("has-error").append(html);
			else
				$("#" + e).parent().addClass("has-error").append(html);
		}
	}
}

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
			var html = App.Util.renderAlert(response.Message, "alert-success", true);
		} else {
			var html = App.Util.renderAlert("<b>Error</b> - " + response.Message, "alert-danger", true);
		}

		$("#logoBody").prepend(html);
	});
});

$("#btnEditPersonalInfo").click(function() {
	$("#personalInfoBody .alert").remove();
	$("div").removeClass("has-error");
	$(".text-danger").remove();
	var token = document.getElementsByName("__RequestVerificationToken")[0].value;
		
	$.post("/Account/EditPersonalInfo", {
		Name: $("#Name").val(),
		Lastname: $("#Lastname").val(),
		Birthday: $("#Birthday").val(),
		Email: $("#Email").val(),
		Newsletter: $("#Newsletter").val(),
		__RequestVerificationToken: token
	}, function(response) {
		if (response.Success) {
			var html = App.Util.renderAlert(response.Message, "alert-success", true);
			$("#personalInfoBody").prepend(html);
			$("#profileName").text("Mi Perfil: " + response.Value);
		} else {
			renderErrors(response.Value);
		}
	});
});