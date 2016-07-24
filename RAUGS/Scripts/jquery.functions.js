$(document).ready(function () {
    /* CAD MASK */

    //	MASCARA DE CAMPO CPF/CNPJ
    if ($('.mask_cpf_cnpj')[0]) {
        $('.mask_cpf_cnpj').cadMask({ hasRawField: true });
        $('.mask_cpf_cnpj').keyup(function () {
            if ($('#raw_id').val().length > 0) {
                $('#raw_id').val($(this).val());
            }
        }).blur(function () {
            $('#raw_id').val('');
            $(this).data('value', new Array());
        });
    }
    //MASCARA DE NUMEROS
    $('body').on('focus', '.mask_numbers', function (event) {
        event.preventDefault();
        $('.mask_numbers').attr("onkeypress", "return sonumeros(event);");
    })
    //	CLASSE PARA DESABILITAR A TECLA ENTER
    .on('keyup', '.disableEnter', function (event) {
        event.preventDefault();
        var unicode = event.keyCode;
        // Desabilitando o enter
        if (unicode == 13) {
            return false;
        }
        return true;
    })
    //	MASCARA DE METRO QUADRADO
    .on('focus', '.mask_metro_quadrado', function (event) {
        event.preventDefault();
        $(this).removeClass('mask_metro_quadrado').maskMoney({ precision: 3 });
        if ($(this).hasClass('must_return_value')) {
            $(this).blur(function () {
                if (($(this).val() == '' || $(this).val() == '0.000' || $(this).val() == undefined))
                    $(this).val('0.000');
            });
        }
    })
    //	MASCARA DE CAMPOS PARA VERIFICACAO DE EMAIL
    .on('focus', '.mask_email', function (event) {
        event.preventDefault();
        $('.mask_email').attr("onblur", "return checaValidadeEmail(this.name, this.value);");
    })
    //	MASCARA DE NIRF
    .on('focus', '.mask_nirf', function (event) {
        event.preventDefault();
        $(this).removeClass('mask_nirf').mask('9.999.999-9');
    })
    //	MASCARA DE CODIGO INCRA
    .on('focus', '.mask_codigo_incra', function (event) {
        event.preventDefault();
        $(this).removeClass('mask_codigo_incra').mask('999.999.999.999-9');
    })
    //	MASCARA DE TELEFONE
    //.on('focus', '.mask_telefone', function (event) {
    //    event.preventDefault();
    //    $(this).removeClass('mask_telefone').mask('(99) 9999-9999');
    //})
    //	MASCARA DE CEP
    .on('focus', '.mask_cep', function (event) {
        event.preventDefault();
        $(this).removeClass('mask_cep').mask('99.999-999');
    })
    //	MASCARA DE CPF
    .on('focus', '.mask_cpf', function (event) {
        event.preventDefault();
        $(this).removeClass('mask_cpf').mask('999.999.999-99');
    })
    //	MASCARA DE CNPJ
    .on('focus', '.mask_cnpj', function (event) {
        event.preventDefault();
        $(this).removeClass('mask_cnpj').mask('99.999.999/9999-99');
    })
    //	MASCARA DE DATA
    .on('focus', '.mask_date', function (event) {
        event.preventDefault();
        $(this).removeClass('mask_date').mask('99/99/9999');
    })
    .on('focus', '.mask_rg', function (event) {
        event.preventDefault();
        $(this).removeClass('mask_rg').mask('99.999.999-99');
    })
    .on('focus', '.mask_pis_pasep', function (event) {
        event.preventDefault();
        $(this).removeClass('mask_pis_pasep').mask('99.99999.99-9');
    })
    .on('focus', '.mask_pis_pasep_serie', function (event) {
        event.preventDefault();
        $(this).removeClass('mask_pis_pasep_serie').mask('999-9');
    })
    .on('focus', '.mask_titulo_eleitor', function (event) {
        event.preventDefault();
        $(this).removeClass('mask_titulo_eleitor').mask('9999999999/99');
    })
    //	MASCARA DE DATA
    .on('focus', '.mask_cns', function (event) {
        event.preventDefault();
        $(this).removeClass('mask_cns').mask('999 9999 9999 9999');
    })
    //	MASCARA DE HORAS
    .on('focus', '.mask_hours', function (event) {
        event.preventDefault();
        $(this).removeClass('mask_hours').mask('99:99');
    })
    //	MASCARA DE VALORES - REAL
    .on('focus', '.mask_real', function (event) {
        event.preventDefault();
        $(this).removeClass('mask_real').maskMoney({ showSymbol: false, symbol: 'R$ ', defaultZero: false, thousands: '.', decimal: ',' });
        if ($(this).hasClass('must_return_value')) {
            $(this).blur(function () {
                if (($(this).val() == '' || $(this).val() == '0,00' || $(this).val() == undefined))
                    $(this).val('0,00');
            });
        }
    })
    //	MASCARA DE PERCENTUAL
    .on('focus', '.mask_percentual', function (event) {
        event.preventDefault();
        $(this).removeClass('mask_percentual').maskMoney({ showSymbol: true, symbol: '%', precision: 3, decimal: ',' });
        if ($(this).hasClass('must_return_value')) {
            $(this).blur(function () {
                if (($(this).val() == '' || $(this).val() == '0.000' || $(this).val() == undefined))
                    $(this).val('0.000');
            });
        }
    })
    //	MASCARA DE QUANTIDADE
    .on('focus', '.mask_qtd', function (event) {
        event.preventDefault();
        $(this).removeClass('mask_qtd').maskMoney({ showSymbol: false, symbol: '', defaultZero: false, thousands: '', decimal: '' });
    });
});