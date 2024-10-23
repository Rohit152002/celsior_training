namespace LifeInsuranceApplication.Models
{
    public class ClaimType
    {
        public int Id { get; set; }
        public string ClaimName { get; set;} = string.Empty;
        public IEnumerable<Claim> Claims{get;set;}

        public ClaimType()
        {
            Claims = new List<Claim>();
        }
    }
}