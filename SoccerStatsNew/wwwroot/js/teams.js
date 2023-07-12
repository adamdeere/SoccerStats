function onClick(e) {
    var param = this.element.attr("param");
    location.href = `/Fixture?team=${param}`;
}