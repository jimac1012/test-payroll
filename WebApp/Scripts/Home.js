var select2 = $('#employeeSelect').select2({});
$.ajax({
    url: '/Home/GetEmployeeTypes',
    dataType: 'json',
    method: "GET",
    success: function (result) {
        select2.empty();
        select2.select2({
            data: result,
            theme: 'bootstrap4',
            width: '100%',
            placeholder: 'Select Employee Type'
        });
    }
});

$('#birthDatePicker').daterangepicker({
    autoApply: true,
    format: 'DD-MM-YYYY',
    singleDatePicker: true,
    showDropdowns: true,
    minYear: 1901,
    maxYear: parseInt(moment().format('YYYY'), 0)
});

var table = $('.table-employees').DataTable({
    "paging": true,
    "searching": true,
    "responsive": true,
    "autoWidth": true,
    "scrollY": $(window).height() / 1.9,
    "order": [[1, "asc"]],
    "columnDefs": [
        {
            "targets": [-1],
            "searchable": false,
            "orderable": false
        }, {
            "targets": 0,
            "searchable": false,
            "orderable": false,
            "visible": false
        }
    ],
    "language": {
        search: "_INPUT_",
        searchPlaceholder: "Search records",
        emptyTable: "No records found."
    },
    columns: [
        { data: "ID" },
        { data: "Name" },
        { data: "EmployeeType" },
        {
            data: null,
            defaultContent:
                '<div class="btn-group btn-group-sm text-right" role="group" aria-label="control">' +
                '<button class="btn btn-sm btn-info">' +
                '<i class="fas fa-info-circle"></i> <span class="d-none d-xl-block">Details</span></button></div>'
        }
    ]
});

$('#modelToggle').on("click",
    function () {
        $('#modelTitle').text('Create New Employee');
        disableModelInput(false);
    });

$('#btnCreate').on("click",
    function () {
        disableModelInput(true);
        $('.btn-close').prop('disabled', true);
        $('#btnCreate').removeClass('hidden');
        $('#btnLoading').addClass('hidden');
        const jsonData = {
            Name: $('#textName').val(),
            BirthDate: $('#birthDatePicker').val(),
            TIN: $('#textTin').val(),
            BasicSalary: $('#textSalary').val(),
            EmployeeType: $('#employeeSelect').val()
        };

        $.ajax({
            url: '/Home/CreateEmployee',
            dataType: 'json',
            method: "POST",
            data: jsonData,
            success: function (result) {
                table.row.add(result).draw(false);
                disableModelInput(false);
                $('#inputModal').modal('toggle');
            }
        });

        return false;
    });

$('#btnCompute').on("click",
    function () {
        $('#btnComputing').removeClass('hidden');
        $('#btnCompute').addClass('hidden');

        const dayInput = $('#dayMultipler').val();
        console.log(dayInput);

        var day = 0;
        if (dayInput.length) { // zero-length string AFTER a trim
            day = dayInput;
        }

        const jsonData = {
            ID: $('#employeeId').val(),
            DayMultiplier: day
        }

        $.ajax({
            url: '/Home/ComputeSalary',
            dataType: 'json',
            method: "POST",
            data: jsonData,
            success: function (result) {
                $('#btnComputing').addClass('hidden');
                $('#btnCompute').removeClass('hidden');
                $('#computedSalary').val(result);
            }
        });

        return false;
    });

$('.table-employees tbody').on('click',
    'button',
    function () {
        $('#btnCreate').addClass('hidden');
        const data = table.row($(this).parents('tr')).data();
        $.ajax({
            url: '/Home/GetEmployeeDetails',
            dataType: 'json',
            data: { id: data["ID"] },
            method: "GET",
            success: function (result) {
                $('#divSalary').removeClass('hidden');
                $('#employeeId').val(result["ID"]);
                $('#textName').val(result["Name"]);
                $('#birthDatePicker').val(result["BirthDate"]);
                $('#textTin').val(result["TIN"]);
                $('#textSalary').val(result["BasicSalary"]);
                $('#employeeSelect').val(result["EmployeeType"]);
                $('#multiplerParam').text(result["MultiplierText"]);
                $('#dayMultipler').val(0);
                $('#computedSalary').val(0);

                disableModelInput(true);
                $('#modelTitle').text('Employee Details');
                $('#inputModal').modal('toggle');
            }
        });
    });

$('#inputModal').on('shown.bs.modal',
    function () {
        $('.btn-close').prop('disabled', false);
    });

$('#inputModal').on('hidden.bs.modal',
    function () {
        const formattedDate = new Date();
        const d = formattedDate.getDate();
        const y = formattedDate.getFullYear();
        var m = formattedDate.getMonth();
        m += 1; // JavaScript months are 0-11

        $('#divSalary').addClass('hidden');
        $('#btnCreate').removeClass('hidden');
        $('#btnLoading').addClass('hidden');
        $('#textName').val('');
        $('#birthDatePicker').val(d + "-" + m + "-" + y);
        $('#textTin').val('');
        $('#textSalary').val(0);
        $('#employeeSelect').val(0);
    });

function disableModelInput(forDisable) {
    $('#textName').prop('disabled', forDisable);
    $('#birthDatePicker').prop('disabled', forDisable);
    $('#textTin').prop('disabled', forDisable);
    $('#textSalary').prop('disabled', forDisable);
    $('#employeeSelect').prop('disabled', forDisable);
}