using Application.DTOs;
using Domain;

namespace Application
{
    public interface IAppointmentAppService
    {
        Appointment CreateAppointment(AppointmentDto appointment);
        Appointment GetAppointment(Guid id);
        public Appointment RescheduleAppointment(AppointmentDto appointment);
    }
}
