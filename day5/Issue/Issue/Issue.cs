using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Issue
{
    internal class Issue
    {
        //Id, Title, Description, ReportedBy , AssignedTo, CreatedDate, Status
        public int? Id {  get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ReportedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Status { get; set; }
        public int? AssignedTo { get; set; }
        public DateTime ClosedDate { get; set; }

        public Issue(int id, string title, string description, DateTime reportedBy , string status)
        {
            Id = id;
            Title = title;
            Description = description;
            ReportedBy = reportedBy;
            CreatedDate = DateTime.Now;
            Status = status;
        }
        public bool ChangeStatus(string newStatus)
        {
            if (Status == "Closed")
            {
                Console.WriteLine("Cannot change staus as the issue is closed. Please raise a new Issue");
                return false;
            }
            Status = newStatus;
            if (newStatus == "Closed")
            {
                ClosedDate = DateTime.Now;
                Console.WriteLine($"Issue with {Id} is maked as Closed");
            }
            return true;
        }
        public bool AssignIssue(int assignedTo)
        {
            if (Status == "Closed")
            {
                Console.WriteLine("Cannot assign issue as the issue is closed. Please raise a new Issue");
                return false;
            }
            AssignedTo = assignedTo;
            Console.WriteLine($"Issue with {Id} successfully Assigned to {AssignedTo}");
            return true;
        }

    }
}
