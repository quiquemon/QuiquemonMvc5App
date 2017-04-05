function renderErrors(errors) {
	for (var e in errors) {
		if (errors[e] != null) {
			var html = "<p class='text-danger'>" + errors[e] + "</p>";
			
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
	var button = $(this);
	var token = document.getElementsByName("__RequestVerificationToken")[0].value;

	$("#personalInfoBody .alert").remove();
	$("#personalInfoBody div").removeClass("has-error");
	$("#personalInfoBody .text-danger").remove();
	button.prop("disabled", true);
		
	$.post("/Account/EditPersonalInfo", {
		Name: $("#Name").val(),
		Lastname: $("#Lastname").val(),
		Birthday: $("#Birthday").val(),
		Email: $("#Email").val(),
		Newsletter: $("#Newsletter").val(),
		__RequestVerificationToken: token
	}, function(response) {
		button.prop("disabled", false);

		if (response.Success) {
			var html = App.Util.renderAlert(response.Message, "alert-success", true);
			$("#personalInfoBody").prepend(html);
			$("#profileName").text("Mi Perfil: " + response.Value);
		} else {
			renderErrors(response.Value);
		}
	});
});

$("#btnEditPassword").click(function() {
	var button = $(this);
	var token = document.getElementsByName("__RequestVerificationToken")[0].value;

	$("#passwordBody .alert").remove();
	$("#passwordBody div").removeClass("has-error");
	$("#passwordBody .text-danger").remove();
	button.prop("disabled", true);

	$.post("/Account/EditPassword", {
		OldPassword: $("#OldPassword").val(),
		NewPassword: $("#NewPassword").val(),
		__RequestVerificationToken: token
	}, function(response) {
		button.prop("disabled", false);

		if (response.Success) {
			var html = App.Util.renderAlert(response.Message, "alert-success", true);
			$("#passwordBody").prepend(html);
		} else {
			renderErrors(response.Value);
		}
	});
});