$('select.state').on('change', function () {
    var _this = $('#' + $(this).attr('child-for'));
    _this.empty()
        .append('<option value>Choose District</option>');
    $.each(dis.filter(c => c.Province == $(this).val()), function (i, d) {
        _this.append('<option value="' + d.Name + '">' + d.Name + '</option>');
    })
    _this.trigger("chosen:updated");

});
$(document).ready(function () {
    $('.select-chosen').chosen();
    $('form').validate().settings.ignore = []

    $('.btn-copy').on('click', function () {
        $('select[Name="TemporaryState"]').val($('select[Name="PermanentState"]').val());
        $('select[Name="TemporaryState"]').trigger('change');
        $('select[Name="TemporaryState"]').trigger("chosen:updated");
        $('select[Name="TemporaryDistrict"]').val($('select[Name="PermanentDistrict"]').val());
        $('select[Name="TemporaryDistrict"]').trigger("chosen:updated");

        $('input[name="TemporaryMunicipality"]').val($('input[name="PermanentMunicipality"]').val());
        $('input[name="TemporaryWardNumber"]').val($('input[name="PermanentWardNumber"]').val());
        $('input[name="TemporaryStreet"]').val($('input[name="PermanentStreet"]').val());
        $('input[name="TemporaryHouseNo"]').val($('input[name="ParmanentHouseNo"]').val());
    });

    $('.btn-edit').on('click', function (e) {
        e.preventDefault();
        if ($(this).hasClass('btn-edit')) {
            $(this).parents('form').find('input').attr('readOnly', false);
            $(this).parents('form').find('input').prop('disabled', false);
            $(this).parents('form').find('select').prop('disabled', false);
            $(this).parents('form').find('.btn-copy').prop('disabled', false);
            $(this).parents('form').find('select').trigger("chosen:updated");
            $(this).removeClass('btn-edit');
            $(this).addClass('btn-cancel');
            $(this).text("Cancel")
            $('.btn-submit').attr('hidden', false)
           
        } else {
            $(this).parents('form').find('input').attr('readOnly', true);
            $(this).parents('form').find('input').prop('disabled', true);
            $(this).parents('form').find('select').prop('disabled', true);
            $(this).parents('form').find('.btn-copy').prop('disabled', true);
            $(this).removeClass('btn-cancel');
            $(this).addClass('btn-edit');
            $(this).text("Edit")
            $('.btn-submit').attr('hidden', true)
        }
        $('.scroll-top').trigger('click');
    });
});