$(function () {
    $('.tab-content:not(:first)').hide(); /* hide all divs except first */
    $('.button:first').addClass('special'); /* add a class to the first and active div */
    $('.tab-content:first').addClass('active'); /* add a class to the first and active div */

    $('#viernes, #sabado, #domingo, #lunes, #martes, #miercoles').on('click', function (e) {
        //e.preventDefault(); /* prevent anchor from firing */
        var option = $(this).prop('id'); /* define the current button */
        var active = $('.tab-content.active'); /* find active item */
        var currButton = $('.button.special'); /* find active button */
        switch (option) {
            case 'viernes': { newActive = 0; newButton = 0; } break;
            case 'sabado': { newActive = 1; newButton = 1; } break;
            case 'domingo': { newActive = 2; newButton = 2; } break;
            case 'lunes': { newActive = 3; newButton = 3; } break;
            case 'martes': { newActive = 4; newButton = 4; } break;
            case 'miercoles': { newActive = 5; newButton = 5; } break;
        }
        //var newActive = (option == 'sabado') ? 1 : 0; /* define the new active page */
        //var newButton = (option == 'sabado') ? 1 : 0; /* define the new active button */

        active.removeClass('active').hide() /* remove active state from the old page and hide it */
        $('.tab-content').eq(newActive).addClass('active').show(); /* add active state to the new page and show it */

        currButton.removeClass('special') /* remove special state from the old button */
        $('.button').eq(newActive).addClass('special') /* add special state to the new button*/

    });

});