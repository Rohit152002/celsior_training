
using LifeInsuranceApplication.Interfaces;
using LifeInsuranceApplication.Misc;
using LifeInsuranceApplication.Models;
using MailKit.Net.Smtp;
using MimeKit;

namespace LifeInsuranceApplication.Services
{
    public class MailService : IEmailSender
    {
        private readonly EmailConfiguration _emailConfig;
        public MailService(EmailConfiguration emailConfig)
        {
            _emailConfig = emailConfig;
        }
        public void SendEmail(Message message)
        {
            var emailMessage = CreateEmailMessage(message);
            Send(emailMessage);
        }


        private MimeMessage CreateEmailMessage(Message message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("email",_emailConfig.From));
            emailMessage.To.AddRange(message.To);
            emailMessage.Subject = message.Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = message.Content };

                    Console.WriteLine(message.To);
            return emailMessage;
        }

        private void Send(MimeMessage mailMessage)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                    client.Connect(_emailConfig.SmtpServer, _emailConfig.Port, true);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    client.Authenticate(_emailConfig.UserName, _emailConfig.Password);

                    client.Send(mailMessage);
                    Console.WriteLine("Email sent successfully to: " + string.Join(", ", mailMessage.To));
                }
                catch (SmtpProtocolException ex)
                {
                    // Log specific SMTP protocol exception
                    Console.WriteLine($"SMTP Protocol Error: {ex.Message}");
                    throw; // Rethrow if needed
                }
                catch (SmtpCommandException ex)
                {
                    // Log command-specific errors
                    Console.WriteLine($"SMTP Command Error:  - {ex.Message}");
                    throw; // Rethrow if needed
                }
                catch (Exception ex)
                {
                    // Log generic errors
                    Console.WriteLine($"Error sending email: {ex.Message}");
                    throw; // Rethrow if needed
                }
                finally
                {
                    client.Disconnect(true);
                    client.Dispose();
                }
            }
        }
    }


}
