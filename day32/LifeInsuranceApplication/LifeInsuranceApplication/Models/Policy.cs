namespace LifeInsuranceApplication.Models
{
    public class Policy{
        public int Id {get;set;}
        public string PolicyNumber{get; set;}= string.Empty;
        public string PolicyDescription { get; set; } = string.Empty;
        public IEnumerable<CustomerClaim> CustomerClaims {get;set;}

        public Policy()
        {
            CustomerClaims = new List<CustomerClaim>();
        } 
    }
}