using Core.Exceptions;
using Core.Ports;

namespace Core.UseCases
{
    public class RescheduleAppointmentCommandHandler(IAppointmentRepository appointmentRepository, ICalendarService calendarService)
    {
        private readonly IAppointmentRepository _appointmentRepository = appointmentRepository;
        private readonly ICalendarService _calendarService = calendarService;

        public void Handle(RescheduleAppointmentCommand command)
        {
            var appointment = _appointmentRepository.GetById(command.Id);

            if (appointment == null) throw new InvalidAppointmentException($"Appointment {command.Id} not found");
            if (!_calendarService.IsRoomAvailable(command.Location, command.NewStartDate, command.NewEndDate)) throw new InvalidAppointmentException("Can't reschedule.");

            appointment.Reschedule(command.Location, command.NewStartDate, command.NewEndDate);

            _appointmentRepository.Update(appointment);
        }
    }
}
