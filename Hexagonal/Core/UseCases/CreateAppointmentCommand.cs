namespace Core.UseCases
{
    public record CreateAppointmentCommand(string Title, string Location, DateTime StartDate, DateTime EndDate);
}
