$(function () {
   
    var ratio = parseFloat(1 / parseFloat($('#d-ab').width()));
    $('.dragThis').draggable(
        {
            containment: 'parent',
            drag: function (e) {
                var offset = $(this).position();
                var offsetParent = $(this).parent().position();
                var xPos = offset.left;
                var yPos = offset.top;
                $('#x-' + $(this).attr('id')).val(xPos * ratio);
                $('#y-' + $(this).attr('id')).val(yPos * ratio);
            }
        });
    $('input[type="number"]').on('change', function () {
        try {
            var id = $(this).attr('id');
            var elem = $('#' + id.split('-')[1]);
            var point = id.split('-')[0];
            var position = $(elem).position();
            if (point == 'x') {
                $(elem).css({ top: position.top, left: parseFloat($(this).val()) + 'cm', position: 'absolute' });
            }

            else if (point == 'y')
                $(elem).css({ top: parseFloat($(this).val()) + 'cm', left: position.left, position: 'absolute' });
        } catch {

        }
    });
    $('#x-size').off().on('change', function (e) {
        e.preventDefault();
        $('.cheque-body').height($(this).val() + 'cm');
    });
    $('#y-size').off().on('change', function (e) {
        e.preventDefault();
        $('.cheque-body').width($(this).val() + 'cm');
    });
});