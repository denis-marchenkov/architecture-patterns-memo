using Core.Ports;

namespace ExternalServices
{
    public class CalendarAdapter : ICalendarService
    {
        public bool IsRoomAvailable(string location, DateTime start, DateTime end)
        {
            return true;
        }
    }
}
