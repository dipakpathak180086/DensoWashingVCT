 


function ShowCalender1(textField)
{
    $(textField).datetimepicker({
        dayOfWeekStart: 1,
        lang: 'en',
        disabledDates: ['1986/01/08', '1986/01/09', '1986/01/10'],
        startDate: '2015/01/01',
        formatTime: 'H:i',
        formatDate: 'MMM.dd.yyyy',
        defaultDate: '2015/01/01', // it's my birthday
        //defaultTime:'10:00',
        timepickerScrollbar: true,
        datepicker: true,
        //allowTimes: ['12:00', '13:00', '15:00', '17:00', '17:05', '17:20', '19:00', '20:00'],
        step: 1
    });
};

function RemoveSpecialChar(txtName) {
    if (txtName.value != '' && txtName.value.match(/^[\w]+$/) == null) {
        txtName.value = txtName.value.replace(/[\W]/g, '');
    }
}

function isNumberKey(control_id, evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode > 31 && (charCode < 48 || charCode > 57) && (charCode <= 45 || charCode > 47))
        return false;
    if (charCode == 46) {
        return false;
    }
    return true;
}
function isNumberOrDecimal(control_id, evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode > 31 && (charCode < 48 || charCode > 57) && (charCode <= 45 || charCode > 47))
        return false;
    if (charCode == 46) {
        var dotcount = document.getElementById(control_id).value.split('.').length - 1;
        if (dotcount >= 1) {
            return false;
        }
    }
    return true;
}