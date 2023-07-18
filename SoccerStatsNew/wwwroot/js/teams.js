function onClick(e) {
    var param = this.element.attr("param");
    console.log(param);
    location.href = `/Fixture?team=${param}`;
}

function onFixtureClick(e) {
    var param = this.element.attr("param");
    console.log(param);
}