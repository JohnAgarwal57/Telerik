define(function() {
  'use strict';
  var Item;
  Item = (function() {
    function Item(content) {
      this.getData = function() {
        return {
          content : content,
        };
      };
    }
	
    return Item;
  })();
  return Item;
});