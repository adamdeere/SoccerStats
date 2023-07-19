function onChange(arg) {
    var rows = arg.sender.select();
    var itemId = rows[0].dataset['id'];
    if (itemId) {
        location.href = `Team/?team=${itemId}`;
    }
}

function onTeamClick(e) {

}