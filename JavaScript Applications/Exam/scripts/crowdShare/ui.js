define(['jquery', 'handlebars', 'kendo'], function ($) {
	var START_MENU_SIZE = 300,
		consts = {
			$mainContent: $("#main-content")
		};

	var initHomePage = function() {
		var username = localStorage.getItem('crowdShareUserName');
		
		initPage('#menu', $('#menu-container'));

		consts.$mainContent.load('home.html', function() {
			if (username && username !=='' && username !=='null') {
				$('#logout').text('Welcome: ' + username + ' (Logout)');
			}
		});
	};

	var initLoginPage = function () {
		initPage('#menu', $('#menu-container'));

		consts.$mainContent.load('login.html', function() {
			$('#login-nickname').kendoMaskedTextBox();
			$('#login-password').kendoMaskedTextBox();
			$('#login-button').kendoButton();
			$('#login-nickname').focus();
		});
	};

	var initRegisterPage = function() {
		initPage('#menu', $('#menu-container'));

		consts.$mainContent.load('register.html', function() {
			$('#register-nickname').kendoMaskedTextBox();
			$('#register-password').kendoMaskedTextBox();
			$('#repeat-register-password').kendoMaskedTextBox();
			$('#register-button').kendoButton();
			$('#register-nickname').focus();
		});
	};

	var initCreatePostPage = function(chatItems) {
		initPage('#menu', $('#menu-container'));

		consts.$mainContent.load('createPost.html', function() {
			$('#createpost-title').kendoMaskedTextBox();
			$('#createpost-body').kendoMaskedTextBox();
			$('#post-button').kendoButton();
			$('#createpost-title').focus();
		});
	};

	var initGetPostsPage = function(chatItems) {
		initPage('#menu', $('#menu-container'));

		consts.$mainContent.load('getPosts.html', function() {
			$('#getmessages-button').kendoButton();
			$('#search-title-body').kendoMaskedTextBox();
			$('#search-user').kendoMaskedTextBox();
			$('#posts-count').kendoMaskedTextBox();
			$('#search-user').focus();
		});
	};

	var showError = function(err) {
		consts.$mainContent.text(err.responseText);
	};

	var initPage = function (menu, container) {
		container.load('menu.html', function() {
			$(menu).kendoMenu();
		});

		consts.$mainContent.text(' ');
	};

	function drawKendoGrid(items, postsCount) {
		$('#grid').kendoGrid({
			dataSource: {
				data : items,
				pageSize: postsCount|0 || 10
			},
			height: window.innerHeight - START_MENU_SIZE,
			groupable: true,
			sortable: true,
			filterable: true,
			pageable: {
				refresh: true,
				pageSizes: true,
				buttonCount: 5
			},
			columns:	[	{ field: "user.username", title: "User" },
							{ field: "postDate", title: "Date"},
							{ field: "title", title: "Title"},
							{ field: "body", title: "Body"},
						]
		});

	}

	return {
		initHomePage: initHomePage,
		initLoginPage: initLoginPage,
		initRegisterPage: initRegisterPage,
		initCreatePostPage: initCreatePostPage,
		initGetPostsPage: initGetPostsPage,
		showError: showError,
		drawKendoGrid: drawKendoGrid
	};
});