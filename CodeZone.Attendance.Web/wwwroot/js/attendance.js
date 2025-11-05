$(document).ready(function () {
    let currentPage = 1;
    let currentEmployeeId = null;
    let currentAttendanceId = null;

    // Load attendance list on page load
    loadAttendanceList();

    // Quick attendance marking - Employee selection change
    $('#quickEmployeeSelect').on('change', function () {
        currentEmployeeId = $(this).val();
        checkAttendanceStatus();
    });

    // Quick attendance marking - Date selection change
    $('#quickDatePicker').on('change', function () {
        const selectedDate = new Date($(this).val());
        const today = new Date();
        today.setHours(0, 0, 0, 0);

        // Prevent future dates
        if (selectedDate > today) {
            alert('Cannot select future dates!');
            $(this).val(today.toISOString().split('T')[0]);
            return;
        }

        checkAttendanceStatus();
    });

    // Check attendance status for selected employee and date
    function checkAttendanceStatus() {
        const employeeId = $('#quickEmployeeSelect').val();
        const date = $('#quickDatePicker').val();

        if (!employeeId || !date) {
            $('#currentStatusDisplay').html('<strong>Not marked</strong>').removeClass('alert-success alert-danger alert-warning').addClass('alert-info');
            currentAttendanceId = null;
            return;
        }

        $.ajax({
            url: '/Attendance/GetAttendanceStatus',
            type: 'GET',
            data: { employeeId: employeeId, date: date },
            success: function (response) {
                if (response.success) {
                    if (response.exists) {
                        currentAttendanceId = response.id;
                        const statusClass = response.statusValue === 0 ? 'alert-success' : 'alert-danger';
                        const icon = response.statusValue === 0 ? '<i class="bi bi-check-circle"></i>' : '<i class="bi bi-x-circle"></i>';
                        $('#currentStatusDisplay')
                            .html(`${icon} <strong>${response.status}</strong>`)
                            .removeClass('alert-info alert-success alert-danger alert-warning')
                            .addClass(statusClass);
                    } else {
                        currentAttendanceId = null;
                        $('#currentStatusDisplay')
                            .html('<strong>Not marked</strong>')
                            .removeClass('alert-success alert-danger alert-warning')
                            .addClass('alert-info');
                    }
                }
            },
            error: function () {
                showNotification('Error checking attendance status', 'danger');
            }
        });
    }

    // Mark Present button
    $('#markPresentBtn').on('click', function () {
        markAttendance(0); // 0 = Present
    });

    // Mark Absent button
    $('#markAbsentBtn').on('click', function () {
        markAttendance(1); // 1 = Absent
    });

    // Mark attendance function
    function markAttendance(status) {
        const employeeId = $('#quickEmployeeSelect').val();
        const date = $('#quickDatePicker').val();

        if (!employeeId || !date) {
            alert('Please select both employee and date');
            return;
        }

        const token = $('input[name="__RequestVerificationToken"]').val();

        if (currentAttendanceId) {
            // Update existing attendance
            $.ajax({
                url: '/Attendance/UpdateAttendance',
                type: 'POST',
                data: {
                    id: currentAttendanceId,
                    status: status
                },
                headers: {
                    'RequestVerificationToken': token
                },
                success: function (response) {
                    if (response.success) {
                        showNotification(response.message, 'success');
                        checkAttendanceStatus();
                        loadAttendanceList();
                    } else {
                        showNotification(response.message, 'danger');
                    }
                },
                error: function () {
                    showNotification('Error updating attendance', 'danger');
                }
            });
        } else {
            // Create new attendance
            $.ajax({
                url: '/Attendance/MarkAttendance',
                type: 'POST',
                data: {
                    employeeId: employeeId,
                    date: date,
                    status: status
                },
                headers: {
                    'RequestVerificationToken': token
                },
                success: function (response) {
                    if (response.success) {
                        showNotification(response.message, 'success');
                        checkAttendanceStatus();
                        loadAttendanceList();
                    } else {
                        showNotification(response.message, 'danger');
                    }
                },
                error: function () {
                    showNotification('Error marking attendance', 'danger');
                }
            });
        }
    }

    // Clear selection button
    $('#clearSelectionBtn').on('click', function () {
        $('#quickEmployeeSelect').val('');
        $('#quickDatePicker').val(new Date().toISOString().split('T')[0]);
        $('#currentStatusDisplay').html('<strong>Not marked</strong>').removeClass('alert-success alert-danger alert-warning').addClass('alert-info');
        currentAttendanceId = null;
    });

    // Apply filter button
    $('#applyFilterBtn').on('click', function () {
        currentPage = 1;
        loadAttendanceList();
    });

    // Clear filter button
    $('#clearFilterBtn').on('click', function () {
        $('#filterDepartment').val('');
        $('#filterEmployee').val('');
        $('#filterStartDate').val('');
        $('#filterEndDate').val('');
        currentPage = 1;
        loadAttendanceList();
    });

    // Live search on filter fields
    let searchTimeout;
    $('#filterDepartment, #filterEmployee, #filterStartDate, #filterEndDate').on('change', function () {
        clearTimeout(searchTimeout);
        searchTimeout = setTimeout(function () {
            currentPage = 1;
            loadAttendanceList();
        }, 500);
    });

    // Load attendance list with filters
    function loadAttendanceList() {
        const departmentId = $('#filterDepartment').val();
        const employeeId = $('#filterEmployee').val();
        const startDate = $('#filterStartDate').val();
        const endDate = $('#filterEndDate').val();

        $('#attendanceListContainer').html('<div class="text-center py-5"><div class="spinner-border text-primary" role="status"><span class="visually-hidden">Loading...</span></div></div>');

        $.ajax({
            url: '/Attendance/AttendanceList',
            type: 'GET',
            data: {
                page: currentPage,
                pageSize: 10,
                departmentId: departmentId,
                employeeId: employeeId,
                startDate: startDate,
                endDate: endDate
            },
            success: function (data) {
                $('#attendanceListContainer').html(data);
                attachPaginationHandlers();
                attachDeleteHandlers();
            },
            error: function () {
                $('#attendanceListContainer').html('<div class="alert alert-danger">Error loading attendance records</div>');
            }
        });
    }

    // Attach pagination handlers
    function attachPaginationHandlers() {
        $('.pagination-link').on('click', function (e) {
            e.preventDefault();
            currentPage = $(this).data('page');
            loadAttendanceList();
            $('html, body').animate({ scrollTop: $('#attendanceListContainer').offset().top - 100 }, 300);
        });
    }

    // Attach delete handlers
    function attachDeleteHandlers() {
        $('.delete-attendance').on('click', function () {
            const id = $(this).data('id');
            if (confirm('Are you sure you want to delete this attendance record?')) {
                deleteAttendance(id);
            }
        });
    }

    // Delete attendance
    function deleteAttendance(id) {
        const token = $('input[name="__RequestVerificationToken"]').val();

        $.ajax({
            url: '/Attendance/DeleteAttendance',
            type: 'POST',
            data: { id: id },
            headers: {
                'RequestVerificationToken': token
            },
            success: function (response) {
                if (response.success) {
                    showNotification(response.message, 'success');
                    loadAttendanceList();
                    checkAttendanceStatus();
                } else {
                    showNotification(response.message, 'danger');
                }
            },
            error: function () {
                showNotification('Error deleting attendance', 'danger');
            }
        });
    }

    // Show notification
    function showNotification(message, type) {
        const alertHtml = `
            <div class="alert alert-${type} alert-dismissible fade show position-fixed top-0 start-50 translate-middle-x mt-3" role="alert" style="z-index: 9999; min-width: 300px;">
                ${message}
                <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
            </div>
        `;
        $('body').append(alertHtml);
        setTimeout(function () {
            $('.alert').alert('close');
        }, 3000);
    }

    // Disable future dates in date picker
    const today = new Date().toISOString().split('T')[0];
    $('#quickDatePicker').attr('max', today);
});