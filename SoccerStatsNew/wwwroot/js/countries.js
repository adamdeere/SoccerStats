function onAdditionalData() {
    return {
        text: $("#countries").val()
    };
}

function onSelect(e) {
    var dataItem = this.dataItem(e.item.index());
    var countryCode = dataItem.countryCode;
    if (countryCode) {
        console.log(countryCode);
        location.href = `/?code=${countryCode}`;
    }
}

function onClick(e) {
    console.log("event :: click (" + $(e.event.target).closest(".k-button").attr("id") + ")");
}