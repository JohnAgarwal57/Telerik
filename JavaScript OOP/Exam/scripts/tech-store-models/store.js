define(['./item'],function (Item) {
	'use strict';
	var Store = (function() {
		function Store(name) {
			if (6 < name.length || name.length < 30) {
				this.name = name;
			}
			else {
				throw new Error('Name must be between 6 and 30 characters');
			}

			this._items = [];
		}

		Store.prototype.addItem = function(item) {
			if (item instanceof Item) {
				this._items.push(item);
			}

			return this;
		};

		Store.prototype.getAll = function() {
			var sortedItems = this._items.sort(sortItemsByName);

			return sortedItems;
		};

		Store.prototype.getSmartPhones = function() {
			return filterItemsByType(this._items, 'smart-phone').sort(sortItemsByName);
		};

		Store.prototype.getMobiles = function() {
			var smartPhones = filterItemsByType(this._items, 'smart-phone'),
				tablets = filterItemsByType(this._items, 'tablet'),
				mobiles = smartPhones.concat(tablets);

			return mobiles.sort(sortItemsByName);
		};

		Store.prototype.getComputers = function() {
			var pcs = filterItemsByType(this._items, 'pc'),
				notebooks = filterItemsByType(this._items, 'notebook'),
				computers = pcs.concat(notebooks);

			return computers.sort(sortItemsByName);
		};

		Store.prototype.filterItemsByType = function(type) {
			var filteredItems = filterItemsByType(this._items, type);

			return filteredItems.sort(sortItemsByName);
		};

		Store.prototype.filterItemsByPrice  = function(prices) {
			var min, max;
			if (prices === undefined) {
				min = 0;
				max = Number.POSITIVE_INFINITY;
			}
			else {
				min = prices.min | 0;
				max = prices.max;

				// max = prices.max | Number.POSITIVE_INFINITY not working....
				if (max === undefined) {
					max = Number.POSITIVE_INFINITY;
				}
			}

			var filteredItems = filterItemsByPrice(this._items, min, max);

			return filteredItems.sort(sortItemsByPrice);
		};

		Store.prototype.countItemsByType = function(type) {
			var itemsByType = {},
				allItems = this._items;

			for (var i = 0, len = allItems.length; i < len; i++) {
				if (allItems[i].type in itemsByType) {
					itemsByType[allItems[i].type]++;
				}
				else {
					itemsByType[allItems[i].type] = 1;
				}
			}

			return itemsByType;
		};

		Store.prototype.filterItemsByName = function(namePart) {
			var partOfName = namePart.toLowerCase(),
				allItems = this._items,
				foundItems = [];

			for (var i = 0, len = allItems.length; i < len; i++) {
				if (allItems[i].name.toLowerCase().indexOf(partOfName) > -1) {
					foundItems.push(allItems[i]);
				}
			}
			
			return foundItems;
			
		};

		function sortItemsByName(current, next) {
			var textCurrent = current.name.toUpperCase(),
				textNext = next.name.toUpperCase();

			return (textCurrent < textNext) ? -1 : (textCurrent > textNext) ? 1 : 0;
		}

		function sortItemsByPrice(current, next) {
			return current.price - next.price;
		}

		function filterItemsByType(items, type) {
			var filterItems = items.filter(function(item) {
				return item.type === type;
			});

			return filterItems;
		}

		function filterItemsByPrice(items, min, max) {
			var filterItems = items.filter(function(item) {
				return item.price >= min && item.price <= max;
			});

			return filterItems;
		}

		return Store;
	}());

	return Store;
});