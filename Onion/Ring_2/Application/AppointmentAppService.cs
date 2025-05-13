using Application.DTOs;
using Domain;
using DomainServices;

namespace Application;

public class AppointmentAppService : IAppointmentAppService
{

    private readonly IAppointmentRepository _appointmenRepository;
    private readonly IAppointmentService _appointmentService;

    public AppointmentAppService(IAppointmentRepository appointmenRepository, IAppointmentService appointmentService)
    {
        _appointmenRepository = appointmenRepository;
        _appointmentService = appointmentService;
    }

    public Appointment CreateAppointment(AppointmentDto appointmentDto)
    {
        var newAppointment = Appointment.Create(appointmentDto.Title, appointmentDto.Location, appointmentDto.StartDate, appointmentDto.EndDate);
        _appointmenRepository.Add(newAppointment);

        return newAppointment;
    }

    public Appointment GetAppointment(Guid id)
    {
        return _appointmenRepository.GetById(id) ?? throw new Exception("Appointment not found");
    }

    public Appointment RescheduleAppointment(AppointmentDto appointmentDto)
    {
        var appointment = GetAppointment(appointmentDto.Id);

        _appointmentService.Reschedule(appointment, appointmentDto.Location, appointmentDto.StartDate, appointmentDto.EndDate);

        _appointmenRepository.Update(appointment);

        return appointment;
    }
}
