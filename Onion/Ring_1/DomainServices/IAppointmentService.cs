using Domain;

namespace DomainServices
{
    public interface IAppointmentService
    {
        public void Reschedule(Appointment appointment, string location, DateTime newStartDate, DateTime newEndDate);
    }
}
