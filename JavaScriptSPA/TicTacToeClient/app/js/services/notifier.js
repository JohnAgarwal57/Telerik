ticTacToeApp.factory('notifier', ['toastr',
	function(toastr) {
		return {
			success: function success(msg) {
				toastr.success(msg);
			},
			error: function error(msg) {
				toastr.error(msg);
			}
		};
	}]);