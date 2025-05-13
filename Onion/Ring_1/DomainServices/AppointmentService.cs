using Domain;
using Domain.Exceptions;

namespace DomainServices
{
    public class AppointmentService : IAppointmentService
    {
        private readonly ICalendarService _calendarService;

        public AppointmentService(ICalendarService calendarService) => _calendarService = calendarService;

        public void Reschedule(Appointment appointment, string location, DateTime newStartDate, DateTime newEndDate)
        {
            if (newStartDate >= newEndDate) throw new InvalidAppointmentException($"{nameof(newStartDate)} must be before {nameof(newEndDate)}.");

            if(!_calendarService.IsRoomAvailable(location, newStartDate, newEndDate)) throw new InvalidAppointmentException("Can't reschedule.");

            appointment.Reschedule(location, newStartDate, newEndDate);
        }
    }
}
