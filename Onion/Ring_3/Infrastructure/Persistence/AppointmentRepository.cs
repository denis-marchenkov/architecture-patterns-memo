using Domain;
using DomainServices;
using System.Collections.Concurrent;

namespace Infrastructure.Persistence
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private static readonly ConcurrentDictionary<Guid, Appointment> _appointments = new();

        public void Add(Appointment appointment)
        {
            if (appointment == null) throw new ArgumentNullException(nameof(appointment));

            _appointments.TryAdd(appointment.Id, appointment);
        }


        public Appointment? GetById(Guid id)
        {
            return _appointments.TryGetValue(id, out Appointment? appointment) ? appointment : null;
        }


        public void Update(Appointment appointment)
        {
            ArgumentNullException.ThrowIfNull(appointment);
            if (!_appointments.ContainsKey(appointment.Id)) throw new KeyNotFoundException($"Appointment {appointment.Id} not found.");

            _appointments[appointment.Id] = appointment;
        }
    }
}
