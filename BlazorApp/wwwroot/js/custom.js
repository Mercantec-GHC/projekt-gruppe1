$(function () {

    // ============================================================== 
    //Fix header while scroll
    // ==============================================================  
    var wind = $(window);
    wind.on("load", function () {
        var bodyScroll = wind.scrollTop(),
            navbar = $(".topbar");
        if (bodyScroll > 40) {
            navbar.addClass("fixed-header")
        } else {
            navbar.removeClass("fixed-header")
        }
    });
    
    $( 'ul.dropdown-menu [data-bs-toggle="dropdown"]' ).on( 'click', function(event) {
        event.preventDefault();
        event.stopPropagation();

        $( this ).siblings().toggleClass( 'show' );

        if ( !$( this ).next().hasClass( 'show' ) ) {
            $( this ).parents( '.dropdown-menu' ).first().find( '.show' ).removeClass( 'show' );
        }

        $( this ).parents( 'li.nav-item.dropdown.show' ).on( 'hidden.bs.dropdown', function(e) {
            $( '.dropdown-submenu .show' ).removeClass( 'show' );
        });
    });
    
    $(window).scroll(function () {
        if ($(window).scrollTop() >= 200) {
            $('.topbar').addClass('fixed-header');
        } else {
            $('.topbar').removeClass('fixed-header');
        }
    });

    $('.product-item').isotope({
        itemSelector: '.product-desc',
        layoutMode: 'fitRows'
    });

    $('.product-tab ul li a').click(function(){
        $('.product-tab ul li a').removeClass("active");
        $(this).addClass("active");

        var selector = $(this).attr("data-filter");
        $('.product-item').isotope({
            filter: selector
        });

        return false
    });

    // ============================================================== 
    //Featured Property Carousel
    //
    
    $('.featured-property-carousel').owlCarousel({
        loop: true,
        margin: 30,
        nav: false,
        navText: ['<i class="fa fa-angle-left"></i>', '<i class="fa fa-angle-right"></i>'],
        dots: true,
        autoplay: true,
        center: true,
        responsiveClass: true,
        responsive:{
            0:{
                items:1
            },
            600:{
                items:2
            },
            1000:{
                items:3
            }
        }
    });

    $('.testimonial-carousal').owlCarousel({
        loop: true,
        margin: 30,
        nav: false,
        navText: ['<i class="fa fa-angle-left"></i>', '<i class="fa fa-angle-right"></i>'],
        dots: true,
        autoplay: false,
        center: true,
        responsiveClass: true,
        autoHeight: false,
        responsive: {
            0: {
                items: 1,
            },
            768: {
                items: 1,
                center: false
            },
            1024: {
                items: 1,
            }
        }
    });

    $('.testimonial-carousal-st2').owlCarousel({
        loop: true,
        margin: 30,
        nav: false,
        navText: ['<i class="fa fa-angle-left"></i>', '<i class="fa fa-angle-right"></i>'],
        dots: false,
        autoplay: true,
        // center: true,
        responsiveClass: true,
        responsive: {
            0: {
                items: 1,
            },
            768: {
                items: 2,
                center: false
            },
            1024: {
                items: 3,
            }
        }
    });

    $('.v1-banner-carousel').owlCarousel({
        animateOut: 'fadeOut',
        loop: true,
        margin: 30,
        nav: false,
        navText: ['<i class="fa fa-angle-left"></i>', '<i class="fa fa-angle-right"></i>'],
        dots: false,
        autoplay: true,
        center: true,
        smartSpeed:450,
        responsiveClass: true,
        responsive: {
            0: {
                items: 1,
            },
            768: {
                items: 1,
                center: false
            },
            1024: {
                items: 1,
            }
        }

    });

    $('.v2-banner-carousel').owlCarousel({
        animateOut: 'fadeOut',
        loop: true,
        margin: 30,
        nav: false,
        navText: ['<i class="fa fa-angle-left"></i>', '<i class="fa fa-angle-right"></i>'],
        dots: false,
        autoplay: true,
        center: true,
        smartSpeed:450,
        responsiveClass: true,
        responsive: {
            0: {
                items: 1,
            },
            768: {
                items: 1,
                center: false
            },
            1024: {
                items: 1,
            }
        }

    });

    $('.property-img-carousal').owlCarousel({
        loop:true,
        margin:3,
        dots: false,
        nav: true,
        navText: [$(".property-prev"), $(".property-next")],
        responsive:{
            0:{
                items:1
            },
            600:{
                items:1
            },
            1000:{
                items:3
            }
        }
    });

});