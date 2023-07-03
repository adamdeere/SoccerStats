function OnCountrySelect(e) {

    var countryName = e.sender.text();
    if (countryName) {
        location.href = `/?code=${countryName}`;
    }
}

function OnSeasonSelect(e) {
    alert(e.sender.text() + e.sender.value());
}