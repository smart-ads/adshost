'use strict';

$(document).ready(function () {
    var body_ = $("body");
    var doc = $(document);
    var sampleAdded = false;
    var windowHeight = (window.innerHeight ? window.innerHeight : (document.documentElement.clientHeight ? document.documentElement.clientHeight : document.body.offsetHeight));


    /*
    *
    * Add banner sample to site
    *
    */
    var addSample = function (linkId, blockName, cssProperties, bannerText) {

        linkId.click(function () {
            //console.log("clicked");
            var adsample = $(".a_d_sample");
            if (!sampleAdded) {

                sampleAdded = true;
                body_.append('<div id="' + blockName + '" class="a_d_sample"><a href="#" class="close-sample" title="Закрыть пример"></a><div class="sample-container">' + bannerText + '</div></div>');
                adsample = $(".a_d_sample");

                // Redraw - center block on scroll and resize window


                var redraw = function () {
                    // var windowHeight = (window.innerHeight ? window.innerHeight : (document.documentElement.clientHeight ? document.documentElement.clientHeight : document.body.offsetHeight));
                    //console.log(cssProperties);
                    //console.log(  );
                    var offsetTop = Math.min(cssProperties.top + doc.scrollTop(), body_.height());
                    //console.log( offsetTop );
                    adsample.css("top", offsetTop + "px");
                    //console.log("Action!");
                };

                $(window).resize(redraw);
                doc.scroll(redraw).resize(redraw).scroll();
                adsample.find(".close-sample").click(function () {
                    adsample.hide();
                    return false;
                });

            }

            adsample.show();
            return false;
        });
    }


    var toplineCSS = { top: 0 };
    addSample($("#topline-sample"), "toplinesample", toplineCSS, "Баннер TopLine 730 на 90 пикселей. Здесь будет наша реклама!");

    var richMediaCSS = { top: Math.round(windowHeight / 2) };
    addSample($(".richmedia-sample"), "richsample", richMediaCSS, "Баннер Rich-media 640 на 480 пикселей. Здесь будет наша реклама!");

    var catFishCSS = { top: windowHeight };
    addSample($("#catfish-sample"), "catsample", catFishCSS, "Баннер CatFish 730 на 90 пикселей. Здесь будет наша реклама!");

    var adSpotCSS = { top: windowHeight };
    addSample($("#spot-sample"), "spotsample", adSpotCSS, "Баннер AdSpot 300 на 250 пикселей. Здесь будет наша реклама!");

    var popbnrCSS = { top: Math.round(windowHeight / 2) };
    addSample($("#popbnr-sample"), "popbnr", popbnrCSS, "PopUnder 468 на 75 пикселей. Здесь будет наша реклама!");


    $(window).resize(function () {

        windowHeight = (window.innerHeight ? window.innerHeight : (document.documentElement.clientHeight ? document.documentElement.clientHeight : document.body.offsetHeight));

        popbnrCSS.top = Math.round(windowHeight / 2);
        richMediaCSS.top = Math.round(windowHeight / 2);
        adSpotCSS.top = windowHeight;
        catFishCSS.top = windowHeight;

    });


});