using Core.Domain;
using Core.Ports;
using System.Collections.Concurrent;

namespace Persistence
{
    public class AppointmentRepositoryAdapter : IAppointmentRepository
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
            if (appointment == null) throw new ArgumentNullException(nameof(appointment));
            if (!_appointments.ContainsKey(appointment.Id)) throw new KeyNotFoundException($"Appointment {appointment.Id} not found.");

            _appointments[appointment.Id] = appointment;
        }
    }
}
