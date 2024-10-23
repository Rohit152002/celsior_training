namespace LifeInsuranceApplication.Models
{
    public class Policy{
        public int Id {get;set;}
        public string PolicyNumber{get; set;}= string.Empty;
        public IEnumerable<Claim> Claims {get;set;}

        public Policy()
        {
            Claims = new List<Claim>();
        } 
    }
}