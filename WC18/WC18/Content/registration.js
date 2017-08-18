var total1 = 0;
var total2 = 0;
var alojamiento = 0;
$(function () {

    $('#form-conferencia, #form-entrenamientos, #form-cena, #form-alojamiento, #form-tour').on('click', function (e) {
        //e.preventDefault(); /* prevent anchor from firing */

        var option = $(this).prop('id'); /* define the current button */

        var span1 = $('#precioTemp'); /* find active item */
        var span2 = $('#precioTard'); /* find active item */

        if (option == 'form-conferencia' || option == 'form-entrenamientos') {
            if ($(this).is(':checked')) {
                total1 = total1 + 60;
                total2 = total2 + 80;
            }
            else {
                total1 = total1 - 60;
                total2 = total2 - 80;
            }
        }
        else if (option == 'form-cena') {
            if ($(this).is(':checked')) {
                total1 = total1 + 30;
                total2 = total2 + 30;
            }
            else {
                total1 = total1 - 30;
                total2 = total2 - 30;
            }
        }
        else if (option == 'form-tour') {
            if ($(this).is(':checked')) {
                total1 = total1 + 75;
                total2 = total2 + 75;
            }
            else {
                total1 = total1 - 75;
                total2 = total2 - 75;
            }
        }
        else if (option == 'form-alojamiento') {
            var valuedias = $('#form-dias').val();
            alojamiento = valuedias * 40;
            if ($(this).is(':checked')) {

                total1 = total1 + alojamiento;
                total2 = total2 + alojamiento;
            }
            else {
                total1 = total1 - alojamiento;
                total2 = total2 - alojamiento;
                alojamiento = 0;
            }
        }

        $('#precioTemp').text(total1);
        $('#precioTard').text(total2);

    });

});

$(function () {

    $('#form-dias').on('change', function (e) {

        var valuedias = $('#form-dias').val();
        total1 = total1 - alojamiento;
        total2 = total2 - alojamiento;
        if ($('#form-alojamiento').is(':checked')) {
            alojamiento = (valuedias * 40);
            total1 = total1 + alojamiento;
            total2 = total2 + alojamiento;
        }
        $('#precioTemp').text(total1);
        $('#precioTard').text(total2);

    });

});

$(function () {

    $('#reset').on('click', function (e) {

        total1 = 0;
        total2 = 0;
        alojamiento = 0;
        $('#precioTemp').text(total1);
        $('#precioTard').text(total2);

    });

});
