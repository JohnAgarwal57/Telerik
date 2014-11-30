define(['Q'], function (Q) {
	var httpRequest = (function () {
		var getJSON = function (url, contentType, acceptType) {
			var deferred = Q.defer();

			Q.stopUnhandledRejectionTracking();

			$.ajax({
				url: url,
				type: 'GET',
				contentType: contentType || '',
				acceptType: acceptType || '',
				success: function (data) {
					deferred.resolve(data);
				},
				error: function (err) {
					deferred.reject(err);
				}
			});

			return deferred.promise;
		};

		var postJSON = function (options) {
			var deferred = Q.defer(),
				type = 'PUT';

			if (options.message) {
				options.message = JSON.stringify(options.message);
				type = 'POST';
			}

			Q.stopUnhandledRejectionTracking();

			$.ajax({
				beforeSend: function (xhrObj) {
					xhrObj.setRequestHeader("x-sessionkey", options.sessionKey);
				},
				url: options.url,
				data: options.message,
				type: type,
				contentType: options.contentType,
				acceptType: options.acceptType,
				success: function (data) {
					deferred.resolve(data);
				},
				error: function (err) {
					deferred.reject(err);
				}
			});

			return deferred.promise;
		};

		return {
			getJSON: getJSON,
			postJSON: postJSON
		};
	}());

	return httpRequest;
});