$.fn.tabs = function () {
	var $this = $(this),
		$contents = $('.tab-item-content'),
		$current = $this.children().first(),
		$titles = $('.tab-item-title').on('click', TabClick);

	$current.addClass('current');

	$this.addClass('tabs-container');
	$contents.hide();

	$current.children().show();

	function TabClick() {
		$('.current').removeClass('current');
		$contents.hide();
		$(this).parent().addClass('current');
		$(this).parent().children().show();
	}
	
};