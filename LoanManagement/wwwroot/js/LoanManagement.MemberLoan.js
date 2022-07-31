memberLoan = {
    init: function () {
        $('.select-chosen').chosen();
        $('form').validate().settings.ignore = []
    },
    sumInstallment: function () {
        let total = 0;
        $.each($('.install'), function (i, d) {
            var a = parseFloat($(this).val());
            if (!isNaN(a)) {
                total = total + a;
            }
        });
        return total;
    },
    matureDate: function () {
        try {
            var dateOfComm = $('input[name="DateOfCommencementNep"]').val();
            var duration = $('input[name="Duration"]').val();
            if (dateOfComm != "" && duration != "") {
                let year = dateOfComm.split('-')[0];
                let month = dateOfComm.split('-')[1];
                let day = dateOfComm.split('-')[2];
                var dt = NepaliCalendar.getEnglishDate(year, month, day);
                $('input[name="DateOfCommencement"]').val(moment(dt).format("MM-DD-YYYY"));
                let m = moment(dt).add(duration, 'year');
                let npDate = NepaliCalendar.BSDate(m.year(), m.month(), m.date());
                $('input[name="LoanMaturityDate"]').val(m.format("MM-DD-yyyy"));
                return npDate.npYear + '-' + String(npDate.npMonth).padStart(2, '0') + '-' + String(npDate.npDay).padStart(2, '0');
            } else
                return '';
        }
        catch {
            return '';
        }
    },
    submit: function () {
        if ($('form').valid()) {
            bootbox.confirm("Are you sure you want to save the record?", function (result) {
                if (result) {
                    $('form').submit();
                }
            });
        }
    }
}