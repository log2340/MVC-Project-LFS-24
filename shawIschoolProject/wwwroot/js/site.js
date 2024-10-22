// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

const proxyServer = "https://people.rit.edu/~dsbics/proxy/https://ischool.gccis.rit.edu/api/";

//uses ajax to get course data based on name passed in
function getAjax(courseName) {
    $.ajax({
        type: 'get',
        url: proxyServer + "course/courseID=" + courseName,
        dataType: 'json',
        data: {},
        cache: false,
        async: true,
        beforeSend: function () {
            //turn on spinner or some such thing
        }
    }).always(function () {
        //kill spinner or cleanup
    }).fail(function () {
        //handle failure
    }).done(function (msg) {
        //fills container with data grabbed from ajax
        $('#courseInfoContainer').html("<h2>" + msg.courseID + "</h2><h2>" + msg.title + "</h2><h4>" + msg.description + "</h4>");
       // turns container into dialog and opens it
        $('#courseInfoContainer').dialog({ autoOpen: true, dialogClass: "close", width: 800 });

    });
}
// Write your JavaScript code.


//make sure document is ready
$(function () {
    $('#pepTabs').tabs();
    $('#degreeTabs').tabs();
    $('#tableTabs').tabs();
    $('.minorAcc').accordion({
        collapsible: true,
        heightStyle: "content",
        active: false
    });
    $('.concAcc').accordion({
        collapsible: true,
        heightStyle: "content",
        active: false
    });
    new DataTable('#coopTable', {
        lengthMenu: [
            [10, 25, 50, -1],
            [10, 25, 50, 'All']
        ]
    });
    new DataTable('#employTable', {
        lengthMenu: [
            [10, 25, 50, -1],
            [10, 25, 50, 'All']
        ]
    });

    //now turn it on
    $('#hideMe').fadeIn(1200);
})

