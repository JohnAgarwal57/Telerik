define(function() {
	'use strict';
	var Item = (function() {
		function Item(type, name, price) {
			var types = [
					'accessory',
					'smart-phone',
					'notebook',
					'pc',
					'tablet'
				];

			if (6 < name.length || name.length < 30) {
				this.name = name;
			} else {
				throw new Error('Name must be between 6 and 30 characters');
			}

			if (types.indexOf(type) !== -1) {
				this.type = type;
			} else {
				throw new Error('Incorect type');
			}
			
			if (isFinite(price)) {
				this.price = price;
			} else {
				throw new Error('Price must be numeric');
			}
		}
	
		return Item;
	})();

	return Item;
});