function onClick(e) {
    var param = this.element.attr("param");
    console.log(param);
    location.href = `/Fixture?team=${param}`;
}

function onTeamClick(e) {
    var param = this.element.attr("id");
    location.href = `/Player?team=${param}`;
}
function onSelect(e) {
    if (e.item) {
        var dataItem = this.dataItem(e.item);
        location.href = `/League/Details?league=${dataItem.LeagueId}&year=${dataItem.Year}`;
    } else {
        console.log(e);
    }
}