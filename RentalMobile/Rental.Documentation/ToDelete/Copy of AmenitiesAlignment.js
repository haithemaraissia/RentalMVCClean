
$(document).ready(function ($) {



    






    //Feature
    $('#Feature ul ').each(function (i) {
        var thisLength = $(this).children().length;
        if (thisLength == 0) {
            $(this).parent().html('<ul class="arrow"><li style="background:none; border-bottom:0"></li></ul>');
        }
    });

    var lastitemcount = $('#Feature ul li').children().last().parent().parent().children().length - 1;
    var lastitemindex = $('#Feature ul').length - 1;
    var maximumitemcount = lastitemcount;
    var maximumitemindex = lastitemindex;

    $('#Feature ul ').each(function (i) {
        var thisLength = $(this).children().length;
        if (thisLength >= maximumitemcount) {
            maximumitemcount = thisLength;
            maximumitemindex = i;
        }
    });

    if (lastitemcount < maximumitemcount) {
        var lastitem = $('#Feature ul ').eq(lastitemindex).clone();
        var maxitem = $('#Feature ul ').eq(maximumitemindex).clone();
        var temp = $('#Feature ul ').eq(lastitemindex).clone();
        $('#Feature ul ').eq(lastitemindex).html(maxitem);
        $('#Feature ul ').eq(maximumitemindex).html(temp);
    }




















    //CommunityAmenity
    $('#CommunityAmenity ul ').each(function (i) {
        var thisLength = $(this).children().length;
        if (thisLength == 0) {
            $(this).parent().html('<ul class="arrow"><li style="background:none; border-bottom:0"></li></ul>');
        }
    });

    var lastitemcount = $('#CommunityAmenity ul li').children().last().parent().parent().children().length - 1;
    var lastitemindex = $('#CommunityAmenity ul').length - 1;
    var maximumitemcount = lastitemcount;
    var maximumitemindex = lastitemindex;

    $('#CommunityAmenity ul ').each(function (i) {
        var thisLength = $(this).children().length;
        if (thisLength >= maximumitemcount) {
            maximumitemcount = thisLength;
            maximumitemindex = i;
        }
    });

    if (lastitemcount < maximumitemcount) {
        var lastitem = $('#CommunityAmenity ul ').eq(lastitemindex).clone();
        var maxitem = $('#CommunityAmenity ul ').eq(maximumitemindex).clone();
        var temp = $('#CommunityAmenity ul ').eq(lastitemindex).clone();
        $('#CommunityAmenity ul ').eq(lastitemindex).html(maxitem);
        $('#CommunityAmenity ul ').eq(maximumitemindex).html(temp);
    }




























    //UnitAppliance
    $('#UnitAppliance ul ').each(function (i) {
        var thisLength = $(this).children().length;
        if (thisLength == 0) {
            $(this).parent().html('<ul class="arrow"><li style="background:none; border-bottom:0"></li></ul>');
        }
    });

    var lastitemcount = $('#UnitAppliance ul li').children().last().parent().parent().children().length - 1;
    var lastitemindex = $('#UnitAppliance ul').length - 1;
    var maximumitemcount = lastitemcount;
    var maximumitemindex = lastitemindex;

    $('#UnitAppliance ul ').each(function (i) {
        var thisLength = $(this).children().length;
        if (thisLength >= maximumitemcount) {
            maximumitemcount = thisLength;
            maximumitemindex = i;
        }
    });

    if (lastitemcount < maximumitemcount) {
        var lastitem = $('#UnitAppliance ul ').eq(lastitemindex).clone();
        var maxitem = $('#UnitAppliance ul ').eq(maximumitemindex).clone();
        var temp = $('#UnitAppliance ul ').eq(lastitemindex).clone();
        $('#UnitAppliance ul ').eq(lastitemindex).html(maxitem);
        $('#UnitAppliance ul ').eq(maximumitemindex).html(temp);
    }



    //InteriorAmenity
    $('#InteriorAmenity ul ').each(function (i) {
        var thisLength = $(this).children().length;
        if (thisLength == 0) {
            $(this).parent().html('<ul class="arrow"><li style="background:none; border-bottom:0"></li></ul>');
        }
    });

    var lastitemcount = $('#InteriorAmenity ul li').children().last().parent().parent().children().length - 1;
    var lastitemindex = $('#InteriorAmenity ul').length - 1;
    var maximumitemcount = lastitemcount;
    var maximumitemindex = lastitemindex;

    $('#InteriorAmenity ul ').each(function (i) {
        var thisLength = $(this).children().length;
        if (thisLength >= maximumitemcount) {
            maximumitemcount = thisLength;
            maximumitemindex = i;
        }
    });

    if (lastitemcount < maximumitemcount) {
        var lastitem = $('#InteriorAmenity ul ').eq(lastitemindex).clone();
        var maxitem = $('#InteriorAmenity ul ').eq(maximumitemindex).clone();
        var temp = $('#InteriorAmenity ul ').eq(lastitemindex).clone();
        $('#InteriorAmenity ul ').eq(lastitemindex).html(maxitem);
        $('#InteriorAmenity ul ').eq(maximumitemindex).html(temp);
    }

















    //ExteriorAmenity
    $('#ExteriorAmenity ul ').each(function (i) {
        var thisLength = $(this).children().length;
        if (thisLength == 0) {
            $(this).parent().html('<ul class="arrow"><li style="background:none; border-bottom:0"></li></ul>');
        }
    });

    var lastitemcount = $('#ExteriorAmenity ul li').children().last().parent().parent().children().length - 1;
    var lastitemindex = $('#ExteriorAmenity ul').length - 1;
    var maximumitemcount = lastitemcount;
    var maximumitemindex = lastitemindex;

    $('#ExteriorAmenity ul ').each(function (i) {
        var thisLength = $(this).children().length;
        if (thisLength >= maximumitemcount) {
            maximumitemcount = thisLength;
            maximumitemindex = i;
        }
    });

    if (lastitemcount < maximumitemcount) {
        var lastitem = $('#ExteriorAmenity ul ').eq(lastitemindex).clone();
        var maxitem = $('#ExteriorAmenity ul ').eq(maximumitemindex).clone();
        var temp = $('#ExteriorAmenity ul ').eq(lastitemindex).clone();
        $('#ExteriorAmenity ul ').eq(lastitemindex).html(maxitem);
        $('#ExteriorAmenity ul ').eq(maximumitemindex).html(temp);
    }
















    //LuxuryAmenity
    $('#LuxuryAmenity ul ').each(function (i) {
        var thisLength = $(this).children().length;
        if (thisLength == 0) {
            $(this).parent().html('<ul class="arrow"><li style="background:none; border-bottom:0"></li></ul>');
        }
    });

    var lastitemcount = $('#LuxuryAmenity ul li').children().last().parent().parent().children().length - 1;
    var lastitemindex = $('#LuxuryAmenity ul').length - 1;
    var maximumitemcount = lastitemcount;
    var maximumitemindex = lastitemindex;

    $('#LuxuryAmenity ul ').each(function (i) {
        var thisLength = $(this).children().length;
        if (thisLength >= maximumitemcount) {
            maximumitemcount = thisLength;
            maximumitemindex = i;
        }
    });

    if (lastitemcount < maximumitemcount) {
        var lastitem = $('#LuxuryAmenity ul ').eq(lastitemindex).clone();
        var maxitem = $('#LuxuryAmenity ul ').eq(maximumitemindex).clone();
        var temp = $('#LuxuryAmenity ul ').eq(lastitemindex).clone();
        $('#LuxuryAmenity ul ').eq(lastitemindex).html(maxitem);
        $('#LuxuryAmenity ul ').eq(maximumitemindex).html(temp);
    }


});
