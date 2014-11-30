define(['jquery', 'logic'], function ($, logic) {
	var postMessage = function() {
		var username = localStorage.getItem("CrowdChatUserName");
			
		var	message = {
				user : username,
				text : $('#messageBox').val()
			};
		
		logic.postMessage(message);
		$('messageBox').val(' ');
	};

	$("a").on("click", function(){
		$('.active').removeClass('active');
		$(this).parent().addClass('active');
	});

	$(document).on("click", "#sendButton", function(){
		postMessage();
	});

	$(document).on("click", "#confirmButton", function(){
		localStorage.setItem("CrowdChatUserName", $('#nickNameBox').val());
		$('#nickNameBox').val(' ');
	});

	$(document).on("keyup", "#messageBox", function(){
		if(event.keyCode == 13){
			postMessage();
		}
	});
});