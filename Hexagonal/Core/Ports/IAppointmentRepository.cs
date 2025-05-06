using Core.Domain;

namespace Core.Ports
{
    public interface IAppointmentRepository
    {
        Appointment? GetById(Guid id);
        void Add(Appointment appointment);
        void Update(Appointment appointment);
    }
}
