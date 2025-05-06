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

            appointment.Reschedule(command.Location, command.NewStartDate, command.NewEndDate, _calendarService);

            _appointmentRepository.Update(appointment);
        }
    }
}
