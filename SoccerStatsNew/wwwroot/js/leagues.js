function onChange(arg) {
    var selected = $.map(this.select(), function (item) {
        return $(item).text();
    });
    if (selected) {
        location.href = `Team/Display?team=${selected}`;
    }
   
}

function OnCountrySelect(e) {

    var countryName = e.sender.text();
    if (countryName) {
        location.href = `/?code=${countryName}`;
    }
}
function OnSelect(e) {
    var season = e.sender.text();
    var league = e.sender.value();

    if (season && league) {
        location.href = `/Team?league=${league}&season=${season}`;
    }
}

function scrollButtonClick(e) {
    var button = $(e.currentTarget);
    var scrollToLeft = button.find(".k-i-arrow-chevron-left").length !== 0;
    var scrollContainer = $(".k-card-deck").eq(0);
    var lastCard = scrollContainer.find(".k-card").last();
    var cardWidth = lastCard.outerWidth(true);


    if (scrollToLeft) {
        scrollContainer.scrollLeft(scrollContainer.scrollLeft() - cardWidth);
    } else {
        scrollContainer.scrollLeft(scrollContainer.scrollLeft() + cardWidth);
    }
};