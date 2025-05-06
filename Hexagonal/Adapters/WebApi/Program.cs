using Core.UseCases;
using WebApi.Configuration;

var builder = WebApplication.CreateBuilder(args);

// wire up adapters for core interfaces
builder.Services.InjectAdapters();

var app = builder.Build();

app.UseHttpsRedirection();


app.MapPost("/appointments", (CreateAppointmentCommand command, CreateAppointmentCommandHandler handler) =>
{
    var result = handler.Handle(command);

    return Results.Ok(result);
});

app.MapPatch("/appointments/{id:guid}/reschedule", (Guid id, RescheduleAppointmentCommand command, RescheduleAppointmentCommandHandler handler) =>
{
    handler.Handle(command);

    return Results.Ok();
});

app.Run();
