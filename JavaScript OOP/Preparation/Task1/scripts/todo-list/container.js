define(['./section'], function (Section) {
	'use strict';
	var Container;
	
	Container = (function() {
		function Container() {
			var sections = [];

			this.add = function(section) {
				if (section instanceof Section) {
					sections.push(section);
				} else {
					throw new Error("Error");
				}
			};

			this.getData = function() {
				var allData = [];

				for (var i = 0, len = sections.length; i < len; i++) {
					allData.push(sections[i].getData());
				}

				return allData;
			};
		}

		return Container;
	}());

	return Container;
});