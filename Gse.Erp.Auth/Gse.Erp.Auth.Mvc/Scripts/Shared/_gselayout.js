
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

        $("#exampleModal").modal('show');

        deactiveAllNavLinksCSS();

        var controller = (e.target.hash === '#Login') ? '/Account' : '/Home';
        var action = '/' + e.target.hash.split('#')[1];

        var uri = controller + action;
        $.ajax({
            method: "GET",
            //contentType: 'application/html; charset=UTF-8',
            //dataType: 'html',
            url: uri,
            success: function (view) {
                $("#content").html(view);
                activeNavLinkCSS(location.hash);

                $("#exampleModal").modal('hide');
            },
            error: function () {
                $("#exampleModal").modal('hide');
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

    //// alert(location.hash);
    //if (location.hash === '#Login')
    //{
    //    deactiveAllNavLinksCSS();

    //    var controller = "/Account";
    //    var action = '/' + location.hash.split('#')[1];

    //    var uri = controller + action;
    //    $.ajax({
    //        method: "GET",
    //        url: uri,
    //        success: function (view) {
    //            $("#content").html(view);
    //            activeNavLinkCSS(location.hash);
    //        }
    //    });
    //}
    createNavMenuLinks();
});