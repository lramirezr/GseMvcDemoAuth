
function activeNavLinkCSS(url) {
    $("nav ul.nav.masthead-nav li").find("a[href='" + url + "']").parent().addClass("active");
}

function deactiveNavLinkCSS(url) {
    $("nav ul.nav.masthead-nav li").find("a[href='" + url + "']").parent().removeClass("active");
}

function deactiveAllNavLinksCSS() {
    $.each($("nav ul.nav.masthead-nav li"), function (index, value) {
        $(value).removeClass("active");
    });
}

var setNavLink = function (e) {

    if (e.target.hash) {
        
        deactiveAllNavLinksCSS();

        var uri = "/Home/" + e.target.hash.split('#')[1];
        $.ajax({
            method: "GET",
            //contentType: 'application/html; charset=UTF-8',
            //dataType: 'html',
            url: uri,
            success: function (view) {
                $("#content").html(view);
                activeNavLinkCSS(location.hash);
            }
        });
    } else {
        location.href = location.origin;
    }
};

function createNavMenuLinks() {
    $.each($("nav ul.nav.masthead-nav li"), function (index, value) {
        value.addEventListener("click", setNavLink, false);
    });
}
/* MAIN */
$(document).ready(function () {
    createNavMenuLinks();
});