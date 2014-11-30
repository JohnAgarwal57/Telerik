app.filter('isMine', function() {
	'use strict';

    return function(input) {
        switch (input) {
            case false: return "img/false.png";
            case true: return "img/true.png";
        }
    };
});