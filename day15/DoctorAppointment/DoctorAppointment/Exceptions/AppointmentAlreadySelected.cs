namespace DoctorAppointment.Exceptions
{
    public class AppointmentAlreadySelected : Exception
    {
        public AppointmentAlreadySelected(string? message) : base(message)
        {
        }
    }
}
