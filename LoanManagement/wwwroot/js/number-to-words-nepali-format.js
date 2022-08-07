$(function () {
    amountInWord = function (number) {
        var no, point, hundred, digits_1, i, str, words, digits, divider, plural, counter, result, points;
        number = number.toString().split('.');
        no = number[0];
        point = number[1];
        hundred = '';
        digits_1 = no.length;
        i = 0;
        str = new Array();
        words = { '0': '', '1': 'One', '2': 'Two', '3': 'Three', '4': 'Four', '5': 'Five', '6': 'Six', '7': 'Seven', '8': 'Eight', '9': 'Nine', '10': 'Ten', '11': 'Eleven', '12': 'Twelve', '13': 'Thirteen', '14': 'Fourteen', '15': 'Fifteen', '16': 'Sixteen', '17': 'Seventeen', '18': 'Eighteen', '19': 'Nineteen', '20': 'Twenty', '30': 'Thirty', '40': 'Forty', '50': 'Fifty', '60': 'Sixty', '70': 'Seventy', '80': 'Eighty', '90': 'Ninety' };
        digits = new Array('', 'Hundred', 'Thousand', 'Lakh', 'Crore');
        while (i < digits_1) {
            divider = (i == 2) ? 10 : 100;
            number = Math.floor(no % divider);
            no = Math.floor(no / divider);
            i += (divider == 10) ? 1 : 2;
            if (number) {
                counter = str.length;
                plural = (counter && number > 9) ? 's' : '';
                hundred = (counter == 1 && str[0] && parseInt(point) == 0) ? 'and ' : '';
                str.push((number < 21) ? words[number] + " " + digits[counter] + plural + " " + hundred : words[Math.floor(number / 10) * 10] + " " + words[number % 10] + " " + digits[counter] + plural + " " + hundred);
            } else {
                str.push('');
            }
        }
        str = str.reverse();
        result = str.join('');
        points = (point && (parseInt(point) != 0)) ? " and " + words[parseInt(point / 10)] + " " + words[point = point % 10] + " Paisa Only." : (result!=""?' Only':'');
        return result.trim() + points;
    }
});

