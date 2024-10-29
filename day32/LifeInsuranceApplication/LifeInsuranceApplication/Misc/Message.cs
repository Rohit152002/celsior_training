using MailKit.Net.Smtp;
using MimeKit;



namespace LifeInsuranceApplication.Misc
{
    public class Message
    {
        public List<MailboxAddress> To { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public Message(IEnumerable<string> to, string subject, string content)
        {
            To = new List<MailboxAddress>();
            To.AddRange(to.Select(email => 
            new MailboxAddress("", new List<string>(), email)));
            Subject = subject;
            Content = content;
        }
    }
}
