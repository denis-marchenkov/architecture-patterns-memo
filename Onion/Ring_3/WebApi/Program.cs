using Application;
using Application.DTOs;
using DomainServices;
using Infrastructure.ExternalServices;
using Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ICalendarService, CalendarService>();
builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();
builder.Services.AddScoped<IAppointmentAppService, AppointmentAppService>();

var app = builder.Build();


app.MapPost("/appointments", (AppointmentDto appointment, IAppointmentAppService appService) =>
{
    var result = appService.CreateAppointment(appointment);

    return Results.Ok(result);
});

app.MapPatch("/appointments/{id:guid}/reschedule", (AppointmentDto appointment, IAppointmentAppService appService) =>
{
    var result = appService.RescheduleAppointment(appointment);

    return Results.Ok(result);
});

app.Run();
