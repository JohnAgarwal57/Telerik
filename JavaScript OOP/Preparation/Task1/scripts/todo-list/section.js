define(['./item'], function(Item) {
  'use strict';
  var Section;

  Section = (function() {
    function Section(title) {
      if (typeof title !== 'string') {
                throw new Error('Section title must be string');
            }

      var items = [];

      this.add = function(item) {
        if (item instanceof Item) {
          items.push(item);
        }
        else {
          throw new Error('Error');
        }
      };

      this.getData = function() {
        var allData = {
          title : title,
          items : []
        };

        for (var i = 0, len = items.length; i < len; i++) {
          allData.items.push(items[i].getData());
        }

        return allData;
      };
    }

    return Section;
  }());

  return Section;
});