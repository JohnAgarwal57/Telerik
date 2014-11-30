define(['jquery', 'handlebars', 'kendo'], function ($) {
	var initMainPage = function() {
		clearPage();

		var h2 = $('<h2></h2>').text('Crowd chat'),
			div = $('<div> </div>').attr('id', 'nickname-containter').addClass('nickname-containter'),
			label =$('<label></label>')
				.text('Select nickname:'),
			nickName = $('<input type="text" />')
				.attr('id', 'nickNameBox')
				.addClass('nickNameBox')
				.height('29px')
				.width('30%')
				.kendoMaskedTextBox(),
			confirmButton = $('<button> </button>')
					.attr('id', 'confirmButton')
					.addClass('k-primary')
					.height('29px')
					.width('10%')
					.text('Confirm')
					.kendoButton();
		
		div.append(label).append(nickName).append(confirmButton);
		$('#main-content').append(div);

		setActive($('#homeLink'));
	},
	initChatPage = function(chatItems) {
		clearPage();

		var username = localStorage.getItem('CrowdChatUserName');

		if (username) {
			addChatArea();
			setMessageFeed(chatItems);
			$('#messageBox').focus();
			setActive($('#chatLink'));
		}
		else {
			$('#main-content').text('Please choose nickname on home page!');
		}
	},
	initAboutPage = function() {
		clearPage();

		var h2 = $('<h2></h2>').text('Crowd chat SPA develop by ME :)');
		$('#main-content').append(h2);
		setActive($('#aboutLink'));
	},
	clearPage = function() {
		$('#main-content').text(' ');
	},
	showError = function(err) {
		$('#main-content').text(err.responseText);
	},
	setMessageFeed = function(items) {
		$('feed-container').html(' ');
		var chatItems = [],
			div = $('<div> </div>').attr('id', 'feed-container').addClass('feed-container');

		items.reverse();
		items.forEach(function(item) {
			var newText,
				newBy;

			newText = item.text.replace(/&nbsp;/gi, ' ').replace(/&#39/g, "'");
			newBy = item.by.replace(/&nbsp;/gi, ' ').replace(/&#39/g, "'");

			chatItems.push({text : newText, by : newBy});
		});

		$('#main-content').append(div);

		handleBarConvert($("#chat-template"), $('#feed-container'),chatItems);
	},
	handleBarConvert = function (template, container, items) {
		var currentTemplate = Handlebars.compile(template.html());

		container.html(currentTemplate({
			message : items
		}));
	},
	addChatArea = function() {
		var div = $('<div> </div>')
					.attr('id', 'chat-area')
					.addClass('chat-area'),
			sendButton = $('<button> </button>')
					.attr('id', 'sendButton')
					.addClass('k-primary')
					.height('29px')
					.width('10%')
					.text('Send')
					.kendoButton();
			messageBox = $('<input type="text" />')
					.attr('id', 'messageBox')
					.addClass('messageBox')
					.height('29px')
					.width('89%')
					.kendoMaskedTextBox();
		
		div.append(messageBox);
		div.append(sendButton);
		$('#main-content').append(div);
	},
	setActive = function(selector) {
		$('.active').removeClass('active');
		selector.addClass('active');
	};

	return {
		initMainPage: initMainPage,
		initChatPage: initChatPage,
		initAboutPage: initAboutPage,
		showError: showError,
		setMessageFeed: setMessageFeed
	};
});