function OnCountrySelect(e) {

    var countryName = e.sender.text();
    if (countryName) {
        location.href = `/?code=${countryName}`;
    }
}

function OnSeasonSelect(e) {
    alert(e.sender.text() + e.sender.value());
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