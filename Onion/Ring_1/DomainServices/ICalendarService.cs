namespace DomainServices
{
    public interface ICalendarService
    {
        bool IsRoomAvailable(string location, DateTime start, DateTime end);
    }
}
