function OnGridSelect(arg) {
    var rows = arg.sender.select();
    var itemId = $($(rows[0]).find('.pt-indicator')[0]).attr('data-id');

    if (itemId) {
        window.location.href = `Prediction?fixture=${itemId}`;
    }
}