(function () {

    var demo = window.demo = window.demo || {};

    // Helper constants for date/time calculations
    var minute = 60000;
    var hour = minute * 60;

    var scheduler = null;

    // Confirmation window message for inserting
    var insertMessage = "Inserting {0} task in this slot will overlap another appointment. Do you want to continue?";

    window.OnClientAppointmentMoveStart = function (sender, args) {
        // Cache the Scheduler object reference so we don't have to retrieve it every time
        scheduler = sender;
    }

    window.OnClientAppointmentResizeStart = function (sender, args) {
        // Cache the Scheduler object reference so we don't have to retrieve it every time
        scheduler = sender;
    }

    window.appointmentInserting = function (sender, args) {
        // The slot that the user double-clicked to insert a new appointment
        var targetSlot = args.get_targetSlot();
        scheduler = sender;
        // Calculate the end time of the new appointment
        // By default, new appointments span 2 rows, so we multiply the minutesPerRow property by 2                             
        var endTime = new Date(targetSlot.get_startTime().getTime() + scheduler.get_minutesPerRow() * minute * 2);

        // Check if the new appointment is overlapping with one of the existing appointments
        if (overlapsWithAnotherAppointment(null, targetSlot.get_startTime(), endTime)) {
            // Cancel the event to prevent showing the insert form
            args.set_cancel(true);

            // The new appointment will overlap with an existing one - ask the user to confirm the operation
            var confirmMessage = String.format(insertMessage, "a new");
            radconfirm(confirmMessage, function (arg) { confirmInsertConflict(arg, targetSlot) }, 330, 180);
        }
    }

    function confirmInsertConflict(arg, targetSlot) {
        if (arg) {
            // The user confirmed the inserting of the conflicting appointment
            // Show the in-line insert form at the double-clicked slot
            scheduler.showInsertFormAt(targetSlot);
        }
    }

    window.appointmentResizeEnd = function (sender, args) {
        var appointment = args.get_appointment();

        var startTime = args.get_newStartTime();
        var endTime = args.get_newEndTime();

        var editSeries = args.get_editingRecurringSeries();

        // Check if the appointment will overlap with another appointment after resizing
        if (overlapsWithAnotherAppointment(appointment, startTime, endTime)) {
            // The resized appointment will overlap. Cancel the event to prevent the automatic resize.
            args.set_cancel(true);

            // Pop a confirmation window
            var confirmMessage = "After resizing, the '" + appointment.get_subject() + "' task will overlap with another appointment. Do you want to continue?";
            radconfirm(confirmMessage,
            function (arg) {
                if (arg) {
                    // The user has confirmed the resize - update the start and end time of the appointment
                    appointment.set_start(startTime);
                    appointment.set_end(endTime);
                    scheduler.updateAppointment(appointment, editSeries);
                }
            }, 330, 180);
        }
    }

    window.appointmentMoveEnd = function (sender, args) {
        var appointment = args.get_appointment();

        // Calculate the duration of the appointment
        var appointmentDuration = appointment.get_end() - appointment.get_start();

        // The new start time is provided in the event arguments                
        var newStartTime = args.get_newStartTime();

        // Add the duration of the appointment to the new start time to get the new end time
        var newEndTime = new Date(newStartTime.getTime() + appointmentDuration);

        var editSeries = args.get_editingRecurringSeries();

        // Check if moving the appointment will overlap an existing appointment
        if (overlapsWithAnotherAppointment(appointment, newStartTime, newEndTime)) {
            // The moved appointment will overlap. Cancel the event to prevent moving the appointment.
            args.set_cancel(true);

            // Pop a confirmation window
            var confirmMessage = "Moving the '" + appointment.get_subject() + "' task to this slot will overlap another appointment. Do you want to continue?";
            radconfirm(confirmMessage,
            function (arg) {
                if (arg) {
                    // The user has confirmed moving the appointment. Update the start and end time.
                    appointment.set_start(newStartTime);
                    appointment.set_end(newEndTime);
                    scheduler.updateAppointment(appointment, editSeries);
                }
            }, 330, 180);
        }
    }

    function overlapsWithAnotherAppointment(appointment, startTime, endTime) {
        // Get all appointments in the given time range
        var appointments = scheduler.get_appointments().getAppointmentsInRange(startTime, endTime);

        // If there are no appointments in the range, there is no overlapping
        if (appointments.get_count() == 0)
            return false;

        // If we are checking a specific appointment and it's the only one in the range, there is no overlapping
        if (appointment && appointments.get_count() == 1 && appointments.getAppointment(0) == appointment)
            return false;

        return true;
    }

    function isPartOfSchedulerAppointmentArea(htmlElement) {
        // Determines if an HTML element is part of the scheduler appointment area
        // This can be either the rsContent or the rsAllDay div (in day and week view)
        return $telerik.$(htmlElement).parents().is("div.rsAllDay") ||
                $telerik.$(htmlElement).parents().is("div.rsContent")
    }
} ());