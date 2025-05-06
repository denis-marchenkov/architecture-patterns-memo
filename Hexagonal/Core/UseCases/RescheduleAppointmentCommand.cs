namespace Core.UseCases
{
    public record RescheduleAppointmentCommand(Guid Id, string Location, DateTime NewStartDate, DateTime NewEndDate);
}
