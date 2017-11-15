
function openNav() {

    document.getElementById("mySidenav").style.width = "20%";
    document.body.style.backgroundColor = "rgba(0,0,0,0.0)";

}

$(document).click(function (e) {

    if (!$(e.target).is('mySidenav')) {
        $('.collapse').collapse('hide');
    }

});



function closeNav() {

        var btn = document.getElementById("closebtn");
        var barra = document.getElementById("mySidenav").style.width = "0px";

    }



