using DomainServices;

namespace Infrastructure.ExternalServices
{
    public class CalendarService : ICalendarService
    {
        public bool IsRoomAvailable(string location, DateTime start, DateTime end)
        {
            return true;
        }
    }
}
