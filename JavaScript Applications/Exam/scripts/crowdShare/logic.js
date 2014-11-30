define(['httpRequest', "ui", "underscore", "cryptojs", "sha1"], function (httpRequest, ui) {
	var url = 'http://jsapps.bgcoder.com/', /*'http://localhost:3000/',*/
		contentType = 'application/json',
		acceptType = 'application/json',
		consts = {
			localStorageUserName: 'crowdShareUserName',
			localStorageSessionKey: 'crowdShareSessionKey',
			successRegisterMessage: 'You have been registered. Now you may login.',
			asc: 'asc',
			message: {
				"username": username,
				"authCode": authCode
			}
		};

	var navigateTo = function (location) {
		window.location.hash = location;
	};

	var login = function (username, password) {
		var authCode,
			options;

		authCode = CryptoJS.SHA1(username + password).toString();

		options = {
			url: url + 'auth',
			contentType: contentType,
			acceptType: acceptType,
			message: consts.message,
		};

		httpRequest.postJSON(options)
			.then(function (success) {
				localStorage.setItem(consts.localStorageUserName, username);
				localStorage.setItem(consts.localStorageSessionKey, success.sessionKey);

				navigateTo('#/');
			})
			.then(null, function (err) {
				alert(JSON.parse(err.responseText).message);
			});
	};

	var logout = function () {
		var sessionKey = localStorage.getItem(consts.localStorageSessionKey),
			options = {
				url: url + 'user',
				contentType: contentType,
				acceptType: acceptType,
				message: consts.message,
				sessionKey: sessionKey
			};


		httpRequest.postJSON(options)
			.then(function (success) {
				localStorage.setItem(consts.localStorageUserName, '');
				localStorage.setItem(consts.localStorageSessionKey, '');

				navigateTo('#/');
			})
			.then(null, function (err) {
				alert(JSON.parse(err.responseText).message);
			});
	};

	var registerAccount = function (username, password) {
		var authCode = username + password,
			options;

		authCode = CryptoJS.SHA1(authCode).toString();

		options = {
			url: url + 'user',
			contentType: contentType,
			acceptType: acceptType,
			message: consts.message,
		};

		httpRequest.postJSON(options)
			.then(function (success) {
				$('#register-nickname').val(' ');
				$('#register-password').val(' ');
				$('#repeat-register-password').val(' ');

				alert(consts.successRegisterMessage);

				window.location.hash = '#/';
			})
			.then(null, function (err) {
				alert(JSON.parse(err.responseText).message);
			});
	};

	var postMessage = function (title, body) {
		var sessionKey = localStorage.getItem(consts.localStorageSessionKey),
			options = {
				url: url + 'post',
				contentType: contentType,
				acceptType: acceptType,
				message: {
					"title": title,
					"body": body
				},
				key: sessionKey
			};

		httpRequest.postJSON(options)
			.then(function (success) {
				$('#createpost-title').val(' ');
				$('#createpost-body').val(' ');
				alert('Message post!');
			})
			.then(null, function (err) {
				alert(JSON.parse(err.responseText).message);
				window.location.hash = '#/login';
			});
	};

	var getMessages = function (searchUser, searchTitleBody, postsCount) {
		var searchURL,
			searchURLUser = '',
			searchURLTitleBody = '';

		if (searchUser) {
			searchURLUser = '?user=' + searchUser;
		}

		if (searchTitleBody) {
			searchURLTitleBody = '?pattern=' + searchTitleBody;
		}

		searchURL = url + 'post' + searchURLTitleBody + searchURLUser;


		httpRequest.getJSON(searchURL, contentType, acceptType)
			.then(function (data) {
				ui.drawKendoGrid(data, postsCount);
			}, function (err) {
				alert(JSON.parse(err.responseText).message);
			}
			);
	};

	var orderData = function (by, dir, data) {
		var orderedData = _.chain(data)
			.sortBy(function (post) {
				return post[by];
			})
			.value();

		if (dir !== consts.asc) {
			orderedData = orderedData.reverse();
		}

		return orderedData;
	};

	return {
		postMessage: postMessage,
		login: login,
		logout: logout,
		registerAccount: registerAccount,
		getMessages: getMessages,
		orderData: orderData
	};
});