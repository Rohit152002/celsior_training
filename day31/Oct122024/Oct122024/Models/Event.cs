using System.ComponentModel.DataAnnotations;

namespace Oct122024.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string EventName { get; set; }=string.Empty;
        public DateTime EventTime { get; set; }
        public string EventDescription { get; set; } = string.Empty;
    }
}
