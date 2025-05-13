using Domain;

namespace DomainServices
{
    public interface IAppointmentRepository
    {
        Appointment? GetById(Guid id);
        void Add(Appointment appointment);
        void Update(Appointment appointment);
    }
}
