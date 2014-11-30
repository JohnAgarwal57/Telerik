define(['httpRequest', "ui"], function (httpRequest, ui) {
	var dataLength,
		currentPage,
		url = 'http://crowd-chat.herokuapp.com/posts',
		contentType = 'application/json',
		acceptType = 'application/json',
		initMainPage = function() {
			ui.initMainPage();
			currentPage = "main";
		},
		initChatPage = function() {
			getChatFeed();
			currentPage = "chat";
		},
		initAboutPage = function() {
			ui.initAboutPage();
			currentPage = "about";
		},
		postMessage = function(message) {
			httpRequest.postJSON(url, contentType, acceptType, message)
				.then(getChatFeed())
				.then(getChatFeed());
		},
		getChatFeed = function() {
			httpRequest.getJSON(url, contentType, acceptType)
				.then(function (data) {
						dataLength = data.length;
						ui.initChatPage(data);
					}, function (err) {
						ui.showError(err);
					}
				);
		},
		refresh = setInterval(function() {
			httpRequest.getJSON(url, contentType, acceptType)
				.then(function (data) {
						if (dataLength !== data.length && currentPage === 'chat') {
							ui.setMessageFeed(data);
						}
						dataLength = data.length;
					}, function (err) {
						ui.showError(err);
					}
				);
		}, 1000);

	return {
		initMainPage: initMainPage,
		initChatPage: initChatPage,
		initAboutPage: initAboutPage,
		postMessage: postMessage
	};
});