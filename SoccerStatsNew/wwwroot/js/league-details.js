function onChange(arg) {
    var rows = arg.sender.select();
    var itemId = rows[0].dataset['id'];
    var yearId = rows[0].dataset['year'];
   
    if (itemId && yearId) {
        location.href = `Team/?team=${itemId}&year=${yearId}`;
    }
}