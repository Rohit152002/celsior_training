using System.Runtime.Serialization;
namespace DoctorAppointment.Exceptions
{
    [Serializable]
    internal class NoEntityFoundException : Exception
    {
        private string v;
        private string key;

        public NoEntityFoundException()
        {
        }

        public NoEntityFoundException(string? message) : base(message)
        {
        }

        public NoEntityFoundException(string v, string key)
        {
            this.v = v;
            this.key = key;
        }

        public NoEntityFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
