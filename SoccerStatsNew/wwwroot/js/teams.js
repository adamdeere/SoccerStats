function onClick(e) {
    var param = this.element.attr("param");
    console.log(param);
    location.href = `/Fixture?team=${param}`;
}

function onTeamClick(e) {
    var param = this.element.attr("param");
    location.href = `/Player?team=${param}`;
}

function onTableClick(e) {
    var param = this.element.attr("param");
   
}