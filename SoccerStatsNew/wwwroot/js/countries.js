function onAdditionalData() {
    return {
        text: $("#countries").val()
    };
}

function onSelect(e) {
    var dataItem = this.dataItem(e.item.index());
    var countryName = dataItem.Name;
    if (countryName) {
        location.href = `/?code=${countryName}`;
    }
}