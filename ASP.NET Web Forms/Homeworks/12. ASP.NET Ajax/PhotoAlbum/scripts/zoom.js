(function () {
    $("#main").on("click", ".Image", function (ev) {
        var image = $("#img").attr("src");

        window.open(image, 'Popup', ' location=yes, width=1600, height=1200');
    });
})();