namespace Core.Exceptions
{
    public class InvalidAppointmentException : Exception
    {
        public InvalidAppointmentException(string? message) : base(message)
        {
        }
    }
}
