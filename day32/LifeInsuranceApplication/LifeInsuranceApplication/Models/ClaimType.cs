namespace LifeInsuranceApplication.Models
{
    public class ClaimType
    {
        public int Id { get; set; }
        public string ClaimName { get; set;} = string.Empty;
        public IEnumerable<CustomerClaim> CustomerClaims{get;set;}

        public ClaimType()
        {
            CustomerClaims = new List<CustomerClaim>();
        }
    }
}