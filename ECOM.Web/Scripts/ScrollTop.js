var $ = jQuery.noConflict();
jQuery(document).ready(function ($) {
    scrollToTop.init();
});

var scrollToTop =
{
    init: function () {

        $(window).scroll(function () {
            if ($(this).scrollTop() > 100) {
                $('.scrollToTop').fadeIn();
            } else {
                $('.scrollToTop').fadeOut();
            }
        });

        $('.scrollToTop').click(function () {
            $('html, body').animate({ scrollTop: 0 }, 1000);
            return false;
        });
    }
};