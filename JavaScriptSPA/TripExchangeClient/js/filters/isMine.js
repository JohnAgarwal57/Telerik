'use strict';

app.filter('isMine', function() {
    return function(input) {
        switch (input) {
            case false: return "img/false.png";
                break;
            case true: return "img/true.png";
                break;
        }
    }
});