function onChange(arg) {
    var rows = arg.sender.select();
    var itemId = rows[0].dataset['id'];
    if (itemId) {
        console.log(location.href);
        var thing = 'Team/?team=' + itemId;
        location.href = thing;
    }
}