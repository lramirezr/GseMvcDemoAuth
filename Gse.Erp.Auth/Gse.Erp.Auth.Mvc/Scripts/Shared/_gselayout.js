function createNavMenuLinks() {
    $.each($("nav ul.nav.masthead-nav li"), function (index, value) {
        value.addEventListener("click", setNavLink, false);
    });
}

var setNavLink = function (e) {
    var hash = (e.target.hash.split('#')[1] || '');
    if (hash !== '') {
        var uri = "/Home/" + hash; // $(this).find("a").attr("href");

        $.each($("nav ul.nav.masthead-nav li"), function (index, value) {
            $(value).removeClass("active");
        });

        $.ajax({
            method: "GET",
            //contentType: 'application/html; charset=UTF-8',
            //dataType: 'html',
            url: uri,
            success: function (view) {
                // $("div.inner.cover").html(view);
                $("#content").html(view);
                $("nav ul.nav.masthead-nav li").find("a[href='" + location.hash + "']").parent().addClass("active");
            }
        });
    } else {
        location.href = location.origin;
    }
};

$(document).ready(function () {
    createNavMenuLinks();
});