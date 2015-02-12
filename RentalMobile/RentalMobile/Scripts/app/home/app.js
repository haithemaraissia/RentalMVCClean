

$(document).ready(function ($) {

    //            // Init Carousel	
    //            $('.bx-carousel').bxSlider({
    //                auto: true,
    //                minSlides: 1,
    //                maxSlides: 3,
    //                slideWidth: 300,
    //                slideMargin: 20,
    //                nextSelector: '#carousel-next',
    //                prevSelector: '#carousel-prev',
    //                pager: false
    //            });



    // Init bx slider 
    $('.bxslider').bxSlider({
        mode: 'fade',
        captions: true,
        pagerCustom: '#bx-pager',
        auto: true
    });


    //Easy tabs
    $('.tab-container').easytabs();

    //FitVids
    //    $('#video').fitVids();



    //Custom selects
    $('.custom-select').customSelect();





    $(".filter-list a").click(function () {

        $("#property-list").fadeTo(200, 0.10);

        $(".filter-list a").removeClass("current");
        $(this).addClass("current");

        newSelection = $(this).attr("data-rel");

        $(".prop-type").not("." + newSelection).slideUp();
        $("." + newSelection).slideDown();

        $("#property-list").fadeTo(600, 1);

    });
});

