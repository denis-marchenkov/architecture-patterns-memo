using Core.Domain;
using Core.Ports;

namespace Core.UseCases
{
    public class CreateAppointmentCommandHandler(IAppointmentRepository appointmentRepository)
    {
        private readonly IAppointmentRepository _appointmentRepository = appointmentRepository;

        public Appointment Handle(CreateAppointmentCommand command)
        {
            var appointment = Appointment.Create(command.Title, command.Location, command.StartDate, command.EndDate);
            _appointmentRepository.Add(appointment);

            return appointment;
        }
    }
}
