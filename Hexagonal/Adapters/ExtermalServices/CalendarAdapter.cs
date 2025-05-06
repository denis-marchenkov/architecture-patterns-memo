using Core.Ports;

namespace ExtermalServices
{
    public class CalendarAdapter : ICalendarService
    {
        public bool IsRoomAvailable(string location, DateTime start, DateTime end)
        {
            return true;
        }
    }
}
