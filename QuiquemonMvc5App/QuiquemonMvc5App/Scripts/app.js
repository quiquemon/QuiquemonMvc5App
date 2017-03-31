var App = (function() {
	var Util = (function() {
		function renderAlert(message, alertType, closable) {
			return "<div class='alert " + alertType + (closable ? " alert-dismissable" : "") + " fade in'>"
				+ (closable ? "<a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a>" : "")
				+ message + "<div>";
		}

		return {
			renderAlert: renderAlert
		};
	})();

	return {
		Util: Util
	};
})();