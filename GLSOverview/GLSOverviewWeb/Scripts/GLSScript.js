$(document).ready(function () {

    (function ($) {
        $('#filter').keyup(function () {
            var rex = new RegExp($(this).val(), 'i');
            $('.searchable tr').hide();
            $('.searchable tr').filter(function () {
                return rex.test($(this).text());
            }).show();
        })
    }(jQuery));
});

// If browser cannot handle the input type date (HTML5 thing), then use the nuget packet Bootstrap Datepicker datepicker.
// http://www.aubrett.com/InformationTechnology/WebDevelopment/MVC/DatePickerMVC5.aspx
//if (!Modernizr.inputtypes.date) {
    $(function () {
        $(".datepicker").datepicker();
    });
//} // Changed to always use datepicker