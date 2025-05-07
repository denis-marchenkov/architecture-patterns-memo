using Core.Exceptions;
using Core.Ports;

namespace Core.Domain
{
    public class Appointment
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        private Appointment(Guid id, string title, string location, DateTime startDate, DateTime endDate)
        {
            if (string.IsNullOrEmpty(title)) throw new InvalidAppointmentException($"{nameof(Title)} is required.");
            if (string.IsNullOrEmpty(title)) throw new InvalidAppointmentException($"{nameof(Location)} is required.");
            if (startDate >= endDate) throw new InvalidAppointmentException($"{nameof(StartDate)} must be before {nameof(EndDate)}.");

            Id = id;
            Title = title;
            Location = location;
            StartDate = startDate;
            EndDate = endDate;
        }

        public static Appointment Create(string title, string location, DateTime startDate, DateTime endDate) => new(Guid.NewGuid(), title, location, startDate, endDate);


        public void Reschedule(string location, DateTime newStartDate, DateTime newEndDate)
        {
            if (newStartDate >= newEndDate) throw new InvalidAppointmentException($"{nameof(newStartDate)} must be before {nameof(newEndDate)}.");

            Location = location;
            StartDate = newStartDate;
            EndDate = newEndDate;
        }

    }
}
