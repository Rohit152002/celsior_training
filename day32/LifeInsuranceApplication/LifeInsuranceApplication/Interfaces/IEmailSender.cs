using LifeInsuranceApplication.Misc;

namespace LifeInsuranceApplication.Interfaces
{
    public interface IEmailSender
    {
        void SendEmail(Message message);
    }
}
