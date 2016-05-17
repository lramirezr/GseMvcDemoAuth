$("#frmLogin").submit(function (e) {
    var __hash__ = e.target.action.slice(e.target.action.indexOf('#'));

    var controller = (__hash__ === '#Login') ? '/Account' : '/Home';
    var action = '/' + __hash__.split('#')[1];

    var uri = controller + action;
    $.ajax({
        method: "POST",
        url: uri,
        data: $(e.target).serialize(),
        success: function (data, textStatus, jqXHR) {
            $("#content").html(data);
            // $("#content").html(view);
            activeNavLinkCSS(__hash__);
            $("#exampleModal").modal('hide');
        },
        error: function (jqXHR, textStatus, errorThrow) {
            $("#exampleModal").modal('hide');
        }
    });
    e.preventDefault();
});

var smbtLogin = function (e) {
    $("#exampleModal").modal('show');
    $("#frmLogin").submit();
};

$(document).ready(function () {

    document.getElementById('smbtLogin').addEventListener("click", smbtLogin, false);
});